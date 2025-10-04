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
            SuspendLayout();
            // 
            // txtFuncion
            // 
            txtFuncion.Location = new Point(104, 60);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(255, 23);
            txtFuncion.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(190, 31);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 1;
            label1.Text = "Ingrese Funcion";
            // 
            // Resul_Derivada
            // 
            Resul_Derivada.BorderStyle = BorderStyle.Fixed3D;
            Resul_Derivada.Location = new Point(76, 144);
            Resul_Derivada.Name = "Resul_Derivada";
            Resul_Derivada.Size = new Size(313, 56);
            Resul_Derivada.TabIndex = 2;
            Resul_Derivada.Text = "Derivada";
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(190, 98);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(75, 23);
            btnCalcular.TabIndex = 3;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // Resul_PuntoCritico
            // 
            Resul_PuntoCritico.BorderStyle = BorderStyle.Fixed3D;
            Resul_PuntoCritico.Location = new Point(76, 232);
            Resul_PuntoCritico.Name = "Resul_PuntoCritico";
            Resul_PuntoCritico.Size = new Size(313, 56);
            Resul_PuntoCritico.TabIndex = 4;
            Resul_PuntoCritico.Text = "Puntos Criticos";
            // 
            // Resul_Inflexion
            // 
            Resul_Inflexion.BorderStyle = BorderStyle.Fixed3D;
            Resul_Inflexion.Location = new Point(76, 322);
            Resul_Inflexion.Name = "Resul_Inflexion";
            Resul_Inflexion.Size = new Size(313, 56);
            Resul_Inflexion.TabIndex = 5;
            Resul_Inflexion.Text = "Puntos Inflexion";
            // 
            // Resul_CrecDecre
            // 
            Resul_CrecDecre.BorderStyle = BorderStyle.Fixed3D;
            Resul_CrecDecre.Location = new Point(76, 413);
            Resul_CrecDecre.Name = "Resul_CrecDecre";
            Resul_CrecDecre.Size = new Size(313, 56);
            Resul_CrecDecre.TabIndex = 6;
            Resul_CrecDecre.Text = "Crecimiento/Decrecimiento";
            // 
            // ResulConcavidad
            // 
            ResulConcavidad.BorderStyle = BorderStyle.Fixed3D;
            ResulConcavidad.Location = new Point(76, 496);
            ResulConcavidad.Name = "ResulConcavidad";
            ResulConcavidad.Size = new Size(313, 56);
            ResulConcavidad.TabIndex = 7;
            ResulConcavidad.Text = "Concavidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 118);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 8;
            label2.Text = "Derivada";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(76, 208);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 9;
            label3.Text = "Puntos Criticos";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(76, 297);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 10;
            label4.Text = "Puntos Inflexion";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(76, 389);
            label5.Name = "label5";
            label5.Size = new Size(160, 15);
            label5.TabIndex = 11;
            label5.Text = "Crecimiento / Decrecimiento";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(76, 481);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 12;
            label6.Text = "Concavidad";
            label6.Click += label6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(489, 561);
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
    }
}
