using System;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace WFA_generador_codigo
{
    public partial class asistencias : DevExpress.XtraEditors.XtraUserControl
    {
        public asistencias()
        {
            InitializeComponent();
        }

        public void CargarDatos(int status)
        {
            try
            {
                string cadenaConexion = "server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+";

                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    SqlCommand comando = new SqlCommand("usp_mostrar_asistencias_status", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@status", status);

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    gridControl1.DataSource = tabla;
                    gridView1.PopulateColumns();
                    gridView1.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        public void ActualizarLabelStatus(int statusActual)
        {
            switch (statusActual)
            {
                case 1:
                    Status.Text = "ASISTENCIA";
                    break;
                case 2:
                    Status.Text = "RETARDO";
                    break;
                case 3:
                    Status.Text = "FALTA";
                    break;
                case 4:
                    Status.Text = "ASISTENCIA PARCIAL";
                    break;
                default:
                    Status.Text = "Estatus";
                    break;
            }
            Status.Refresh();
        }
    }
}