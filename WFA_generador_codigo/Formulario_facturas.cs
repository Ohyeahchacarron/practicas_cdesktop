using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using System.Linq;
using System.Drawing;

namespace WFA_generador_codigo
{
    public partial class Formulario_facturas : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection conexion;

        public class Factura
        {
            public int id { get; set; }
            public string folio { get; set; }
            public DateTime fecha { get; set; }
            public bool pagado { get; set; }
            public string estatus => pagado ? "Pagado" : "Pendiente";
            public List<DetalleFactura> detalles { get; set; } = new List<DetalleFactura>();
        }

        public class Cliente
        {
            public int id_cliente { get; set; }
            public string razon_social { get; set; }
            public decimal credito { get; set; }
            public decimal deuda_total { get; set; }
            public decimal limite_disponible { get; set; }
            public List<Factura> facturas { get; set; } = new List<Factura>();
            public float porcentaje_vencido { get; set; }
            public float porcentaje_deuda { get; set; }
            public float porcentaje_vencido_total { get; set; }
        }

        public class DetalleFactura
        {
            public int id_factura { get; set; }
            public int id_producto { get; set; }
            public decimal precio { get; set; }
            public int cantidad { get; set; }
            public decimal total => precio * cantidad;
        }

        public Formulario_facturas()
        {
            InitializeComponent();
            conexion = new SqlConnection("server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+");
            gridView1.MasterRowExpanded += GridView1_MasterRowExpanded;
            gridView2.MasterRowExpanded += GridView2_MasterRowExpanded;
            CargarDatosClientes();
        }

        private void GridView1_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            try
            {
                GridView masterView = sender as GridView;
                if (masterView != null)
                {
                    GridView detailView = masterView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
                    if (detailView != null)
                    {
                        detailView.Columns["id"].Visible = false;
                        detailView.Columns["pagado"].Visible = false;
                        detailView.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GridView2_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            try
            {
                GridView masterView = sender as GridView;
                if (masterView != null)
                {
                    GridView detailView = masterView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
                    if (detailView != null)
                    {
                        foreach (DevExpress.XtraGrid.Columns.GridColumn column in detailView.Columns)
                        {
                            if (column.FieldName == "id_factura")
                            {
                                column.Visible = false;
                                break;
                            }
                        }

                        detailView.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al expandir: {ex.Message}", "Error");
            }
        }

        private void GridView3_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            try
            {
                GridView masterView = sender as GridView;
                if (masterView != null)
                {
                    GridView detailView = masterView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
                    if (detailView != null)
                    {
                        detailView.Columns["id_factura"].Visible = false;
                        detailView.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }
        private void CargarDatosClientes()
        {
            try
            {
                List<Cliente> listaClientes = new List<Cliente>();
                conexion.Open();

                string queryClientes = "EXEC CalcularDeudaClientes";

                using (var cmdClientes = new SqlCommand(queryClientes, conexion))
                using (var readerClientes = cmdClientes.ExecuteReader())
                {
                    while (readerClientes.Read())
                    {
                        listaClientes.Add(new Cliente
                        {
                            id_cliente = readerClientes.IsDBNull(0) ? 0 : readerClientes.GetInt32(0),
                            razon_social = readerClientes.IsDBNull(1) ? string.Empty : readerClientes.GetString(1),
                            credito = readerClientes.IsDBNull(2) ? 0m : readerClientes.GetDecimal(2),
                            deuda_total = readerClientes.IsDBNull(3) ? 0m : readerClientes.GetDecimal(3),
                            limite_disponible = readerClientes.IsDBNull(4) ? 0m : readerClientes.GetDecimal(4),
                            porcentaje_vencido = 0,
                            porcentaje_deuda = 0,
                            porcentaje_vencido_total = 0
                        });
                    }
                }

                string queryPorcentajeVencidoTotal = "EXEC db_accessadmin.CalcularPorcentajeVencidoTotal";

                using (var cmdPorcentajeVencidoTotal = new SqlCommand(queryPorcentajeVencidoTotal, conexion))
                using (var readerPorcentajeVencidoTotal = cmdPorcentajeVencidoTotal.ExecuteReader())
                {
                    while (readerPorcentajeVencidoTotal.Read())
                    {
                        int idCliente = readerPorcentajeVencidoTotal.IsDBNull(0) ? 0 : readerPorcentajeVencidoTotal.GetInt32(0);
                        float porcentaje = readerPorcentajeVencidoTotal.IsDBNull(2) ? 0 : Convert.ToSingle(readerPorcentajeVencidoTotal[2]);

                        var cliente = listaClientes.FirstOrDefault(c => c.id_cliente == idCliente);
                        if (cliente != null)
                        {
                            cliente.porcentaje_vencido_total = porcentaje;
                        }
                    }
                }

                string queryPorcentajes = "EXEC db_accessadmin.CalcularPorcentajeVencido";

                using (var cmdPorcentajes = new SqlCommand(queryPorcentajes, conexion))
                using (var readerPorcentajes = cmdPorcentajes.ExecuteReader())
                {
                    while (readerPorcentajes.Read())
                    {
                        int idCliente = readerPorcentajes.IsDBNull(0) ? 0 : readerPorcentajes.GetInt32(0);
                        float porcentaje = readerPorcentajes.IsDBNull(2) ? 0 : Convert.ToSingle(readerPorcentajes[2]);

                        var cliente = listaClientes.FirstOrDefault(c => c.id_cliente == idCliente);
                        if (cliente != null)
                        {
                            cliente.porcentaje_vencido = porcentaje;
                        }
                    }
                }

                string queryPorcentajeDeuda = "EXEC db_accessadmin.CalcularPorcentajeDeuda";

                using (var cmdPorcentajeDeuda = new SqlCommand(queryPorcentajeDeuda, conexion))
                using (var readerPorcentajeDeuda = cmdPorcentajeDeuda.ExecuteReader())
                {
                    while (readerPorcentajeDeuda.Read())
                    {
                        int idCliente = readerPorcentajeDeuda.IsDBNull(0) ? 0 : readerPorcentajeDeuda.GetInt32(0);
                        float porcentaje = readerPorcentajeDeuda.IsDBNull(2) ? 0 : Convert.ToSingle(readerPorcentajeDeuda[2]);

                        var cliente = listaClientes.FirstOrDefault(c => c.id_cliente == idCliente);
                        if (cliente != null)
                        {
                            cliente.porcentaje_deuda = porcentaje;
                        }
                    }
                }

                string queryFacturas = "SELECT [id], [folio], [fecha], [pagada] as pagado FROM [programador02].[db_accessadmin].[facturas] WHERE [id_cliente] = @idCliente";

                foreach (var cliente in listaClientes)
                {
                    using (var cmdFacturas = new SqlCommand(queryFacturas, conexion))
                    {
                        cmdFacturas.Parameters.AddWithValue("@idCliente", cliente.id_cliente);

                        using (var readerFacturas = cmdFacturas.ExecuteReader())
                        {
                            while (readerFacturas.Read())
                            {
                                Factura factura = new Factura
                                {
                                    id = readerFacturas.IsDBNull(0) ? 0 : readerFacturas.GetInt32(0),
                                    folio = readerFacturas.IsDBNull(1) ? string.Empty : readerFacturas.GetString(1),
                                    fecha = readerFacturas.IsDBNull(2) ? DateTime.MinValue : readerFacturas.GetDateTime(2),
                                    pagado = readerFacturas.IsDBNull(3) ? false : readerFacturas.GetBoolean(3)
                                };

                                cliente.facturas.Add(factura);
                            }
                            readerFacturas.Close();
                        }
                    }

                    foreach (var factura in cliente.facturas)
                    {
                        factura.detalles = CargarDetallesFactura(factura.id);
                    }
                }

                gridControl1.DataSource = listaClientes;

                var columnaPorcentajeVencido = gridView1.Columns["porcentaje_vencido"];
                if (columnaPorcentajeVencido != null)
                {
                    var progressBarEdit = new RepositoryItemProgressBar();
                    progressBarEdit.Minimum = 0;
                    progressBarEdit.Maximum = 100;
                    progressBarEdit.ShowTitle = true;
                    columnaPorcentajeVencido.ColumnEdit = progressBarEdit;
                }

                var columnaPorcentajeDeuda = gridView1.Columns["porcentaje_deuda"];
                if (columnaPorcentajeDeuda != null)
                {
                    var progressBarEdit = new RepositoryItemProgressBar();
                    progressBarEdit.Minimum = 0;
                    progressBarEdit.Maximum = 100;
                    progressBarEdit.ShowTitle = true;
                    columnaPorcentajeDeuda.ColumnEdit = progressBarEdit;
                }

                var columnaPorcentajeVencidoTotal = gridView1.Columns["porcentaje_vencido_total"];
                if (columnaPorcentajeVencidoTotal != null)
                {
                    var progressBarEdit = new RepositoryItemProgressBar();
                    progressBarEdit.Name = "barra_vencido_t";
                    progressBarEdit.Minimum = 0;
                    progressBarEdit.Maximum = 100;
                    progressBarEdit.ShowTitle = true;
                    columnaPorcentajeVencidoTotal.ColumnEdit = progressBarEdit;
                }

                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar datos: {ex.Message}", "Error");
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }

        private List<DetalleFactura> CargarDetallesFactura(int idFactura)
        {
            List<DetalleFactura> detalles = new List<DetalleFactura>();

            try
            {
                string queryDetalles = @"
            SELECT fd.id_factura, fd.id_producto, fd.precio, SUM(ft.cantidad) AS cantidad
            FROM facturas_detalle fd
            JOIN facturas_tallas ft ON fd.id = ft.id_factura_detalle
            WHERE fd.id_factura = @idFactura
            GROUP BY fd.id_factura, fd.id_producto, fd.precio";

                using (var cmdDetalles = new SqlCommand(queryDetalles, conexion))
                {
                    cmdDetalles.Parameters.AddWithValue("@idFactura", idFactura);

                    using (var readerDetalles = cmdDetalles.ExecuteReader())
                    {
                        while (readerDetalles.Read())
                        {
                            detalles.Add(new DetalleFactura
                            {
                                id_factura = readerDetalles.GetInt32(0),
                                id_producto = readerDetalles.GetInt32(1),
                                precio = readerDetalles.GetDecimal(2),
                                cantidad = readerDetalles.GetInt32(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error");
            }

            return detalles;
        }

    }
}
