using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace WFA_generador_codigo
{
    public partial class Formulario_alumnos : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection conexion;

        public Formulario_alumnos()
        {
            InitializeComponent();
            conexion = new SqlConnection("server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+");
        }

        private void Formulario_alumnos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select alumnos.*, cast(0 as int) as modificacion from db_accessadmin.alumnos", conexion);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                dt.Columns.Add("modificacion_texto", typeof(string));
                
                foreach (DataRow row in dt.Rows)
                {
                    row["modificacion_texto"] = ObtenerTextoModificacion(Convert.ToInt32(row["modificacion"]));
                }

                tabla_alumnos.DataSource = dt;
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private string ObtenerTextoModificacion(int valor)
        {
            switch (valor)
            {
                case 0: return "ACTIVO";
                case 1: return "EDITAR";
                case 2: return "ELIMINAR";
                default: return "ACTIVO";
            }
        }

        private void ConfigurarColumnas()
        {
            GridView view = tabla_alumnos.MainView as GridView;
            if (view != null)
            {
                view.OptionsBehavior.Editable = true;
                view.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                view.InitNewRow += View_InitNewRow;
                
                GridColumn colModificacionOriginal = view.Columns["modificacion"];
                if (colModificacionOriginal != null)
                {
                    colModificacionOriginal.Visible = false;
                }

                GridColumn colModificacionTexto = view.Columns["modificacion_texto"];
                if (colModificacionTexto != null)
                {
                    colModificacionTexto.Caption = "Modificación";
                    colModificacionTexto.OptionsColumn.AllowEdit = false;
                }

                GridColumn colId = view.Columns["id"];
                if (colId != null)
                {
                    colId.Visible = false;
                    colId.OptionsColumn.AllowEdit = false;
                }

                GridColumn colNombre = view.Columns["nombre"];
                if (colNombre != null)
                {
                    colNombre.Caption = "Nombre del Alumno";
                    colNombre.OptionsColumn.AllowEdit = true;
                }

                GridColumn colGrado = view.Columns["grado"];
                if (colGrado != null)
                {
                    colGrado.Caption = "Grado";
                    colGrado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    colGrado.OptionsColumn.AllowEdit = true;
                }
                
                view.BestFitColumns();
            }
        }

        private void View_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                DataRow row = view.GetDataRow(e.RowHandle);
                if (row != null)
                {
                    row["id"] = 0;
                    row["modificacion"] = 0;
                    row["modificacion_texto"] = "ACTIVO";
                    row["grado"] = 0;
                    row["nombre"] = "";
                }
            }
        }

        private void Recorrer_cuadricula()
        {
            DataTable tblGuardar = new DataTable();
            tblGuardar.Columns.Add("indice", typeof(int));
            tblGuardar.Columns.Add("id", typeof(int));
            tblGuardar.Columns.Add("nombre", typeof(string));
            tblGuardar.Columns.Add("grado", typeof(int));
            tblGuardar.Columns.Add("estatus", typeof(int)); 

            int indice = 1;

            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                DataRow row = gridView1.GetDataRow(i);
                if (row != null)
                {
                    int id = 0;
                    int estatus = 0;

                    if (row["id"] != DBNull.Value)
                    {
                        id = Convert.ToInt32(row["id"]);
                    }
                    if (row["modificacion"] != DBNull.Value)
                    {
                        estatus = Convert.ToInt32(row["modificacion"]); 
                    }

                    bool esNuevo = (id == 0);
                    bool esModificado = (estatus == 1);
                    bool esEliminado = (estatus == 2);

                    if (esNuevo || esModificado || esEliminado)
                    {
                        DataRow dtRow = tblGuardar.NewRow();
                        dtRow["indice"] = indice++;
                        dtRow["id"] = id;
                        dtRow["nombre"] = row["nombre"];
                        dtRow["grado"] = row["grado"];
                        dtRow["estatus"] = estatus; 

                        tblGuardar.Rows.Add(dtRow);
                    }
                }
            }

            Console.WriteLine("Datos a guardar:");
            foreach (DataRow row in tblGuardar.Rows)
            {
                Console.WriteLine($"Índice: {row["indice"]}, ID: {row["id"]}, Nombre: {row["nombre"]}, Grado: {row["grado"]}, Estatus: {row["estatus"]}");
            }

            if (tblGuardar.Rows.Count > 0)
            {
                GuardarAlumnos(tblGuardar);
            }
            else
            {
                Console.WriteLine("No hay datos modificados o nuevos para guardar.");
            }
        }

        private void GuardarAlumnos(DataTable tblGuardar)
        {
            try
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("db_accessadmin.usp_alumnos_guardar_index", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@detalle", SqlDbType.Structured)
                    {
                        Value = tblGuardar
                    });

                    cmd.ExecuteNonQuery();
                    
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error de SQL al guardar: {sqlEx.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar alumnos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            CargarDatos();
        }

        private void boton_guardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Recorrer_cuadricula();
                MessageBox.Show("Datos guardados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "modificacion_texto" && e.Column.FieldName != "modificacion")
            {
                GridView view = sender as GridView;
                DataRow row = view.GetDataRow(e.RowHandle);
                if (row != null)
                {
                    row["modificacion"] = 1; 
                    row["modificacion_texto"] = "EDITAR"; 
                }
            }
        }

        private void boton_eliminar_Click(object sender, EventArgs e)
        {
            GridView view = tabla_alumnos.MainView as GridView;
            if (view != null && view.SelectedRowsCount > 0)
            {
                int filaSeleccionada = view.GetSelectedRows()[0];
                DataRow row = view.GetDataRow(filaSeleccionada);
                if (row != null)
                {
                    row["modificacion"] = 2;
                    row["modificacion_texto"] = "ELIMINAR";
                    MessageBox.Show("Registro marcado para eliminación.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
