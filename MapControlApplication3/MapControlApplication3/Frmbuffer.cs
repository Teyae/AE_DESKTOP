using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    public partial class Frmbuffer : Form
    {
        IFeatureLayer feaLyr = null;
        double distance;
        string path;
        string unit;
        private IMap map = null;
        public Frmbuffer(IMap pMap)
        {
            this.map = pMap;
            InitializeComponent();
        }

        private void Frmbuffer_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < map.LayerCount; i++)
            {
                ILayer lyr = map.get_Layer(i);
                combo_layer.Items.Add(lyr.Name);
            }
        }

        private void btn_path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)                           //傻逼问题自己想清楚了
            {
                path = fbd.SelectedPath;
                text_path.Text = fbd.SelectedPath;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (combo_layer.SelectedItem == null)
            {
                MessageBox.Show("没有图层！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (combo_unit.SelectedItem == null || text_dis.Text == null || text_path == null)
            {
                MessageBox.Show("请完善距离、单位、路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            data_operate dop = new data_operate();
            feaLyr = dop.GetLayerByName(map, combo_layer.SelectedItem.ToString()) as IFeatureLayer;
            distance = System.Convert.ToDouble(text_dis.Text);
            unit = combo_unit.SelectedItem.ToString();
            MapAnalysis.BufferAnalysis(feaLyr, path, distance, unit);
        }

    }
}
