using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;


namespace WFA_generador_codigo
{
    public partial class Formulario_2 : DevExpress.XtraEditors.XtraForm
    {
        //conexion a la base de datos
        private SqlConnection conexion = new SqlConnection("server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+");
        private int? idSeleccionado = null;

        public Formulario_2()
        {
            InitializeComponent();
            GridView gridView = tabla_articulos.MainView as GridView;
            if (gridView != null)
            {
                gridView.FocusedRowChanged += tabla_articulos_FocusedRowChanged;
            }

        }

        private void CargarArticulos()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                // carga los datos en la tabla
                using (SqlCommand cmd = new SqlCommand("[db_accessadmin].[usp_articulos_seleccionar]", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    tabla_articulos.DataSource = dt;
                    GridView gridView = tabla_articulos.MainView as GridView;
                    if (gridView != null)
                    {
                        gridView.ClearSelection(); 
                        gridView.FocusedRowHandle = GridControl.AutoFilterRowHandle; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los artículos: " + ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        //evento cuando carga el formulario
        private void Formulario_2_Load(object sender, EventArgs e)
        {
            CargarArticulos();
            LimpiarCampos();
            
        }

        private void tabla_articulos_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
                if (row != null)
                {
                    //los campos a actualizar
                    idSeleccionado = Convert.ToInt32(row["id"]);
                    text_articulo.Text = row["descripcion"].ToString();
                    text_id_tipo.Text = row["id_tipo_articulo"].ToString();
                    text_costo.Text = row["costo"].ToString();
                    text_precio.Text = row["precio"].ToString();
                }
            }
        }

        private void crear_articulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                using (SqlCommand cmd = new SqlCommand("[db_accessadmin].[usp_articulos_guardar]", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // si ya hay un articulo seleccionado se actualiza
                    if (idSeleccionado.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@id", idSeleccionado.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@id", DBNull.Value);
                    }

                    // parametros para el procedimiento almacenado
                    cmd.Parameters.AddWithValue("@descripcion", text_articulo.Text);
                    cmd.Parameters.AddWithValue("@id_tipo_articulo", Convert.ToInt32(text_id_tipo.Text));
                    cmd.Parameters.AddWithValue("@costo", Convert.ToDecimal(text_costo.Text));
                    cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(text_precio.Text));

                    // ejecutar el procedimiento almacenado
                    cmd.ExecuteNonQuery();
                }
                // mensaje segun si es insercion o actualizacion
                MessageBox.Show(idSeleccionado.HasValue ? "Artículo actualizado correctamente." : "Artículo insertado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();

                // recarga la tabla de articulos cuando se agregan nuevos registros
                CargarArticulos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el artículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    
        private void LimpiarCampos()
        {
            idSeleccionado = null;
            text_articulo.Text = "";
            text_id_tipo.Text = "";
            text_costo.Text = "";
            text_precio.Text = "";
        }
    }
}
