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
    public partial class FormSelectByAttr : Form
    {
        IFeatureLayer feaLyr = null;
        private IMap map = null;
        //定义一个带参数的构造函数，pMap为形参,神仙注释 
        public FormSelectByAttr(IMap pMap)
        {
            this.map = pMap;
            InitializeComponent();
        }

        private void FormSelectByAttr_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < map.LayerCount; i++)
            {
                ILayer lyr = map.get_Layer(i);
                combo_layer.Items.Add(lyr.Name);
            }
        }

        private void btn_equal_Click(object sender, EventArgs e)
        {
            textbox_sql.AppendText("=");
        }

        private void btn_and_Click(object sender, EventArgs e)
        {
            textbox_sql.AppendText("And");
        }

        private void btn_gt_Click(object sender, EventArgs e)
        {
            textbox_sql.AppendText(">");
        }

        private void btn_lt_Click(object sender, EventArgs e)
        {
            textbox_sql.AppendText("<");
        }

        private void btn_notequal_Click(object sender, EventArgs e)
        {
            textbox_sql.AppendText("<>");
        }

        private void btn_like_Click(object sender, EventArgs e)
        {
            textbox_sql.AppendText("Like");
        }

        private void btn_or_Click(object sender, EventArgs e)
        {
            textbox_sql.AppendText("Or");
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            textbox_sql.AppendText("*");
        }

        private void btn_null_Click(object sender, EventArgs e)
        {
            textbox_sql.AppendText("''");
        }

        private void listBox_attri_DoubleClick(object sender, EventArgs e)
        {
            string item_double = listBox_attri.SelectedItem.ToString();
            textbox_sql.AppendText(item_double);
        }

        private void combo_layer_SelectedIndexChanged(object sender, EventArgs e)
        {
            data_operate dop = new data_operate();
            feaLyr = (dop.GetLayerByName(map, combo_layer.SelectedItem.ToString())) as IFeatureLayer;
            IFeatureClass feaCls = null;
            if(feaLyr != null)
            {
                feaCls = feaLyr.FeatureClass;
                for (int i = 0; i < feaCls.Fields.FieldCount; i++)
                {
                    string strFieldName = feaCls.Fields.get_Field(i).Name;
                    listBox_attri.Items.Add(strFieldName);
                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            IActiveView map_trans = map as IActiveView;
            MapAnalysis.SelectMapFeaturesByAttributeQuery(map_trans, feaLyr, textbox_sql.Text);
           
        }

    }
}
