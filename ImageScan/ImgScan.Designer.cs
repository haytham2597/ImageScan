namespace ImageScan
{
    partial class ImgScan
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImgScan));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView_Files = new System.Windows.Forms.TreeView();
            this.panel_processImg = new System.Windows.Forms.Panel();
            this.checkBox_Deskew = new System.Windows.Forms.CheckBox();
            this.checkBox_Auto = new System.Windows.Forms.CheckBox();
            this.label_threshold = new System.Windows.Forms.Label();
            this.trackBar_Threshold = new System.Windows.Forms.TrackBar();
            this.checkBox_Binarization = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip_Node = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.guardarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel_processImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threshold)).BeginInit();
            this.contextMenuStrip_Node.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(864, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip_Principal";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.cerrarTodoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.abrirToolStripMenuItem.Text = "Abrir (Ctrl + O)";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.guardarToolStripMenuItem.Text = "Guardar todo (Ctrl + S)";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // cerrarTodoToolStripMenuItem
            // 
            this.cerrarTodoToolStripMenuItem.Name = "cerrarTodoToolStripMenuItem";
            this.cerrarTodoToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.cerrarTodoToolStripMenuItem.Text = "Cerrar todo (Ctrl + Q)";
            this.cerrarTodoToolStripMenuItem.Click += new System.EventHandler(this.cerrarTodoToolStripMenuItem_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panel_processImg, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.36347F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.63653F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(864, 547);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView_Files);
            this.splitContainer1.Size = new System.Drawing.Size(858, 449);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.TabIndex = 5;
            // 
            // treeView_Files
            // 
            this.treeView_Files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Files.HideSelection = false;
            this.treeView_Files.Location = new System.Drawing.Point(0, 0);
            this.treeView_Files.Name = "treeView_Files";
            this.treeView_Files.Size = new System.Drawing.Size(130, 449);
            this.treeView_Files.StateImageList = this.imageList;
            this.treeView_Files.TabIndex = 0;
            this.treeView_Files.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeView_Files_NodeMouseHover);
            this.treeView_Files.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Files_AfterSelect);
            this.treeView_Files.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Files_NodeMouseClick);
            // 
            // panel_processImg
            // 
            this.panel_processImg.Controls.Add(this.checkBox_Deskew);
            this.panel_processImg.Controls.Add(this.checkBox_Auto);
            this.panel_processImg.Controls.Add(this.label_threshold);
            this.panel_processImg.Controls.Add(this.trackBar_Threshold);
            this.panel_processImg.Controls.Add(this.checkBox_Binarization);
            this.panel_processImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_processImg.Location = new System.Drawing.Point(3, 458);
            this.panel_processImg.Name = "panel_processImg";
            this.panel_processImg.Size = new System.Drawing.Size(858, 86);
            this.panel_processImg.TabIndex = 1;
            // 
            // checkBox_Deskew
            // 
            this.checkBox_Deskew.AutoSize = true;
            this.checkBox_Deskew.Location = new System.Drawing.Point(138, 3);
            this.checkBox_Deskew.Name = "checkBox_Deskew";
            this.checkBox_Deskew.Size = new System.Drawing.Size(74, 17);
            this.checkBox_Deskew.TabIndex = 4;
            this.checkBox_Deskew.Text = "Enderezar";
            this.checkBox_Deskew.UseVisualStyleBackColor = true;
            this.checkBox_Deskew.CheckedChanged += new System.EventHandler(this.checkBox_Deskew_CheckedChanged);
            // 
            // checkBox_Auto
            // 
            this.checkBox_Auto.AutoSize = true;
            this.checkBox_Auto.Location = new System.Drawing.Point(3, 3);
            this.checkBox_Auto.Name = "checkBox_Auto";
            this.checkBox_Auto.Size = new System.Drawing.Size(48, 17);
            this.checkBox_Auto.TabIndex = 3;
            this.checkBox_Auto.Text = "Auto";
            this.checkBox_Auto.UseVisualStyleBackColor = true;
            this.checkBox_Auto.CheckedChanged += new System.EventHandler(this.checkBox_Auto_CheckedChanged);
            // 
            // label_threshold
            // 
            this.label_threshold.AutoSize = true;
            this.label_threshold.Location = new System.Drawing.Point(9, 36);
            this.label_threshold.Name = "label_threshold";
            this.label_threshold.Size = new System.Drawing.Size(39, 13);
            this.label_threshold.TabIndex = 2;
            this.label_threshold.Text = "Límite:";
            // 
            // trackBar_Threshold
            // 
            this.trackBar_Threshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_Threshold.Location = new System.Drawing.Point(76, 26);
            this.trackBar_Threshold.Maximum = 255;
            this.trackBar_Threshold.Minimum = 1;
            this.trackBar_Threshold.Name = "trackBar_Threshold";
            this.trackBar_Threshold.Size = new System.Drawing.Size(773, 45);
            this.trackBar_Threshold.TabIndex = 1;
            this.trackBar_Threshold.Value = 100;
            this.trackBar_Threshold.Scroll += new System.EventHandler(this.trackBar_Threshold_Scroll);
            // 
            // checkBox_Binarization
            // 
            this.checkBox_Binarization.AutoSize = true;
            this.checkBox_Binarization.Location = new System.Drawing.Point(57, 3);
            this.checkBox_Binarization.Name = "checkBox_Binarization";
            this.checkBox_Binarization.Size = new System.Drawing.Size(75, 17);
            this.checkBox_Binarization.TabIndex = 0;
            this.checkBox_Binarization.Text = "Binarizado";
            this.checkBox_Binarization.UseVisualStyleBackColor = true;
            this.checkBox_Binarization.CheckedChanged += new System.EventHandler(this.checkBox_bin_CheckedChanged);
            // 
            // contextMenuStrip_Node
            // 
            this.contextMenuStrip_Node.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripMenuItem1,
            this.guardarComoToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.contextMenuStrip_Node.Name = "contextMenuStrip_Node";
            this.contextMenuStrip_Node.Size = new System.Drawing.Size(151, 70);
            // 
            // guardarToolStripMenuItem1
            // 
            this.guardarToolStripMenuItem1.Name = "guardarToolStripMenuItem1";
            this.guardarToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.guardarToolStripMenuItem1.Text = "Guardar";
            this.guardarToolStripMenuItem1.Click += new System.EventHandler(this.guardarToolStripMenuItem1_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar como";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "CheckIcon.png");
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // ImgScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 571);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImgScan";
            this.Text = "Image Scan";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImgScan_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImgScan_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel_processImg.ResumeLayout(false);
            this.panel_processImg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threshold)).EndInit();
            this.contextMenuStrip_Node.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TreeView treeView_Files;
        private System.Windows.Forms.Panel panel_processImg;
        private System.Windows.Forms.Label label_threshold;
        private System.Windows.Forms.TrackBar trackBar_Threshold;
        private System.Windows.Forms.CheckBox checkBox_Binarization;
        private System.Windows.Forms.CheckBox checkBox_Auto;
        private System.Windows.Forms.CheckBox checkBox_Deskew;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Node;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cerrarTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}

