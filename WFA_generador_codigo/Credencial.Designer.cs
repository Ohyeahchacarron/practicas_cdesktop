namespace WFA_generador_codigo
{
    partial class Credencial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Data.DataSet dataSet1;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Credencial));
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.empleado = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPanel2 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.nombre_empleado = new DevExpress.XtraReports.UI.XRLabel();
            this.no_empleado = new DevExpress.XtraReports.UI.XRLabel();
            this.puesto = new DevExpress.XtraReports.UI.XRLabel();
            this.departamento = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.empleado,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
            this.dataTable1.TableName = "Table1";
            // 
            // empleado
            // 
            this.empleado.Caption = "empleado";
            this.empleado.ColumnName = "empleado";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "no_empleado";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "puesto";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "departamento";
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "foto";
            this.dataColumn5.ColumnName = "foto";
            this.dataColumn5.DataType = typeof(byte[]);
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1,
            this.xrPageBreak1});
            this.Detail.HeightF = 287.3842F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPanel1
            // 
            this.xrPanel1.BackColor = System.Drawing.Color.Transparent;
            this.xrPanel1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.BorderWidth = 5F;
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox2,
            this.xrLine2,
            this.xrLine1,
            this.xrPanel2,
            this.puesto,
            this.departamento,
            this.xrLabel1});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(106.25F, 10.00001F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(436.2745F, 257.2823F);
            this.xrPanel1.StylePriority.UseBackColor = false;
            this.xrPanel1.StylePriority.UseBorderDashStyle = false;
            this.xrPanel1.StylePriority.UseBorders = false;
            this.xrPanel1.StylePriority.UseBorderWidth = false;
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.xrPictureBox2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox2.Image")));
            this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(366.6392F, 9.99999F);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.SizeF = new System.Drawing.SizeF(59.63541F, 49.2448F);
            this.xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            this.xrPictureBox2.StylePriority.UseBackColor = false;
            this.xrPictureBox2.StylePriority.UseBorders = false;
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(23.4068F, 198.9728F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(389.3229F, 2F);
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(23.40684F, 245.2823F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(389.3229F, 2F);
            // 
            // xrPanel2
            // 
            this.xrPanel2.BackColor = System.Drawing.Color.Black;
            this.xrPanel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPanel2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.xrLabel2,
            this.nombre_empleado,
            this.no_empleado});
            this.xrPanel2.LocationFloat = new DevExpress.Utils.PointFloat(9.999981F, 59.24479F);
            this.xrPanel2.Name = "xrPanel2";
            this.xrPanel2.SizeF = new System.Drawing.SizeF(416.2746F, 103.9966F);
            this.xrPanel2.StylePriority.UseBackColor = false;
            this.xrPanel2.StylePriority.UseBorders = false;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPictureBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Image", null, "Table1.foto")});
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(9.999981F, 9.999998F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(103.4068F, 83.99654F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            this.xrPictureBox1.StylePriority.UseBorders = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.ForeColor = System.Drawing.Color.OrangeRed;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(117.5267F, 59.04167F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(102.474F, 23.00001F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseForeColor = false;
            this.xrLabel2.Text = "No. empleado";
            // 
            // nombre_empleado
            // 
            this.nombre_empleado.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.nombre_empleado.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Table1.empleado")});
            this.nombre_empleado.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre_empleado.ForeColor = System.Drawing.Color.OrangeRed;
            this.nombre_empleado.LocationFloat = new DevExpress.Utils.PointFloat(117.5267F, 22.73148F);
            this.nombre_empleado.Name = "nombre_empleado";
            this.nombre_empleado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.nombre_empleado.SizeF = new System.Drawing.SizeF(202.474F, 23F);
            this.nombre_empleado.StylePriority.UseBorders = false;
            this.nombre_empleado.StylePriority.UseFont = false;
            this.nombre_empleado.StylePriority.UseForeColor = false;
            // 
            // no_empleado
            // 
            this.no_empleado.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.no_empleado.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Table1.no_empleado")});
            this.no_empleado.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no_empleado.ForeColor = System.Drawing.Color.OrangeRed;
            this.no_empleado.LocationFloat = new DevExpress.Utils.PointFloat(220.0007F, 59.04167F);
            this.no_empleado.Name = "no_empleado";
            this.no_empleado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.no_empleado.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.no_empleado.StylePriority.UseBorders = false;
            this.no_empleado.StylePriority.UseFont = false;
            this.no_empleado.StylePriority.UseForeColor = false;
            // 
            // puesto
            // 
            this.puesto.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.puesto.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Table1.puesto")});
            this.puesto.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puesto.ForeColor = System.Drawing.Color.Black;
            this.puesto.LocationFloat = new DevExpress.Utils.PointFloat(23.40677F, 175.9728F);
            this.puesto.Name = "puesto";
            this.puesto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.puesto.SizeF = new System.Drawing.SizeF(134.1435F, 23F);
            this.puesto.StylePriority.UseBorders = false;
            this.puesto.StylePriority.UseFont = false;
            this.puesto.StylePriority.UseForeColor = false;
            // 
            // departamento
            // 
            this.departamento.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.departamento.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Table1.departamento")});
            this.departamento.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departamento.ForeColor = System.Drawing.Color.Black;
            this.departamento.LocationFloat = new DevExpress.Utils.PointFloat(23.4068F, 213.7357F);
            this.departamento.Name = "departamento";
            this.departamento.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.departamento.SizeF = new System.Drawing.SizeF(174.4793F, 23F);
            this.departamento.StylePriority.UseBorders = false;
            this.departamento.StylePriority.UseFont = false;
            this.departamento.StylePriority.UseForeColor = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Font = new System.Drawing.Font("Leelawadee", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(23.40685F, 23.80209F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(174.4792F, 23F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Empresa fantasma";
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 275.3842F);
            this.xrPageBreak1.Name = "xrPageBreak1";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 100F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Credencial
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dataTable1});
            this.DataMember = "Table1";
            this.DataSource = this.dataSet1;
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel nombre_empleado;
        private DevExpress.XtraReports.UI.XRLabel no_empleado;
        private DevExpress.XtraReports.UI.XRLabel puesto;
        private DevExpress.XtraReports.UI.XRLabel departamento;
        private DevExpress.XtraReports.UI.XRPanel xrPanel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox2;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn empleado;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
    }
}
