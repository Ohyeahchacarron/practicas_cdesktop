namespace WFA_generador_codigo
{
    partial class Formulario_empleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formulario_empleado));
            this.tabla_empleados = new DevExpress.XtraGrid.GridControl();
            this.empleados_activos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.empleado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.departamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.puesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.no_empleado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fecha_ingreso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sueldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.medio_reclutamiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.boton_nuevo = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_empleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleados_activos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // tabla_empleados
            // 
            this.tabla_empleados.AllowDrop = true;
            this.tabla_empleados.Location = new System.Drawing.Point(12, 95);
            this.tabla_empleados.MainView = this.empleados_activos;
            this.tabla_empleados.Name = "tabla_empleados";
            this.tabla_empleados.Size = new System.Drawing.Size(1074, 336);
            this.tabla_empleados.TabIndex = 0;
            this.tabla_empleados.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.empleados_activos});
            // 
            // empleados_activos
            // 
            this.empleados_activos.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.empleados_activos.Appearance.EvenRow.Options.UseBackColor = true;
            this.empleados_activos.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Black;
            this.empleados_activos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empleados_activos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.empleados_activos.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.empleados_activos.Appearance.HeaderPanel.Options.UseFont = true;
            this.empleados_activos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.empleados_activos.Appearance.OddRow.BackColor = System.Drawing.Color.Silver;
            this.empleados_activos.Appearance.OddRow.Options.UseBackColor = true;
            this.empleados_activos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.empleado,
            this.departamento,
            this.puesto,
            this.no_empleado,
            this.fecha_ingreso,
            this.sueldo,
            this.medio_reclutamiento});
            this.empleados_activos.GridControl = this.tabla_empleados;
            this.empleados_activos.Name = "empleados_activos";
            this.empleados_activos.OptionsView.EnableAppearanceEvenRow = true;
            this.empleados_activos.OptionsView.EnableAppearanceOddRow = true;
            this.empleados_activos.OptionsView.ShowGroupPanel = false;
            this.empleados_activos.PaintStyleName = "Flat";
            // 
            // empleado
            // 
            this.empleado.AppearanceHeader.BackColor = System.Drawing.Color.Black;
            this.empleado.AppearanceHeader.Options.UseBackColor = true;
            this.empleado.Caption = "Empleado";
            this.empleado.FieldName = "empleado";
            this.empleado.Name = "empleado";
            this.empleado.OptionsColumn.AllowEdit = false;
            this.empleado.Visible = true;
            this.empleado.VisibleIndex = 0;
            // 
            // departamento
            // 
            this.departamento.Caption = "Departamento";
            this.departamento.FieldName = "departamento";
            this.departamento.Name = "departamento";
            this.departamento.OptionsColumn.AllowEdit = false;
            this.departamento.Visible = true;
            this.departamento.VisibleIndex = 1;
            // 
            // puesto
            // 
            this.puesto.Caption = "Puesto";
            this.puesto.FieldName = "puesto";
            this.puesto.Name = "puesto";
            this.puesto.OptionsColumn.AllowEdit = false;
            this.puesto.Visible = true;
            this.puesto.VisibleIndex = 2;
            // 
            // no_empleado
            // 
            this.no_empleado.Caption = "No. de empleado";
            this.no_empleado.FieldName = "no_empleado";
            this.no_empleado.Name = "no_empleado";
            this.no_empleado.OptionsColumn.AllowEdit = false;
            this.no_empleado.Visible = true;
            this.no_empleado.VisibleIndex = 3;
            // 
            // fecha_ingreso
            // 
            this.fecha_ingreso.Caption = "Fecha de ingreso";
            this.fecha_ingreso.FieldName = "fecha_ingreso";
            this.fecha_ingreso.Name = "fecha_ingreso";
            this.fecha_ingreso.OptionsColumn.AllowEdit = false;
            this.fecha_ingreso.Visible = true;
            this.fecha_ingreso.VisibleIndex = 4;
            // 
            // sueldo
            // 
            this.sueldo.Caption = "Sueldo";
            this.sueldo.DisplayFormat.FormatString = "{0:$0}";
            this.sueldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.sueldo.FieldName = "sueldo";
            this.sueldo.Name = "sueldo";
            this.sueldo.OptionsColumn.AllowEdit = false;
            this.sueldo.Visible = true;
            this.sueldo.VisibleIndex = 5;
            // 
            // medio_reclutamiento
            // 
            this.medio_reclutamiento.Caption = "Medio de reclutamiento";
            this.medio_reclutamiento.FieldName = "medio_reclutamiento";
            this.medio_reclutamiento.Name = "medio_reclutamiento";
            this.medio_reclutamiento.OptionsColumn.AllowEdit = false;
            this.medio_reclutamiento.Visible = true;
            this.medio_reclutamiento.VisibleIndex = 6;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.boton_nuevo);
            this.layoutControl1.Controls.Add(this.tabla_empleados);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1098, 493);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Black;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.LookAndFeel.SkinMaskColor = System.Drawing.Color.Black;
            this.panelControl1.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Black;
            this.panelControl1.LookAndFeel.SkinName = "Office 2013";
            this.panelControl1.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.False;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1074, 79);
            this.panelControl1.TabIndex = 6;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = global::WFA_generador_codigo.Properties.Resources.ati;
            this.pictureEdit1.Location = new System.Drawing.Point(987, 5);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(72, 69);
            this.pictureEdit1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(21, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(327, 41);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Lista de empleados";
            // 
            // boton_nuevo
            // 
            this.boton_nuevo.Appearance.BackColor = System.Drawing.Color.Black;
            this.boton_nuevo.Appearance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_nuevo.Appearance.ForeColor = System.Drawing.Color.White;
            this.boton_nuevo.Appearance.Options.UseBackColor = true;
            this.boton_nuevo.Appearance.Options.UseFont = true;
            this.boton_nuevo.Appearance.Options.UseForeColor = true;
            this.boton_nuevo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.boton_nuevo.Location = new System.Drawing.Point(921, 445);
            this.boton_nuevo.Name = "boton_nuevo";
            this.boton_nuevo.Size = new System.Drawing.Size(136, 26);
            this.boton_nuevo.TabIndex = 4;
            this.boton_nuevo.Text = "Nuevo ingreso";
            this.boton_nuevo.Click += new System.EventHandler(this.boton_nuevo_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.layoutControlItem3,
            this.emptySpaceItem6,
            this.emptySpaceItem2,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1098, 493);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.tabla_empleados;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 83);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1078, 340);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(1049, 433);
            this.emptySpaceItem4.MaxSize = new System.Drawing.Size(0, 30);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(29, 30);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 433);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(909, 30);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.boton_nuevo;
            this.layoutControlItem3.Location = new System.Drawing.Point(909, 433);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(140, 30);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(0, 423);
            this.emptySpaceItem6.MaxSize = new System.Drawing.Size(0, 12);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(1078, 10);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 463);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(1078, 10);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.panelControl1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(5, 5);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1078, 83);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // Formulario_empleado
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 493);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1114, 376);
            this.Name = "Formulario_empleado";
            this.Text = "Registro de empleados";
            ((System.ComponentModel.ISupportInitialize)(this.tabla_empleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleados_activos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl tabla_empleados;
        private DevExpress.XtraGrid.Views.Grid.GridView empleados_activos;
        private DevExpress.XtraGrid.Columns.GridColumn empleado;
        private DevExpress.XtraGrid.Columns.GridColumn departamento;
        private DevExpress.XtraGrid.Columns.GridColumn puesto;
        private DevExpress.XtraGrid.Columns.GridColumn no_empleado;
        private DevExpress.XtraGrid.Columns.GridColumn fecha_ingreso;
        private DevExpress.XtraGrid.Columns.GridColumn sueldo;
        private DevExpress.XtraGrid.Columns.GridColumn medio_reclutamiento;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton boton_nuevo;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}