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
    public partial class Frmdbconnection : Form
    {
        string pinstance, puser, ppassword, pdatabase;
        public Frmdbconnection()
        {
            InitializeComponent();
        }
        public static IWorkspace OpenSdeWorkspaceByPropertySet(string instance, string user, string password, string database)
        {
            IPropertySet Propset = new PropertySetClass();
            Propset.SetProperty("SERVER", "localhost\\SQLEXPRESS");
            Propset.SetProperty("INSTANCE",instance );
            Propset.SetProperty("USER", user);
            Propset.SetProperty("PASSWORD", password);
            Propset.SetProperty("DATABASE", database);
            Propset.SetProperty("VERSION", "SDE.DEFAULT");

            IWorkspaceFactory workspaceFactory = new SdeWorkspaceFactoryClass();
            return workspaceFactory.Open(Propset, 0);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            pinstance = "sde:sqlserver:" + text_instance.Text;
            puser = text_username.Text;
            ppassword = text_password.Text;
            pdatabase = text_database.Text;
            IWorkspace pworkspace = OpenSdeWorkspaceByPropertySet(pinstance, puser, ppassword, pdatabase);
            data_operate dop = new data_operate();
            List<IFeatureClass> featClsList = dop.getAllFeatClsFromGDB(pworkspace);
        }

    }
}
