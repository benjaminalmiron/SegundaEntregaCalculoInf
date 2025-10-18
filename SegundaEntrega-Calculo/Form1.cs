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

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            // Muestra una ventana de carga mientras se procesan los cálculos.
            LoadingForm loading = new LoadingForm();
            loading.Show();

            // Variables principales para la función y sus derivadas.
            Entity funcion = Entity.Number.Integer.Zero;
            Entity derivada = Entity.Number.Integer.Zero;
            Entity derivada_segunda = Entity.Number.Integer.Zero;

            // Listas donde se guardarán los puntos críticos e inflexión.
            double[] listaPuntosCriticos = new double[0];
            double[] listaPuntosInflexion = new double[0];

            await Task.Run(() =>
            {
                try
                {
                    // Toma el texto de la función y quita espacios.
                    string funcion_texto = txtFuncion.Text.Trim();

                    // Valida que se haya ingresado algo.
                    if (string.IsNullOrEmpty(funcion_texto))
                        throw new Exception("Ingrese una función válida");

                    // Convierte el texto en una entidad matemática y simplifica la expresión.
                    funcion = funcion_texto.ToEntity().Simplify();

                    // Verifica que la función contenga la variable 'x'.
                    if (!funcion.Vars.Contains("x"))
                        throw new Exception("La función debe contener la variable 'x'");

                    // Calcula la primera derivada respecto de 'x'.
                    derivada = funcion.Differentiate("x");

                    // Si la derivada es 0, la función no depende de 'x' o es constante.
                    if (derivada == Entity.Number.Integer.Zero)
                        throw new Exception("La función es constante o no depende de 'x'");

                    // Calcula y simplifica la segunda derivada.
                    derivada_segunda = derivada.Differentiate("x").Simplify();

                    // Actualiza los resultados en los controles del formulario (desde otro hilo).
                    this.Invoke(() =>
                    {
                        Resul_Derivada.Text = $"f'(x) = {derivada}\nf''(x) = {derivada_segunda}";
                    });

                    // Calcula los puntos críticos (donde f'(x) = 0).
                    var puntosCriticos = MathS.SolveEquation(derivada, "x").Simplify();

                    // Si hay soluciones finitas, las guarda en una lista.
                    if (puntosCriticos is AngouriMath.Entity.Set.FiniteSet setCriticos && setCriticos.Count > 0)
                    {
                        listaPuntosCriticos = new double[setCriticos.Count];
                        int i = 0;

                        // Convierte cada raíz a número y la guarda.
                        foreach (var punto in setCriticos)
                        {
                            listaPuntosCriticos[i] = (double)punto.EvalNumerical();
                            i++;
                        }

                        // Redondea los valores a 2 decimales para mostrarlos más prolijos.
                        for (int f = 0; f < listaPuntosCriticos.Length; f++)
                            listaPuntosCriticos[f] = Math.Round(listaPuntosCriticos[f], 2);

                        // Ordena los puntos críticos de menor a mayor y elimina repetidos.
                        Array.Sort(listaPuntosCriticos);
                        listaPuntosCriticos = listaPuntosCriticos.Distinct().ToArray();

                        // Muestra los puntos críticos en el formulario.
                        this.Invoke(() =>
                        {
                            Resul_PuntoCritico.Text = "x => " + string.Join("; ", listaPuntosCriticos.Select(p => p.ToString("F2")));
                        });
                    }
                    else
                    {
                        // Si no hay puntos críticos, muestra el mensaje correspondiente.
                        this.Invoke(() => { Resul_PuntoCritico.Text = "No hay puntos críticos"; });
                    }

                    // Puntos de inflexión
                    var puntosInflexion = MathS.SolveEquation(derivada_segunda, "x").Simplify();

                    // Verifica si hay soluciones finitas para f''(x) = 0
                    if (puntosInflexion is AngouriMath.Entity.Set.FiniteSet setInflexion && setInflexion.Count > 0)
                    {
                        // Convierte los puntos encontrados a valores numéricos
                        listaPuntosInflexion = new double[setInflexion.Count];
                        int i = 0;
                        foreach (var punto in setInflexion)
                        {
                            listaPuntosInflexion[i] = (double)punto.EvalNumerical();
                            i++;
                        }

                        // Redondea, ordena y elimina duplicados
                        for (int f = 0; f < listaPuntosInflexion.Length; f++)
                            listaPuntosInflexion[f] = Math.Round(listaPuntosInflexion[f], 2);

                        Array.Sort(listaPuntosInflexion);
                        listaPuntosInflexion = listaPuntosInflexion.Distinct().ToArray();

                        // Muestra los puntos de inflexión en el formulario
                        this.Invoke(() =>
                        {
                            Resul_Inflexion.Text = "x => " + string.Join("; ", listaPuntosInflexion.Select(p => p.ToString("F2")));
                        });
                    }
                    else
                    {
                        // Si no hay puntos de inflexión, muestra mensaje
                        this.Invoke(() => { Resul_Inflexion.Text = "No hay puntos de inflexión"; });
                    }

                    // Cálculo de los intervalos de crecimiento y decrecimiento
                    if (puntosCriticos != null)
                    {
                        string resultado = "";
                        bool primer = true;                    // Indica si es el primer intervalo
                        double ultimoPunto = double.NegativeInfinity; // Empieza desde -∞

                        // Recorre cada punto crítico para evaluar el signo de la derivada
                        foreach (var punto in listaPuntosCriticos)
                        {
                            double valor;

                            if (primer)
                            {
                                // Evalúa f'(x) antes del primer punto crítico
                                valor = (double)derivada.Substitute("x", punto - 1).EvalNumerical();

                                // Determina si la función crece o decrece
                                if (valor > 0)
                                    resultado += $"En el intervalo (-∞, {punto:F2}) f(x) => Crece\n";
                                else
                                    resultado += $"En el intervalo (-∞, {punto:F2}) f(x) => Decrece\n";

                                primer = false;
                            }
                            else
                            {
                                // Evalúa f'(x) entre dos puntos críticos (en el punto medio)
                                valor = (double)derivada.Substitute("x", (ultimoPunto + punto) / 2).EvalNumerical();

                                // Determina el comportamiento en ese intervalo
                                if (valor > 0)
                                    resultado += $"En el intervalo ({ultimoPunto:F2}, {punto:F2}) f(x) => Crece\n";
                                else
                                    resultado += $"En el intervalo ({ultimoPunto:F2}, {punto:F2}) f(x) => Decrece\n";
                            }

                            // Guarda el punto actual como límite inferior del próximo intervalo
                            ultimoPunto = punto;
                        }

                        // Evaluamos el último intervalo, desde el último punto crítico hasta +∞
                        double valorFinal = (double)derivada.Substitute("x", ultimoPunto + 1).EvalNumerical();

                        // Determina si la función crece o decrece en este tramo
                        if (valorFinal > 0)
                            resultado += $"En el intervalo ({ultimoPunto:F2}, +∞) f(x) => Crece\n";
                        else
                            resultado += $"En el intervalo ({ultimoPunto:F2}, +∞) f(x) => Decrece\n";

                        // Actualiza el control de la interfaz con Invoke (porque estamos en un hilo aparte)
                        this.Invoke(() =>
                        {
                            Resul_CrecDecre.Text = resultado;
                        });
                    }
                    else
                    {
                        // Si no hay puntos críticos, muestra mensaje de error
                        this.Invoke(() =>
                        {
                            Resul_CrecDecre.Text = "No se pudo calcular crecimiento/decrecimiento";
                        });
                    }


                    // Calculo de concavidad usando la segunda derivada
                    if (puntosInflexion != null)
                    {
                        string resultado = "";
                        bool primer = true;
                        double ultimoPunto = double.NegativeInfinity;

                        foreach (var punto in listaPuntosInflexion)
                        {
                            double valor;
                            if (primer)
                            {
                                // Evaluamos un punto antes del primer punto de inflexión
                                valor = (double)derivada_segunda.Substitute("x", punto - 1).EvalNumerical();
                                if (valor > 0)
                                    resultado += $"En el intervalo (-∞, {punto:F2}) f(x) => Cóncava hacia arriba\n";
                                else
                                    resultado += $"En el intervalo (-∞, {punto:F2}) f(x) => Cóncava hacia abajo\n";
                                primer = false;
                            }
                            else
                            {
                                // Evaluamos un punto entre el último punto de inflexión y el actual
                                valor = (double)derivada_segunda.Substitute("x", (ultimoPunto + punto) / 2).EvalNumerical();
                                if (valor > 0)
                                    resultado += $"En el intervalo ({ultimoPunto:F2}, {punto:F2}) f(x) => Cóncava hacia arriba\n";
                                else
                                    resultado += $"En el intervalo ({ultimoPunto:F2}, {punto:F2}) f(x) => Cóncava hacia abajo\n";
                            }

                            ultimoPunto = punto;
                        }

                        // Evaluamos el último intervalo hasta +∞
                        double valorFinal = (double)derivada_segunda.Substitute("x", ultimoPunto + 1).EvalNumerical();
                        if (valorFinal > 0)
                            resultado += $"En el intervalo ({ultimoPunto:F2}, +∞) f(x) => Cóncava hacia arriba\n";
                        else
                            resultado += $"En el intervalo ({ultimoPunto:F2}, +∞) f(x) => Cóncava hacia abajo\n";

                        // Actualizamos el control de la UI con Invoke
                        this.Invoke(() =>
                        {
                            ResulConcavidad.Text = resultado;
                        });
                    }

                }
                // Manejo de errores
                catch (Exception ex)
                {
                    this.Invoke(() =>
                    {
                        MessageBox.Show("Error al procesar la función: " + ex.Message);
                    });
                }
            });

            // Cerrar loading en el hilo principal
            loading.Close();
        }



        private void btnData_Click(object sender, EventArgs e)
        {
            Info form = new Info();
            form.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
