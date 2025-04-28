using System;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace WFA_generador_codigo
{
    public partial class Formulario_empleado : DevExpress.XtraEditors.XtraForm
    {
        public Formulario_empleado()
        {
            InitializeComponent();

            if (tabla_empleados == null || empleados_activos == null)
            {
                XtraMessageBox.Show("Error: Los controles del grid no están inicializados");
                return;
            }

            try
            {
                CargarEmpleadosActivos();
                empleados_activos.RowClick += GridView1_RowClick;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar empleados: {ex.Message}");
            }
        }

        private void CargarEmpleadosActivos()
        {
            DataTable dt = Modulo.EjecutarProcedimientoAlmacenado("usp_mostrar_empleados_activos");

            if (dt == null || dt.Rows.Count == 0)
            {
                XtraMessageBox.Show("No se encontraron datos de empleados");
                return;
            }

            tabla_empleados.DataSource = dt;

            if (empleados_activos.Columns["id"] != null) empleados_activos.Columns["id"].Visible = false;
            if (empleados_activos.Columns["id_departamento"] != null) empleados_activos.Columns["id_departamento"].Visible = false;
            if (empleados_activos.Columns["id_puesto"] != null) empleados_activos.Columns["id_puesto"].Visible = false;
            if (empleados_activos.Columns["id_medio_reclutamiento"] != null) empleados_activos.Columns["id_medio_reclutamiento"].Visible = false;
            if (empleados_activos.Columns["foto"] != null) empleados_activos.Columns["foto"].Visible = false;

            empleados_activos.BestFitColumns();
        }

        private void GridView1_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2 && e.RowHandle >= 0) 
                {
                    DataRow row = empleados_activos.GetDataRow(e.RowHandle);
                    if (row != null)
                    {
                        using (Nuevos_registros formEdicion = new Nuevos_registros(row))
                        {
                            if (formEdicion.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                CargarEmpleadosActivos();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al seleccionar empleado: {ex.Message}");
            }
        }

        private void boton_nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                using (Nuevos_registros formNuevo = new Nuevos_registros())
                {
                    if (formNuevo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        CargarEmpleadosActivos();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al abrir formulario: {ex.Message}");
            }
        }

        private void boton_recargar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarEmpleadosActivos();
                XtraMessageBox.Show("Datos actualizados correctamente");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al recargar datos: {ex.Message}");
            }
        }
    }
}