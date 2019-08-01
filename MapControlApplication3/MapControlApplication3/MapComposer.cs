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

namespace MapControlApplication3
{
    class MapComposer
    {
        public static void PointRenderSimply( IFeatureLayer fealyr,IColor pcolor,IColor plinecolor,double size ,double psize,bool useoutline)
        {
            SimpleMarkerSymbol smsc = new SimpleMarkerSymbolClass();
            smsc.Color = pcolor;
            smsc.Outline = useoutline;
            smsc.OutlineColor = plinecolor;
            smsc.Size = size;
            smsc.OutlineSize = psize;
            SimpleRenderer sr = new SimpleRendererClass();
            sr.Symbol = smsc as ISymbol;
            IGeoFeatureLayer geofealyr = fealyr as IGeoFeatureLayer;
            geofealyr.Renderer = sr as IFeatureRenderer;
        }
        public static void PolylineRenderSimply(IFeatureLayer fealyr, IColor lineColor, double lineWidth)
        {
            IMarkerLineSymbol pMarkerLine = new MarkerLineSymbolClass();
            pMarkerLine.Color = lineColor;
            pMarkerLine.Width = lineWidth;
            SimpleRenderer sr = new SimpleRendererClass();
            sr.Symbol = pMarkerLine as ISymbol;
            IGeoFeatureLayer geofealyr = fealyr as IGeoFeatureLayer;
            geofealyr.Renderer = sr as IFeatureRenderer;
        }
        public static void PolygonRenderSimply(IFeatureLayer fealyr, IColor pcolor, IColor plinecolor, double psize)
        {
            ISimpleFillSymbol sfs = new SimpleFillSymbol();
            sfs.Color = pcolor;
            sfs.Outline.Color = plinecolor;
            sfs.Outline.Width = psize;
            SimpleRenderer sr = new SimpleRendererClass();
            sr.Symbol = sfs as ISymbol;
            IGeoFeatureLayer geofealyr = fealyr as IGeoFeatureLayer;
            geofealyr.Renderer = sr as IFeatureRenderer;
        }
        public static void CopyMap(IMap fromMap, IMap toMap)
        {
            IObjectCopy objectCopy = new ObjectCopyClass();
            object copyFromMap = fromMap;
            object copyMap = objectCopy.Copy(copyFromMap);
            object copyToMap = toMap;
            objectCopy.Overwrite(copyMap, ref copyToMap);
        }
        public static IElement AddTitle(IPageLayout pageLayout, String s,IColor color,double angle)
        {
            ITextElement pTextElement = new TextElementClass();
            pTextElement.Text = s;
            ITextSymbol pTextSymbol = new TextSymbolClass();//Text的符号样式
            //pTextSymbol.Size = 30;
            pTextSymbol.Color = color;
            pTextSymbol.Angle = angle;
            pTextSymbol.RightToLeft = false;//文本由左向右排列
            pTextSymbol.VerticalAlignment = esriTextVerticalAlignment.esriTVACenter;//垂直方向基线对齐
            pTextSymbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft;//文本两端对齐
            pTextElement.Symbol = pTextSymbol;

            //设置位置                        
            IElement pElement = pTextElement as IElement;
            return pElement;
            //pElement.Geometry = pageLayout.TrackRectangle();
            //将元素添加到容器中
           // pGraphicsContainer.AddElement(pElement, 0);
         }
    }
}
