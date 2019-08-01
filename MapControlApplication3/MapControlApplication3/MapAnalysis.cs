using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;

namespace MapControlApplication3
{
    class MapAnalysis
    {
        public static void SelectMapFeaturesByAttributeQuery(IActiveView activeView, IFeatureLayer featureLayer, String whereClause)
        {
            if (activeView == null || featureLayer == null || whereClause == null)
            {
                return;
            }
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection; // Dynamic Cast

            // Set up the query
            ESRI.ArcGIS.Geodatabase.IQueryFilter queryFilter = new ESRI.ArcGIS.Geodatabase.QueryFilterClass();
            queryFilter.WhereClause = whereClause;

            // Invalidate only the selection cache. Flag the original selection
            activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection, null, null);

            // Perform the selection
            featureSelection.SelectFeatures(queryFilter, ESRI.ArcGIS.Carto.esriSelectionResultEnum.esriSelectionResultNew, false);

            // Flag the new selection
            activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection, null, null);
        }
        public static void SelectMapFeaturesByGeometryQuery(IActiveView activeView, IFeatureLayer featureLayer, IGeometry geometry)
        {
            if (activeView == null || featureLayer == null || geometry == null)
            {
                return;
            }
            ESRI.ArcGIS.Geodatabase.IFeatureClass pFeatureClass = featureLayer.FeatureClass;
            //空间过滤器
            ESRI.ArcGIS.Geodatabase.ISpatialFilter pSpatialFilter = new ESRI.ArcGIS.Geodatabase.SpatialFilterClass();
            pSpatialFilter.Geometry = geometry;
            //根据图层类型选择缓冲方式
            switch (pFeatureClass.ShapeType)
            {
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryMultipoint:
                    pSpatialFilter.SpatialRel = ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelContains;
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                    pSpatialFilter.SpatialRel = ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelCrosses;
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                    pSpatialFilter.SpatialRel = ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
            }

            //定义空间过滤器的空间字段
            pSpatialFilter.GeometryField = pFeatureClass.ShapeFieldName;
            ESRI.ArcGIS.Geodatabase.IQueryFilter pQueryFilter;
            //利用要素过滤器查询要素
            pQueryFilter = pSpatialFilter as ESRI.ArcGIS.Geodatabase.IQueryFilter;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection; // Dynamic Cast
            // Invalidate only the selection cache. Flag the original selection
            activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection, null, null);

            // Perform the selection
            featureSelection.SelectFeatures(pQueryFilter, ESRI.ArcGIS.Carto.esriSelectionResultEnum.esriSelectionResultNew, false);

            // Flag the new selection
            activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection, null, null);



        }

        public static void BufferAnalysis(IFeatureLayer layer,string path,double radius ,string radius_unit)
        {
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;

            //create a new instance of a buffer tool
            ESRI.ArcGIS.AnalysisTools.Buffer buffer = new ESRI.ArcGIS.AnalysisTools.Buffer(layer, path, Convert.ToString(radius) + " " + radius_unit);

            //ESRI.ArcGIS.AnalysisTools.Buffer buffer = new ESRI.ArcGIS.AnalysisTools.Buffer(layer, this.OutputPath, "100"+" "+"Meters" );
            //以下这些设置，那么选择要素呢？？。。
            buffer.dissolve_option = "ALL";               //这个要设成ALL,否则相交部分不会融合
            buffer.line_side = "FULL";                   //默认是"FULL",最好不要改否则出错
            buffer.line_end_type = "ROUND";                  //默认是"ROUND",最好不要改否则出错

            //execute the buffer tool (very easy :-))
            IGeoProcessorResult results = null;
            try
            {
                results = (IGeoProcessorResult)gp.Execute(buffer, null);
                MessageBox.Show("缓冲区建立成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("缓冲区建立失败！");
               // txtMessages.Text += "Failed to buffer layer: " + layer.Name + "\r\n";
            }
        }


        /////   <summary> 
        /////   得到指定SQL服务器所有数据库的列表 
        /////   </summary> 
        /////   <param   name= "p_strDataBaseList "> 数据库列表 </param> 
        /////   <param   name= "p_strServer "> 服务器名 </param> 
        /////   <param   name= "p_strUser "> 用户名 </param> 
        /////   <param   name= "p_strPWD "> 密码 </param> 
        /////   <returns> </returns> 
        //public static bool GetDataBases(ref   string[] p_strDataBaseList, string p_strServer, string p_strUser, string p_strPWD)
        //{
        //    try
        //    {
        //        int i = 0;

        //        SQLDMO.Application sqlApp = new SQLDMO.ApplicationClass();
        //        SQLDMO.SQLServer srv = new SQLDMO.SQLServerClass();
        //        srv.Connect(p_strServer, p_strUser, p_strPWD);

        //        if (srv.Databases.Count > 0)
        //        {
        //            p_strDataBaseList = new string[srv.Databases.Count];

        //            foreach (SQLDMO.Database db in srv.Databases)
        //            {
        //                if (db.Name != null)
        //                {
        //                    p_strDataBaseList[i] = db.Name;
        //                }
        //                i = i + 1;
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //} 








        // public List<ILayer> GetFeatureLayerList(IMap pMap)         ///代码笔记，
        //{
        //    List<ILayer> myLayers = new List<ILayer>(); 
        //    UID layerFilter = new UIDClass();                               //uid指定获取要素类型
        //    layerFilter.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";       //这段键其实是ifeaturelayer   可查看注册表
        //    IEnumLayer pEnumLayer = pMap.get_Layers(layerFilter, true);
        //        pEnumLayer.Reset();
        //        ILayer pLayer = pEnumLayer.Next();
        //        while (pLayer != null)
        //        {
        //            myLayers.Add(pLayer);
        //            pLayer = pEnumLayer.Next();
        //        }
        //        return myLayers ;
        //}

    }
}
