using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
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
    public partial class Createshapefile : Form
    {
        string shppath,shptype;
        public ISpatialReference Ref_relay;
        
        public Createshapefile()
        {
            InitializeComponent();
            
            
        }
        
        private void btn_path_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存shapefile文件";
            saveFileDialog.Filter = "shape文件|*.shp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                shppath = saveFileDialog.FileName; 
                text_path.Text = saveFileDialog.FileName;           //
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            FileInfo fileinfo = new FileInfo(shppath);
            data_operate dop = new data_operate();
            IFeatureClass fc = dop.CreateShapefile(fileinfo.DirectoryName, fileinfo.Name,Ref_relay,combo_type.SelectedItem.ToString()); 
        }
        
    }
}
