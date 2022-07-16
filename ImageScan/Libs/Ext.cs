using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ImageScan.Libs
{
    public static class Ext
    {
        public class Tuple<T1, T2>
        {
            public T1 First { get; private set; }
            public T2 Second { get; private set; }
            internal Tuple(T1 first, T2 second)
            {
                First = first;
                Second = second;
            }
        }

        public static void Deskew(this IOutputArray img)
        {
            using (var imgCop = img.GetInputArray().GetMat().ToImage<Gray, byte>().Not().Dilate(5))
            using (VectorOfPoint point = new VectorOfPoint())
            using (var rotationMatrix = new Mat(new Size(2, 3), DepthType.Cv32F, 1))
            {
                //CvInvoke.Canny(imgCop, imgCop, 2, 2);
                CvInvoke.FindNonZero(imgCop, point);
                if (point.Size <= 0)
                    return;
                var minAreaRect = CvInvoke.MinAreaRect(point);
                if (minAreaRect.Angle < -45)
                    minAreaRect.Angle = 90 + minAreaRect.Angle;
                CvInvoke.GetRotationMatrix2D(minAreaRect.Center, minAreaRect.Angle, 1.0, rotationMatrix);
                CvInvoke.WarpAffine(img, img, rotationMatrix, imgCop.Size, Inter.Cubic, borderMode: BorderType.Replicate);
            }
        }

        public static Image<TColor, TDepth> CleanScan<TColor, TDepth>(this Image<TColor, TDepth> img) where TColor : struct, Emgu.CV.IColor where TDepth : new()
        {
            var imgSplit = img.Copy().Split();
            using (Mat result = new Mat())
            using (VectorOfMat vec_of_mat = new VectorOfMat())
            {
                for (int i = 0; i < imgSplit.Length; i++)
                {
                    //TODO: Gen automatization of dilate and blur size with imgSIZE factor
                    /*var dilated = imgSplit[i].Dilate((img.Width*img.Height * 7) / 798768); //7
                    CvInvoke.MedianBlur(dilated, dilated, (img.Width * img.Height * 21) / 798768); //21*/
                    var dilated = imgSplit[i].Dilate(7); //7
                    CvInvoke.MedianBlur(dilated, dilated, 21); //21
                    CvInvoke.AbsDiff(imgSplit[i], dilated, dilated);
                    dilated = 255 - dilated;
                    vec_of_mat.Push(dilated);
                    dilated.Dispose();
                }
                CvInvoke.Merge(vec_of_mat, result);
                return result.ToImage<TColor, TDepth>();
            }
        }

        public static Tuple<string, object> GetValueName(this object obj)
        {
            string name = ((Control)obj).Name.Split('_').Last();
            object value = null;
            if (obj is CheckBox cb)
                value = cb.Checked;
            if (obj is TrackBar tb)
                value = tb.Value;
            return new Tuple<string, object>(name, value);
        }
        public static void SetProp(this object obj, object objprop)
        {
            var prop = objprop.GetType().GetProperties();
            for (int i = 0; i < prop.Length; i++)
            {
                var pr = obj.GetValueName();
                if (prop[i].Name == pr.First)
                    prop[i].SetValue(objprop, pr.Second, null);
            }
        }
    }
}
