using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundaEntrega_Calculo
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Procesando...";
            this.Width = 250;
            this.Height = 100;

            Label lbl = new Label();
            lbl.Text = "Por favor espere...";
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Segoe UI", 10);
            this.Controls.Add(lbl);

            ProgressBar bar = new ProgressBar();
            bar.Style = ProgressBarStyle.Marquee;
            bar.Dock = DockStyle.Bottom;
            this.Controls.Add(bar);

        }
    }
}
