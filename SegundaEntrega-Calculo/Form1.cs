using AngouriMath;
using AngouriMath.Extensions;

namespace SegundaEntrega_Calculo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                //Ingreso de funcion
                var funcion = txtFuncion.Text.Trim();

                if (string.IsNullOrEmpty(funcion))
                {
                    MessageBox.Show("Ingrese una funcion valida");
                    return;
                }

                var funcionProcesada = funcion.ToEntity();

                //Se calculan derviadas de nivel 1 y 2
                var derivada = funcionProcesada.Derive("x").ToString().Trim();
                var derivada2 = derivada.Derive("x").ToString().Trim();


                Resul_Derivada.Text = $"f(x) = {derivada}\n\nf(x) = {derivada2}";


                //Calculo de punto criticos de la derivada 1
                var puntosCriticos = MathS.SolveEquation(derivada, "x");

                if (puntosCriticos != null)
                {
                    Resul_PuntoCritico.Text = $"x => {puntosCriticos}";
                }
                else
                {
                    Resul_PuntoCritico.Text = "No hay puntos criticos";
                }

                //Calculo de punto inflexion en la derivada 2
                var puntosInflexion = MathS.SolveEquation(derivada2, "x");

                Resul_Inflexion.Text = $"x = {puntosInflexion}";



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al analizar la función: {ex.Message}");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
