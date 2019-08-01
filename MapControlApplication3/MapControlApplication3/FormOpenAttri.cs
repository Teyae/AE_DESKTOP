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
    public partial class FormOpenAttri : Form
    {
        public DataTable DtSource;     //数据源属性
        public IFeatureLayer m_featLayer;
        public bool m_bAllRecords;
        int totalCount;
        int selectedCount;

        public FormOpenAttri(IFeatureLayer featLyr, bool IsAll)
        {
            m_featLayer = featLyr;
            m_bAllRecords = IsAll;
            InitializeComponent();
        }

        private void FormOpenAttri_Load(object sender, EventArgs e)
        {
            if (m_bAllRecords)
            {
                btnSelectedFeature.Checked = false;
                btnAllFeature.Checked = true;
            }
            else
            {
                btnSelectedFeature.Checked = true;
                btnAllFeature.Checked = false;
            }
            if (m_featLayer != null)
            {
                IFeatureSelection featSelection = m_featLayer as IFeatureSelection;
                data_operate dop = new data_operate();
                DataTable dt = dop.OpenAttrubutionTable(m_featLayer, m_bAllRecords);
                dataGridView1.DataSource = dt;

                totalCount = m_featLayer.FeatureClass.FeatureCount(null);
                selectedCount = featSelection.SelectionSet.Count;
                lblCount.Text = string.Format("(共{0}条记录，选中{1}条)", totalCount, selectedCount);
                this.Text = "图层属性表（" + m_featLayer.Name + "）";
            }
        }

        private void btnAllFeature_Click(object sender, EventArgs e)
        {
            if (m_featLayer != null)
            {
                data_operate dop = new data_operate();
                DataTable dt = dop.OpenAttrubutionTable(m_featLayer, true);
                dataGridView1.DataSource = dt;
                btnAllFeature.Checked = true;
                btnSelectedFeature.Checked = false;
            }
        }

        private void btnSelectedFeature_Click(object sender, EventArgs e)
        {
            if (m_featLayer != null)
            {
                data_operate dop = new data_operate();
                DataTable dt = dop.OpenAttrubutionTable(m_featLayer, false);
                dataGridView1.DataSource = dt;
                btnAllFeature.Checked = false;
                btnSelectedFeature.Checked = true;
            }
        }
    }
}
