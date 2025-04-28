using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;

namespace WFA_generador_codigo
{
    public partial class Formulario_dashboard : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection conexion;

        public Formulario_dashboard()
        {
            InitializeComponent();

            conexion = new SqlConnection("server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+");

            dashboardViewer1.ConfigureDataConnection += DashViewer_ConfigureDataConnection;

            this.Load += Formulario_dashboard_Load;
        }

        private void DashViewer_ConfigureDataConnection(object sender, DashboardConfigureDataConnectionEventArgs e)
        {
            MsSqlConnectionParameters parameters = e.ConnectionParameters as MsSqlConnectionParameters;
            if (parameters != null)
            {
                parameters.UserName = "programador02";
                parameters.Password = "s0p0rt31+";
                parameters.ServerName = "192.168.22.146";
                parameters.DatabaseName = "programador02";
            }
        }

        private void Formulario_dashboard_Load(object sender, EventArgs e)
        {
            try
            {

                Dashboard dashboard = new Dashboard();
                string strDashSeleccionado = "C:\\Users\\PROGRAMADOR02\\Documents\\dash_ventas_titulos.xml";
                dashboard.LoadFromXml(strDashSeleccionado);

                dashboardViewer1.Dashboard = dashboard;

                dashboardViewer1.ReloadData();

                Dashboard dashboard2 = new Dashboard();
                string strDashSeleccionado2 = "C:\\Users\\PROGRAMADOR02\\Documents\\dash_estilos_requerimiento.xml";
                dashboard2.LoadFromXml(strDashSeleccionado2);

                dashboardViewer2.Dashboard = dashboard2;

                dashboardViewer2.ReloadData();


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar el dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            formulario_dash form_dash = new formulario_dash();
            form_dash.Show();
        }
    }
}