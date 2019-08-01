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
            //    Ref = m_mapControl.Map.SpatialReference;      //Ϊʲô����һ������֮��ᱨnull�Ĵ���ֱ���þͲ����д�����벻ͨ
            //else
            //    Ref = null;
        }
        #endregion


        private ILayer m_tocLayer = null;
        private INewDimensionFeedback iLineFeed = null;
        public IPointCollection pointColl = new PolylineClass();
        public IPoint startpoint = new PointClass();
        //public ISpatialReference Ref;

        private int flagSelect = 0;//ͼ�β�ѯ���Ʊ�ʶ��
        private int flagEdit = 0;//Ҫ�ر༭���Ʊ�ʶ��
        //private int flagMapNavi = 0; //��ͼ���ο��Ʊ�ʶ��      �����õģ�
       

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
                 ////ofg.Title = "���ĵ�";
                 ////ofg.Filter = "mxd�ĵ�|*.mxd";
                 ////ofg.Multiselect = false;
                //// if (ofg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //// {
                 ////    string strFileName = ofg.FileName;
                 ////    m_mapControl.LoadMxFile(strFileName);    //
               ////  }
            //// else
                 ////{
                    //// MessageBox.Show("��Ч·����");
                   ////  return;
            ////  }
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Title = "���ĵ�";
            ofg.Filter = "mxd�ĵ�|*.mxd";
            ofg.Multiselect = false;
            ofg.RestoreDirectory = true;
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                string sFilename = ofg.FileName;
                if (sFilename == "")                 //����Ƿ�Ϊ��
                    return;
                if (m_mapControl.CheckMxFile(sFilename))    
                    m_mapControl.LoadMxFile(sFilename);
                else
                {
                    MessageBox.Show(sFilename + "��Ч��", "��Ϣ��ʾ");
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

        private void �̶���������СToolStripMenuItem_Click(object sender, EventArgs e)
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
            pEnv.Expand(.05,0.5,true);     //�Ŵ�����
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
            }//����ΧΪ�����˳�
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
            //switch (flagMapNavi)                   //switch�÷����¼���Ӧ����ûд�ԣ������������������û�ν��ϣ�û��
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


            if(btnAddPoint.Checked && comboEditLayers.SelectedIndex != -1)//��ʵ�ڶ����������Բ�Ҫ�ѣ�
            {
                IPoint point = new PointClass();
                point.PutCoords(e.mapX,e.mapY);     //����¼�����һ�δ���һ�Σ���һ��refreshһ��
                data_operate dop = new data_operate();
                ILayer layer = dop.GetLayerByName(m_mapControl.Map,comboEditLayers.SelectedItem.ToString());
                IFeatureLayer fealyr = layer as IFeatureLayer;
                //һЩҪ�ز���������ͼ������Ͻ��У������㷽����;
                dop.AddFeature(fealyr,point);           //ע�⴫��Ҫ��Ϊͼ��Ҫ�ؼ�
                m_mapControl.ActiveView.Refresh();
            }
            if (btnAddPolyline.Checked && comboEditLayers.SelectedIndex != -1)//��ʵ�ڶ����������Բ�Ҫ�ѣ�
            {
                startpoint.PutCoords(e.mapX, e.mapY);     //����¼�����һ�δ���һ�Σ���һ��refreshһ��
                pointColl.AddPoint(startpoint);
            }
            if (btnAddPolygon.Checked && comboEditLayers.SelectedIndex != -1)//��ʵ�ڶ����������Բ�Ҫ�ѣ�
            {
                startpoint.PutCoords(e.mapX, e.mapY);     //����¼�����һ�δ���һ�Σ���һ��refreshһ��
                pointColl.AddPoint(startpoint);
            }

            //�ռ��ѯmouse down�¼�
            if (flagSelect != 0 && comboEditLayers.SelectedIndex != -1)
            {
                data_operate dop = new data_operate();
                IFeatureLayer selectedlayer = dop.GetLayerByName(m_mapControl.Map,comboEditLayers.SelectedItem.ToString()) as IFeatureLayer;
                ESRI.ArcGIS.Carto.IActiveView pActiveView = this.axMapControl1.ActiveView;
                //��ȡ����
                ESRI.ArcGIS.Geometry.IPoint pPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
                ESRI.ArcGIS.Geometry.IGeometry pGeometry = null;
                switch (flagSelect)
                {
                    case 1:         //���β�ѯ
                        pGeometry = this.axMapControl1.TrackRectangle();
                        break;
                    case 2:         //�߲�ѯ
                        pGeometry = this.axMapControl1.TrackLine();
                        break;
                    case 3:         //���ѯ
                        ESRI.ArcGIS.Geometry.ITopologicalOperator pTopo;
                        ESRI.ArcGIS.Geometry.IGeometry pBuffer;
                        pGeometry = pPoint;
                        pTopo = pGeometry as ESRI.ArcGIS.Geometry.ITopologicalOperator;
                        //���ݵ�λ����������������뾶��Ϊ0.1���������޸�
                        pBuffer = pTopo.Buffer(0.1);
                        pGeometry = pBuffer.Envelope;
                        break;
                }

                MapAnalysis.SelectMapFeaturesByGeometryQuery(m_mapControl.ActiveView, selectedlayer, pGeometry);
 
            }



        }

        private void �򿪹����ĵ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void opentest_Click(object sender, EventArgs e) ///////�򿪵�ͼ�ĵ�
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Title = "���ĵ�";
            ofg.Filter = "mxd�ĵ�|*.mxd";
            ofg.Multiselect = false;
            if (ofg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strFileName = ofg.FileName;
                m_mapControl.LoadMxFile(strFileName);
            }
            else
            {
                MessageBox.Show("��Ч·����");
                return;
            }
        }

        private void �̶�ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuZoomOutF_Click(object sender, EventArgs e)
        {
           // ICommand command = new ControlsMapZoomOutFixedCommandClass();
            //command.OnCreate(m_mapControl.Object);
            //command.OnClick();
            m_mapControl.CurrentTool = null;       //����
            m_mapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;    //����
            IEnvelope pEnv = null;                //����������
            pEnv = m_mapControl.Extent;           //����mapcontrol��ǰ��extent
            pEnv.Expand(2.0, 2.0, true);     //��С���� ��������extent��С
            m_mapControl.Extent = pEnv;           
            m_mapControl.ActiveView.Refresh();     //������ʾ

        }

        private void mnuRecZoomOut_Click(object sender, EventArgs e)
        {
            IEnvelope pEnvelope;
            pEnvelope = m_mapControl.TrackRectangle();
            if (pEnvelope == null || pEnvelope.IsEmpty || pEnvelope.Height == 0 || pEnvelope.Width == 0)
            {
                return;
            }//����ΧΪ�����˳�
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
            openFileDialog.Title = "��ͼ���ļ�";
            openFileDialog.Filter = "shp�ļ�|*.shp";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string strFullFileName = openFileDialog.FileName;
                string strShortFileName = openFileDialog.SafeFileName;  
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                //System.Diagnostics.Debug.WriteLine(strFileName);//����������в鿴��ȡ���ļ���
                data_operate dataope = new data_operate();
                IFeatureClass fc = dataope.OpenShapeFeatureClass(fileInfo.DirectoryName, strShortFileName);
                AddFeatureLayer(fc, fc.AliasName);
            }

        }    
        //����gdb���click�¼�
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
            
        //��д����featureclass����ͼ�ķ�����
        private void AddFeatureLayer(IFeatureClass featureClass, string layerName)
        {
            IFeatureLayer featureLayer = new FeatureLayerClass();          //ʵ����Ҫ��ͼ�㣻
            featureLayer.FeatureClass = featureClass;                      //ͨ��ͼ�����Ը�ֵ��ͼ�������Ҫ�أ�
            featureLayer.Name = layerName;                                 //������
            ILayer layer = featureLayer as ILayer;                        //ǿ��ת����featurelayer��layer ������������Ҳ�ǲ�֪��������
            m_mapControl.Map.AddLayer(layer);                              //ֻҪ֪����Ϊ�˺Ϸ��Ĵ�������ȥ��ֻ����תΪlayer��һ��ֻΪ�Ϸ������������ǺǺ�

        }
        //toc����Ҽ�������Ӧ�¼����Լ��Բ�ͬĿ��ĵ�����ʾ����
        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 1) return;
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;                     //????ö�����Ͳ���ֱ�ӣ�����
            IBasicMap map = null;
            object other = null;
            object index = null;
            axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref m_tocLayer, ref other, ref index);
            if (item == esriTOCControlItem.esriTOCControlItemMap)       //��ͼ�Ҽ�ѡ��
            {
                cms_adddata.Visible = true;
                cms_openattri.Visible = false;
                cms_remove.Visible = false;
                cms_zoom.Visible = false;
                cms_symbology.Visible = false;
            }
            else if (item == esriTOCControlItem.esriTOCControlItemLayer)  //ͼ���Ҽ�ѡ��
            {
                cms_adddata.Visible = false;
                cms_openattri.Visible = true;
                cms_remove.Visible = true;
                cms_zoom.Visible = true;
                cms_symbology.Visible = true;    //��դ��ʸ����
            }
            contextMenuStrip1.Show(axTOCControl1, e.x, e.y);            //��ʾ����

        }
        //�Ҽ��˵������Ա�click�¼�
        private void cms_openattri_Click(object sender, EventArgs e)
        { 
           
            if (m_tocLayer != null)        //  ͼ����������ѡ�еģ���
            {
                IFeatureLayer feaLyr = m_tocLayer as IFeatureLayer;  //�ӿ�ת��
                IFeatureClass feaCls = feaLyr.FeatureClass;
                data_operate dataope = new data_operate();
                FormOpenAttri frm = new FormOpenAttri(feaLyr, true);
                frm.Show();

            }
        }
        //�Ҽ��˵���������
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



        /////04/08�ָ��ߡ���������������������������������������������������������������������������������������


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
            //sfd.Title = "�½�shape_point�ļ�";
            //sfd.Filter = "shape�ļ�|*.shp";
            //if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    string strFullFileName = sfd.FileName;
            //    FileInfo fileinfo = new FileInfo(sfd.FileName);   //fileinfo�����þ��Ǵ���������ļ����ƣ�����֮�����ͨ��fileinfoʵ����������ȡ·��Ŀ¼�����ļ���
            //    data_operate dop = new data_operate();
            //    //IFeatureClass fc = dop.CreateShapefile(fileinfo.DirectoryName, fileinfo.Name, m_mapControl.Map.SpatialReference); 
            
        }

        private void mnuCreateGDB_Click(object sender, EventArgs e)
        {
            data_operate DOP = new data_operate();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "ѡ��GDB�ļ�����·��";
            saveFileDialog.Filter = "DGB�ļ�|*.gdb";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileinfo = new FileInfo(saveFileDialog.FileName);
                DOP.CreateGDB(fileinfo.DirectoryName, fileinfo.Name);
            }
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            if (btnAddPoint.Checked) //������������if���д����ò�Ƶ㵽Ϊֹ
            {
                btnAddPoint.Checked = false;
            }
            else
            {
                if (comboEditLayers.SelectedIndex == -1)
                {
                    MessageBox.Show("��ѡ��һ��ͼ�㣡");
                    return;
                }
                data_operate dop = new data_operate();
                ILayer layer = dop.GetLayerByName(m_mapControl.Map, comboEditLayers.SelectedItem.ToString());   //�����õ�combo���ͼ����Ϊ���ж�ͼ��Ҫ������
                IFeatureLayer fealyr = layer as IFeatureLayer;    //IFeatureLayer��ilayer
                if (fealyr.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint)
                {
                    MessageBox.Show("��ѡ����ӵ����͵�ͼ��!");
                    return;
                }
                if (MessageBox.Show("�Ƿ����Ҫ�أ�", "����", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnAddPoint.Checked = true;
                }
            }
        }
        private void GetAllFeatureLayers()                  //��Ҫд��mainform��ĺ����������ܽ�һ�£�һ�����¼���Ӧ������һ����combo�ؼ�item����¼�
        {
            comboEditLayers.Items.Clear();
            ILayer layer;                //���ݲ�������
            for (int i = 0; i < m_mapControl.LayerCount; i++)    //����.layercount������ԣ�����mapcontrol��ʾ�Ļ���toc���ؽ����ģ����￴����toc���ؽ�����
            {
                layer = m_mapControl.get_Layer(i);
                IFeatureLayer fealyr = (IFeatureLayer)layer;
                if(fealyr.FeatureClass.FeatureType != esriFeatureType.esriFTRasterCatalogItem )
                    comboEditLayers.Items.Add(layer.Name);         //�ж��Ƿ�Ϊդ��
            }
            if (comboEditLayers.Items.Count > 0)
            {
                comboEditLayers.SelectedIndex = 0;       //�������֪��selectedindexΪ-1��comboΪ�յ���˼���ǿջ���ûѡ��
            }

        }

        private void btnAddPolyline_Click(object sender, EventArgs e)
        {
            if (btnAddPolyline.Checked) //������������if���д����ò�Ƶ㵽Ϊֹ
            {
                btnAddPolyline.Checked = false;
            }
            else
            {
                if (comboEditLayers.SelectedIndex == -1)
                {
                    MessageBox.Show("��ѡ��һ��ͼ�㣡");
                    return;
                }
                data_operate dop = new data_operate();
                ILayer layer = dop.GetLayerByName(m_mapControl.Map, comboEditLayers.SelectedItem.ToString());   //�����õ�combo���ͼ����Ϊ���ж�ͼ��Ҫ������
                IFeatureLayer fealyr = layer as IFeatureLayer;    //IFeatureLayer��ilayer
                if (fealyr.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolyline)
                {
                    MessageBox.Show("��ѡ����������͵�ͼ��!");
                    return;
                }
                if (MessageBox.Show("�Ƿ����Ҫ�أ�", "����", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnAddPolyline.Checked = true;
                }
            }
        }

        private void btnAddPolygon_Click(object sender, EventArgs e)
        {
            if (btnAddPolygon.Checked) //������������if���д����ò�Ƶ㵽Ϊֹ
            {
                btnAddPolygon.Checked = false;
            }
            else
            {
                if (comboEditLayers.SelectedIndex == -1)
                {
                    MessageBox.Show("��ѡ��һ��ͼ�㣡");
                    return;
                }
                data_operate dop = new data_operate();
                ILayer layer = dop.GetLayerByName(m_mapControl.Map, comboEditLayers.SelectedItem.ToString());   //�����õ�combo���ͼ����Ϊ���ж�ͼ��Ҫ������
                IFeatureLayer fealyr = layer as IFeatureLayer;    //IFeatureLayer��ilayer
                if (fealyr.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolygon)
                {
                    MessageBox.Show("��ѡ����������͵�ͼ��!");
                    return;
                }
                if (MessageBox.Show("�Ƿ����Ҫ�أ�", "����", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                //һЩҪ�ز���������ͼ������Ͻ��У������㷽������
                IPolyline final = dop.GetPolylineGeometry(pointColl);
                dop.AddFeature(fealyr, final);           //ע�⴫��Ҫ��Ϊͼ��Ҫ�ؼ�
                m_mapControl.ActiveView.Refresh();
            }
            if (btnAddPolygon.Checked && comboEditLayers.SelectedIndex != -1)
            {
                data_operate dop = new data_operate();
                ILayer layer = dop.GetLayerByName(m_mapControl.Map, comboEditLayers.SelectedItem.ToString());
                IFeatureLayer fealyr = layer as IFeatureLayer;
                //һЩҪ�ز���������ͼ������Ͻ��У������㷽������ 
                IPolygon final = dop.GetPolygonGeomery(pointColl);
                dop.AddFeature(fealyr, final);           //ע�⴫��Ҫ��Ϊͼ��Ҫ�ؼ� 
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

        private void ��ͼToolStripMenuItem_Click(object sender, EventArgs e)
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
            //m_mapControl.Extent//ת���������÷�Χ�Ľӿ�
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

        //ȫд��main��������05/07

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
                MessageBox.Show("��ѡ��һ��ͼ�㣡");
                return;
            }
            //ȡ��ѡ�񱾰�ť
            if (btnselec_point.Checked)
            {
                btnselec_point.Checked = false;
                flagSelect = 0;
            }
            else
            {
                //�������й��߰�ť��Checked״̬
                ResetToolControlStatus();//�����������Լ����壬��������CheckedΪfalse
                //��ѡ��ť����
                btnselec_point.Checked = true;
                flagSelect = 1;
            }    

        }

        private void btnselec_rec_Click(object sender, EventArgs e)
        {
            if (comboEditLayers.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��һ��ͼ�㣡");
                return;
            }
            //ȡ��ѡ�񱾰�ť
            if (btnselec_rec.Checked)
            {
                btnselec_rec.Checked = false;
                flagSelect = 0;
            }
            else
            {
                //�������й��߰�ť��Checked״̬
                ResetToolControlStatus();//�����������Լ����壬��������CheckedΪfalse
                //��ѡ��ť����
                btnselec_rec.Checked = true;
                flagSelect = 2;
            }    
        }

        private void toolselec_poly_Click(object sender, EventArgs e)
        {
            if (comboEditLayers.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��һ��ͼ�㣡");
                return;
            }
            //ȡ��ѡ�񱾰�ť
            if (toolselec_poly.Checked)
            {
                toolselec_poly.Checked = false;
                flagSelect = 0;
            }
            else
            {
                //�������й��߰�ť��Checked״̬
                ResetToolControlStatus();//�����������Լ����壬��������CheckedΪfalse
                //��ѡ��ť����
                toolselec_poly.Checked = true;
                flagSelect = 3;
            }    
        }

        private void ��ѡ��ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuBuffer_Click(object sender, EventArgs e)
        {

        }

        private void �ռ����ݿ�����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }





    }  
}