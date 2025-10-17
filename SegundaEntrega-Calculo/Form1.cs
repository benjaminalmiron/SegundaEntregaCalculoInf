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
            // Variables para almacenar la función y sus derivadas
            Entity funcion = Entity.Number.Integer.Zero;
            Entity derivada = Entity.Number.Integer.Zero;
            Entity derivada_segunda = Entity.Number.Integer.Zero;

            // Esta lista se usará para calcular los intervalos de crecimiento y decrecimiento
            double[] listaPuntosCriticos = new double[0];
            double[] listaPuntosInflexion = new double[0];

            // Ingreso de funcion
            string funcion_texto = txtFuncion.Text.Trim();

            // Verifica que el campo de texto no esté vacío
            if (string.IsNullOrEmpty(funcion_texto))
            {
                MessageBox.Show("Ingrese una funcion valida");
                return;
            }

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

            // En las variables se mantienen los objetos entity, no las versiones de texto

            // Calculo de la primera derivada
            derivada = funcion.Differentiate("x").Simplify();

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
                {
                    listaPuntosCriticos[f] = Math.Round(listaPuntosCriticos[f], 2);
                }

                Array.Sort(listaPuntosCriticos);
                listaPuntosCriticos = listaPuntosCriticos.Distinct().ToArray();
                Resul_PuntoCritico.Text = "x => " + string.Join("; ", listaPuntosCriticos.Select(p => p.ToString("F2")));
            }
            else
            {
                Resul_PuntoCritico.Text = "No hay puntos criticos";
            }

            //Calculo de punto inflexion en la derivada 2
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
                {
                    listaPuntosInflexion[f] = Math.Round(listaPuntosInflexion[f], 2);
                }

                Array.Sort(listaPuntosInflexion);
                listaPuntosInflexion = listaPuntosInflexion.Distinct().ToArray();
                Resul_Inflexion.Text = "x => " + string.Join("; ", listaPuntosInflexion.Select(p => p.ToString("F2")));
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

                // Mostramos el resultado en el formulario
                Resul_CrecDecre.Text = resultado;
            }
            else
            {
                // En caso de error, mostramos un mensaje de aviso
                Resul_CrecDecre.Text = "No se pudo calcular crecimiento/decrecimiento";
            }

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

                ResulConcavidad.Text = resultado;
            }
            else
            {
                ResulConcavidad.Text = "No se pudo calcular la concavidad";
            }
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