using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace WFA_generador_codigo
{
    public partial class Menu : DevExpress.XtraEditors.XtraForm
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Formulario_alumnos form_alumnos = new Formulario_alumnos();
            form_alumnos.Show();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Formulario_2 form_tienda = new Formulario_2();
            form_tienda.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            formulario form_generadorc = new formulario();
            form_generadorc.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Formulario_talla form_talla = new Formulario_talla();
            form_talla.Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Formulario_facturas form_folio = new Formulario_facturas();
            form_folio.Show();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            formulario_colores form_colores = new formulario_colores();
            form_colores.Show();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Formulario_estilos form_estilo = new Formulario_estilos();
            form_estilo.Show();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            reporte repo = new reporte();
            DataTable dt = new DataTable();
            repo.DataSource = dt;
            repo.DataMember = dt.TableName;
            repo.ShowPreview();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Reporte_proveedor repo_pro = new Reporte_proveedor();
            DataTable dt = new DataTable();
            repo_pro.DataSource = dt;
            repo_pro.DataMember = dt.TableName;
            repo_pro.ShowPreview();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            Reporte_estilo repo_est = new Reporte_estilo();
            DataTable dt = new DataTable();
            repo_est.DataSource = dt;
            repo_est.DataMember = dt.TableName;
            repo_est.ShowPreview();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            Formulario_dashboard form_dash = new Formulario_dashboard();
            form_dash.Show();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            Dash_asistencias dash_asis = new Dash_asistencias();
            dash_asis.Show();
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            Formulario_status form_asis = new   Formulario_status();
            form_asis.Show();
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            Formulario_empleado form_emp = new Formulario_empleado();
            form_emp.Show();
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            Formulario_arrastre form_arra = new Formulario_arrastre();
            form_arra.Show();
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            Formulario_arbol form_arbol = new Formulario_arbol();
            form_arbol.Show();
        }
    }
}