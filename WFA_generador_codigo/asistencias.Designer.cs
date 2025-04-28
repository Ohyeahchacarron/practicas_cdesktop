namespace WFA_generador_codigo
{
    partial class asistencias
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.empleado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(43, 43);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(400, 200);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.empleado,
            this.fecha});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // empleado
            // 
            this.empleado.Caption = "Empleado";
            this.empleado.FieldName = "empleado";
            this.empleado.Name = "empleado";
            this.empleado.Visible = true;
            this.empleado.VisibleIndex = 0;
            // 
            // fecha
            // 
            this.fecha.Caption = "Fecha";
            this.fecha.FieldName = "fecha";
            this.fecha.Name = "fecha";
            this.fecha.Visible = true;
            this.fecha.VisibleIndex = 1;
            // 
            // Status
            // 
            this.Status.Appearance.Font = new System.Drawing.Font("Yu Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Status.Appearance.Options.UseFont = true;
            this.Status.Appearance.Options.UseForeColor = true;
            this.Status.Location = new System.Drawing.Point(15, 14);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(132, 25);
            this.Status.TabIndex = 7;
            this.Status.Text = "labelControl1";
            // 
            // asistencias
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Status);
            this.Controls.Add(this.gridControl1);
            this.Name = "asistencias";
            this.Size = new System.Drawing.Size(457, 250);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn empleado;
        private DevExpress.XtraGrid.Columns.GridColumn fecha;
        private DevExpress.XtraEditors.LabelControl Status;
    }
}
