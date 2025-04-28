namespace WFA_generador_codigo
{
    partial class Formulario_arbol
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.arbol_proyectos = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.arbol_proyectos)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(199, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(112, 26);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Proyectos";
            // 
            // arbol_proyectos
            // 
            this.arbol_proyectos.Location = new System.Drawing.Point(37, 101);
            this.arbol_proyectos.Name = "arbol_proyectos";
            this.arbol_proyectos.Size = new System.Drawing.Size(427, 254);
            this.arbol_proyectos.TabIndex = 2;
            // 
            // Formulario_arbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 421);
            this.Controls.Add(this.arbol_proyectos);
            this.Controls.Add(this.labelControl1);
            this.Name = "Formulario_arbol";
            this.Text = "Formulario_arbol";
            ((System.ComponentModel.ISupportInitialize)(this.arbol_proyectos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTreeList.TreeList arbol_proyectos;
    }
}