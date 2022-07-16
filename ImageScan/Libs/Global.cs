using Emgu.CV;
using Emgu.CV.Structure;

namespace ImageScan.Libs
{
    public class Global
    {
        public class Property
        {
            public class ProcessSettingsUser
            {
                public int Threshold { set; get; } = 100;
                public bool Auto { set; get; }
                public bool Binarization { set; get; }
                public bool Deskew { set; get; }
            }
            public class ImgPropScan
            {
                public string FullPath { set; get; }
                public Image<Bgr, byte> ImgOriginal { set; get; }
                public Image<Bgr, byte> Clean { set; get; }
                public Image<Bgr, byte> ImgDst { set; get; }
                public ProcessSettingsUser ProcessSettingsUser { set; get; } = new ProcessSettingsUser();
            }
        }
    }
}
