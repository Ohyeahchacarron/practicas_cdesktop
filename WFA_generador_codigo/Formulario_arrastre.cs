using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace WFA_generador_codigo
{
    public partial class Formulario_arrastre : XtraForm
    {
        public Formulario_arrastre()
        {
            InitializeComponent();
        }
        private Point inicioArrastre;
        private bool arrastrando = false;
        private void Formulario_arrastre_Load(object sender, EventArgs e)
        {
            DataTable dtSeleccionados = new DataTable();
            dtSeleccionados.Columns.Add("no_empleado", typeof(string));
            dtSeleccionados.Columns.Add("empleado", typeof(string));
            tabla_nuevo_empleados.DataSource = dtSeleccionados;

            all_empleados.OptionsBehavior.Editable = false;
            all_empleados.OptionsView.ColumnAutoWidth = false;
            all_empleados.OptionsView.ShowAutoFilterRow = false;
            all_empleados.OptionsView.ShowGroupPanel = false;

            news_empleados.OptionsBehavior.Editable = false;
            news_empleados.OptionsView.ColumnAutoWidth = false;
            news_empleados.OptionsView.ShowAutoFilterRow = false;
            news_empleados.OptionsView.ShowGroupPanel = false;

            try
            {
                tabla_todo_empleados.DataSource = Modulo.EjecutarProcedimientoAlmacenado("usp_mostrar_empleados_activos");
                all_empleados.BestFitColumns();
                all_empleados.Columns["empleado"].Width = 200;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tabla_todo_empleados.MouseDown += Tabla_todo_empleados_MouseDown;
            tabla_todo_empleados.MouseMove += Tabla_todo_empleados_MouseMove;
            tabla_nuevo_empleados.DragOver += Tabla_nuevo_empleados_DragOver;
            tabla_nuevo_empleados.DragDrop += Tabla_nuevo_empleados_DragDrop;
            tabla_nuevo_empleados.AllowDrop = true;
        }

        private void Tabla_todo_empleados_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                inicioArrastre = e.Location;
                arrastrando = false;
            }
        }

        private void Tabla_todo_empleados_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !arrastrando)
            {
                if (Math.Abs(e.X - inicioArrastre.X) > SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - inicioArrastre.Y) > SystemInformation.DragSize.Height)
                {
                    GridHitInfo hitInfo = all_empleados.CalcHitInfo(e.Location);
                    if (hitInfo.InRow)
                    {
                        DataRow row = all_empleados.GetDataRow(hitInfo.RowHandle);
                        if (row != null)
                        {
                            arrastrando = true;
                            tabla_todo_empleados.DoDragDrop($"{row["no_empleado"]}|{row["empleado"]}", DragDropEffects.Copy);
                        }
                    }
                }
            }
        }

        private void Tabla_nuevo_empleados_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(string)) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void Tabla_nuevo_empleados_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                string[] datos = e.Data.GetData(typeof(string)).ToString().Split('|');
                if (datos.Length == 2)
                {
                    DataTable dt = (DataTable)tabla_nuevo_empleados.DataSource;
                    if (dt.Select($"no_empleado = '{datos[0]}'").Length == 0)
                    {
                        dt.Rows.Add(datos[0], datos[1]);
                       
                    }
                }
            }
        }
    }
}
