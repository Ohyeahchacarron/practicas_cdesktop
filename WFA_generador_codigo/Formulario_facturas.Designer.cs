namespace WFA_generador_codigo
{
    partial class Formulario_facturas
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.folio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pagado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.estatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id_cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.razon_social = new DevExpress.XtraGrid.Columns.GridColumn();
            this.credito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deuda_total = new DevExpress.XtraGrid.Columns.GridColumn();
            this.limite_disponible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.porcentaje_vencido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barra_vencido = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.porcentaje_deuda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barra_deuda = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.porcentaje_vencido_total = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barra_vencido_t = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id_factura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id_producto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.precio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.total = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barra_vencido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barra_deuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barra_vencido_t)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.folio,
            this.fecha,
            this.pagado,
            this.estatus});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id_factura";
            this.id.Name = "id";
            this.id.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // folio
            // 
            this.folio.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.folio.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.folio.AppearanceHeader.Options.UseBackColor = true;
            this.folio.AppearanceHeader.Options.UseForeColor = true;
            this.folio.Caption = "folio";
            this.folio.FieldName = "folio";
            this.folio.Name = "folio";
            this.folio.OptionsColumn.AllowEdit = false;
            this.folio.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.folio.Visible = true;
            this.folio.VisibleIndex = 0;
            // 
            // fecha
            // 
            this.fecha.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.fecha.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.fecha.AppearanceHeader.Options.UseBackColor = true;
            this.fecha.AppearanceHeader.Options.UseForeColor = true;
            this.fecha.Caption = "fecha";
            this.fecha.FieldName = "fecha";
            this.fecha.Name = "fecha";
            this.fecha.OptionsColumn.AllowEdit = false;
            this.fecha.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.fecha.Visible = true;
            this.fecha.VisibleIndex = 1;
            // 
            // pagado
            // 
            this.pagado.AppearanceHeader.BackColor = System.Drawing.Color.Transparent;
            this.pagado.AppearanceHeader.ForeColor = System.Drawing.Color.Transparent;
            this.pagado.AppearanceHeader.Options.UseBackColor = true;
            this.pagado.AppearanceHeader.Options.UseForeColor = true;
            this.pagado.Caption = "pagado";
            this.pagado.FieldName = "pagado";
            this.pagado.Name = "pagado";
            this.pagado.OptionsColumn.AllowEdit = false;
            this.pagado.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // estatus
            // 
            this.estatus.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.estatus.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.estatus.AppearanceHeader.Options.UseBackColor = true;
            this.estatus.AppearanceHeader.Options.UseForeColor = true;
            this.estatus.Caption = "estatus";
            this.estatus.FieldName = "estatus";
            this.estatus.Name = "estatus";
            this.estatus.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.estatus.Visible = true;
            this.estatus.VisibleIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.gridControl1.EmbeddedNavigator.UseWaitCursor = true;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode2.LevelTemplate = this.gridView3;
            gridLevelNode2.RelationName = "Level2";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(24, 68);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.barra_vencido,
            this.barra_deuda,
            this.barra_vencido_t});
            this.gridControl1.Size = new System.Drawing.Size(668, 319);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseWaitCursor = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView3,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id_cliente,
            this.razon_social,
            this.credito,
            this.deuda_total,
            this.limite_disponible,
            this.porcentaje_vencido,
            this.porcentaje_deuda,
            this.porcentaje_vencido_total});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // id_cliente
            // 
            this.id_cliente.Caption = "id";
            this.id_cliente.Name = "id_cliente";
            // 
            // razon_social
            // 
            this.razon_social.AppearanceHeader.BackColor = System.Drawing.Color.Black;
            this.razon_social.AppearanceHeader.BackColor2 = System.Drawing.Color.Black;
            this.razon_social.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.razon_social.AppearanceHeader.Options.UseForeColor = true;
            this.razon_social.Caption = "razon social";
            this.razon_social.FieldName = "razon_social";
            this.razon_social.Name = "razon_social";
            this.razon_social.OptionsColumn.AllowEdit = false;
            this.razon_social.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.razon_social.Visible = true;
            this.razon_social.VisibleIndex = 0;
            // 
            // credito
            // 
            this.credito.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.credito.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.credito.AppearanceHeader.Options.UseBackColor = true;
            this.credito.AppearanceHeader.Options.UseForeColor = true;
            this.credito.Caption = "credito";
            this.credito.FieldName = "credito";
            this.credito.Name = "credito";
            this.credito.OptionsColumn.AllowEdit = false;
            this.credito.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.credito.Visible = true;
            this.credito.VisibleIndex = 1;
            // 
            // deuda_total
            // 
            this.deuda_total.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.deuda_total.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.deuda_total.AppearanceHeader.Options.UseBackColor = true;
            this.deuda_total.AppearanceHeader.Options.UseForeColor = true;
            this.deuda_total.Caption = "saldo pendiente";
            this.deuda_total.FieldName = "deuda_total";
            this.deuda_total.Name = "deuda_total";
            this.deuda_total.OptionsColumn.AllowEdit = false;
            this.deuda_total.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.deuda_total.Visible = true;
            this.deuda_total.VisibleIndex = 2;
            // 
            // limite_disponible
            // 
            this.limite_disponible.AppearanceHeader.BackColor = System.Drawing.Color.Gray;
            this.limite_disponible.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.limite_disponible.AppearanceHeader.Options.UseBackColor = true;
            this.limite_disponible.AppearanceHeader.Options.UseForeColor = true;
            this.limite_disponible.Caption = "limte disponible";
            this.limite_disponible.FieldName = "limite_disponible";
            this.limite_disponible.Name = "limite_disponible";
            this.limite_disponible.OptionsColumn.AllowEdit = false;
            this.limite_disponible.Visible = true;
            this.limite_disponible.VisibleIndex = 3;
            // 
            // porcentaje_vencido
            // 
            this.porcentaje_vencido.Caption = "% de facturas vencida";
            this.porcentaje_vencido.ColumnEdit = this.barra_vencido;
            this.porcentaje_vencido.FieldName = "porcentaje_vencido";
            this.porcentaje_vencido.Name = "porcentaje_vencido";
            this.porcentaje_vencido.Visible = true;
            this.porcentaje_vencido.VisibleIndex = 4;
            // 
            // barra_vencido
            // 
            this.barra_vencido.Name = "barra_vencido";
            // 
            // porcentaje_deuda
            // 
            this.porcentaje_deuda.Caption = "% de deuda";
            this.porcentaje_deuda.ColumnEdit = this.barra_deuda;
            this.porcentaje_deuda.FieldName = "porcentaje_deuda";
            this.porcentaje_deuda.Name = "porcentaje_deuda";
            this.porcentaje_deuda.Visible = true;
            this.porcentaje_deuda.VisibleIndex = 5;
            // 
            // barra_deuda
            // 
            this.barra_deuda.Name = "barra_deuda";
            // 
            // porcentaje_vencido_total
            // 
            this.porcentaje_vencido_total.Caption = "% vencido total";
            this.porcentaje_vencido_total.ColumnEdit = this.barra_vencido_t;
            this.porcentaje_vencido_total.FieldName = "porcentaje_vencido_total";
            this.porcentaje_vencido_total.Name = "porcentaje_vencido_total";
            this.porcentaje_vencido_total.Visible = true;
            this.porcentaje_vencido_total.VisibleIndex = 6;
            // 
            // barra_vencido_t
            // 
            this.barra_vencido_t.Name = "barra_vencido_t";
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id_factura,
            this.id_producto,
            this.precio,
            this.cantidad,
            this.total});
            this.gridView3.GridControl = this.gridControl1;
            this.gridView3.Name = "gridView3";
            // 
            // id_factura
            // 
            this.id_factura.Caption = "id_factura";
            this.id_factura.Name = "id_factura";
            // 
            // id_producto
            // 
            this.id_producto.Caption = "Id producto";
            this.id_producto.Name = "id_producto";
            this.id_producto.Visible = true;
            this.id_producto.VisibleIndex = 0;
            // 
            // precio
            // 
            this.precio.Caption = "precio";
            this.precio.Name = "precio";
            this.precio.Visible = true;
            this.precio.VisibleIndex = 1;
            // 
            // cantidad
            // 
            this.cantidad.Caption = "cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.Visible = true;
            this.cantidad.VisibleIndex = 2;
            // 
            // total
            // 
            this.total.Caption = "total";
            this.total.Name = "total";
            this.total.Visible = true;
            this.total.VisibleIndex = 3;
            // 
            // Formulario_facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 449);
            this.Controls.Add(this.gridControl1);
            this.Name = "Formulario_facturas";
            this.Text = "Formulario_facturas";
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barra_vencido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barra_deuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barra_vencido_t)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn folio;
        private DevExpress.XtraGrid.Columns.GridColumn fecha;
        private DevExpress.XtraGrid.Columns.GridColumn estatus;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn razon_social;
        private DevExpress.XtraGrid.Columns.GridColumn credito;
        private DevExpress.XtraGrid.Columns.GridColumn deuda_total;
        private DevExpress.XtraGrid.Columns.GridColumn limite_disponible;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn id_cliente;
        private DevExpress.XtraGrid.Columns.GridColumn pagado;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn id_factura;
        private DevExpress.XtraGrid.Columns.GridColumn id_producto;
        private DevExpress.XtraGrid.Columns.GridColumn precio;
        private DevExpress.XtraGrid.Columns.GridColumn cantidad;
        private DevExpress.XtraGrid.Columns.GridColumn total;
        private DevExpress.XtraGrid.Columns.GridColumn porcentaje_vencido;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar barra_vencido;
        private DevExpress.XtraGrid.Columns.GridColumn porcentaje_deuda;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar barra_deuda;
        private DevExpress.XtraGrid.Columns.GridColumn porcentaje_vencido_total;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar barra_vencido_t;
    }
}