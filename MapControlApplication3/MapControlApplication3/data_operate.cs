using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
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

namespace MapControlApplication3
{
    class data_operate
    {
        //编写读取shapefile数据的方法：
        public IFeatureClass OpenShapeFeatureClass(string shpPath, string shpName)
        {
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(shpPath, 0);       //调用工厂的方法；
            IFeatureWorkspace shpWorkspace = (IFeatureWorkspace)workspace;          //强制转换接口；
            IFeatureClass featureClass = shpWorkspace.OpenFeatureClass(shpName);    //声明一个要素类对象，调用工作空间的方法打开要素并赋值，传入参数为文件名
            return featureClass;
        }
 
        //读取geodatabase数据的方法
        public IFeatureClass OpenGDBFeatureClass(string dbPath, string clsName)
        {
            IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(dbPath, 0);
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace;
            IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(clsName);
            return featureClass;
        }

        //两种数据类型差在一个是shapefileworkspacefactory,一个是fileGDBworkspacefactory
        public DataTable OpenAttrubutionTable(IFeatureLayer featLyr,bool bAllRecords)
        {
            IFeatureClass feaCls = featLyr.FeatureClass;
            //先把表的结构弄好！！！
            //一个要素相当于属性表的一行，则创建一个新的数据行
            DataTable dt = new DataTable();
            for (int i = 0; i < feaCls.Fields.FieldCount; i++)
            {
                string strFieldName = feaCls.Fields.get_Field(i).Name;
                dt.Columns.Add(new DataColumn(strFieldName));

            }
            string strGeoType = "未知";
            if (feaCls.ShapeType == esriGeometryType.esriGeometryPolygon)
            {
                strGeoType = "面";
            }
            if (feaCls.ShapeType == esriGeometryType.esriGeometryLine)
            {
                strGeoType = "线";
            }
            if (feaCls.ShapeType == esriGeometryType.esriGeometryPoint)
            {
                strGeoType = "点";
            }
            //得到一个可以便利所有feature的游标
            IFeatureCursor featCursor = null;
            if (bAllRecords)
            {
                //若为所有要素的，则在要素类的基础上进行过滤查询，查询条件无
                featCursor = feaCls.Search(null, false);
            }
            else
            {
                //若为选择要素，则得到选择要素集
                IFeatureSelection featureSelection = featLyr as IFeatureSelection;
                ISelectionSet selectionSet = featureSelection.SelectionSet;
                //在选择要素集的基础上查询过滤，查询条件无，得到游标ICursor
                ICursor cursor = null;
                selectionSet.Search(null, false, out cursor);
                //转化为IFeatureCursor
                featCursor = cursor as IFeatureCursor;
            }
            IFeature feature = featCursor.NextFeature();             //先获取第一个
            //如果游标读取到要素，则进入循环
            while (feature != null)
            {
                DataRow dr = dt.NewRow();
                //循环遍历每个要素的所有字段
                for (int j = 0; j < feaCls.Fields.FieldCount; j++)
                {
                    if (feature.Fields.get_Field(j).Type == esriFieldType.esriFieldTypeGeometry)
                        dr[j] = strGeoType;
                    else
                    {
                        object o = feature.get_Value(j);
                        dr[j] = o.ToString();
                    }
                }
                //将上述数据行加到表格的行集合里面
                dt.Rows.Add(dr);
                //移动游标，读取下一个要素
                feature = featCursor.NextFeature();
            }
            return dt;
            //两个type
        }
        

        //创建shapefile
        public IFeatureClass CreateShapefile(string shpPath, string shpName, ISpatialReference shpRef,string shpType)///////////模式
        {
            IFeatureClass feaCls = null;////////模式
            IFields fields = new Fields();
            IFieldsEdit fieldsEdit = fields as IFieldsEdit;
            IField field = new Field();                               //
            IFieldEdit fieldEdit = field as IFieldEdit;//

            fieldEdit.Name_2 = "OID";                             //遵守规定。。。但是都有？？？
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;//
            fieldsEdit.AddField(field);//

            fieldEdit = new FieldClass();
            fieldEdit.Name_2 = "NAME";                             //遵守规定。。。但是都有？？？
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            fieldsEdit.AddField(fieldEdit as IField);

            //定义一个图形shape字段，
            //先给出几何图形的定义，包括设置图形类型和空间参考
            IGeometryDefEdit geoDefEdit = new GeometryDefClass();
            if (shpType == "point")
            {
                geoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
            }
            if (shpType == "polyline")
            {
                geoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryLine;
            }
            if (shpType == "polygon")
            {
                geoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
            }
            geoDefEdit.SpatialReference_2 = shpRef;               //几何类型有空间参考属性
            fieldEdit = new FieldClass();
            fieldEdit.Name_2 = "Shape";                             //遵守规定。。。但是都有？？？
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;      //图形参考在这里定义 ,要说明几何类型
            fieldEdit.GeometryDef_2 = geoDefEdit as IGeometryDef;//////!重头戏！真有趣啊      因为是几何类型，所以在字段编辑的属性再加上几何ref

            fieldsEdit.AddField(fieldEdit as IField);


            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(shpPath, 0);       //调用工厂的方法；
            IFeatureWorkspace shpWorkspace = (IFeatureWorkspace)workspace;
            feaCls = shpWorkspace.CreateFeatureClass(shpName, fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");     //此处发现更替路径创建会报错
            
            return feaCls;//////////////模式
        }
        //创建GDB
        public IWorkspace CreateGDB(string gdbPath, string gdbName)
        {
            IPropertySet ps = new PropertySetClass();
            ps.SetProperty("DATABASE",gdbPath);
            IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactory();
            IWorkspaceName newWorkspacename = workspaceFactory.Create(gdbPath,gdbName,ps,0);
            IName name = (IName)newWorkspacename;
            IWorkspace newWorkspace = (IWorkspace)name.Open();
            return newWorkspace;

        }


        ////04/16---------------------------------------
        public ILayer GetLayerByName(IMap map, string layername)
        {
            ILayer lyr = null;
            if (map == null || layername == "")
                return null;                      //其实这个判断也有点多余，对于相关的用到的操作来说，但是加上后显得更加规范不是吗？？
            for (int i = 0; i < map.LayerCount; i++)    //这里是一个一个遍历过去，但肯定有其他方法的，立个flag
            {
                if (map.get_Layer(i).Name == layername)
                {
                    lyr = map.get_Layer(i);
                    return lyr;             //这个if语句里也需要return吗？不写会怎么样？
                }
 
            }
                return lyr;
 
        }
        public void AddFeature(IFeatureLayer fealyr, IGeometry geometry)
        {
            IFeatureClass featurecls = fealyr.FeatureClass;
            if (featurecls.ShapeType != geometry.GeometryType)
                return;                                           //这个if语句也是迷

            IDataset dataset = featurecls as IDataset;
            IWorkspace workspace = dataset.Workspace;
            IWorkspaceEdit workspaceEdit = workspace as IWorkspaceEdit;
            workspaceEdit.StartEditing(true);
            workspaceEdit.StartEditOperation();

            IFeatureBuffer featurebuffer = featurecls.CreateFeatureBuffer();
            featurebuffer.Shape = geometry;                ///实锤

            ////以下代码为测试设置其他字段值
            //int index = featureBuffer.Fields.FindField("Name");
            //featureBuffer.set_Value(index, "测试点");
            IFeatureCursor featurecusor = featurecls.Insert(true);
            featurecusor.InsertFeature(featurebuffer);
            featurecusor.Flush();

            workspaceEdit.StopEditOperation();
            workspaceEdit.StopEditing(true);            //C#庐山真面目，让你感觉到可以这样写
        }
        public IPolyline GetPolylineGeometry(IPointCollection IPC)
        {
            IPolyline polyline = null;
            polyline = IPC as IPolyline;
            return polyline;
        }
        //public IPolygon GetPolygonGeomery(IPointCollection ipc)
        //{

        //    IGeometryCollection polygon = new PolygonClass();
        //    IPolyline polyline = ipc as IPolyline;
        //    ILine repolyline = new LineClass();
        //    repolyline.PutCoords(polyline.FromPoint, polyline.ToPoint);
        //    ISegment segment = repolyline as ISegment;
        //    ISegmentCollection psc = new RingClass();
        //    psc.AddSegment(segment);
        //    IRing pring = psc as IRing;
        //    pring.Close();
        //    polygon.AddGeometry(pring);
        //    IPolygon finalpolygon = polygon as IPolygon;
        //    return finalpolygon;
            
        //}
        public IPolygon GetPolygonGeomery(IPointCollection ipc)
        {
            IPolyline polyline = null;
            polyline = ipc as IPolyline;
            IRing pring = polyline as IRing;
            pring.Close();
            IPolygon polygon = pring as IPolygon;
            return polygon;
        }



        public List<IFeatureClass> getAllFeatClsFromGDB(IWorkspace workspace)
        {
            IFeatureWorkspace pFeatureWorkspace = workspace as IFeatureWorkspace;
            IEnumDataset pEnumDataset = workspace.get_Datasets(esriDatasetType.esriDTAny);
            //获取pworkspace目录下根目录的dataset
            pEnumDataset.Reset();
            List<IFeatureClass> featClsList = new List<IFeatureClass>();
            //获取dataset
            IDataset pDataset;
            while ((pDataset = pEnumDataset.Next()) != null)
            {
                if (pDataset is IFeatureDataset)
                {
                    IEnumDataset enuemData = pDataset.Subsets;
                    IDataset pDataset2;
                    while ((pDataset2 = enuemData.Next()) != null)
                    {
                        IFeatureClass featCls = pDataset2 as IFeatureClass;
                        featClsList.Add(featCls);
                    }

                }
                else if (pDataset is IFeatureClass)
                {
                    IFeatureClass pFC = pDataset as IFeatureClass;
                    featClsList.Add(pFC);
                }
            }
            return featClsList;
        }


           ////04/30不知咋地落了一块内容，感觉头秃了一块一样，shit

    }
}
