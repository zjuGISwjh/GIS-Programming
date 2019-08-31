namespace MapControlApplication1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.print = new System.Windows.Forms.ToolStripMenuItem();
            this.MapOutPut = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreateBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.cbBookmarkList = new System.Windows.Forms.ComboBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.SpatialData = new System.Windows.Forms.ToolStripMenuItem();
            this.miAccessData = new System.Windows.Forms.ToolStripMenuItem();
            this.myBuffer = new System.Windows.Forms.ToolStripMenuItem();
            this.miCartoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleRender = new System.Windows.Forms.ToolStripMenuItem();
            this.View = new System.Windows.Forms.ToolStripMenuItem();
            this.mapView = new System.Windows.Forms.ToolStripMenuItem();
            this.pageLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.miData = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreateShapefile = new System.Windows.Forms.ToolStripMenuItem();
            this.pointshp = new System.Windows.Forms.ToolStripMenuItem();
            this.lineshp = new System.Windows.Forms.ToolStripMenuItem();
            this.polyshp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddFeature = new System.Windows.Forms.ToolStripMenuItem();
            this.AddPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.AddLine = new System.Windows.Forms.ToolStripMenuItem();
            this.AddPolygon = new System.Windows.Forms.ToolStripMenuItem();
            this.axPageLayoutControl2 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.miCreateBookmark});
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1145, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuExitApp,
            this.print,
            this.MapOutPut});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(46, 24);
            this.menuFile.Text = "File";
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(210, 24);
            this.menuNewDoc.Text = "New Document";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(210, 24);
            this.menuOpenDoc.Text = "Open Document...";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(210, 24);
            this.menuSaveDoc.Text = "SaveDocument";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(210, 24);
            this.menuSaveAs.Text = "Save As...";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(207, 6);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(210, 24);
            this.menuExitApp.Text = "Exit";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // print
            // 
            this.print.Enabled = false;
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(210, 24);
            this.print.Text = "print";
            this.print.Click += new System.EventHandler(this.output_Click);
            // 
            // MapOutPut
            // 
            this.MapOutPut.Enabled = false;
            this.MapOutPut.Name = "MapOutPut";
            this.MapOutPut.Size = new System.Drawing.Size(210, 24);
            this.MapOutPut.Text = "MapOutPut";
            this.MapOutPut.Click += new System.EventHandler(this.mapOutPutToolStripMenuItem_Click);
            // 
            // miCreateBookmark
            // 
            this.miCreateBookmark.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.miCreateBookmark.Name = "miCreateBookmark";
            this.miCreateBookmark.Size = new System.Drawing.Size(81, 24);
            this.miCreateBookmark.Text = "创建书签";
            this.miCreateBookmark.Click += new System.EventHandler(this.miCreateBookmark_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Margin = new System.Windows.Forms.Padding(4);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(1145, 676);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl1_OnMouseUp);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 56);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(4);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1145, 28);
            this.axToolbarControl1.TabIndex = 3;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTOCControl1.Location = new System.Drawing.Point(4, 84);
            this.axTOCControl1.Margin = new System.Windows.Forms.Padding(4);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(300, 492);
            this.axTOCControl1.TabIndex = 4;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(452, 290);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(4);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 84);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 592);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(4, 576);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1141, 100);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(71, 95);
            this.statusBarXY.Text = "Test 123";
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Location = new System.Drawing.Point(4, 446);
            this.axPageLayoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(304, 61);
            this.axPageLayoutControl1.TabIndex = 8;
            this.axPageLayoutControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.axPageLayoutControl1_OnMouseDown);
            this.axPageLayoutControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseMoveEventHandler(this.axPageLayoutControl1_OnMouseMove);
            // 
            // cbBookmarkList
            // 
            this.cbBookmarkList.FormattingEnabled = true;
            this.cbBookmarkList.Location = new System.Drawing.Point(141, 32);
            this.cbBookmarkList.Margin = new System.Windows.Forms.Padding(4);
            this.cbBookmarkList.Name = "cbBookmarkList";
            this.cbBookmarkList.Size = new System.Drawing.Size(160, 23);
            this.cbBookmarkList.TabIndex = 9;
            this.cbBookmarkList.SelectedIndexChanged += new System.EventHandler(this.cbBookmarkList_SelectedIndexChanged);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SpatialData,
            this.miCartoToolStripMenuItem,
            this.View,
            this.miData});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1145, 28);
            this.menuStrip2.TabIndex = 10;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // SpatialData
            // 
            this.SpatialData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAccessData,
            this.myBuffer});
            this.SpatialData.Name = "SpatialData";
            this.SpatialData.Size = new System.Drawing.Size(103, 24);
            this.SpatialData.Text = "SpatialData";
            this.SpatialData.Click += new System.EventHandler(this.DataBook_Click);
            // 
            // miAccessData
            // 
            this.miAccessData.Name = "miAccessData";
            this.miAccessData.Size = new System.Drawing.Size(168, 24);
            this.miAccessData.Text = "空间数据查询";
            this.miAccessData.Click += new System.EventHandler(this.miAccessDataToolStripMenuItem_Click);
            // 
            // myBuffer
            // 
            this.myBuffer.Name = "myBuffer";
            this.myBuffer.Size = new System.Drawing.Size(168, 24);
            this.myBuffer.Text = "缓冲区分析";
            this.myBuffer.Click += new System.EventHandler(this.myBuffer_Click);
            // 
            // miCartoToolStripMenuItem
            // 
            this.miCartoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleRender});
            this.miCartoToolStripMenuItem.Name = "miCartoToolStripMenuItem";
            this.miCartoToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.miCartoToolStripMenuItem.Text = "MapRender";
            this.miCartoToolStripMenuItem.Click += new System.EventHandler(this.miCartoToolStripMenuItem_Click);
            // 
            // simpleRender
            // 
            this.simpleRender.Name = "simpleRender";
            this.simpleRender.Size = new System.Drawing.Size(181, 24);
            this.simpleRender.Text = "SimpleRender";
            this.simpleRender.Click += new System.EventHandler(this.simpleRenderToolStripMenuItem_Click);
            // 
            // View
            // 
            this.View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapView,
            this.pageLayout});
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(51, 24);
            this.View.Text = "视图";
            // 
            // mapView
            // 
            this.mapView.Checked = true;
            this.mapView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapView.Name = "mapView";
            this.mapView.Size = new System.Drawing.Size(163, 24);
            this.mapView.Text = "MapView";
            this.mapView.Click += new System.EventHandler(this.mapView_Click);
            // 
            // pageLayout
            // 
            this.pageLayout.Name = "pageLayout";
            this.pageLayout.Size = new System.Drawing.Size(163, 24);
            this.pageLayout.Text = "PageLayout";
            this.pageLayout.Click += new System.EventHandler(this.pageLayout_Click);
            // 
            // miData
            // 
            this.miData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCreateShapefile,
            this.miAddFeature});
            this.miData.Name = "miData";
            this.miData.Size = new System.Drawing.Size(81, 24);
            this.miData.Text = "数据操作";
            // 
            // miCreateShapefile
            // 
            this.miCreateShapefile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointshp,
            this.lineshp,
            this.polyshp});
            this.miCreateShapefile.Name = "miCreateShapefile";
            this.miCreateShapefile.Size = new System.Drawing.Size(166, 24);
            this.miCreateShapefile.Text = "创建Shapfile";
            this.miCreateShapefile.Click += new System.EventHandler(this.miCreateShapefile_Click);
            // 
            // pointshp
            // 
            this.pointshp.Name = "pointshp";
            this.pointshp.Size = new System.Drawing.Size(123, 24);
            this.pointshp.Text = "点图层";
            this.pointshp.Click += new System.EventHandler(this.pointshp_Click);
            // 
            // lineshp
            // 
            this.lineshp.Name = "lineshp";
            this.lineshp.Size = new System.Drawing.Size(123, 24);
            this.lineshp.Text = "线图层";
            this.lineshp.Click += new System.EventHandler(this.lineshp_Click);
            // 
            // polyshp
            // 
            this.polyshp.Name = "polyshp";
            this.polyshp.Size = new System.Drawing.Size(123, 24);
            this.polyshp.Text = "面图层";
            this.polyshp.Click += new System.EventHandler(this.polyshp_Click);
            // 
            // miAddFeature
            // 
            this.miAddFeature.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPoint,
            this.AddLine,
            this.AddPolygon});
            this.miAddFeature.Name = "miAddFeature";
            this.miAddFeature.Size = new System.Drawing.Size(166, 24);
            this.miAddFeature.Text = "添加要素";
            this.miAddFeature.Click += new System.EventHandler(this.miAddFeature_Click);
            // 
            // AddPoint
            // 
            this.AddPoint.Name = "AddPoint";
            this.AddPoint.Size = new System.Drawing.Size(123, 24);
            this.AddPoint.Text = "点要素";
            this.AddPoint.Click += new System.EventHandler(this.AddPoint_Click);
            // 
            // AddLine
            // 
            this.AddLine.Name = "AddLine";
            this.AddLine.Size = new System.Drawing.Size(123, 24);
            this.AddLine.Text = "线要素";
            this.AddLine.Click += new System.EventHandler(this.AddLine_Click);
            // 
            // AddPolygon
            // 
            this.AddPolygon.Name = "AddPolygon";
            this.AddPolygon.Size = new System.Drawing.Size(123, 24);
            this.AddPolygon.Text = "面要素";
            this.AddPolygon.Click += new System.EventHandler(this.AddPolygon_Click);
            // 
            // axPageLayoutControl2
            // 
            this.axPageLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.axPageLayoutControl2.Name = "axPageLayoutControl2";
            this.axPageLayoutControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl2.OcxState")));
            this.axPageLayoutControl2.Size = new System.Drawing.Size(1145, 676);
            this.axPageLayoutControl2.TabIndex = 11;
            this.axPageLayoutControl2.Visible = false;
            this.axPageLayoutControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.axPageLayoutControl2_OnMouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 676);
            this.Controls.Add(this.cbBookmarkList);
            this.Controls.Add(this.axPageLayoutControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.axPageLayoutControl2);
            this.Controls.Add(this.axMapControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "ArcEngine Controls Application";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.ToolStripMenuItem miCreateBookmark;
        private System.Windows.Forms.ComboBox cbBookmarkList;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem SpatialData;
        private System.Windows.Forms.ToolStripMenuItem miAccessData;
        private System.Windows.Forms.ToolStripMenuItem miCartoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleRender;
        private System.Windows.Forms.ToolStripMenuItem View;
        private System.Windows.Forms.ToolStripMenuItem mapView;
        private System.Windows.Forms.ToolStripMenuItem pageLayout;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl2;
        private System.Windows.Forms.ToolStripMenuItem print;
        private System.Windows.Forms.ToolStripMenuItem MapOutPut;
        private System.Windows.Forms.ToolStripMenuItem miData;
        private System.Windows.Forms.ToolStripMenuItem miCreateShapefile;
        private System.Windows.Forms.ToolStripMenuItem miAddFeature;
        private System.Windows.Forms.ToolStripMenuItem pointshp;
        private System.Windows.Forms.ToolStripMenuItem lineshp;
        private System.Windows.Forms.ToolStripMenuItem polyshp;
        private System.Windows.Forms.ToolStripMenuItem AddPoint;
        private System.Windows.Forms.ToolStripMenuItem AddLine;
        private System.Windows.Forms.ToolStripMenuItem AddPolygon;
        private System.Windows.Forms.ToolStripMenuItem myBuffer;
    }
}

