using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WFA_generador_codigo
{
    public partial class Formulario_status : DevExpress.XtraEditors.XtraForm
    {
        public int statusActual = 1;

        public Formulario_status()
        {
            InitializeComponent();
        }

        private void ActualizarLabelStatus()
        {
            var control = Modulo.Find<asistencias>(panelControl1);
            if (control != null)
            {
                control.ActualizarLabelStatus(statusActual);
            }
        }

        private void boton_siguiente_Click(object sender, EventArgs e)
        {
            statusActual = statusActual % 4 + 1;
            Modulo.ChangeView<asistencias>(transitionManager1, panelControl1);
            var control = Modulo.Find<asistencias>(panelControl1);
            if (control != null)
            {
                control.CargarDatos(statusActual);
                control.ActualizarLabelStatus(statusActual);
            }
        }

        private void Formulario_status_Load(object sender, EventArgs e)
        {
            Modulo.ChangeView<asistencias>(transitionManager1, panelControl1);
            var control = Modulo.Find<asistencias>(panelControl1);
            if (control != null)
            {
                control.CargarDatos(statusActual);
                control.ActualizarLabelStatus(statusActual);
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusActual = statusActual % 4 + 1;
            Modulo.ChangeView<asistencias>(transitionManager1, panelControl1);
            var control = Modulo.Find<asistencias>(panelControl1);
            if (control != null)
            {
                control.CargarDatos(statusActual);
                control.ActualizarLabelStatus(statusActual);
            }
        }
    }
}