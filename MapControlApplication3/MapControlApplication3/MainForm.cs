using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Output;


namespace MapControlApplication3
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        public IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;
        #endregion

        #region class constructor
        public MainForm()
        {
            InitializeComponent();
            //if (m_mapControl.Map.SpatialReference == null)
            //    Ref = m_mapControl.Map.SpatialReference;      //为什么定义一个变量之后会报null的错？？直接用就不会有错，妈的想不通
            //else
            //    Ref = null;
        }
        #endregion


        private ILayer m_tocLayer = null;
        private INewDimensionFeedback iLineFeed = null;
        public IPointCollection pointColl = new PolylineClass();
        public IPoint startpoint = new PointClass();
        //public ISpatialReference Ref;

        private int flagSelect = 0;//图形查询控制标识符
        private int flagEdit = 0;//要素编辑控制标识符
        //private int flagMapNavi = 0; //地图漫游控制标识符      干嘛用的？
       

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;

            //disable the Save menu (since there is no document yet)
            menSaveDoc.Enabled = false;
        }

        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open Document command
            //ICommand command = new ControlsOpenDocCommandClass();
           // command.OnCreate(m_mapControl.Object);
            //command.OnClick();
           // OpenFileDialog ofg = new OpenFileDialog();
                 ////ofg.Title = "打开文档";
                 ////ofg.Filter = "mxd文档|*.mxd";
                 ////ofg.Multiselect = false;
                //// if (ofg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //// {
                 ////    string strFileName = ofg.FileName;
                 ////    m_mapControl.LoadMxFile(strFileName);    //
               ////  }
            //// else
                 ////{
                    //// MessageBox.Show("无效路径！");
                   ////  return;
            ////  }
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Title = "打开文档";
            ofg.Filter = "mxd文档|*.mxd";
            ofg.Multiselect = false;
            ofg.RestoreDirectory = true;
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                string sFilename = ofg.FileName;
                if (sFilename == "")                 //检查是否为空
                    return;
                if (m_mapControl.CheckMxFile(sFilename))    
                    m_mapControl.LoadMxFile(sFilename);
                else
                {
                    MessageBox.Show(sFilename + "无效！", "信息提示");
                    return;
                }
            }
            GetAllFeatureLayers();

        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
            if (btnAddPolyline.Checked && comboEditLayers.SelectedIndex != -1)
            {
                //System.Drawing.Point endpoint = new System.Drawing.Point(e.x, e.y);
                //System.Drawing.Point systemstartpoint = new System.Drawing.Point(Convert.ToInt32(startpoint.X), Convert.ToInt32(startpoint.Y));
                //Graphics g = null;
                //Pen p = new Pen(Color.Red);
                //g.DrawLine(p, systemstartpoint, endpoint);
            }
  
           
        }

        private void axToolbarControl1_OnMouseDown(object sender, IToolbarControlEvents_OnMouseDownEvent e)
        {

        }

        private void 固定比例尺缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsMapZoomOutFixedCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void mnuZoomOut_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsMapZoomOutToolClass();
            command.OnCreate(m_mapControl.Object);
            m_mapControl.CurrentTool = command as ITool;
        }

        private void mnuZoomIn_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsMapZoomInToolClass();
            command.OnCreate(m_mapControl.Object);
            m_mapControl.CurrentTool = command as ITool;
        }

        private void mnuZoomInF_Click(object sender, EventArgs e)
        {
           // ICommand command = new ControlsMapZoomInFixedCommandClass();
           // command.OnCreate(m_mapControl.Object);
           // command.OnClick();
            m_mapControl.CurrentTool = null;
            m_mapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
            IEnvelope pEnv = null;
            pEnv = m_mapControl.Extent;
            pEnv.Expand(.05,0.5,true);     //放大两倍
            m_mapControl.Extent = pEnv;
            m_mapControl.ActiveView.Refresh();
        }

        private void mnuFull_Click(object sender, EventArgs e)
        {
            //ICommand command = new ControlsMapFullExtentCommandClass();
           // command.OnCreate(m_mapControl.Object);
            //command.OnClick();
            m_mapControl.Extent = m_mapControl.FullExtent;
        }

        private void mnuIden_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsGlobeIdentifyToolClass();
            command.OnCreate(m_mapControl.Object);
            m_mapControl.CurrentTool = command as ITool;
        }

        private void mnuRecZoomIn_Click(object sender, EventArgs e)
        {
            IEnvelope pEnvelope;
            pEnvelope = m_mapControl.TrackRectangle();
            if (pEnvelope == null || pEnvelope.IsEmpty || pEnvelope.Height == 0 || pEnvelope.Width == 0)
            {
                return;
            }//拉框范围为空则退出
            else
            {
                double dWidth = m_mapControl.ActiveView.Extent.Width / m_mapControl.ActiveView.Extent.Width / pEnvelope.Width;
                double dHeight = m_mapControl.ActiveView.Extent.Height / pEnvelope.Height / pEnvelope.Height;
                double dXmin = m_mapControl.ActiveView.Extent.XMin + ((pEnvelope.XMin - m_mapControl.ActiveView.Extent.XMin) / m_mapControl.ActiveView.Extent.Width / pEnvelope.Width);
                double dYmin = m_mapControl.ActiveView.Extent.YMin + ((pEnvelope.YMin - m_mapControl.ActiveView.Extent.YMin) / m_mapControl.ActiveView.Extent.Height / pEnvelope.Height);
                double dXmax = dXmin + dWidth;
                double dYmax = dYmin + dHeight;
                pEnvelope.PutCoords(dXmin, dYmin, dXmax, dYmax);
            }
            m_mapControl.ActiveView.Extent = pEnvelope;
            m_mapControl.ActiveView.Refresh();
        }

        private void mnuAdddata_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsAddDataCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
            GetAllFeatureLayers();
            
        }

        public void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //IEnvelope ipEnv;
            //switch (flagMapNavi)                   //switch用法，事件响应函数没写对，触发命令，和拉框哪里没衔接上，没用
            //{
            //    case 1:
            //        ipEnv = axMapControl1.TrackRectangle();
            //        axMapControl1.Extent = ipEnv;
            //        break;
            //    case 2:
            //        ipEnv = axMapControl1.Extent;
            //        ipEnv.Expand(2.0, 2.0, true);
            //        axMapControl1.Extent = ipEnv;
            //        break;
            //    case 3:
            //        m_mapControl.Pan();
            //        break;
            //    default:
            //        flagMapNavi = 0;
            //        break;
            //}


            if(btnAddPoint.Checked && comboEditLayers.SelectedIndex != -1)//其实第二个条件可以不要把？
            {
                IPoint point = new PointClass();
                point.PutCoords(e.mapX,e.mapY);     //这个事件鼠标点一次触发一次，点一次refresh一次
                data_operate dop = new data_operate();
                ILayer layer = dop.GetLayerByName(m_mapControl.Map,comboEditLayers.SelectedItem.ToString());
                IFeatureLayer fealyr = layer as IFeatureLayer;
                //一些要素操作都是在图层对象上进行（点运算方法）;
                dop.AddFeature(fealyr,point);           //注意传入要素为图层要素集
                m_mapControl.ActiveView.Refresh();
            }
            if (btnAddPolyline.Checked && comboEditLayers.SelectedIndex != -1)//其实第二个条件可以不要把？
            {
                startpoint.PutCoords(e.mapX, e.mapY);     //这个事件鼠标点一次触发一次，点一次refresh一次
                pointColl.AddPoint(startpoint);
            }
            if (btnAddPolygon.Checked && comboEditLayers.SelectedIndex != -1)//其实第二个条件可以不要把？
            {
                startpoint.PutCoords(e.mapX, e.mapY);     //这个事件鼠标点一次触发一次，点一次refresh一次
                pointColl.AddPoint(startpoint);
            }

            //空间查询mouse down事件
            if (flagSelect != 0 && comboEditLayers.SelectedIndex != -1)
            {
                data_operate dop = new data_operate();
                IFeatureLayer selectedlayer = dop.GetLayerByName(m_mapControl.Map,comboEditLayers.SelectedItem.ToString()) as IFeatureLayer;
                ESRI.ArcGIS.Carto.IActiveView pActiveView = this.axMapControl1.ActiveView;
                //获取鼠标点
                ESRI.ArcGIS.Geometry.IPoint pPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
                ESRI.ArcGIS.Geometry.IGeometry pGeometry = null;
                switch (flagSelect)
                {
                    case 1:         //矩形查询
                        pGeometry = this.axMapControl1.TrackRectangle();
                        break;
                    case 2:         //线查询
                        pGeometry = this.axMapControl1.TrackLine();
                        break;
                    case 3:         //点查询
                        ESRI.ArcGIS.Geometry.ITopologicalOperator pTopo;
                        ESRI.ArcGIS.Geometry.IGeometry pBuffer;
                        pGeometry = pPoint;
                        pTopo = pGeometry as ESRI.ArcGIS.Geometry.ITopologicalOperator;
                        //根据点位创建缓冲区，缓冲半径设为0.1，可自行修改
                        pBuffer = pTopo.Buffer(0.1);
                        pGeometry = pBuffer.Envelope;
                        break;
                }

                MapAnalysis.SelectMapFeaturesByGeometryQuery(m_mapControl.ActiveView, selectedlayer, pGeometry);
 
            }



        }

        private void 打开工程文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void opentest_Click(object sender, EventArgs e) ///////打开地图文档
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Title = "打开文档";
            ofg.Filter = "mxd文档|*.mxd";
            ofg.Multiselect = false;
            if (ofg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strFileName = ofg.FileName;
                m_mapControl.LoadMxFile(strFileName);
            }
            else
            {
                MessageBox.Show("无效路径！");
                return;
            }
        }

        private void 固定ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuZoomOutF_Click(object sender, EventArgs e)
        {
           // ICommand command = new ControlsMapZoomOutFixedCommandClass();
            //command.OnCreate(m_mapControl.Object);
            //command.OnClick();
            m_mapControl.CurrentTool = null;       //？？
            m_mapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;    //？？
            IEnvelope pEnv = null;                //声明包络线
            pEnv = m_mapControl.Extent;           //记下mapcontrol当前的extent
            pEnv.Expand(2.0, 2.0, true);     //缩小两倍 重新设置extent大小
            m_mapControl.Extent = pEnv;           
            m_mapControl.ActiveView.Refresh();     //重新显示

        }

        private void mnuRecZoomOut_Click(object sender, EventArgs e)
        {
            IEnvelope pEnvelope;
            pEnvelope = m_mapControl.TrackRectangle();
            if (pEnvelope == null || pEnvelope.IsEmpty || pEnvelope.Height == 0 || pEnvelope.Width == 0)
            {
                return;
            }//拉框范围为空则退出
            else
            {
                double dWidth = m_mapControl.ActiveView.Extent.Width * m_mapControl.ActiveView.Extent.Width / pEnvelope.Width;
                double dHeight = m_mapControl.ActiveView.Extent.Height * pEnvelope.Height / pEnvelope.Height;
                double dXmin = m_mapControl.ActiveView.Extent.XMin - ((pEnvelope.XMin - m_mapControl.ActiveView.Extent.XMin) * m_mapControl.ActiveView.Extent.Width / pEnvelope.Width);
                double dYmin = m_mapControl.ActiveView.Extent.YMin - ((pEnvelope.YMin - m_mapControl.ActiveView.Extent.YMin) * m_mapControl.ActiveView.Extent.Height / pEnvelope.Height);
                double dXmax = dXmin + dWidth;
                double dYmax = dYmin + dHeight;
                pEnvelope.PutCoords(dXmin, dYmin, dXmax, dYmax);
            }
            m_mapControl.ActiveView.Extent = pEnvelope;
            m_mapControl.ActiveView.Refresh();
        }
        private void mnuLoadShapefile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开图层文件";
            openFileDialog.Filter = "shp文件|*.shp";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string strFullFileName = openFileDialog.FileName;
                string strShortFileName = openFileDialog.SafeFileName;  
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                //System.Diagnostics.Debug.WriteLine(strFileName);//在输出窗口中查看获取的文件名
                data_operate dataope = new data_operate();
                IFeatureClass fc = dataope.OpenShapeFeatureClass(fileInfo.DirectoryName, strShortFileName);
                AddFeatureLayer(fc, fc.AliasName);
            }

        }    
        //加载gdb鼠标click事件
        private void mnuLoadGDB_Click(object sender, EventArgs e)
        {
            selcet_gdb gdb = new selcet_gdb();
            gdb.ShowDialog();
            data_operate dataope = new data_operate();
            foreach (string s in gdb.seletedFCAttr)
            {
                IFeatureClass gdbfc = dataope.OpenGDBFeatureClass(gdb.SelectedGDBPath, s);
                AddFeatureLayer(gdbfc, gdbfc.AliasName);
            }
        }
            
        //编写加载featureclass至地图的方法：
        private void AddFeatureLayer(IFeatureClass featureClass, string layerName)
        {
            IFeatureLayer featureLayer = new FeatureLayerClass();          //实例化要素图层；
            featureLayer.FeatureClass = featureClass;                      //通过图层属性赋值向图层中添加要素；
            featureLayer.Name = layerName;                                 //命名，
            ILayer layer = featureLayer as ILayer;                        //强制转换，featurelayer→layer 区别在哪里我也是不知道。。。
            m_mapControl.Map.AddLayer(layer);                              //只要知道是为了合法的传参数进去，只能先转为layer，一切只为合法化，法治社会呵呵呵

        }
        //toc鼠标右键单机响应事件，以及对不同目标的弹框显示内容
        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 1) return;
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;                     //????枚举类型不能直接？？？
            IBasicMap map = null;
            object other = null;
            object index = null;
            axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref m_tocLayer, ref other, ref index);
            if (item == esriTOCControlItem.esriTOCControlItemMap)       //地图右键选项
            {
                cms_adddata.Visible = true;
                cms_openattri.Visible = false;
                cms_remove.Visible = false;
                cms_zoom.Visible = false;
                cms_symbology.Visible = false;
            }
            else if (item == esriTOCControlItem.esriTOCControlItemLayer)  //图层右键选项
            {
                cms_adddata.Visible = false;
                cms_openattri.Visible = true;
                cms_remove.Visible = true;
                cms_zoom.Visible = true;
                cms_symbology.Visible = true;    //分栅格矢量吗
            }
            contextMenuStrip1.Show(axTOCControl1, e.x, e.y);            //显示弹框

        }
        //右键菜单打开属性表click事件
        private void cms_openattri_Click(object sender, EventArgs e)
        { 
           
            if (m_tocLayer != null)        //  图层是在哪里选中的？？
            {
                IFeatureLayer feaLyr = m_tocLayer as IFeatureLayer;  //接口转换
                IFeatureClass feaCls = feaLyr.FeatureClass;
                data_operate dataope = new data_operate();
                FormOpenAttri frm = new FormOpenAttri(feaLyr, true);
                frm.Show();

            }
        }
        //右键菜单其他内容
        private void cms_adddata_Click(object sender, EventArgs e)
        {
                ICommand command = new ControlsAddDataCommandClass();
                command.OnCreate(m_mapControl.Object);
                command.OnClick();
                GetAllFeatureLayers();
        }

        private void cms_zoom_Click(object sender, EventArgs e)
        {
            if (m_tocLayer != null)
            {
                m_mapControl.Extent = m_tocLayer.AreaOfInterest;
            }
        }

        private void cms_remove_Click(object sender, EventArgs e)
        {
            if (m_tocLayer != null)
            {
                m_mapControl.Map.DeleteLayer(m_tocLayer);
            }
            GetAllFeatureLayers();
        }



        /////04/08分割线————————————————————————————————————————————


        private void mnuCreateShapefile_Click(object sender, EventArgs e)
        {
            Createshapefile csf = new Createshapefile();
            csf.Ref_relay = m_mapControl.Map.SpatialReference;
            if (m_mapControl.Map.SpatialReference == null)
                csf.text_ref.Text = "NULL";
            else
                csf.text_ref.Text = m_mapControl.Map.SpatialReference.ToString();
            csf.ShowDialog();

            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Title = "新建shape_point文件";
            //sfd.Filter = "shape文件|*.shp";
            //if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    string strFullFileName = sfd.FileName;
            //    FileInfo fileinfo = new FileInfo(sfd.FileName);   //fileinfo的作用就是传入参数（文件名称？），之后可以通过fileinfo实例属性来获取路径目录名、文件名
            //    data_operate dop = new data_operate();
            //    //IFeatureClass fc = dop.CreateShapefile(fileinfo.DirectoryName, fileinfo.Name, m_mapControl.Map.SpatialReference); 
            
        }

        private void mnuCreateGDB_Click(object sender, EventArgs e)
        {
            data_operate DOP = new data_operate();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "选择GDB文件创建路径";
            saveFileDialog.Filter = "DGB文件|*.gdb";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileinfo = new FileInfo(saveFileDialog.FileName);
                DOP.CreateGDB(fileinfo.DirectoryName, fileinfo.Name);
            }
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            if (btnAddPoint.Checked) //关于属性栏的if语句写法，貌似点到为止
            {
                btnAddPoint.Checked = false;
            }
            else
            {
                if (comboEditLayers.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择一个图层！");
                    return;
                }
                data_operate dop = new data_operate();
                ILayer layer = dop.GetLayerByName(m_mapControl.Map, comboEditLayers.SelectedItem.ToString());   //这里用到combo里的图层是为了判断图层要素类型
                IFeatureLayer fealyr = layer as IFeatureLayer;    //IFeatureLayer和ilayer
                if (fealyr.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint)
                {
                    MessageBox.Show("请选择添加点类型的图层!");
                    return;
                }
                if (MessageBox.Show("是否添加要素？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnAddPoint.Checked = true;
                }
            }
        }
        private void GetAllFeatureLayers()                  //需要写在mainform里的函数，可以总结一下，一种是事件响应函数，一种是combo控件item添加事件
        {
            comboEditLayers.Items.Clear();
            ILayer layer;                //传递参数作用
            for (int i = 0; i < m_mapControl.LayerCount; i++)    //还有.layercount这个属性，是在mapcontrol显示的还是toc加载进来的？这里看来是toc加载进来的
            {
                layer = m_mapControl.get_Layer(i);
                IFeatureLayer fealyr = (IFeatureLayer)layer;
                if(fealyr.FeatureClass.FeatureType != esriFeatureType.esriFTRasterCatalogItem )
                    comboEditLayers.Items.Add(layer.Name);         //判断是否为栅格
            }
            if (comboEditLayers.Items.Count > 0)
            {
                comboEditLayers.SelectedIndex = 0;       //这里可以知道selectedindex为-1是combo为空的意思？是空还是没选？
            }

        }

        private void btnAddPolyline_Click(object sender, EventArgs e)
        {
            if (btnAddPolyline.Checked) //关于属性栏的if语句写法，貌似点到为止
            {
                btnAddPolyline.Checked = false;
            }
            else
            {
                if (comboEditLayers.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择一个图层！");
                    return;
                }
                data_operate dop = new data_operate();
                ILayer layer = dop.GetLayerByName(m_mapControl.Map, comboEditLayers.SelectedItem.ToString());   //这里用到combo里的图层是为了判断图层要素类型
                IFeatureLayer fealyr = layer as IFeatureLayer;    //IFeatureLayer和ilayer
                if (fealyr.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolyline)
                {
                    MessageBox.Show("请选择添加线类型的图层!");
                    return;
                }
                if (MessageBox.Show("是否添加要素？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnAddPolyline.Checked = true;
                }
            }
        }

        private void btnAddPolygon_Click(object sender, EventArgs e)
        {
            if (btnAddPolygon.Checked) //关于属性栏的if语句写法，貌似点到为止
            {
                btnAddPolygon.Checked = false;
            }
            else
            {
                if (comboEditLayers.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择一个图层！");
                    return;
                }
                data_operate dop = new data_operate();
                ILayer layer = dop.GetLayerByName(m_mapControl.Map, comboEditLayers.SelectedItem.ToString());   //这里用到combo里的图层是为了判断图层要素类型
                IFeatureLayer fealyr = layer as IFeatureLayer;    //IFeatureLayer和ilayer
                if (fealyr.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolygon)
                {
                    MessageBox.Show("请选择添加面类型的图层!");
                    return;
                }
                if (MessageBox.Show("是否添加要素？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnAddPolygon.Checked = true;
                }
            }
        }

        private void axMapControl1_OnDoubleClick(object sender, IMapControlEvents2_OnDoubleClickEvent e)
        {
            if(btnAddPolyline.Checked && comboEditLayers.SelectedIndex != -1)
            {
                data_operate dop = new data_operate();
                ILayer layer = dop.GetLayerByName(m_mapControl.Map, comboEditLayers.SelectedItem.ToString());
                IFeatureLayer fealyr = layer as IFeatureLayer;
                //一些要素操作都是在图层对象上进行（点运算方法），
                IPolyline final = dop.GetPolylineGeometry(pointColl);
                dop.AddFeature(fealyr, final);           //注意传入要素为图层要素集
                m_mapControl.ActiveView.Refresh();
            }
            if (btnAddPolygon.Checked && comboEditLayers.SelectedIndex != -1)
            {
                data_operate dop = new data_operate();
                ILayer layer = dop.GetLayerByName(m_mapControl.Map, comboEditLayers.SelectedItem.ToString());
                IFeatureLayer fealyr = layer as IFeatureLayer;
                //一些要素操作都是在图层对象上进行（点运算方法）， 
                IPolygon final = dop.GetPolygonGeomery(pointColl);
                dop.AddFeature(fealyr, final);           //注意传入要素为图层要素集 
                m_mapControl.ActiveView.Refresh();
            }
         }

        private void cms_symbology_Click(object sender, EventArgs e)
        {
            IFeatureLayer feam_tocLayer = m_tocLayer as IFeatureLayer;
            IFeatureClass featurecls = feam_tocLayer.FeatureClass;
            FrmPointSymbol fps = new FrmPointSymbol();
            if (featurecls.ShapeType == esriGeometryType.esriGeometryPolyline)
            {
                fps.checkBox1.Enabled = false;
                fps.panel_linecolor.Enabled = false;
                fps.panel_linecolor.BackColor = System.Drawing.Color.Silver;
                fps.nud_linesize.Enabled = false;
            }
            if (featurecls.ShapeType == esriGeometryType.esriGeometryPolygon)
            {
                fps.nud_linesize.Enabled = false;
            }

            IColor panelcolor = new RgbColor();
            IColor paneloutlinecolor = new RgbColor();
            fps.ShowDialog();
            panelcolor.RGB = fps.Panelcolor.B * 65536 + fps.Panelcolor.G * 256 + fps.Panelcolor.R;
            paneloutlinecolor.RGB = fps.Paneloutsidecolor.B * 65536 + fps.Paneloutsidecolor.G * 256 + fps.Paneloutsidecolor.R;
            if (featurecls.ShapeType == esriGeometryType.esriGeometryPoint)
            {
                MapComposer.PointRenderSimply(feam_tocLayer, panelcolor, paneloutlinecolor, fps.Size1, fps.NumOutlineSize, fps.Useoutline);
            }
            if (featurecls.ShapeType == esriGeometryType.esriGeometryPolyline)
            {

                MapComposer.PolylineRenderSimply(feam_tocLayer, panelcolor, fps.Size1);
            }
            if (featurecls.ShapeType == esriGeometryType.esriGeometryPolygon)
            {
                MapComposer.PolygonRenderSimply(feam_tocLayer, panelcolor, paneloutlinecolor, fps.NumOutlineSize);
            }
            m_mapControl.ActiveView.Refresh();
        }

        private void 地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuDisplayMap_Click(object sender, EventArgs e)
        {
            axTOCControl1.SetBuddyControl(axMapControl1.Object);
            axToolbarControl1.SetBuddyControl(axMapControl1.Object);
            MapComposer.CopyMap(axPageLayoutControl1.ActiveView.FocusMap,m_mapControl.Map);
            tabControl1.SelectedTab = tabPage1;
            mnuDisplayLayout.Checked = false;
            mnuDisplayMap.Checked = true;
        }

        private void mnuDisplayLayout_Click(object sender, EventArgs e)
        {
            axTOCControl1.SetBuddyControl(axPageLayoutControl1.Object);
            axToolbarControl1.SetBuddyControl(axPageLayoutControl1.Object);
            MapComposer.CopyMap(m_mapControl.Map, axPageLayoutControl1.ActiveView.FocusMap);
            axPageLayoutControl1.ActiveView.Extent = m_mapControl.ActiveView.Extent;
            axPageLayoutControl1.Refresh();
            tabControl1.SelectedTab = tabPage2;
            mnuDisplayLayout.Checked = true;
            mnuDisplayMap.Checked = false;
            //m_mapControl.Extent//转到可以设置范围的接口
            //IActiveView activeVeiw = axPageLayoutControl1.ActiveView.FocusMap as IActiveView;
            

        }
        //private void ChangeControl()
        //{
        //    if (mnuDisplayLayout.Checked == false)
        //    {
        //       // IMapControl2 axMapControl1 = (IMapControl2)axTOCControl1.Buddy;
        //        axTOCControl1.SetBuddyControl(axMapControl1.Object);

        //        tabControl1.SelectedTab = tabPage1;
        //    }
        //    else
        //    {
        //        axTOCControl1.SetBuddyControl(axMapControl1.Object);
        //        tabControl1.SelectedTab = tabPage2;
        //        mnuDisplayLayout.Checked = true;
        //        mnuDisplayMap.Checked = false;
        //    }
        //}

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            //// IMap pagelayoutmap = (IMap)axPageLayoutControl1.m;CUODE
            //MapComposer.CopyMap(m_mapControl.Map, axPageLayoutControl1.ActiveView.FocusMap);
            //axPageLayoutControl1.ActiveView.Extent = m_mapControl.ActiveView.Extent;
            //axPageLayoutControl1.Refresh();
        }

        private void axPageLayoutControl1_OnAfterScreenDraw(object sender, IPageLayoutControlEvents_OnAfterScreenDrawEvent e)
        {
            //// IMap pagelayoutmap = (IMap)axPageLayoutControl1.Object;CUODE
            //MapComposer.CopyMap(axPageLayoutControl1.ActiveView.FocusMap, m_mapControl.Map);
            //m_mapControl.ActiveView.Extent = axPageLayoutControl1.ActiveView.Extent;

        }

        private void mnuOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            string path = sfd.FileName;
            IExport docExport;
            docExport = new ExportJPEGClass();
            IActiveView docActiveView;
            IPrintAndExport docPrintExport;
            int iOutputResolution = 300;
            if (!mnuDisplayLayout.Checked)
                docActiveView = axMapControl1.ActiveView;
            else
                docActiveView = axPageLayoutControl1.ActiveView;

            docPrintExport = new PrintAndExportClass();
            docExport.ExportFileName = path;
            docPrintExport.Export(docActiveView, docExport, iOutputResolution, true, null);
        }

        //全写在main函数里了05/07

        public void AddNorthArrow(ESRI.ArcGIS.Carto.IPageLayout pagelayout, ESRI.ArcGIS.Carto.IMap map)
        {
            //pagelayout = (ESRI.ArcGIS.Carto.IPageLayout)axPageLayoutControl1;
            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            envelope.PutCoords(0.2, 0.2, 5, 5); //  Specify the location and size of the north arrow

            ESRI.ArcGIS.esriSystem.IUID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
            uid.Value = "esriCarto.MarkerNorthArrow";

            ESRI.ArcGIS.Carto.IGraphicsContainer graphicsContainer = pagelayout as ESRI.ArcGIS.Carto.IGraphicsContainer; // Dynamic Cast
            ESRI.ArcGIS.Carto.IActiveView activeView = pagelayout as ESRI.ArcGIS.Carto.IActiveView; // Dynamic Cast
            ESRI.ArcGIS.Carto.IFrameElement frameElement = graphicsContainer.FindFrame(map);
            ESRI.ArcGIS.Carto.IMapFrame mapFrame = frameElement as ESRI.ArcGIS.Carto.IMapFrame; // Dynamic Cast
            ESRI.ArcGIS.Carto.IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid as ESRI.ArcGIS.esriSystem.UID, null); // Dynamic Cast
            ESRI.ArcGIS.Carto.IElement element = mapSurroundFrame as ESRI.ArcGIS.Carto.IElement; // Dynamic Cast
            element.Geometry = envelope;
            element.Activate(activeView.ScreenDisplay);
            graphicsContainer.AddElement(element, 0);
            ESRI.ArcGIS.Carto.IMapSurround mapSurround = mapSurroundFrame.MapSurround;

            ESRI.ArcGIS.Carto.IMarkerNorthArrow markerNorthArrow = mapSurround as ESRI.ArcGIS.Carto.IMarkerNorthArrow; // Dynamic Cast
            ESRI.ArcGIS.Display.IMarkerSymbol markerSymbol = markerNorthArrow.MarkerSymbol;
            ESRI.ArcGIS.Display.ICharacterMarkerSymbol characterMarkerSymbol = markerSymbol as ESRI.ArcGIS.Display.ICharacterMarkerSymbol; // Dynamic Cast
            characterMarkerSymbol.CharacterIndex = 200; // change the symbol for the North Arrow
            markerNorthArrow.MarkerSymbol = characterMarkerSymbol;

        }

        private void mnuInsertNorthArrow_Click(object sender, EventArgs e)
        {
            AddNorthArrow(axPageLayoutControl1.PageLayout,axPageLayoutControl1.ActiveView.FocusMap);
            axPageLayoutControl1.ActiveView.Refresh();
        }
        public void AddLegend(ESRI.ArcGIS.Carto.IPageLayout pageLayout, ESRI.ArcGIS.Carto.IMap map, System.Double posX, System.Double posY, System.Double legW)
        {
            ESRI.ArcGIS.Carto.IGraphicsContainer graphicsContainer = pageLayout as ESRI.ArcGIS.Carto.IGraphicsContainer; // Dynamic Cast
            ESRI.ArcGIS.Carto.IMapFrame mapFrame = graphicsContainer.FindFrame(map) as ESRI.ArcGIS.Carto.IMapFrame; // Dynamic Cast
            ESRI.ArcGIS.esriSystem.IUID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
            uid.Value = "esriCarto.Legend";
            ESRI.ArcGIS.Carto.IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame((ESRI.ArcGIS.esriSystem.UID)uid, null); // Explicit Cast

            //Get aspect ratio
            ESRI.ArcGIS.Carto.IQuerySize querySize = mapSurroundFrame.MapSurround as ESRI.ArcGIS.Carto.IQuerySize; // Dynamic Cast
            System.Double w = 0;
            System.Double h = 0;
            querySize.QuerySize(ref w, ref h);
            System.Double aspectRatio = w / h;

            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            envelope.PutCoords(posX, posY, (posX * legW), (posY * legW / aspectRatio));
            ESRI.ArcGIS.Carto.IElement element = mapSurroundFrame as ESRI.ArcGIS.Carto.IElement; // Dynamic Cast
            element.Geometry = envelope;
            graphicsContainer.AddElement(element, 0);

        }

        private void mnuInsertLegend_Click(object sender, EventArgs e)
        {
            AddLegend(axPageLayoutControl1.PageLayout, axPageLayoutControl1.ActiveView.FocusMap,2.0,2.0,5.0);
            axPageLayoutControl1.ActiveView.Refresh();
        }

        public void AddScalebar(ESRI.ArcGIS.Carto.IPageLayout pageLayout, ESRI.ArcGIS.Carto.IMap map)
        {
            ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
            envelope.PutCoords(0.2, 0.2, 1, 2); // Specify the location and size of the scalebar
            ESRI.ArcGIS.esriSystem.IUID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
            uid.Value = "esriCarto.AlternatingScaleBar";

            // Create a Surround. Set the geometry of the MapSurroundFrame to give it a location
            // Activate it and add it to the PageLayout's graphics container
            ESRI.ArcGIS.Carto.IGraphicsContainer graphicsContainer = pageLayout as ESRI.ArcGIS.Carto.IGraphicsContainer; // Dynamic Cast
            ESRI.ArcGIS.Carto.IActiveView activeView = pageLayout as ESRI.ArcGIS.Carto.IActiveView; // Dynamic Cast
            ESRI.ArcGIS.Carto.IFrameElement frameElement = graphicsContainer.FindFrame(map);
            ESRI.ArcGIS.Carto.IMapFrame mapFrame = frameElement as ESRI.ArcGIS.Carto.IMapFrame; // Dynamic Cast
            ESRI.ArcGIS.Carto.IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uid as ESRI.ArcGIS.esriSystem.UID, null); // Dynamic Cast
            ESRI.ArcGIS.Carto.IElement element = mapSurroundFrame as ESRI.ArcGIS.Carto.IElement; // Dynamic Cast
            element.Geometry = envelope;
            element.Activate(activeView.ScreenDisplay);
            graphicsContainer.AddElement(element, 0);
            ESRI.ArcGIS.Carto.IMapSurround mapSurround = mapSurroundFrame.MapSurround;


            ESRI.ArcGIS.Carto.IScaleBar markerScaleBar = ((ESRI.ArcGIS.Carto.IScaleBar)(mapSurround));
            markerScaleBar.LabelPosition = ESRI.ArcGIS.Carto.esriVertPosEnum.esriBelow;
            markerScaleBar.UseMapSettings();
        }

        private void mnuInsertScalebar_Click(object sender, EventArgs e)
        {
            AddScalebar(axPageLayoutControl1.PageLayout, axPageLayoutControl1.ActiveView.FocusMap);
            axPageLayoutControl1.ActiveView.Refresh();
        }

        private void mnuInsertTitle_Click(object sender, EventArgs e)
        {
            FormMapTitle FMT = new FormMapTitle();
            FMT.ShowDialog();
            IColor color_trans = new RgbColor();
            color_trans.RGB = FMT.Panelcolor.B * 65536 + FMT.Panelcolor.G * 256 + FMT.Panelcolor.R;
            IElement semi_element =
            MapComposer.AddTitle(axPageLayoutControl1.PageLayout, FMT.Maptitle, color_trans, FMT.Angle);
            IGraphicsContainer pGraphicsContainer = (IGraphicsContainer)axPageLayoutControl1.PageLayout;
            semi_element.Geometry = axPageLayoutControl1.TrackRectangle();
            pGraphicsContainer.AddElement(semi_element, 0);
            axPageLayoutControl1.Refresh();
        }

        private void mnuSearchByAttr_Click(object sender, EventArgs e)
        {
            FormSelectByAttr fsb = new FormSelectByAttr(m_mapControl.Map);
            fsb.ShowDialog();

        }

        private void comboEditLayers_Click(object sender, EventArgs e)
        {

        }

        private void btnselec_clear_Click(object sender, EventArgs e)
        {
            this.axMapControl1.Map.ClearSelection();
        }

        private void ResetToolControlStatus()
        {
            btnselec_point.Checked = false;
            btnselec_rec.Checked = false;
            toolselec_poly.Checked = false;
 
        }
        private void btnselec_point_Click(object sender, EventArgs e)
        {
            if (comboEditLayers.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个图层！");
                return;
            }
            //取消选择本按钮
            if (btnselec_point.Checked)
            {
                btnselec_point.Checked = false;
                flagSelect = 0;
            }
            else
            {
                //重设所有工具按钮的Checked状态
                ResetToolControlStatus();//这个方法大家自己定义，就是设置Checked为false
                //点选按钮按下
                btnselec_point.Checked = true;
                flagSelect = 1;
            }    

        }

        private void btnselec_rec_Click(object sender, EventArgs e)
        {
            if (comboEditLayers.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个图层！");
                return;
            }
            //取消选择本按钮
            if (btnselec_rec.Checked)
            {
                btnselec_rec.Checked = false;
                flagSelect = 0;
            }
            else
            {
                //重设所有工具按钮的Checked状态
                ResetToolControlStatus();//这个方法大家自己定义，就是设置Checked为false
                //点选按钮按下
                btnselec_rec.Checked = true;
                flagSelect = 2;
            }    
        }

        private void toolselec_poly_Click(object sender, EventArgs e)
        {
            if (comboEditLayers.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个图层！");
                return;
            }
            //取消选择本按钮
            if (toolselec_poly.Checked)
            {
                toolselec_poly.Checked = false;
                flagSelect = 0;
            }
            else
            {
                //重设所有工具按钮的Checked状态
                ResetToolControlStatus();//这个方法大家自己定义，就是设置Checked为false
                //点选按钮按下
                toolselec_poly.Checked = true;
                flagSelect = 3;
            }    
        }

        private void 点选查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuBuffer_Click(object sender, EventArgs e)
        {

        }

        private void 空间数据库连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }





    }  
}