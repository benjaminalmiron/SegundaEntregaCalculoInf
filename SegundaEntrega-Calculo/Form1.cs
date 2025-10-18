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
            LoadingForm loading = new LoadingForm();
            loading.Show();

            // Variables
            Entity funcion = Entity.Number.Integer.Zero;
            Entity derivada = Entity.Number.Integer.Zero;
            Entity derivada_segunda = Entity.Number.Integer.Zero;
            double[] listaPuntosCriticos = new double[0];
            double[] listaPuntosInflexion = new double[0];

            await Task.Run(() =>
            {
                try
                {
                    // Ingreso de función
                    string funcion_texto = txtFuncion.Text.Trim();
                    if (string.IsNullOrEmpty(funcion_texto))
                        throw new Exception("Ingrese una función válida");

                    funcion = funcion_texto.ToEntity().Simplify();
                    if (!funcion.Vars.Contains("x"))
                        throw new Exception("La función debe contener la variable 'x'");

                    derivada = funcion.Differentiate("x");
                    if (derivada == Entity.Number.Integer.Zero)
                        throw new Exception("La función es constante o no depende de 'x'");

                    derivada_segunda = derivada.Differentiate("x").Simplify();

                    // Actualizar controles con Invoke
                    this.Invoke(() =>
                    {
                        Resul_Derivada.Text = $"f'(x) = {derivada}\nf''(x) = {derivada_segunda}";
                    });

                    // Puntos críticos
                    var puntosCriticos = MathS.SolveEquation(derivada, "x").Simplify();
                    if (puntosCriticos is AngouriMath.Entity.Set.FiniteSet setCriticos && setCriticos.Count > 0)
                    {
                        listaPuntosCriticos = new double[setCriticos.Count];
                        int i = 0;
                        foreach (var punto in setCriticos)
                        {
                            listaPuntosCriticos[i] = (double)punto.EvalNumerical();
                            i++;
                        }
                        for (int f = 0; f < listaPuntosCriticos.Length; f++)
                            listaPuntosCriticos[f] = Math.Round(listaPuntosCriticos[f], 2);

                        Array.Sort(listaPuntosCriticos);
                        listaPuntosCriticos = listaPuntosCriticos.Distinct().ToArray();

                        this.Invoke(() =>
                        {
                            Resul_PuntoCritico.Text = "x => " + string.Join("; ", listaPuntosCriticos.Select(p => p.ToString("F2")));
                        });
                    }
                    else
                    {
                        this.Invoke(() => { Resul_PuntoCritico.Text = "No hay puntos críticos"; });
                    }

                    // Puntos de inflexión
                    var puntosInflexion = MathS.SolveEquation(derivada_segunda, "x").Simplify();
                    if (puntosInflexion is AngouriMath.Entity.Set.FiniteSet setInflexion && setInflexion.Count > 0)
                    {
                        listaPuntosInflexion = new double[setInflexion.Count];
                        int i = 0;
                        foreach (var punto in setInflexion)
                        {
                            listaPuntosInflexion[i] = (double)punto.EvalNumerical();
                            i++;
                        }
                        for (int f = 0; f < listaPuntosInflexion.Length; f++)
                            listaPuntosInflexion[f] = Math.Round(listaPuntosInflexion[f], 2);

                        Array.Sort(listaPuntosInflexion);
                        listaPuntosInflexion = listaPuntosInflexion.Distinct().ToArray();

                        this.Invoke(() =>
                        {
                            Resul_Inflexion.Text = "x => " + string.Join("; ", listaPuntosInflexion.Select(p => p.ToString("F2")));
                        });
                    }
                    else
                    {
                        this.Invoke(() => { Resul_Inflexion.Text = "No hay puntos de inflexión"; });
                    }

                    // Calculo de los intervalos de crecimiento y decrecimiento
                    if (puntosCriticos != null)
                    {
                        string resultado = "";
                        bool primer = true;
                        double ultimoPunto = double.NegativeInfinity;

                        foreach (var punto in listaPuntosCriticos)
                        {
                            double valor;
                            if (primer)
                            {
                                valor = (double)derivada.Substitute("x", punto - 1).EvalNumerical();
                                if (valor > 0)
                                    resultado += $"En el intervalo (-∞, {punto.ToString("F2")}) f(x) => Crece\n";
                                else
                                    resultado += $"En el intervalo (-∞, {punto.ToString("F2")}) f(x) => Decrece\n";
                                primer = false;
                            }
                            else
                            {
                                valor = (double)derivada.Substitute("x", (ultimoPunto + punto) / 2).EvalNumerical();
                                if (valor > 0)
                                    resultado += $"En el intervalo ({ultimoPunto.ToString("F2")}, {punto.ToString("F2")}) f(x) => Crece\n";
                                else
                                    resultado += $"En el intervalo ({ultimoPunto.ToString("F2")}, {punto.ToString("F2")}) f(x) => Decrece\n";
                            }

                            ultimoPunto = punto;
                        }

                        double valorFinal = (double)derivada.Substitute("x", ultimoPunto + 1).EvalNumerical();
                        if (valorFinal > 0)
                            resultado += $"En el intervalo ({ultimoPunto.ToString("F2")}, +∞) f(x) => Crece\n";
                        else
                            resultado += $"En el intervalo ({ultimoPunto.ToString("F2")}, +∞) f(x) => Decrece\n";

                        this.Invoke(() =>
                        {
                            Resul_CrecDecre.Text = resultado;
                        });
                    }
                    else
                    {
                        this.Invoke(() =>
                        {
                            Resul_CrecDecre.Text = "No se pudo calcular crecimiento/decrecimiento";
                        });
                    }

                    // Calculo de concavidad
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
                                valor = (double)derivada_segunda.Substitute("x", punto - 1).EvalNumerical();
                                if (valor > 0)
                                    resultado += $"En el intervalo (-∞, {punto.ToString("F2")}) f(x) => Cóncava hacia arriba\n";
                                else
                                    resultado += $"En el intervalo (-∞, {punto.ToString("F2")}) f(x) => Cóncava hacia abajo\n";
                                primer = false;
                            }
                            else
                            {
                                valor = (double)derivada_segunda.Substitute("x", (ultimoPunto + punto) / 2).EvalNumerical();
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

                        this.Invoke(() =>
                        {
                            ResulConcavidad.Text = resultado;
                        });
                    }
                }
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
