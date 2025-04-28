using DevExpress.Utils.Animation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_generador_codigo
{
   public static class Modulo
    {
        public static readonly string connectionString = "server=192.168.22.146; database=programador02; user=programador02; password=s0p0rt31+";
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            if (row[prop.Name] == null || row[prop.Name] == DBNull.Value) { }
                            else
                            {
                                if (prop.PropertyType.FullName.Contains("Nullable") && prop.PropertyType.FullName.Contains("Int32"))
                                {
                                    if (row[prop.Name] == null || row[prop.Name] == DBNull.Value)
                                        propertyInfo.SetValue(obj, null);
                                    else
                                        propertyInfo.SetValue(obj, int.Parse(row[prop.Name].ToString()));
                                }
                                else if (prop.PropertyType.FullName.Contains("Nullable") && prop.PropertyType.FullName.Contains("Double"))
                                {
                                    if (row[prop.Name] == null || row[prop.Name] == DBNull.Value)
                                        propertyInfo.SetValue(obj, null);
                                    else
                                        propertyInfo.SetValue(obj, double.Parse(row[prop.Name].ToString()));
                                }
                                else if (prop.PropertyType.FullName.Contains("Nullable") && propertyInfo.PropertyType.FullName.Contains("DateTime"))
                                {
                                    if (row[prop.Name] == null || row[prop.Name] == DBNull.Value)
                                        propertyInfo.SetValue(obj, null);
                                    else
                                        propertyInfo.SetValue(obj, DateTime.Parse(row[prop.Name].ToString()));
                                }
                                else
                                    propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                            }
                        }
                        catch 
                        {

                            //                MessageBox.Show(ex.Message);
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable EjecutarProcedimientoAlmacenado(string nombreProcedimiento)
        {
            DataTable tablaResultados = new DataTable();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(nombreProcedimiento, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        conexion.Open();
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(tablaResultados);
                        }
                    }
                    finally
                    {
                        if (conexion.State == ConnectionState.Open)
                            conexion.Close();
                    }
                }
            }

            return tablaResultados;
        }


        public static void ChangeView<T>(TransitionManager trmUserControl, PanelControl pnPanel, bool dejarAnterior = false) where T : Control, new()
        {
            if (trmUserControl.IsTransition)
            {
                trmUserControl.EndTransition();
            }

            trmUserControl.StartTransition(pnPanel);
            try
            {
                if (!dejarAnterior)
                {
                }
                //pnMdi.Controls.Clear();
                T find = Find<T>(pnPanel);
                if (find != null && dejarAnterior)
                {
                    find.BringToFront();
                }
                else
                {
                    if (find != null)
                    {
                        pnPanel.Controls.Remove(find);
                        find.Dispose();
                    }
                    find = new T();
                    find.Parent = pnPanel;
                    find.Dock = DockStyle.Fill;
                    find.BringToFront();
                }

            }
            finally
            {
                trmUserControl.EndTransition();
            }
        }

        public static T Find<T>(Control container) where T : Control
        {
            for (int i = 0; i < container.Controls.Count; i++)
            {
                if (container.Controls[i] is T)
                {

                    return (T)container.Controls[i];
                }
            }
            return null;
        }
    }
}
