using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WFA_generador_codigo
{
    public partial class Formulario_estilos : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection conexion;

        public class RequerimientoProveedor
        {
            public string proveedor { get; set; }
            public string producto { get; set; }
            public decimal cantidad { get; set; }
            public decimal costo { get; set; }
            public decimal importe { get; set; }
        }

        public class ConsumoEstilo
        {
            public string estilo { get; set; }
            public decimal pares { get; set; }
            public string productos { get; set; }
            public decimal consumo_par { get; set; }
            public decimal total_consumo { get; set; }
        }

        public Formulario_estilos()
        {
            InitializeComponent();
            conexion = new SqlConnection("server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+");
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                conexion.Open();
                CargarRequerimientosProveedores();
                CargarConsumosEstilo();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error");
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }

        private void CargarRequerimientosProveedores()
        {
            try
            {
                DataTable datos = Modulo.EjecutarProcedimientoAlmacenado("[db_accessadmin].[usp_reporte_proveedor]");
                var requerimientos = new List<RequerimientoProveedor>();
                requerimientos = Modulo.DataTableToList<RequerimientoProveedor>(datos);

                requerido_proveedores.DataSource = requerimientos;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar requerimientos de proveedores: {ex.Message}", "Error");
            }
        }

        public void CargarConsumosEstilo()
        {
            try
            {
                DataTable datos = Modulo.EjecutarProcedimientoAlmacenado("[db_accessadmin].[usp_reporte_estilos]");
                var consumos = new List<ConsumoEstilo>();
                consumos = Modulo.DataTableToList<ConsumoEstilo>(datos);
                consumo_estilo.DataSource = consumos;
                gridView1.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar consumos por estilo: {ex.Message}", "Error");
            }
        }
       
    }
}