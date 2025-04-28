using System;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using System.Drawing;

namespace WFA_generador_codigo
{
    public partial class Reporte_proveedor : DevExpress.XtraReports.UI.XtraReport
    {

        public Reporte_proveedor()
        {
            InitializeComponent();
            ConfigurarGrupos();
            CargarDatos();
            
        }

        private void ConfigurarGrupos()
        {
            GroupField groupField = new GroupField("proveedor");
            GroupHeader1.GroupFields.Add(groupField);
            GroupHeader1.RepeatEveryPage = true;
            xrLabel2.DataBindings.Add("Text", null, "proveedor");

            GroupFooter1.GroupUnion = GroupFooterUnion.WithLastDetail;
            GroupFooter1.PageBreak = PageBreak.None;
            GroupFooter1.PrintAtBottom = true;
            GroupFooter1.HeightF = 30;
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection("server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+"))
                {
                    SqlCommand comando = new SqlCommand("[db_accessadmin].[usp_reporte_proveedor]", conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    dataSet1.Tables["requerido_proveedores"].Clear();
                    da.Fill(dataSet1.Tables["requerido_proveedores"]);

                    this.DataSource = dataSet1;
                    this.DataMember = "requerido_proveedores";
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