using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using System.Drawing;

namespace WFA_generador_codigo
{
    public partial class formulario_colores : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection conexion;

        private System.Drawing.Color ObtenerColorPorNombre(string nombre)
        {
            switch (nombre.ToLower())
            {
                case "azul": return System.Drawing.Color.Blue;
                case "verde": return System.Drawing.Color.Green;
                case "rojo": return System.Drawing.Color.Red;
                case "naranja": return System.Drawing.Color.Orange;
                default: return System.Drawing.Color.Transparent;
            }
        }

        internal class Colores
        {
            public int id { get; set; }
            public string descripcion { get; set; }
        }

        internal class Producto
        {
            public int id { get; set; }
            public string descripcion { get; set; }
            public int id_talla_tipo { get; set; }
            public int id_color { get; set; }
            public byte[] foto { get; set; }

        }

        public formulario_colores()
        {
            InitializeComponent();
            conexion = new SqlConnection("server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+");
        }

        private List<Colores> ObtenerColores()
        {
            List<Colores> colores = new List<Colores>();
            using (var tempConn = new SqlConnection(conexion.ConnectionString))
            {
                tempConn.Open();
                string query = "SELECT id, descripcion FROM colores";
                using (var cmd = new SqlCommand(query, tempConn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        colores.Add(new Colores
                        {
                            id = reader.GetInt32(0),
                            descripcion = reader.GetString(1)
                        });
                    }
                }
            }
            return colores;
        }

        private void CargarProductos()
        {
            try
            {
                List<Producto> listaProductos = new List<Producto>();
                var colores = ObtenerColores();

                using (var tempConn = new SqlConnection(conexion.ConnectionString))
                {
                    tempConn.Open();
                    string queryProductos = "SELECT [id], [descripcion], [id_talla_tipo], [id_color], [foto] FROM [db_accessadmin].[productos]";

                    using (var cmdProductos = new SqlCommand(queryProductos, tempConn))
                    using (var readerProductos = cmdProductos.ExecuteReader())
                    {
                        while (readerProductos.Read())
                        {
                            int colorId = readerProductos.IsDBNull(3) ? 0 : readerProductos.GetInt32(3);
                            listaProductos.Add(new Producto
                            {
                                id = readerProductos.IsDBNull(0) ? 0 : readerProductos.GetInt32(0),
                                descripcion = readerProductos.IsDBNull(1) ? string.Empty : readerProductos.GetString(1),
                                id_talla_tipo = readerProductos.IsDBNull(2) ? 0 : readerProductos.GetInt32(2),
                                id_color = readerProductos.IsDBNull(3) ? 0 : readerProductos.GetInt32(3),
                                foto = readerProductos.IsDBNull(4) ? null : (byte[])readerProductos[4]
                            });

                        }
                    }
                }

                gridControl1.DataSource = listaProductos;
                gridView1.BestFitColumns();

                var repo = new RepositoryItemLookUpEdit();
                repo.DataSource = colores;
                repo.DisplayMember = "descripcion";
                repo.ValueMember = "id";
                repo.NullText = "";
                repo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                repo.Columns.Clear();
                repo.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "Color"));

                repo.CustomDrawCell += (s, e) =>
                {
                    if (e.Row != null && e.Row is Colores colorObj)
                    {
                        var color = ObtenerColorPorNombre(colorObj.descripcion);
                        using (var brush = new SolidBrush(color))
                        {
                            e.Graphics.FillRectangle(brush, e.Bounds);
                        }
                        e.Handled = true;
                    }
                };

                repo.CustomDisplayText += (s, e) =>
                {
                    var color = ObtenerColores().Find(c => c.id.ToString() == e.Value?.ToString());
                    if (color != null)
                        e.DisplayText = color.descripcion;
                };


                RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();
                pictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;

                gridControl1.RepositoryItems.Add(pictureEdit);
                gridView1.Columns["foto"].ColumnEdit = pictureEdit;


                gridView1.Columns["id_color"].ColumnEdit = repo;
                gridView1.RowHeight = 100;

                gridView1.Columns["foto"].Width = 50;
                gridView1.Columns["foto"].Caption = "Imagen";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar productos: {ex.Message}", "Error");
            }
        }

        private void Recorrer_cuadricula()
        {
            DataTable tblGuardar = new DataTable();
            tblGuardar.Columns.Add("indice", typeof(int));
            tblGuardar.Columns.Add("id_producto", typeof(int));
            tblGuardar.Columns.Add("id_color", typeof(int));

            int indice = 1;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetRow(i) as Producto;
                if (row == null)
                    continue;

                DataRow dtRow = tblGuardar.NewRow();
                dtRow["indice"] = indice++;
                dtRow["id_producto"] = row.id;
                dtRow["id_color"] = row.id_color;

                tblGuardar.Rows.Add(dtRow);
            }

            if (tblGuardar.Rows.Count > 0)
            {
                GuardarColores(tblGuardar);
            }
            else
            {
                XtraMessageBox.Show("No hay datos modificados o nuevos para guardar.");
            }
        }

        private void GuardarColores(DataTable tblGuardar)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("db_accessadmin.usp_productos_actualizar_colores", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@detalle", SqlDbType.Structured)
                    {
                        Value = tblGuardar
                    });

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlEx)
            {
                XtraMessageBox.Show($"Error de SQL al guardar: {sqlEx.Message}", "Error");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al guardar los colores: {ex.Message}", "Error");
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }

        private void formulario_colores_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void boton_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Recorrer_cuadricula();
                CargarProductos();
                XtraMessageBox.Show("Datos guardados");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al guardar los datos: " + ex.Message, "Error");
            }
        }

    }
}
