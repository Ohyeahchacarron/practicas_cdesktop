using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace WFA_generador_codigo
{
    public partial class Nuevos_registros : DevExpress.XtraEditors.XtraForm
    {
        private bool modoEdicion = false;
        private int idEmpleado;
        public bool DatosActualizados { get; private set; }

        public Nuevos_registros()
        {
            InitializeComponent();
            CargarCombos();
            ConfigurarControles(true);
            modoEdicion = false;
            boton_borr.Enabled = false;
            boton_credencial.Enabled = false;
        }

        public Nuevos_registros(DataRow empleado)
        {
            InitializeComponent();
            CargarCombos();
            ConfigurarControles(false);
            CargarDatos(empleado);
            modoEdicion = true;
            boton_borr.Enabled = true;
            boton_credencial.Enabled = true;
        }
        private void ConfigurarControles(bool habilitar)
        {
            textNoEmpleado.Properties.ReadOnly = true;
            textNombre.Properties.ReadOnly = !habilitar;
            comboDepartamento.Properties.ReadOnly = !habilitar;
            comboPuesto.Properties.ReadOnly = !habilitar;
            dateIngreso.Properties.ReadOnly = !habilitar;
            textSueldo.Properties.ReadOnly = !habilitar;
            comboMedio.Properties.ReadOnly = !habilitar;
            boton_imagen.Enabled = habilitar;

            boton_edit.Enabled = !habilitar;
            boton_guardar.Enabled = habilitar || modoEdicion;
            boton_borr.Enabled = modoEdicion;
            boton_credencial.Enabled = modoEdicion;
        }

        private void CargarCombos()
        {
            var departamentos = Modulo.EjecutarProcedimientoAlmacenado("usp_obtener_departamentos");
            foreach (DataRow row in departamentos.Rows)
            {
                comboDepartamento.Properties.Items.Add(row["descripcion"].ToString());
            }

            var puestos = Modulo.EjecutarProcedimientoAlmacenado("usp_obtener_puestos");
            foreach (DataRow row in puestos.Rows)
            {
                comboPuesto.Properties.Items.Add(row["descripcion"].ToString());
            }

            var medios = Modulo.EjecutarProcedimientoAlmacenado("usp_obtener_medios_reclutamiento");
            foreach (DataRow row in medios.Rows)
            {
                comboMedio.Properties.Items.Add(row["descripcion"].ToString());
            }
        }

        private void CargarDatos(DataRow empleado)
        {
            idEmpleado = Convert.ToInt32(empleado["id"]);
            textNombre.Text = empleado["empleado"].ToString();
            comboDepartamento.Text = empleado["departamento"].ToString();
            comboPuesto.Text = empleado["puesto"].ToString();
            textNoEmpleado.Text = empleado["no_empleado"].ToString();
            dateIngreso.DateTime = Convert.ToDateTime(empleado["fecha_ingreso"]);
            textSueldo.Text = empleado["sueldo"].ToString();
            comboMedio.Text = empleado["medio_reclutamiento"].ToString();

            if (empleado["foto"] != DBNull.Value)
            {
                byte[] fotoBytes = (byte[])empleado["foto"];
                imageEmpleado.Image = ByteArrayToImage(fotoBytes);
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
                return null;

            try
            {
                using (MemoryStream ms = new MemoryStream(byteArray))
                {
                    return new Bitmap(Image.FromStream(ms));
                }
            }
            catch
            {
                return null;
            }
        }

        private void boton_imagen_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imageEmpleado.Image = Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                }
            }
        }

        private void boton_cr_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] imagenBytes = null;
                if (imageEmpleado.Image != null)
                {
                    using (Image imagenCopia = new Bitmap(imageEmpleado.Image))
                    using (MemoryStream ms = new MemoryStream())
                    {
                        imagenCopia.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        imagenBytes = ms.ToArray();
                    }
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("empleado", typeof(string));
                dt.Columns.Add("no_empleado", typeof(string));
                dt.Columns.Add("puesto", typeof(string));
                dt.Columns.Add("departamento", typeof(string));
                dt.Columns.Add("foto", typeof(byte[]));

                DataRow row = dt.NewRow();
                row["empleado"] = textNombre.Text;
                row["no_empleado"] = textNoEmpleado.Text;
                row["puesto"] = comboPuesto.Text;
                row["departamento"] = comboDepartamento.Text;
                row["foto"] = imagenBytes ?? (object)DBNull.Value;
                dt.Rows.Add(row);

                Credencial reporte = new Credencial();
                reporte.DataSource = dt;

                ReportPrintTool tool = new ReportPrintTool(reporte);
                tool.ShowPreview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al generar credencial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void boton_guar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dxValidationProvider1.Validate())
                {

                
                if (string.IsNullOrEmpty(textNombre.Text))
                {
                    XtraMessageBox.Show("Debe ingresar el nombre del empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboDepartamento.SelectedIndex == -1 || comboPuesto.SelectedIndex == -1)
                {
                    XtraMessageBox.Show("Debe seleccionar departamento y puesto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] fotoBytes = null;
                if (imageEmpleado.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        imageEmpleado.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        fotoBytes = ms.ToArray();
                    }
                }

                using (SqlConnection conexion = new SqlConnection(Modulo.connectionString))
                {
                    conexion.Open();
                    SqlCommand comando;

                    if (modoEdicion)
                    {
                        comando = new SqlCommand("usp_editar_empleado", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@id_empleado", idEmpleado);
                    }
                    else
                    {
                        comando = new SqlCommand("usp_insertar_empleado", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                    }

                    comando.Parameters.AddWithValue("@empleado", textNombre.Text);
                    comando.Parameters.AddWithValue("@id_departamento", comboDepartamento.SelectedIndex + 1);
                    comando.Parameters.AddWithValue("@id_puesto", comboPuesto.SelectedIndex + 1);
                    comando.Parameters.AddWithValue("@fecha_ingreso", dateIngreso.DateTime);
                    comando.Parameters.AddWithValue("@sueldo", Convert.ToDecimal(textSueldo.EditValue));
                    comando.Parameters.AddWithValue("@medio_reclutamiento", comboMedio.Text);

                    SqlParameter fotoParam = new SqlParameter("@foto", SqlDbType.VarBinary);
                    fotoParam.Value = fotoBytes != null ? (object)fotoBytes : DBNull.Value;
                    comando.Parameters.Add(fotoParam);

                    comando.ExecuteNonQuery();

                    DatosActualizados = true;
                    XtraMessageBox.Show(modoEdicion ? "Empleado actualizado correctamente" : "Empleado guardado correctamente",
                                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al guardar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void boton_edit_Click(object sender, EventArgs e)
        {
            ConfigurarControles(true);
        }

        private void boton_borr_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(Modulo.connectionString))
                {
                    SqlCommand comando = new SqlCommand("usp_dar_baja_empleado", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id_empleado", idEmpleado);

                    conexion.Open();
                    comando.ExecuteNonQuery();

                    XtraMessageBox.Show("Empleado dado de baja exitosamente");
                    DatosActualizados = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al dar de baja al empleado: {ex.Message}");
            }
        }

        private void boton_guardar_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}