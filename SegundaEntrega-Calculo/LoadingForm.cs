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
            InitializeComponent(); // Inicializa los componentes del formulario

            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Evita que se cambie el tamaño del formulario
            this.ControlBox = false; // Oculta los botones de minimizar, maximizar y cerrar
            this.StartPosition = FormStartPosition.CenterScreen; // Centra el formulario en la pantalla
            this.Text = "Procesando..."; // Título del formulario
            this.Width = 250; // Ancho del formulario
            this.Height = 100; // Alto del formulario

            // Crear y configurar etiqueta con mensaje
            Label lbl = new Label();
            lbl.Text = "Por favor espere..."; // Mensaje que verá el usuario
            lbl.Dock = DockStyle.Fill; // Ocupa todo el formulario
            lbl.TextAlign = ContentAlignment.MiddleCenter; // Centra el texto
            lbl.Font = new Font("Segoe UI", 10); // Fuente y tamaño
            this.Controls.Add(lbl); // Agrega la etiqueta al formulario

            // Crear y configurar barra de progreso
            ProgressBar bar = new ProgressBar();
            bar.Style = ProgressBarStyle.Marquee; // Animación continua, sin valor fijo
            bar.Dock = DockStyle.Bottom; // Se ubica en la parte inferior
            this.Controls.Add(bar); // Agrega la barra al formulario
        

        }
    }
}
