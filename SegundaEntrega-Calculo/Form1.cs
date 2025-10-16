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
                var funcionTxt = txtFuncion.Text.Trim();

                if (string.IsNullOrEmpty(funcionTxt))
                {
                    MessageBox.Show("Ingrese una funcion valida");
                    return;
                }

                Entity funcion = MathS.FromString(funcionTxt);
                var x = MathS.Var("x");



                var primeraDerivada = funcion.Derive(x).Simplify();
                var segundaDerivada = primeraDerivada.Derive(x).Simplify();

                //Fuerzo reodernamiento y limpieza de signos

                primeraDerivada = primeraDerivada.Simplify();
                segundaDerivada = segundaDerivada.Simplify();


                Resul_Derivada.Text = $"f'(x) = {primeraDerivada}\r\n" +
                $"f''(x) = {segundaDerivada}";



                //Calculo de punto criticos de la derivada 1

                var puntosCriticos = MathS.SolveEquation(primeraDerivada, x);

                if (puntosCriticos != null)
                {
                    Resul_PuntoCritico.Text = $"x => {puntosCriticos.Simplify()}";
                }
                else
                {
                    Resul_PuntoCritico.Text = "No hay puntos criticos";
                }

                //Calculo de punto inflexion en la derivada 2
                var puntosInflexion = MathS.SolveEquation(segundaDerivada, x);

                Resul_Inflexion.Text = $"x = {puntosInflexion}";

                // Calculo de crecimiento y decrecimiento
                try
                {
                    string resultado = "";
                    double[] puntos = { -10, -1, 0, 1, 10 };

                    foreach (var valorX in puntos)
                    {
                        var valorEntity = primeraDerivada.Substitute(x, valorX).EvalNumerical();
                        double valor = (double)valorEntity.RealPart;

                        if (valor > 0)
                            resultado += $"f'(x) > 0 en x={valorX} → Crece\r\n";
                        else if (valor < 0)
                            resultado += $"f'(x) < 0 en x={valorX} → Decrece\r\n";
                        else
                            resultado += $"f'(x) = 0 en x={valorX}\r\n";
                    }

                    Resul_CrecDecre.Text = resultado;
                }
                catch
                {
                    Resul_CrecDecre.Text = "No se pudo calcular crecimiento/decrecimiento";
                }




                // Calculo de concavidad
                try
                {
                    string resultado = "";
                    double[] puntos = { -10, -1, 0, 1, 10 };

                    foreach (var valorX in puntos)
                    {
                        var valorEntity = segundaDerivada.Substitute(x, valorX).EvalNumerical();
                        double valor = (double)valorEntity.RealPart;

                        if (valor > 0)
                            resultado += $"f''(x) > 0 en x={valorX} → Cóncava hacia arriba\r\n";
                        else if (valor < 0)
                            resultado += $"f''(x) < 0 en x={valorX} → Cóncava hacia abajo\r\n";
                        else
                            resultado += $"f''(x) = 0 en x={valorX} → Punto de inflexión\r\n";
                    }

                    ResulConcavidad.Text = resultado;
                }
                catch
                {
                    ResulConcavidad.Text = "No se pudo calcular la concavidad";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al analizar la función: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            Info form = new Info();
            form.ShowDialog();
        }
    }
}

