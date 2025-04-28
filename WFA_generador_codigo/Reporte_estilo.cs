using System;
using System.Drawing;
using DevExpress.XtraReports.UI;
using System.Data;
using WFA_generador_codigo;
using DevExpress.XtraCharts;
using System.Linq;


namespace WFA_generador_codigo
{
    public partial class Reporte_estilo : DevExpress.XtraReports.UI.XtraReport
    {

        public Reporte_estilo()
        {
            InitializeComponent();
            ConfigurarGrupos();
            CargarDatos();
        }

        private void ConfigurarGrupos()
        {
            GroupField groupField = new GroupField("estilo");
            GroupHeader1.GroupFields.Add(groupField);
            GroupHeader1.RepeatEveryPage = true;
        }

        private void CargarDatos()
        {
            try
            {
                DataTable datosOriginales = Modulo.EjecutarProcedimientoAlmacenado("[db_accessadmin].[usp_reporte_estilos]");
                var datosAgrupados = datosOriginales.Clone();
                datosAgrupados.Columns["total_consumo"].DataType = typeof(decimal);

                foreach (DataRow row in datosOriginales.Rows)
                {
                    row["estilo"] = row["estilo"].ToString().Trim();
                }

                foreach (var grupo in datosOriginales.AsEnumerable()
                    .GroupBy(r => r.Field<string>("estilo")))
                {
                    decimal suma = grupo.Sum(r => r.Field<decimal>("total_consumo"));
                    DataRow fila = datosAgrupados.NewRow();
                    fila["estilo"] = grupo.Key;
                    fila["total_consumo"] = suma;
                    datosAgrupados.Rows.Add(fila);
                }

                xrChart1.DataSource = datosAgrupados;
                Series serie = new Series("consumo por estilo", ViewType.Bar);
                serie.ArgumentDataMember = "estilo";
                serie.ValueDataMembers.AddRange("total_consumo");
                xrChart1.Series.Clear();
                xrChart1.Series.Add(serie);
                ((BarSeriesView)serie.View).ColorEach = true;

                serie.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                ((SeriesLabelBase)serie.Label).TextPattern = "{V:C2}";



                dataSet1.Tables["Table1"].Clear();
                foreach (DataRow fila in datosOriginales.Rows)
                {
                    var nueva = dataSet1.Tables["Table1"].NewRow();
                    nueva["pares"] = Convert.ToInt32(fila["pares"]);
                    nueva["producto"] = fila["productos"].ToString();
                    nueva["consumo_por_par"] = Convert.ToDecimal(fila["consumo_par"]);
                    nueva["total_consumo"] = Convert.ToDecimal(fila["total_consumo"]);
                    nueva["estilo"] = fila["estilo"].ToString();
                    dataSet1.Tables["Table1"].Rows.Add(nueva);
                }

                this.CreateDocument();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

    }
}
