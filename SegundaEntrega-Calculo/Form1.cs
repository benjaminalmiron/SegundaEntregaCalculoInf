using AngouriMath;
using AngouriMath.Extensions;

namespace SegundaEntrega_Calculo
{
    public partial class Form1 : Form
    {
<<<<<<< HEAD

=======
>>>>>>> 8a6a432f4ee0e2bbe4f3a26afd7a89f235aba922
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            try
            {
                //Ingreso de funcion
                var funcionTxt = txtFuncion.Text.Trim();

                if (string.IsNullOrEmpty(funcionTxt))
=======
            // Variables para almacenar la función y sus derivadas
            Entity funcion = Entity.Number.Integer.Zero;
            Entity derivada = Entity.Number.Integer.Zero;
            Entity derivada_segunda = Entity.Number.Integer.Zero;

            // Esta lista se usará para calcular los intervalos de crecimiento y decrecimiento
            double[] listaPuntosCriticos = new double[0];
            double[] listaPuntosInflexion = new double[0];

            //try
            {
                // Ingreso de funcion
                string funcion_texto = txtFuncion.Text.Trim();

                // Verifica que el campo de texto no esté vacío
                if (string.IsNullOrEmpty(funcion_texto))
>>>>>>> 8a6a432f4ee0e2bbe4f3a26afd7a89f235aba922
                {
                    MessageBox.Show("Ingrese una funcion valida");
                    return;
                }

<<<<<<< HEAD
                Entity funcion = MathS.FromString(funcionTxt);
                var x = MathS.Var("x");
=======
                // Convierte el texto de la función a un objeto Entity de AngouriMath y simplifica la expresión
                // Lei que simplificar la funcion ayuda a evitar errores en el calculo de derivadas
                funcion = funcion_texto.ToEntity().Simplify();

                // Verifica que la funcion sea valida y que contenga la variable 'x'
                // Esto es util para evitar que se ponga como funcion expresiones no matematicas
                if (!funcion.Vars.Contains("x"))
                {
                    MessageBox.Show("La función debe contener la variable 'x'");
                    return;
                }
>>>>>>> 8a6a432f4ee0e2bbe4f3a26afd7a89f235aba922

                // En las variables se mantienen los objetos entity, no las versiones de texto

<<<<<<< HEAD

                var primeraDerivada = funcion.Derive(x).Simplify();
                var segundaDerivada = primeraDerivada.Derive(x).Simplify();

                //Fuerzo reodernamiento y limpieza de signos

                primeraDerivada = primeraDerivada.Simplify();
                segundaDerivada = segundaDerivada.Simplify();


                Resul_Derivada.Text = $"f'(x) = {primeraDerivada}\r\n" +
                $"f''(x) = {segundaDerivada}";
=======
                // Calculo de la primera derivada
                derivada = funcion.Differentiate("x").Simplify();
>>>>>>> 8a6a432f4ee0e2bbe4f3a26afd7a89f235aba922

                // Si la derivada es cero, la función es constante o no depende de 'x'
                if (derivada == Entity.Number.Integer.Zero)
                {
                    MessageBox.Show("La función ingresada es constante o no contiene 'x'");
                    return;
                }

                // Calculo de la segunda derivada
                derivada_segunda = derivada.Differentiate("x").Simplify();

                // Muestra las derivadas en el labal
                Resul_Derivada.Text = $"f'(x) = {derivada.ToString()}\nf''(x) = {derivada_segunda.ToString()}";

                //Calculo de punto criticos de la derivada 1

                var puntosCriticos = MathS.SolveEquation(primeraDerivada, x);

                if (puntosCriticos != null)
                {
<<<<<<< HEAD
                    Resul_PuntoCritico.Text = $"x => {puntosCriticos.Simplify()}";
=======
                    // Convertimos el conjunto de puntos críticos a un array para poder iterar sobre ellos
                    string puntosTexto = puntosCriticos.ToString();
                    string puntosSinLlaves = puntosTexto.Trim('{', '}').Trim();
                    string[] puntosArray = puntosSinLlaves.Split(',');

                    // Y generamos una lista de valores numéricos a partir de los puntos críticos
                    // Esta lista se usará para calcular los intervalos de crecimiento y decrecimiento
                    listaPuntosCriticos = new double[puntosArray.Length];

                    for (int i = 0; i < puntosArray.Length; i++)
                    {
                        Entity puntoEntity = puntosArray[i].Trim().ToEntity();
                        listaPuntosCriticos[i] = (double)puntoEntity.EvalNumerical();
                    }

                    Array.Sort(listaPuntosCriticos);

                    Resul_PuntoCritico.Text = "x => " + string.Join(", ", listaPuntosCriticos.Select(p => p.ToString("F2")));
>>>>>>> 8a6a432f4ee0e2bbe4f3a26afd7a89f235aba922
                }
                else
                {
                    Resul_PuntoCritico.Text = "No hay puntos criticos";
                }

                //Calculo de punto inflexion en la derivada 2
<<<<<<< HEAD
                var puntosInflexion = MathS.SolveEquation(segundaDerivada, x);
=======
                var puntosInflexion = MathS.SolveEquation(derivada_segunda, "x");
>>>>>>> 8a6a432f4ee0e2bbe4f3a26afd7a89f235aba922

                if (puntosInflexion != null)
                {
<<<<<<< HEAD
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
=======
                    string puntosTexto = puntosInflexion.ToString();
                    string puntosSinLlaves = puntosTexto.Trim('{', '}').Trim();
                    string[] puntosArray = puntosSinLlaves.Split(',');

                    listaPuntosInflexion = new double[puntosArray.Length];

                    for (int i = 0; i < puntosArray.Length; i++)
                    {
                        Entity puntoEntity = puntosArray[i].Trim().ToEntity();
                        listaPuntosInflexion[i] = (double)puntoEntity.EvalNumerical();
                    }

                    Array.Sort(listaPuntosInflexion);

                    Resul_Inflexion.Text = "x => " + string.Join(", ", listaPuntosInflexion.Select(p => p.ToString("F2")));
                }
                else
                {
                    Resul_Inflexion.Text = "No hay puntos de inflexion";
                }

                // Calculo de los intervalos de crecimiento y decrecimiento
                if (puntosCriticos != null)
                {
                    // Variable para almacenar el resultado final
                    string resultado = "";

                    bool primer = true;
                    double ultimoPunto = double.NegativeInfinity;

                    foreach (var punto in listaPuntosCriticos)
                    {
                        // Intervalo entre -∞ y el primer punto crítico
                        if (primer)
                        {
                            // Evaluamos la derivada en un punto antes del primer punto crítico
                            double valor = (double)derivada.Substitute("x", punto - 1).EvalNumerical();
                            if (valor > 0)
                                resultado += $"En el intervalo (-∞, {punto.ToString("F2")}) f(x)  => Crece\n";
                            else
                                resultado += $"En el intervalo (-∞, {punto.ToString("F2")}) f(x)  => Decrece\n";
                            primer = false;
                        }
                        else
                        {
                            // Evaluamos la derivada en un punto entre el último punto crítico y el actual
                            double valor = (double)derivada.Substitute("x", (ultimoPunto + punto) / 2).EvalNumerical();
                            if (valor > 0)
                                resultado += $"En el intervalo ({ultimoPunto.ToString("F2")}, {punto.ToString("F2")}) f(x)  => Crece\n";
                            else
                                resultado += $"En el intervalo ({ultimoPunto.ToString("F2")}, {punto.ToString("F2")}) f(x)  => Decrece\n";
                        }

                        // Actualizamos el último punto crítico
                        ultimoPunto = punto;
                    }

                    // Intervalo entre el último punto crítico y +∞
                    double valorFinal = (double)derivada.Substitute("x", ultimoPunto + 1).EvalNumerical();
                    if (valorFinal > 0)
                        resultado += $"En el intervalo ({ultimoPunto.ToString("F2")}, +∞) f(x)  => Crece\n";
                    else
                        resultado += $"En el intervalo ({ultimoPunto.ToString("F2")}, +∞) f(x)  => Decrece\n";

                    // Mostramos el resultado en el Label5 del formulario
                    label5.Text = resultado;
>>>>>>> 8a6a432f4ee0e2bbe4f3a26afd7a89f235aba922
                }
                else
                {
                    Resul_CrecDecre.Text = "No se pudo calcular crecimiento/decrecimiento";
                }

<<<<<<< HEAD



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
=======
                // Calculo de concavidad
                if (puntosInflexion != null)
                {
                    string resultado = "";

                    bool primer = true;
                    double ultimoPunto = double.NegativeInfinity;

                    foreach (var punto in listaPuntosInflexion)
                    {
                        if (primer)
                        {
                            double valor = (double)derivada_segunda.Substitute("x", punto - 1).EvalNumerical();
                            if (valor > 0)
                                resultado += $"En el intervalo (-∞, {punto.ToString("F2")}) f(x) => Cóncava hacia arriba\n";
                            else
                                resultado += $"En el intervalo (-∞, {punto.ToString("F2")}) f(x) => Cóncava hacia abajo\n";
                            primer = false;
                        }
                        else
                        {
                            double valor = (double)derivada_segunda.Substitute("x", (ultimoPunto + punto) / 2).EvalNumerical();
                            if (valor > 0)
                                resultado += $"En el intervalo ({ultimoPunto.ToString("F2")}, {punto.ToString("F2")}) f(x) => Cóncava hacia arriba\n";
                            else
                                resultado += $"En el intervalo ({ultimoPunto.ToString("F2")}, {punto.ToString("F2")}) f(x) => Cóncava hacia abajo\n";
                        }

                        ultimoPunto = punto;
                    }

                    double valorFinal = (double)derivada_segunda.Substitute("x", ultimoPunto + 1).EvalNumerical();
                    if (valorFinal > 0)
                        resultado += $"En el intervalo ({ultimoPunto.ToString("F2")}, +∞) f(x) => Cóncava hacia arriba\n";
                    else
                        resultado += $"En el intervalo ({ultimoPunto.ToString("F2")}, +∞) f(x) => Cóncava hacia abajo\n";

                    label6.Text = resultado;
                }
                else
                {
                    label6.Text = "No se pudo calcular la concavidad";
                }
            }
            //catch (Exception ex)
            {
               // MessageBox.Show($"Error al analizar la función: {ex.Message}");
            }
>>>>>>> 8a6a432f4ee0e2bbe4f3a26afd7a89f235aba922
        }
    }
}