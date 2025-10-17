namespace SegundaEntrega_Calculo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFuncion = new TextBox();
            label1 = new Label();
            Resul_Derivada = new Label();
            btnCalcular = new Button();
            Resul_PuntoCritico = new Label();
            Resul_Inflexion = new Label();
            Resul_CrecDecre = new Label();
            ResulConcavidad = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnData = new Button();
            SuspendLayout();
            // 
            // txtFuncion
            // 
            txtFuncion.Location = new Point(77, 123);
            txtFuncion.Margin = new Padding(3, 4, 3, 4);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(315, 27);
            txtFuncion.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 93);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 1;
            label1.Text = "Ingrese Funcion";
            // 
            // Resul_Derivada
            // 
            Resul_Derivada.BorderStyle = BorderStyle.Fixed3D;
            Resul_Derivada.Location = new Point(483, 99);
            Resul_Derivada.Name = "Resul_Derivada";
            Resul_Derivada.Size = new Size(358, 75);
            Resul_Derivada.TabIndex = 2;
            Resul_Derivada.Text = "Derivada";
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(306, 161);
            btnCalcular.Margin = new Padding(3, 4, 3, 4);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(86, 31);
            btnCalcular.TabIndex = 3;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // Resul_PuntoCritico
            // 
            Resul_PuntoCritico.BorderStyle = BorderStyle.Fixed3D;
            Resul_PuntoCritico.Location = new Point(77, 267);
            Resul_PuntoCritico.Name = "Resul_PuntoCritico";
            Resul_PuntoCritico.Size = new Size(358, 187);
            Resul_PuntoCritico.TabIndex = 4;
            Resul_PuntoCritico.Text = "Puntos Criticos";
            // 
            // Resul_Inflexion
            // 
            Resul_Inflexion.BorderStyle = BorderStyle.Fixed3D;
            Resul_Inflexion.Location = new Point(483, 267);
            Resul_Inflexion.Name = "Resul_Inflexion";
            Resul_Inflexion.Size = new Size(358, 187);
            Resul_Inflexion.TabIndex = 5;
            Resul_Inflexion.Text = "Puntos Inflexion";
            // 
            // Resul_CrecDecre
            // 
            Resul_CrecDecre.BorderStyle = BorderStyle.Fixed3D;
            Resul_CrecDecre.Location = new Point(77, 535);
            Resul_CrecDecre.Name = "Resul_CrecDecre";
            Resul_CrecDecre.Size = new Size(358, 208);
            Resul_CrecDecre.TabIndex = 6;
            Resul_CrecDecre.Text = "Crecimiento/Decrecimiento";
            // 
            // ResulConcavidad
            // 
            ResulConcavidad.BorderStyle = BorderStyle.Fixed3D;
            ResulConcavidad.Location = new Point(483, 535);
            ResulConcavidad.Name = "ResulConcavidad";
            ResulConcavidad.Size = new Size(358, 208);
            ResulConcavidad.TabIndex = 7;
            ResulConcavidad.Text = "Concavidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(483, 63);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 8;
            label2.Text = "Derivadas";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(77, 227);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 9;
            label3.Text = "Puntos Criticos";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(483, 227);
            label4.Name = "label4";
            label4.Size = new Size(114, 20);
            label4.TabIndex = 10;
            label4.Text = "Puntos Inflexion";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(77, 495);
            label5.Name = "label5";
            label5.Size = new Size(200, 20);
            label5.TabIndex = 11;
            label5.Text = "Crecimiento / Decrecimiento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(483, 495);
            label6.Name = "label6";
            label6.Size = new Size(87, 20);
            label6.TabIndex = 12;
            label6.Text = "Concavidad";
            // 
            // btnData
            // 
            btnData.Location = new Point(189, 87);
            btnData.Margin = new Padding(3, 4, 3, 4);
            btnData.Name = "btnData";
            btnData.Size = new Size(203, 32);
            btnData.TabIndex = 13;
            btnData.Text = "¿Como ingresar la funcion?";
            btnData.UseVisualStyleBackColor = true;
            btnData.Click += btnData_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(910, 835);
            Controls.Add(btnData);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ResulConcavidad);
            Controls.Add(Resul_CrecDecre);
            Controls.Add(Resul_Inflexion);
            Controls.Add(Resul_PuntoCritico);
            Controls.Add(btnCalcular);
            Controls.Add(Resul_Derivada);
            Controls.Add(label1);
            Controls.Add(txtFuncion);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Derivadas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFuncion;
        private Label label1;
        private Label Resul_Derivada;
        private Button btnCalcular;
        private Label Resul_PuntoCritico;
        private Label Resul_Inflexion;
        private Label Resul_CrecDecre;
        private Label ResulConcavidad;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnData;
    }
}
