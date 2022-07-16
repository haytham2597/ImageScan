using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using ImageScan.Libs;

namespace ImageScan
{
    public partial class ImgScan : Form
    {
        private readonly ToolTip toolTip = new ToolTip();
        private readonly Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
        //private readonly ImageBox imgBoxCtrl = new ImageBox();
        private readonly PictureBox imgBoxCtrl = new PictureBox();
        public ImgScan()
        {
            InitializeComponent();
            imgBoxCtrl.SizeMode = PictureBoxSizeMode.StretchImage;
            imgBoxCtrl.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(imgBoxCtrl);
            //tableLayoutPanel_FilesAndImg.Controls.Add(imgBoxCtrl, 1,0);
            
            this.KeyPreview = true;
        }

        private void OpenImage()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;
                if (ofd.FileNames.Length == 0)
                    return;

                this.Cursor = Cursors.WaitCursor;
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    try
                    {
                        var propScan = new Global.Property.ImgPropScan() {FullPath = ofd.FileNames[i], ImgOriginal = new Image<Bgr, byte>(ofd.FileNames[i])};
                        TreeNode tn = new TreeNode {Text = Path.GetFileNameWithoutExtension(ofd.FileNames[i]), Tag = propScan};
                        treeView_Files.Nodes.Add(tn);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Excepción");
                    }
                }
                this.Cursor = Cursors.Default;
                treeView_Files.SelectedNode = treeView_Files.Nodes[0];
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void ImgScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.O)
            {
                OpenImage();
                return;
            }

            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveImgs();
                return;
            }

            if (e.Control && e.KeyCode == Keys.Q)
                CloseAll();

            /*if (e.KeyCode == Keys.S)
                imgBoxCtrl.SetZoomScale(1, new Point(0,0));*/

            if (!(treeView_Files.SelectedNode?.Tag is Global.Property.ImgPropScan imgS))
                return;
            if (imgS.ImgDst == null)
                return;

            if (e.KeyCode == Keys.D)
                imgBoxCtrl.Image = imgS.ImgOriginal.Bitmap;
            if (e.KeyCode == Keys.C)
            {
                if (imgS.Clean == null)
                    return;
                imgBoxCtrl.Image = imgS.Clean.Bitmap;
            }
        }
        private void ImgScan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.D && e.KeyCode != Keys.C)
                return;
            if (!(treeView_Files.SelectedNode?.Tag is Global.Property.ImgPropScan imgS))
                return;
            imgBoxCtrl.Image = imgS.ImgDst.Bitmap;
        }

        private void treeView_Files_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!(e.Node.Tag is Global.Property.ImgPropScan imgS))
                return;
            imgS.Clean = imgS.ImgOriginal.CleanScan();
            imgS.ImgDst = imgS.ImgOriginal.Copy();
            
            checkBox_Auto.Checked = imgS.ProcessSettingsUser.Auto;
            checkBox_Binarization.Checked = imgS.ProcessSettingsUser.Binarization;
            trackBar_Threshold.Value = imgS.ProcessSettingsUser.Threshold;
            checkBox_Deskew.Checked = imgS.ProcessSettingsUser.Deskew;
            label_threshold.Text = $"Límite: {trackBar_Threshold.Value}";
            ProcessImg(sender);
            GC.Collect();
        }

        private void trackBar_Threshold_Scroll(object sender, EventArgs e)
        {
            if (!(treeView_Files.SelectedNode?.Tag is Global.Property.ImgPropScan imgS))
                return;
            if (imgS.Clean == null)
                return;
            if (checkBox_Auto.Checked)
                checkBox_Auto.Checked = false;

            ProcessImg(sender);
        }

        private void checkBox_Auto_CheckedChanged(object sender, EventArgs e)
        {
            ProcessImg(sender);
        }

        private void checkBox_bin_CheckedChanged(object sender, EventArgs e)
        {
            ProcessImg(sender);
        }

        private void ProcessImg(object sender)
        {
            try
            {
                if (!(treeView_Files.SelectedNode?.Tag is Global.Property.ImgPropScan imgS))
                    return;
                if (imgS.Clean == null)
                    return;

                double thresh = trackBar_Threshold.Value;
                if (checkBox_Auto.Checked)
                {
                    thresh = CvInvoke.Threshold(imgS.Clean.Copy().Convert<Gray, byte>(), new Mat(), 0, 255, ThresholdType.Binary | ThresholdType.Otsu);
                    trackBar_Threshold.Value = Convert.ToInt32(thresh);
                }

                if (checkBox_Binarization.Checked)
                {
                    using (Mat m = new Mat())
                    {
                        CvInvoke.Threshold(imgS.Clean.Copy().Convert<Gray, byte>(), m, thresh, 255, ThresholdType.Binary);
                        imgS.ImgDst = m.ToImage<Bgr, byte>();
                    }
                }
                else
                {
                    CvInvoke.Threshold(imgS.Clean, imgS.ImgDst, thresh, 255, ThresholdType.Binary);
                }

                if (checkBox_Deskew.Checked)
                {
                    imgS.ImgDst.Deskew();
                    
                }

                if ((double) currentProcess.WorkingSet64 / 1024f / 1024f >= 350) //For excedeed 350mb in memory, clean some shit
                {
                    Thread.Sleep(500);
                    GC.Collect();
                }

                imgBoxCtrl.Image = imgS.ImgDst.Bitmap;
                sender.SetProp(imgS.ProcessSettingsUser);
                label_threshold.Text = $"Límite: {trackBar_Threshold.Value.ToString()}";
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void checkBox_Deskew_CheckedChanged(object sender, EventArgs e)
        {
            if (!(treeView_Files.SelectedNode?.Tag is Global.Property.ImgPropScan imgS))
                return;
            if (imgS.Clean == null)
                return;
            if (imgS.ImgDst == null)
                return;
            ProcessImg(sender);
        }

        private void treeView_Files_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            if (!(e.Node.Tag is Global.Property.ImgPropScan imgS))
                return;

            toolTip.SetToolTip((Control)sender, $"{imgS.FullPath}, Límite: {imgS.ProcessSettingsUser.Threshold}");
        }

        private void treeView_Files_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            treeView_Files.SelectedNode = e.Node;
            contextMenuStrip_Node.Show(treeView_Files, e.Location);
            /*contextMenuStrip_Node.Items[0].Text = $"Guardar {Path.GetFileName((e.Node.Tag as Global.Property.ImgPropScan).FullPath)}";
            contextMenuStrip_Node.Items[1].Text = $"Eliminar {Path.GetFileName((e.Node.Tag as Global.Property.ImgPropScan).FullPath)}";*/
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView_Files.SelectedNode.Remove();
            if (treeView_Files.Nodes.Count == 0)
            {
                ClearProcess();
                return;
            }
            treeView_Files.SelectedNode = treeView_Files.Nodes[ 0];
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImgs();
        }

        private void SaveImgs()
        {
            if (treeView_Files.Nodes.Count == 0)
                return;
            for (int i = 0; i < treeView_Files.Nodes.Count; i++)
            {
                if (!(treeView_Files.Nodes[i].Tag is Global.Property.ImgPropScan imgS))
                    continue;
                FileInfo file = new FileInfo(imgS.FullPath);
                imgS.ImgDst.Save(Path.Combine(file.DirectoryName, Path.GetFileNameWithoutExtension(file.Name) + "_Scan.jpg"));
                treeView_Files.Nodes[i].StateImageIndex = 0;
            }
            //MessageBox.Show("Se guardaron la/s imágenes");
        }
        private void ClearProcess()
        {
            imgBoxCtrl.Image = null;
            trackBar_Threshold.Value = 100;
            for (int i = 0; i < panel_processImg.Controls.Count; i++)
            {
                if (panel_processImg.Controls[i] is CheckBox cb)
                    cb.Checked = false;
            }
            label_threshold.Text = $"Límite: {trackBar_Threshold.Value.ToString()}";
        }
        private void cerrarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAll();
        }

        private void CloseAll()
        {
            if (treeView_Files.Nodes.Count == 0)
                return;
            for (int i = 0; i < treeView_Files.Nodes.Count; i++)
            {
                if (treeView_Files.Nodes[i].StateImageIndex != -1)
                    continue;
                if (MessageBox.Show("¿Seguro que desea cerrar todo? Hay imágenes sin guardar", "Advertencia", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                break;
            }
            treeView_Files.Nodes.Clear();
            ClearProcess();
        }

        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!(treeView_Files.SelectedNode.Tag is Global.Property.ImgPropScan imgS))
                return;
            FileInfo file = new FileInfo(imgS.FullPath);
            string path = Path.Combine(file.DirectoryName, Path.GetFileNameWithoutExtension(file.Name) + "_Scan.jpg");
            MessageBox.Show($"Se guardó la imágen como {path}");
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (!(treeView_Files.SelectedNode.Tag is Global.Property.ImgPropScan imgS))
                    return;
                sfd.DefaultExt = ".jpg";
                sfd.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                sfd.InitialDirectory = new FileInfo(imgS.FullPath).DirectoryName;
                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                imgS.ImgDst.Save(sfd.FileName);
                MessageBox.Show($"Se guardó la imágen");
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.About().ShowDialog();
        }
    }
}
