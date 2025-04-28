namespace WFA_generador_codigo
{
    partial class formulario_colores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formulario_colores));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id_talla_tipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id_color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.color_combo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.foto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.foto_producto = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.boton_guardar = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_combo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foto_producto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton_guardar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(36, 22);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.color_combo,
            this.foto_producto});
            this.gridControl1.Size = new System.Drawing.Size(400, 200);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.descripcion,
            this.id_talla_tipo,
            this.id_color,
            this.foto});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.Caption = "id_producto";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // descripcion
            // 
            this.descripcion.Caption = "descripcion";
            this.descripcion.FieldName = "descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.OptionsColumn.AllowEdit = false;
            this.descripcion.Visible = true;
            this.descripcion.VisibleIndex = 0;
            // 
            // id_talla_tipo
            // 
            this.id_talla_tipo.Caption = "Id talla tipo";
            this.id_talla_tipo.FieldName = "id_talla_tipo";
            this.id_talla_tipo.Name = "id_talla_tipo";
            this.id_talla_tipo.OptionsColumn.AllowEdit = false;
            this.id_talla_tipo.Visible = true;
            this.id_talla_tipo.VisibleIndex = 1;
            // 
            // id_color
            // 
            this.id_color.Caption = "Color";
            this.id_color.ColumnEdit = this.color_combo;
            this.id_color.FieldName = "id_color";
            this.id_color.Name = "id_color";
            this.id_color.Visible = true;
            this.id_color.VisibleIndex = 2;
            // 
            // color_combo
            // 
            this.color_combo.AutoHeight = false;
            this.color_combo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.color_combo.Name = "color_combo";
            // 
            // foto
            // 
            this.foto.Caption = "Foto";
            this.foto.ColumnEdit = this.foto_producto;
            this.foto.FieldName = "foto";
            this.foto.Name = "foto";
            this.foto.Visible = true;
            this.foto.VisibleIndex = 3;
            // 
            // foto_producto
            // 
            this.foto_producto.Name = "foto_producto";
            // 
            // boton_guardar
            // 
            this.boton_guardar.Cursor = System.Windows.Forms.Cursors.Default;
            this.boton_guardar.EditValue = ((object)(resources.GetObject("boton_guardar.EditValue")));
            this.boton_guardar.Location = new System.Drawing.Point(388, 244);
            this.boton_guardar.Name = "boton_guardar";
            this.boton_guardar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.boton_guardar.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.boton_guardar.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.boton_guardar.Size = new System.Drawing.Size(48, 57);
            this.boton_guardar.TabIndex = 1;
            this.boton_guardar.Click += new System.EventHandler(this.boton_guardar_Click);
            // 
            // formulario_colores
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 321);
            this.Controls.Add(this.boton_guardar);
            this.Controls.Add(this.gridControl1);
            this.Name = "formulario_colores";
            this.Text = "formulario_colores";
            this.Load += new System.EventHandler(this.formulario_colores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_combo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foto_producto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boton_guardar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn id_color;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn id_talla_tipo;
        private DevExpress.XtraEditors.PictureEdit boton_guardar;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit color_combo;
        private DevExpress.XtraGrid.Columns.GridColumn foto;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit foto_producto;
    }
}