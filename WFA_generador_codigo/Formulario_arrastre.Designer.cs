namespace WFA_generador_codigo
{
    partial class Formulario_arrastre
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabla_todo_empleados = new DevExpress.XtraGrid.GridControl();
            this.all_empleados = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.no_empleado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.empleado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabla_nuevo_empleados = new DevExpress.XtraGrid.GridControl();
            this.news_empleados = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nu_empleado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.empleados = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_todo_empleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.all_empleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_nuevo_empleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.news_empleados)).BeginInit();
            this.SuspendLayout();
            // 
            // tabla_todo_empleados
            // 
            this.tabla_todo_empleados.AllowDrop = true;
            this.tabla_todo_empleados.Location = new System.Drawing.Point(21, 99);
            this.tabla_todo_empleados.MainView = this.all_empleados;
            this.tabla_todo_empleados.Name = "tabla_todo_empleados";
            this.tabla_todo_empleados.Size = new System.Drawing.Size(263, 311);
            this.tabla_todo_empleados.TabIndex = 0;
            this.tabla_todo_empleados.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.all_empleados});
            // 
            // all_empleados
            // 
            this.all_empleados.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.no_empleado,
            this.empleado});
            this.all_empleados.GridControl = this.tabla_todo_empleados;
            this.all_empleados.Name = "all_empleados";
            this.all_empleados.OptionsView.ShowGroupPanel = false;
            this.all_empleados.PaintStyleName = "Web";
            // 
            // no_empleado
            // 
            this.no_empleado.Caption = "ID";
            this.no_empleado.FieldName = "no_empleado";
            this.no_empleado.Name = "no_empleado";
            this.no_empleado.Visible = true;
            this.no_empleado.VisibleIndex = 0;
            this.no_empleado.Width = 30;
            // 
            // empleado
            // 
            this.empleado.Caption = "Empleado";
            this.empleado.FieldName = "empleado";
            this.empleado.Name = "empleado";
            this.empleado.Visible = true;
            this.empleado.VisibleIndex = 1;
            // 
            // tabla_nuevo_empleados
            // 
            this.tabla_nuevo_empleados.Location = new System.Drawing.Point(336, 99);
            this.tabla_nuevo_empleados.MainView = this.news_empleados;
            this.tabla_nuevo_empleados.Name = "tabla_nuevo_empleados";
            this.tabla_nuevo_empleados.Size = new System.Drawing.Size(293, 311);
            this.tabla_nuevo_empleados.TabIndex = 1;
            this.tabla_nuevo_empleados.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.news_empleados});
            // 
            // news_empleados
            // 
            this.news_empleados.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nu_empleado,
            this.empleados});
            this.news_empleados.GridControl = this.tabla_nuevo_empleados;
            this.news_empleados.Name = "news_empleados";
            this.news_empleados.OptionsView.ShowGroupPanel = false;
            this.news_empleados.PaintStyleName = "Web";
            // 
            // nu_empleado
            // 
            this.nu_empleado.Caption = "ID";
            this.nu_empleado.FieldName = "no_empleado";
            this.nu_empleado.Name = "nu_empleado";
            this.nu_empleado.Visible = true;
            this.nu_empleado.VisibleIndex = 0;
            this.nu_empleado.Width = 78;
            // 
            // empleados
            // 
            this.empleados.Caption = "Empleado";
            this.empleados.FieldName = "empleado";
            this.empleados.Name = "empleados";
            this.empleados.Visible = true;
            this.empleados.VisibleIndex = 1;
            this.empleados.Width = 200;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(235, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(157, 23);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Nuevos empleados";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(99, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Todos los empleados";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(336, 77);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Arrastre aquí";
            // 
            // Formulario_arrastre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 428);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tabla_nuevo_empleados);
            this.Controls.Add(this.tabla_todo_empleados);
            this.Name = "Formulario_arrastre";
            this.Text = "Formulario_arrastre";
            this.Load += new System.EventHandler(this.Formulario_arrastre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_todo_empleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.all_empleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_nuevo_empleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.news_empleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl tabla_todo_empleados;
        private DevExpress.XtraGrid.Views.Grid.GridView all_empleados;
        private DevExpress.XtraGrid.GridControl tabla_nuevo_empleados;
        private DevExpress.XtraGrid.Views.Grid.GridView news_empleados;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn no_empleado;
        private DevExpress.XtraGrid.Columns.GridColumn empleado;
        private DevExpress.XtraGrid.Columns.GridColumn nu_empleado;
        private DevExpress.XtraGrid.Columns.GridColumn empleados;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}