using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WFA_generador_codigo
{
    public partial class simpleButton1 : Form
    {
      
        public simpleButton1()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+");
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "INSERT INTO titulo(id, nombre_titulo, disponibilidad, precio) VALUES(8, 'La cenicienta', 1, 58.6)";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro agregado");
            conexion.Close();

        }


        Titulo ti = new Titulo();
       
        private void simpleButton1_Load(object sender, EventArgs e)
        {
            conexion.Open();
            DataTable dt = ti.MostrarTitulos();
            dataGridView1.DataSource = dt;
            conexion.Close();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var diasVencimiento = int.Parse(textEdit1.Text);
            conexion.Open();
            SqlCommand comando = new SqlCommand("usp_clientes_dias_vencimiento", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@dias", diasVencimiento);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conexion.Close();
        }

    }

}
