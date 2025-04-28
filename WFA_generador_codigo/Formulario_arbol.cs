using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WFA_generador_codigo
{
    public partial class Formulario_arbol : XtraForm
    {
        public class TareaProyecto
        {
            public string proyecto { get; set; }
            public int id_tarea { get; set; }
            public string tarea { get; set; }
            public int padre { get; set; }
            public string contenido { get; set; }
        }

        public Formulario_arbol()
        {
            InitializeComponent();
            this.Load += Formulario_arbol_Load;
        }

        private void Formulario_arbol_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            DataTable dt = Modulo.EjecutarProcedimientoAlmacenado("usp_mostrar_tareas");

            if (dt == null || dt.Rows.Count == 0)
            {
                XtraMessageBox.Show("No se encontraron datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var todasTareas = dt.AsEnumerable().Select(row => new TareaProyecto
            {
                proyecto = row["proyecto"].ToString(),
                id_tarea = Convert.ToInt32(row["id_tarea"]),
                tarea = row["tarea"].ToString(),
                padre = row["padre"] != DBNull.Value ? Convert.ToInt32(row["padre"]) : 0
            }).ToList();

            var estructuraFinal = new List<TareaProyecto>();
            int proyectoId = -1;

            foreach (var grupo in todasTareas.GroupBy(t => t.proyecto))
            {
                var proyectoNode = new TareaProyecto
                {
                    proyecto = grupo.Key,
                    id_tarea = proyectoId,
                    tarea = grupo.Key,
                    padre = -1,
                    contenido = grupo.Key
                };
                estructuraFinal.Add(proyectoNode);

                foreach (var tarea in grupo.Where(t => t.padre == 0))
                {
                    tarea.padre = proyectoId;
                    tarea.contenido = $"   {tarea.tarea}";
                    estructuraFinal.Add(tarea);
                    AgregarHijos(grupo.ToList(), estructuraFinal, tarea.id_tarea, 2);
                }
                proyectoId--;
            }

            ConfigurarTreeList(estructuraFinal);
        }

        private void AgregarHijos(List<TareaProyecto> tareas, List<TareaProyecto> estructura, int idPadre, int nivel)
        {
            foreach (var hijo in tareas.Where(t => t.padre == idPadre))
            {
                hijo.contenido = new string(' ', nivel * 3) + hijo.tarea;
                estructura.Add(hijo);
                AgregarHijos(tareas, estructura, hijo.id_tarea, nivel + 1);
            }
        }

        private void ConfigurarTreeList(List<TareaProyecto> datos)
        {
            arbol_proyectos.BeginUpdate();
            try
            {
                arbol_proyectos.DataSource = datos;
                arbol_proyectos.KeyFieldName = "id_tarea";
                arbol_proyectos.ParentFieldName = "padre";
                arbol_proyectos.Columns.Clear();

                var columna = arbol_proyectos.Columns.AddField("contenido");
                columna.Caption = "Estructura de Proyectos";
                columna.VisibleIndex = 0;
                columna.Width = 400;

                arbol_proyectos.ExpandAll();
            }
            finally
            {
                arbol_proyectos.EndUpdate();
            }
        }
    }
}