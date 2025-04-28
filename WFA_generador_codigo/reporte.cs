using System;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace WFA_generador_codigo
{
    public partial class reporte : DevExpress.XtraReports.UI.XtraReport
    {
       
        public reporte()
        {
            InitializeComponent();
             CargarDatos();
        }
        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection("server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+"))
                {
                    string query = "SELECT id, descripcion, id_tipo_articulo, costo, precio FROM articulos";
                    SqlDataAdapter da = new SqlDataAdapter(query, conexion);

                    dataSet1.Clear();

                    da.Fill(dataSet1, "Table1");
                    this.DataSource = dataSet1;
                    this.DataMember = "Table1";

                    xrLabel9.DataBindings["Text"].FormatString = "{0:C2}";
                    xrLabel10.DataBindings["Text"].FormatString = "{0:C2}";
                    this.CreateDocument();
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }
    }
}