using AngouriMath;
using AngouriMath.Extensions;

namespace SegundaEntrega_Calculo
{
    public partial class Form1 : Form
    {
        // Variable para almacenar la primera derivada de la funci�n como Entity (para poder evaluarla m�s adelante)
        Entity derivadaEntity = null;
        // Variable para guardar la primera derivada como string (para mostrarla en el Label)
        string derivada = "";
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

                var funcionProcesada = funcion.ToEntity().Simplify();

                // Verifica que la funcion sea valida y que contenga la variable 'x'
                if (!funcionProcesada.Vars.Contains("x"))
                {
                    MessageBox.Show("La funci�n debe contener la variable 'x'");
                    return;
                }

                //Se calculan derviadas de nivel 1 y 2
                derivadaEntity = funcionProcesada.Derive("x"); // primera derivada como Entity
                derivada = derivadaEntity.ToString().Trim();
                var derivada2 = derivadaEntity.Derive("x").ToString().Trim();


                Resul_Derivada.Text = $"f'(x) = {derivada}\nf''(x) = {derivada2}";



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

                // Calculo de crecimiento y decrecimiento
                try
                {
                    //Se convierte la primera derivada a un objeto Entity para poder evaluar su valor en diferentes puntos
                    var derivadaEntity1 = derivada.ToEntity(); // convertimos la primera derivada a Entity
                    string resultado = "";
                    //Definimos algunos puntos de prueba para analizar el comportamiento de la funci�n
                    double[] puntos = { -10, -1, 0, 1, 10 };
                    foreach (var x in puntos)
                    {
                        //Evaluamos el valor de la derivada en el punto x   
                        var valorEntity = derivadaEntity1.Substitute("x", x).EvalNumerical();

                        //Convertimos el valor a double para poder compararlo
                        double valor = (double)valorEntity;

                        //Se determina si la funcion crece, decrece o tiene un punto critico
                        if (valor > 0)
                            resultado += $"f'(x) > 0 en x={x} => Crece\n";
                        else if (valor < 0)
                            resultado += $"f'(x) < 0 en x={x} => Decrece\n";
                        else
                            resultado += $"f'(x) = 0 en x={x}\n";
                    }
                    // Mostramos el resultado en el Label5 del formulario
                    label5.Text = resultado;
                }
                catch
                {
                    // En caso de error, mostramos un mensaje de aviso
                    label5.Text = "No se pudo calcular crecimiento/decrecimiento";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al analizar la funci�n: {ex.Message}");
            }

            // Calculo de concavidad
            try
            {
                // Obtenemos la segunda derivada de la funci�n
                // La segunda derivada nos indica c�mo cambia la pendiente de la funci�n:
                // si es positiva, la funci�n es c�ncava hacia arriba; si es negativa, c�ncava hacia abajo.
                var derivada2Entity = derivadaEntity.Derive("x"); // segunda derivada
                string resultado = "";


                //Se define un conjunto de puntos para evaluar la concavidad
                double[] puntos = { -10, -1, 0, 1, 10 };
                //Se recorre cada punto para evaluar la segunda derivada
                foreach (var x in puntos)
                {
                    // Sustituimos el valor de x en la segunda derivada y evaluamos num�ricamente
                    var valorEntity = derivada2Entity.Substitute("x", x).EvalNumerical();

                    // Convertimos el valor a double
                    double valor = (double)valorEntity;

                    // Dependiendo del signo de f''(x) determinamos la concavidad
                    if (valor > 0)
                        resultado += $"f''(x) > 0 en x={x} => C�ncava hacia arriba\n"; //pendiente creciente
                    else if (valor < 0)
                        resultado += $"f''(x) < 0 en x={x} => C�ncava hacia abajo\n"; //pendiente decreciente
                    else
                        resultado += $"f''(x) = 0 en x={x} => Punto de inflexi�n\n"; // posible cambio de concavidad
                }
                // Mostramos todos los resultados en el Label6 del formulario
                label6.Text = resultado;
            }
            catch
            {
                // Si ocurre alg�n error (por ejemplo, funci�n inv�lida o divisi�n por cero), mostramos un mensaje
                label6.Text = "No se pudo calcular la concavidad";
            }

        }
    }
}
