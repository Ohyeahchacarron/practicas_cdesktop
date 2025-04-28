using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WFA_generador_codigo
{
    public partial class Credencial : DevExpress.XtraReports.UI.XtraReport
    {
        public Credencial()
        {
            InitializeComponent();
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            this.xrPictureBox1.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter;
        }

    }
}
