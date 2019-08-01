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
    public partial class selcet_gdb : Form
    {
        public string SelectedGDBPath;
        public List<string> seletedFCAttr = new List<string>();

        public selcet_gdb()
        {
            InitializeComponent();
        }
        //既然只是为了获取文件名的列表，不用工作空间也行吧？。。（对esri接口功能不熟悉不了解）
        private void btn_save_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)                           //傻逼问题自己想清楚了
            {
                string strPath = fbd.SelectedPath;
                text_path.Text = fbd.SelectedPath;
                IWorkspaceFactory pWksFactory = new FileGDBWorkspaceFactory();
                IWorkspace pWorkspace = pWksFactory.OpenFromFile(strPath, 0);      //这里不是读取过了吗？？已经读进来还要加加载的操作吗？注意只是打开，你看shapefile的这步之后还要转换接口，引用接口的OpenFeatureClass（）方法，可以理解为只是定义了工作空间的路径
                IEnumDataset pEnumDS = pWorkspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
                pEnumDS.Reset();
                while (pEnumDS.Next() != null)       //?
                {
                    IDataset dataset = pEnumDS.Next();
                    string strName = dataset.Name;
                    listV_path.Items.Add(strName);
                }
            }  
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            SelectedGDBPath = text_path.Text;                                //是局部变量的问题，但是怎么感觉有些是能跨着用的？嗯错觉
            for (int i = 0; i < listV_path.SelectedItems.Count; i++)
            {
                string strName = listV_path.SelectedItems[i].Text;
                seletedFCAttr.Add(strName);
            }
        }
    }
}
