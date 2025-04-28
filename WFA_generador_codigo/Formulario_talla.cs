using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using DevExpress.XtraEditors;

namespace WFA_generador_codigo
{
    public partial class Formulario_talla : DevExpress.XtraEditors.XtraForm
    {
        private readonly string _connectionString = "server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+";
        private SqlConnection conexion;

        public Formulario_talla()
        {
            conexion = new SqlConnection("server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+");
            InitializeComponent();
            CargarDatos();

        }

        internal class productos
        {
            public int id_producto { get; set; }
            public int id_talla { get; set; }
            public string descripcion { get; set; }
            public int existencia { get; set; }
        }

        private void CargarDatos()
        {
            try
            {
                if (!(gridControl1.MainView is GridView grvDetalle)) return;
                grvDetalle.Columns.Clear();

                DataTable dt = new DataTable();
                dt.Columns.Add("producto", typeof(string));
                dt.Columns.Add("id_producto", typeof(int));

                using (var conexion = new SqlConnection(_connectionString))
                {
                    conexion.Open();
                    DataTable dtTallas = new DataTable();
                    new SqlDataAdapter("select id, descripcion from tallas order by orden", conexion).Fill(dtTallas);
                    Dictionary<string, string> columnasTallas = dtTallas.AsEnumerable()
                        .ToDictionary(row => $"t-{row["id"]}", row => row["descripcion"].ToString());

                    foreach (var columna in columnasTallas.Keys)
                    {
                        dt.Columns.Add(columna, typeof(int));
                        dt.Columns.Add($"s-{columna.Substring(2)}", typeof(int));
                    }

                    dt.Columns.Add("total", typeof(int));
                    dt.Columns.Add("total_salida", typeof(int));

                    grvDetalle.Columns.Add(new GridColumn
                    {
                        FieldName = "producto",
                        Caption = "Productos",
                        Width = 150,
                        OptionsColumn = { AllowEdit = false },
                        Visible = true,
                        Fixed = FixedStyle.Left
                    });

                    foreach (var col in columnasTallas)
                    {
                        grvDetalle.Columns.Add(new GridColumn
                        {
                            FieldName = col.Key,
                            Caption = col.Value,
                            Width = 60,
                            OptionsColumn = { AllowEdit = false },
                            Visible = true
                        });

                        var salidaColumn = new GridColumn
                        {
                            FieldName = $"s-{col.Key.Substring(2)}",
                            Caption = "Salida",
                            Width = 60,
                            OptionsColumn = { AllowEdit = true },
                            Visible = true
                        };
                        grvDetalle.Columns.Add(salidaColumn);
                    }

                    grvDetalle.Columns.Add(new GridColumn
                    {
                        FieldName = "total",
                        Caption = "Total",
                        Width = 60,
                        OptionsColumn = { AllowEdit = false },
                        Visible = true
                    });
                    grvDetalle.Columns["total"].AppearanceCell.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
                    grvDetalle.Columns["total"].AppearanceCell.ForeColor = Color.IndianRed;

                    grvDetalle.Columns.Add(new GridColumn
                    {
                        FieldName = "total_salida",
                        Caption = "Total Salida",
                        Width = 80,
                        OptionsColumn = { AllowEdit = false },
                        Visible = true
                    });
                    grvDetalle.Columns["total_salida"].AppearanceCell.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
                    grvDetalle.Columns["total_salida"].AppearanceCell.ForeColor = Color.IndianRed;

                    string query = @"
                   select p.id as id_producto, max(p.descripcion) as descripcion, t.id as id_talla,sum(pe.existencia) as existencia
                     from   productos p inner join productos_existencias pe on p.id = pe.id_producto
                     inner join tallas t on pe.id_talla = t.id   
                     group by  p.id, t.id     
                     order by p.id, t.id;";

                    DataTable dtProductos = new DataTable();
                    new SqlDataAdapter(query, conexion).Fill(dtProductos);
                    List<productos> zapatos = Modulo.DataTableToList<productos>(dtProductos);

                    foreach (var grupo in zapatos.GroupBy(c => c.id_producto))
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["producto"] = grupo.First().descripcion;
                        newRow["id_producto"] = grupo.Key;
                        newRow["total"] = grupo.Sum(g => g.existencia);

                        var productoId = grupo.Key;
                        var tallasProducto = zapatos.Where(t => t.id_producto == productoId);

                        foreach (var talla in tallasProducto)
                        {
                            newRow[$"t-{talla.id_talla}"] = talla.existencia;
                            newRow[$"s-{talla.id_talla}"] = 0;
                        }

                        newRow["total_salida"] = 0;
                        dt.Rows.Add(newRow);
                    }

                    DataRow totalRow = dt.NewRow();
                    totalRow["producto"] = "Totales";
                    totalRow["total"] = zapatos.Sum(c => c.existencia);
                    totalRow["total_salida"] = 0;

                    var columnas = grvDetalle.Columns
                             .Where(c => c.FieldName != null && (c.FieldName.Contains("t-") || c.FieldName.Contains("s-")))
                             .ToList();

                    foreach (var columna in columnas)
                    {
                        var idStr = int.Parse(columna.FieldName.Replace("t-", "").Replace("s-", ""));

                        if (columna.FieldName.Contains("t-"))
                        {
                            var total = zapatos.Where(c => c.id_talla == idStr).Sum(c => c.existencia);
                            totalRow[$"t-{idStr}"] = total;
                        }
                        else if (columna.FieldName.Contains("s-"))
                        {
                            totalRow[$"s-{idStr}"] = 0;
                        }
                    }
                    dt.Rows.Add(totalRow);
                }

                gridControl1.DataSource = dt;

                grvDetalle.CellValueChanged += (sender, e) =>
                {
                    if (e.Column == null || !e.Column.FieldName.Contains("s-")) return;

                    var view = sender as GridView;
                    DataRow row = view.GetDataRow(e.RowHandle);
                    if (row == null || row["producto"].ToString() == "Totales") return;

                    try
                    {
                        var tallaId = int.Parse(e.Column.FieldName.Replace("s-", ""));
                        int salida = row[e.Column.FieldName] == DBNull.Value ? 0 : Convert.ToInt32(row[e.Column.FieldName]);
                        int existencia = row[$"t-{tallaId}"] == DBNull.Value ? 0 : Convert.ToInt32(row[$"t-{tallaId}"]);

                        if (salida > existencia || salida < 0)
                        {
                            XtraMessageBox.Show("Valor incorrecto o insuficiente");
                            row[e.Column.FieldName] = 0;
                            salida = 0;
                        }

                        row[$"t-{tallaId}"] = existencia - salida;

                        int totalSalida = view.Columns
                            .Where(c => c.FieldName != null && c.FieldName.Contains("s-"))
                            .Sum(col => row[col.FieldName] == DBNull.Value ? 0 : Convert.ToInt32(row[col.FieldName]));

                        row["total_salida"] = totalSalida;

                        int nuevoTotal = view.Columns
                            .Where(c => c.FieldName != null && c.FieldName.StartsWith("t-"))
                            .Sum(col => row[col.FieldName] == DBNull.Value ? 0 : Convert.ToInt32(row[col.FieldName]));

                        row["total"] = nuevoTotal;
                    }
                    catch { }
                };



                grvDetalle.BestFitColumns();
            }
            catch { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GridView view = gridControl1.MainView as GridView;
            if (view == null) return;

            var columnas = view.Columns
                             .Where(c => c.FieldName != null && c.FieldName.Contains("t-"))
                             .ToList();

            foreach (var columna in columnas)
            {
                var idStr = columna.FieldName.Replace("t-", "");
                if (int.TryParse(idStr, out int id))
                {
                    if (id % 2 == 0)
                    {
                        columna.AppearanceCell.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        columna.AppearanceCell.BackColor = Color.LightGray;
                    }

                }
            }
            view.LayoutChanged();
            view.Invalidate();
        }

        private void Recorrer_cuadricula()
        {
            DataTable tblGuardar = new DataTable();
            tblGuardar.Columns.Add("indice", typeof(int));
            tblGuardar.Columns.Add("id_producto", typeof(int));
            tblGuardar.Columns.Add("id_talla", typeof(int));
            tblGuardar.Columns.Add("existencia", typeof(int));

            int indice = 1;
            DataTable dt = (DataTable)gridControl1.DataSource;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                if (!(row["producto"] is DBNull) && row["producto"].ToString() == "Totales")
                {
                    continue; 
                }

                int idProducto = Convert.ToInt32(row["id_producto"]);

                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName.StartsWith("s-"))
                    {
                        int salida = row[col] == DBNull.Value ? 0 : Convert.ToInt32(row[col]);

                        if (salida > 0)
                        {
                            int idTalla = int.Parse(col.ColumnName.Replace("s-", ""));

                            DataRow dtRow = tblGuardar.NewRow();
                            dtRow["indice"] = indice++;
                            dtRow["id_producto"] = idProducto;
                            dtRow["id_talla"] = idTalla;
                            dtRow["existencia"] = salida;

                            tblGuardar.Rows.Add(dtRow);
                        }
                    }
                }
            }

            if (tblGuardar.Rows.Count > 0)
            {
                GuardarExistencias(tblGuardar);
            }
            else
            {
                XtraMessageBox.Show("No hay datos modificados o nuevos para guardar.");
            }
        }

        private void GuardarExistencias(DataTable tblGuardar)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("db_accessadmin.usp_productos_existencias_guardar", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@detalle", SqlDbType.Structured)
                    {
                        Value = tblGuardar
                    });

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Existencias guardadas correctamente.");
                    ReiniciarColumnas();
                }
            }
            catch (SqlException sqlEx)
            {
                XtraMessageBox.Show($"Error de SQL al guardar: {sqlEx.Message}", "Error");
                               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al guardar las existencias: {ex.Message}", "Error");
                                
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }

        private void ReiniciarColumnas()
        {
            if (gridControl1.DataSource is DataTable dt)
            {
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName.StartsWith("s-"))
                        {
                            row[col] = 0; 
                        }
                    }
                    row["total_salida"] = 0;
                }
                gridControl1.RefreshDataSource();
            }
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                XtraMessageBox.Show("Datos guardados");
                Recorrer_cuadricula();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al guardar los datos: " + ex.Message, "Error");
            }
        }
    }
    
}
