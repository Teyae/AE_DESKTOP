namespace MapControlApplication3
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
            this.components = new System.ComponentModel.Container();
            ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenMxd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdddata = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadShapefile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadGDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateShapefile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateGDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoomOutF = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoomInF = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFull = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIden = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisplayMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisplayLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsertNorthArrow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsertScalebar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsertLegend = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsertTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.数据查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearchByAttr = new System.Windows.Forms.ToolStripMenuItem();
            this.点选查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.矩形查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.多边形查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除选择集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBuffer = new System.Windows.Forms.ToolStripMenuItem();
            this.空间数据库连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_adddata = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_openattri = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_zoom = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_symbology = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comboEditLayers = new System.Windows.Forms.ToolStripComboBox();
            this.btnAddPoint = new System.Windows.Forms.ToolStripButton();
            this.btnAddPolyline = new System.Windows.Forms.ToolStripButton();
            this.btnAddPolygon = new System.Windows.Forms.ToolStripButton();
            this.btnselec_point = new System.Windows.Forms.ToolStripButton();
            this.btnselec_rec = new System.Windows.Forms.ToolStripButton();
            this.toolselec_poly = new System.Windows.Forms.ToolStripButton();
            this.btnselec_clear = new System.Windows.Forms.ToolStripButton();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            ((System.ComponentModel.ISupportInitialize)(axToolbarControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axToolbarControl1
            // 
            axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            axToolbarControl1.Location = new System.Drawing.Point(0, 28);
            axToolbarControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            axToolbarControl1.Name = "axToolbarControl1";
            axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            axToolbarControl1.Size = new System.Drawing.Size(1145, 28);
            axToolbarControl1.TabIndex = 3;
            axToolbarControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IToolbarControlEvents_Ax_OnMouseDownEventHandler(this.axToolbarControl1_OnMouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuMap,
            this.地图ToolStripMenuItem,
            this.数据查询ToolStripMenuItem,
            this.空间分析ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1145, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menNewDoc,
            this.mnuOpenMxd,
            this.mnuAdddata,
            this.menuSeparator,
            this.menSaveDoc,
            this.menuSaveAs,
            this.mnuExitApp,
            this.mnuLoadShapefile,
            this.mnuLoadGDB,
            this.mnuCreateShapefile,
            this.mnuCreateGDB,
            this.mnuOutput});
            this.mnuFile.Image = ((System.Drawing.Image)(resources.GetObject("mnuFile.Image")));
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(67, 24);
            this.mnuFile.Text = "文件";
            // 
            // menNewDoc
            // 
            this.menNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menNewDoc.Image")));
            this.menNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menNewDoc.Name = "menNewDoc";
            this.menNewDoc.Size = new System.Drawing.Size(175, 24);
            this.menNewDoc.Text = "新建文档";
            this.menNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // mnuOpenMxd
            // 
            this.mnuOpenMxd.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpenMxd.Image")));
            this.mnuOpenMxd.ImageTransparentColor = System.Drawing.Color.White;
            this.mnuOpenMxd.Name = "mnuOpenMxd";
            this.mnuOpenMxd.Size = new System.Drawing.Size(175, 24);
            this.mnuOpenMxd.Text = "打开文档";
            this.mnuOpenMxd.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // mnuAdddata
            // 
            this.mnuAdddata.Image = ((System.Drawing.Image)(resources.GetObject("mnuAdddata.Image")));
            this.mnuAdddata.Name = "mnuAdddata";
            this.mnuAdddata.Size = new System.Drawing.Size(175, 24);
            this.mnuAdddata.Text = "加载数据";
            this.mnuAdddata.Click += new System.EventHandler(this.mnuAdddata_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(172, 6);
            // 
            // menSaveDoc
            // 
            this.menSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menSaveDoc.Image")));
            this.menSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menSaveDoc.Name = "menSaveDoc";
            this.menSaveDoc.Size = new System.Drawing.Size(175, 24);
            this.menSaveDoc.Text = "保存文档";
            this.menSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveAs.Image")));
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(175, 24);
            this.menuSaveAs.Text = "保存为";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // mnuExitApp
            // 
            this.mnuExitApp.Image = ((System.Drawing.Image)(resources.GetObject("mnuExitApp.Image")));
            this.mnuExitApp.Name = "mnuExitApp";
            this.mnuExitApp.Size = new System.Drawing.Size(175, 24);
            this.mnuExitApp.Text = "退出";
            this.mnuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // mnuLoadShapefile
            // 
            this.mnuLoadShapefile.Image = ((System.Drawing.Image)(resources.GetObject("mnuLoadShapefile.Image")));
            this.mnuLoadShapefile.Name = "mnuLoadShapefile";
            this.mnuLoadShapefile.Size = new System.Drawing.Size(175, 24);
            this.mnuLoadShapefile.Text = "加载Shapefile";
            this.mnuLoadShapefile.Click += new System.EventHandler(this.mnuLoadShapefile_Click);
            // 
            // mnuLoadGDB
            // 
            this.mnuLoadGDB.Name = "mnuLoadGDB";
            this.mnuLoadGDB.Size = new System.Drawing.Size(175, 24);
            this.mnuLoadGDB.Text = "加载GDB";
            this.mnuLoadGDB.Click += new System.EventHandler(this.mnuLoadGDB_Click);
            // 
            // mnuCreateShapefile
            // 
            this.mnuCreateShapefile.Name = "mnuCreateShapefile";
            this.mnuCreateShapefile.Size = new System.Drawing.Size(175, 24);
            this.mnuCreateShapefile.Text = "创建Shapefile";
            this.mnuCreateShapefile.Click += new System.EventHandler(this.mnuCreateShapefile_Click);
            // 
            // mnuCreateGDB
            // 
            this.mnuCreateGDB.Name = "mnuCreateGDB";
            this.mnuCreateGDB.Size = new System.Drawing.Size(175, 24);
            this.mnuCreateGDB.Text = "创建GDB";
            this.mnuCreateGDB.Click += new System.EventHandler(this.mnuCreateGDB_Click);
            // 
            // mnuOutput
            // 
            this.mnuOutput.Enabled = false;
            this.mnuOutput.Name = "mnuOutput";
            this.mnuOutput.Size = new System.Drawing.Size(175, 24);
            this.mnuOutput.Text = "地图输出";
            this.mnuOutput.Click += new System.EventHandler(this.mnuOutput_Click);
            // 
            // mnuMap
            // 
            this.mnuMap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuZoomOut,
            this.mnuZoomIn,
            this.mnuZoomOutF,
            this.mnuZoomInF,
            this.mnuFull,
            this.mnuIden,
            this.mnuRecZoomIn,
            this.mnuRecZoomOut,
            this.mnuDisplayMap,
            this.mnuDisplayLayout});
            this.mnuMap.Image = ((System.Drawing.Image)(resources.GetObject("mnuMap.Image")));
            this.mnuMap.Name = "mnuMap";
            this.mnuMap.Size = new System.Drawing.Size(67, 24);
            this.mnuMap.Text = "地图";
            // 
            // mnuZoomOut
            // 
            this.mnuZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("mnuZoomOut.Image")));
            this.mnuZoomOut.Name = "mnuZoomOut";
            this.mnuZoomOut.Size = new System.Drawing.Size(183, 24);
            this.mnuZoomOut.Text = "缩小";
            this.mnuZoomOut.Click += new System.EventHandler(this.mnuZoomOut_Click);
            // 
            // mnuZoomIn
            // 
            this.mnuZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("mnuZoomIn.Image")));
            this.mnuZoomIn.Name = "mnuZoomIn";
            this.mnuZoomIn.Size = new System.Drawing.Size(183, 24);
            this.mnuZoomIn.Text = "放大";
            this.mnuZoomIn.Click += new System.EventHandler(this.mnuZoomIn_Click);
            // 
            // mnuZoomOutF
            // 
            this.mnuZoomOutF.Image = ((System.Drawing.Image)(resources.GetObject("mnuZoomOutF.Image")));
            this.mnuZoomOutF.Name = "mnuZoomOutF";
            this.mnuZoomOutF.Size = new System.Drawing.Size(183, 24);
            this.mnuZoomOutF.Text = "固定比例尺缩小";
            this.mnuZoomOutF.Click += new System.EventHandler(this.mnuZoomOutF_Click);
            // 
            // mnuZoomInF
            // 
            this.mnuZoomInF.Image = ((System.Drawing.Image)(resources.GetObject("mnuZoomInF.Image")));
            this.mnuZoomInF.Name = "mnuZoomInF";
            this.mnuZoomInF.Size = new System.Drawing.Size(183, 24);
            this.mnuZoomInF.Text = "固定比例尺放大";
            this.mnuZoomInF.Click += new System.EventHandler(this.mnuZoomInF_Click);
            // 
            // mnuFull
            // 
            this.mnuFull.Image = ((System.Drawing.Image)(resources.GetObject("mnuFull.Image")));
            this.mnuFull.Name = "mnuFull";
            this.mnuFull.Size = new System.Drawing.Size(183, 24);
            this.mnuFull.Text = "全图";
            this.mnuFull.Click += new System.EventHandler(this.mnuFull_Click);
            // 
            // mnuIden
            // 
            this.mnuIden.Image = ((System.Drawing.Image)(resources.GetObject("mnuIden.Image")));
            this.mnuIden.Name = "mnuIden";
            this.mnuIden.Size = new System.Drawing.Size(183, 24);
            this.mnuIden.Text = "查询";
            this.mnuIden.Click += new System.EventHandler(this.mnuIden_Click);
            // 
            // mnuRecZoomIn
            // 
            this.mnuRecZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("mnuRecZoomIn.Image")));
            this.mnuRecZoomIn.Name = "mnuRecZoomIn";
            this.mnuRecZoomIn.Size = new System.Drawing.Size(183, 24);
            this.mnuRecZoomIn.Text = "拉框放大";
            this.mnuRecZoomIn.Click += new System.EventHandler(this.mnuRecZoomIn_Click);
            // 
            // mnuRecZoomOut
            // 
            this.mnuRecZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("mnuRecZoomOut.Image")));
            this.mnuRecZoomOut.Name = "mnuRecZoomOut";
            this.mnuRecZoomOut.Size = new System.Drawing.Size(183, 24);
            this.mnuRecZoomOut.Text = "拉框缩小";
            this.mnuRecZoomOut.Click += new System.EventHandler(this.mnuRecZoomOut_Click);
            // 
            // mnuDisplayMap
            // 
            this.mnuDisplayMap.Checked = true;
            this.mnuDisplayMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuDisplayMap.Name = "mnuDisplayMap";
            this.mnuDisplayMap.Size = new System.Drawing.Size(183, 24);
            this.mnuDisplayMap.Text = "地图";
            this.mnuDisplayMap.Click += new System.EventHandler(this.mnuDisplayMap_Click);
            // 
            // mnuDisplayLayout
            // 
            this.mnuDisplayLayout.Name = "mnuDisplayLayout";
            this.mnuDisplayLayout.Size = new System.Drawing.Size(183, 24);
            this.mnuDisplayLayout.Text = "布局";
            this.mnuDisplayLayout.Click += new System.EventHandler(this.mnuDisplayLayout_Click);
            // 
            // 地图ToolStripMenuItem
            // 
            this.地图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsertNorthArrow,
            this.mnuInsertScalebar,
            this.mnuInsertLegend,
            this.mnuInsertTitle});
            this.地图ToolStripMenuItem.Name = "地图ToolStripMenuItem";
            this.地图ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.地图ToolStripMenuItem.Text = "插入";
            this.地图ToolStripMenuItem.Click += new System.EventHandler(this.地图ToolStripMenuItem_Click);
            // 
            // mnuInsertNorthArrow
            // 
            this.mnuInsertNorthArrow.Name = "mnuInsertNorthArrow";
            this.mnuInsertNorthArrow.Size = new System.Drawing.Size(152, 24);
            this.mnuInsertNorthArrow.Text = "指北针";
            this.mnuInsertNorthArrow.Click += new System.EventHandler(this.mnuInsertNorthArrow_Click);
            // 
            // mnuInsertScalebar
            // 
            this.mnuInsertScalebar.Name = "mnuInsertScalebar";
            this.mnuInsertScalebar.Size = new System.Drawing.Size(152, 24);
            this.mnuInsertScalebar.Text = "比例尺";
            this.mnuInsertScalebar.Click += new System.EventHandler(this.mnuInsertScalebar_Click);
            // 
            // mnuInsertLegend
            // 
            this.mnuInsertLegend.Name = "mnuInsertLegend";
            this.mnuInsertLegend.Size = new System.Drawing.Size(152, 24);
            this.mnuInsertLegend.Text = "图例";
            this.mnuInsertLegend.Click += new System.EventHandler(this.mnuInsertLegend_Click);
            // 
            // mnuInsertTitle
            // 
            this.mnuInsertTitle.Name = "mnuInsertTitle";
            this.mnuInsertTitle.Size = new System.Drawing.Size(152, 24);
            this.mnuInsertTitle.Text = "标题";
            this.mnuInsertTitle.Click += new System.EventHandler(this.mnuInsertTitle_Click);
            // 
            // 数据查询ToolStripMenuItem
            // 
            this.数据查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSearchByAttr,
            this.点选查询ToolStripMenuItem,
            this.矩形查询ToolStripMenuItem,
            this.多边形查询ToolStripMenuItem,
            this.清除选择集ToolStripMenuItem});
            this.数据查询ToolStripMenuItem.Name = "数据查询ToolStripMenuItem";
            this.数据查询ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.数据查询ToolStripMenuItem.Text = "数据查询";
            // 
            // mnuSearchByAttr
            // 
            this.mnuSearchByAttr.Name = "mnuSearchByAttr";
            this.mnuSearchByAttr.Size = new System.Drawing.Size(153, 24);
            this.mnuSearchByAttr.Text = "按属性查询";
            this.mnuSearchByAttr.Click += new System.EventHandler(this.mnuSearchByAttr_Click);
            // 
            // 点选查询ToolStripMenuItem
            // 
            this.点选查询ToolStripMenuItem.Name = "点选查询ToolStripMenuItem";
            this.点选查询ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.点选查询ToolStripMenuItem.Text = "点选查询";
            this.点选查询ToolStripMenuItem.Click += new System.EventHandler(this.点选查询ToolStripMenuItem_Click);
            // 
            // 矩形查询ToolStripMenuItem
            // 
            this.矩形查询ToolStripMenuItem.Name = "矩形查询ToolStripMenuItem";
            this.矩形查询ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.矩形查询ToolStripMenuItem.Text = "矩形查询";
            // 
            // 多边形查询ToolStripMenuItem
            // 
            this.多边形查询ToolStripMenuItem.Name = "多边形查询ToolStripMenuItem";
            this.多边形查询ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.多边形查询ToolStripMenuItem.Text = "多边形查询";
            // 
            // 清除选择集ToolStripMenuItem
            // 
            this.清除选择集ToolStripMenuItem.Name = "清除选择集ToolStripMenuItem";
            this.清除选择集ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.清除选择集ToolStripMenuItem.Text = "清除选择集";
            // 
            // 空间分析ToolStripMenuItem
            // 
            this.空间分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBuffer,
            this.空间数据库连接ToolStripMenuItem});
            this.空间分析ToolStripMenuItem.Name = "空间分析ToolStripMenuItem";
            this.空间分析ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.空间分析ToolStripMenuItem.Text = "空间分析";
            // 
            // mnuBuffer
            // 
            this.mnuBuffer.Name = "mnuBuffer";
            this.mnuBuffer.Size = new System.Drawing.Size(183, 24);
            this.mnuBuffer.Text = "缓冲区分析";
            this.mnuBuffer.Click += new System.EventHandler(this.mnuBuffer_Click);
            // 
            // 空间数据库连接ToolStripMenuItem
            // 
            this.空间数据库连接ToolStripMenuItem.Name = "空间数据库连接ToolStripMenuItem";
            this.空间数据库连接ToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.空间数据库连接ToolStripMenuItem.Text = "空间数据库连接";
            this.空间数据库连接ToolStripMenuItem.Click += new System.EventHandler(this.空间数据库连接ToolStripMenuItem_Click);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(466, 278);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 56);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 620);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(4, 651);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1141, 25);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(71, 20);
            this.statusBarXY.Text = "Test 123";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_adddata,
            this.cms_openattri,
            this.cms_zoom,
            this.cms_remove,
            this.cms_symbology});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 124);
            // 
            // cms_adddata
            // 
            this.cms_adddata.Image = ((System.Drawing.Image)(resources.GetObject("cms_adddata.Image")));
            this.cms_adddata.Name = "cms_adddata";
            this.cms_adddata.Size = new System.Drawing.Size(153, 24);
            this.cms_adddata.Text = "加载数据";
            this.cms_adddata.Click += new System.EventHandler(this.cms_adddata_Click);
            // 
            // cms_openattri
            // 
            this.cms_openattri.Name = "cms_openattri";
            this.cms_openattri.Size = new System.Drawing.Size(153, 24);
            this.cms_openattri.Text = "打开属性表";
            this.cms_openattri.Click += new System.EventHandler(this.cms_openattri_Click);
            // 
            // cms_zoom
            // 
            this.cms_zoom.Image = ((System.Drawing.Image)(resources.GetObject("cms_zoom.Image")));
            this.cms_zoom.Name = "cms_zoom";
            this.cms_zoom.Size = new System.Drawing.Size(153, 24);
            this.cms_zoom.Text = "缩放到图层";
            this.cms_zoom.Click += new System.EventHandler(this.cms_zoom_Click);
            // 
            // cms_remove
            // 
            this.cms_remove.Name = "cms_remove";
            this.cms_remove.Size = new System.Drawing.Size(153, 24);
            this.cms_remove.Text = "删除图层";
            this.cms_remove.Click += new System.EventHandler(this.cms_remove_Click);
            // 
            // cms_symbology
            // 
            this.cms_symbology.Name = "cms_symbology";
            this.cms_symbology.Size = new System.Drawing.Size(153, 24);
            this.cms_symbology.Text = "简单符号化";
            this.cms_symbology.Click += new System.EventHandler(this.cms_symbology_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.comboEditLayers,
            this.btnAddPoint,
            this.btnAddPolyline,
            this.btnAddPolygon,
            this.btnselec_point,
            this.btnselec_rec,
            this.toolselec_poly,
            this.btnselec_clear});
            this.toolStrip1.Location = new System.Drawing.Point(4, 56);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1141, 28);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(69, 25);
            this.toolStripLabel1.Text = "选择图层";
            // 
            // comboEditLayers
            // 
            this.comboEditLayers.Name = "comboEditLayers";
            this.comboEditLayers.Size = new System.Drawing.Size(121, 28);
            this.comboEditLayers.ToolTipText = "选择编辑图层";
            this.comboEditLayers.Click += new System.EventHandler(this.comboEditLayers_Click);
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPoint.Image")));
            this.btnAddPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(104, 25);
            this.btnAddPoint.Text = "添加点要素";
            this.btnAddPoint.ToolTipText = "添加点要素";
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // btnAddPolyline
            // 
            this.btnAddPolyline.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPolyline.Image")));
            this.btnAddPolyline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddPolyline.Name = "btnAddPolyline";
            this.btnAddPolyline.Size = new System.Drawing.Size(104, 25);
            this.btnAddPolyline.Text = "添加线要素";
            this.btnAddPolyline.ToolTipText = "添加线要素";
            this.btnAddPolyline.Click += new System.EventHandler(this.btnAddPolyline_Click);
            // 
            // btnAddPolygon
            // 
            this.btnAddPolygon.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPolygon.Image")));
            this.btnAddPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddPolygon.Name = "btnAddPolygon";
            this.btnAddPolygon.Size = new System.Drawing.Size(104, 25);
            this.btnAddPolygon.Text = "添加面要素";
            this.btnAddPolygon.ToolTipText = "添加面要素";
            this.btnAddPolygon.Click += new System.EventHandler(this.btnAddPolygon_Click);
            // 
            // btnselec_point
            // 
            this.btnselec_point.Image = ((System.Drawing.Image)(resources.GetObject("btnselec_point.Image")));
            this.btnselec_point.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnselec_point.Name = "btnselec_point";
            this.btnselec_point.Size = new System.Drawing.Size(89, 25);
            this.btnselec_point.Text = "点选查询";
            this.btnselec_point.Click += new System.EventHandler(this.btnselec_point_Click);
            // 
            // btnselec_rec
            // 
            this.btnselec_rec.Image = ((System.Drawing.Image)(resources.GetObject("btnselec_rec.Image")));
            this.btnselec_rec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnselec_rec.Name = "btnselec_rec";
            this.btnselec_rec.Size = new System.Drawing.Size(89, 25);
            this.btnselec_rec.Text = "矩形查询";
            this.btnselec_rec.Click += new System.EventHandler(this.btnselec_rec_Click);
            // 
            // toolselec_poly
            // 
            this.toolselec_poly.Image = ((System.Drawing.Image)(resources.GetObject("toolselec_poly.Image")));
            this.toolselec_poly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolselec_poly.Name = "toolselec_poly";
            this.toolselec_poly.Size = new System.Drawing.Size(104, 25);
            this.toolselec_poly.Text = "多边形查询";
            this.toolselec_poly.Click += new System.EventHandler(this.toolselec_poly_Click);
            // 
            // btnselec_clear
            // 
            this.btnselec_clear.Image = ((System.Drawing.Image)(resources.GetObject("btnselec_clear.Image")));
            this.btnselec_clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnselec_clear.Name = "btnselec_clear";
            this.btnselec_clear.Size = new System.Drawing.Size(104, 25);
            this.btnselec_clear.Text = "清除选择集";
            this.btnselec_clear.Click += new System.EventHandler(this.btnselec_clear_Click);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTOCControl1.Location = new System.Drawing.Point(4, 84);
            this.axTOCControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(307, 567);
            this.axTOCControl1.TabIndex = 11;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(311, 84);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(834, 567);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.axMapControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(826, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "地图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(3, 3);
            this.axMapControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(820, 532);
            this.axMapControl1.TabIndex = 14;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(this.axMapControl1_OnAfterScreenDraw);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.axPageLayoutControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(826, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "布局";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(820, 532);
            this.axPageLayoutControl1.TabIndex = 0;
            this.axPageLayoutControl1.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnAfterScreenDrawEventHandler(this.axPageLayoutControl1_OnAfterScreenDraw);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 676);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "ArcEngine Controls Application";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(axToolbarControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem menNewDoc;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenMxd;
        private System.Windows.Forms.ToolStripMenuItem menSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuExitApp;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.ToolStripMenuItem mnuMap;
        private System.Windows.Forms.ToolStripMenuItem mnuZoomOut;
        private System.Windows.Forms.ToolStripMenuItem mnuZoomIn;
        private System.Windows.Forms.ToolStripMenuItem mnuZoomInF;
        private System.Windows.Forms.ToolStripMenuItem mnuFull;
        private System.Windows.Forms.ToolStripMenuItem mnuIden;
        private System.Windows.Forms.ToolStripMenuItem mnuAdddata;
        private System.Windows.Forms.ToolStripMenuItem mnuRecZoomIn;
        private System.Windows.Forms.ToolStripMenuItem mnuRecZoomOut;
        private System.Windows.Forms.ToolStripMenuItem mnuZoomOutF;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadShapefile;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadGDB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cms_adddata;
        private System.Windows.Forms.ToolStripMenuItem cms_openattri;
        private System.Windows.Forms.ToolStripMenuItem cms_zoom;
        private System.Windows.Forms.ToolStripMenuItem cms_remove;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateShapefile;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateGDB;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox comboEditLayers;
        private System.Windows.Forms.ToolStripButton btnAddPoint;
        private System.Windows.Forms.ToolStripButton btnAddPolyline;
        private System.Windows.Forms.ToolStripButton btnAddPolygon;
        private System.Windows.Forms.ToolStripMenuItem cms_symbology;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem 地图ToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.ToolStripMenuItem mnuOutput;
        private System.Windows.Forms.ToolStripMenuItem mnuDisplayMap;
        private System.Windows.Forms.ToolStripMenuItem mnuDisplayLayout;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertNorthArrow;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertScalebar;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertLegend;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertTitle;
        private System.Windows.Forms.ToolStripMenuItem 数据查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSearchByAttr;
        private System.Windows.Forms.ToolStripMenuItem 点选查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 矩形查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 多边形查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除选择集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnselec_point;
        private System.Windows.Forms.ToolStripButton btnselec_rec;
        private System.Windows.Forms.ToolStripButton toolselec_poly;
        private System.Windows.Forms.ToolStripButton btnselec_clear;
        private System.Windows.Forms.ToolStripMenuItem 空间分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBuffer;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.ToolStripMenuItem 空间数据库连接ToolStripMenuItem;
    }
}

