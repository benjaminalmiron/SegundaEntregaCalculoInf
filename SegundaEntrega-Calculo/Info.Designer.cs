namespace SegundaEntrega_Calculo
{
    partial class Info
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(248, 75);
            label1.TabIndex = 0;
            label1.Text = "1- Encierra siempre entre paréntesis el numerador, el denominador, y la base de cualquier potencia para definir claramente el orden de las operaciones.\n\n";
            // 
            // label2
            // 
            label2.Location = new Point(12, 95);
            label2.Name = "label2";
            label2.Size = new Size(248, 75);
            label2.TabIndex = 1;
            label2.Text = "2- El sistema no infiere la multiplicación si solo pones un número junto a una variable (ej. 2x). Siempre usa *.";
            // 
            // label3
            // 
            label3.Location = new Point(12, 160);
            label3.Name = "label3";
            label3.Size = new Size(248, 75);
            label3.TabIndex = 2;
            label3.Text = "3 - Usa ^ para Potencias - Utiliza el símbolo de acento circunflejo para elevar a una potencia.\n\n";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(83, 224);
            label4.Name = "label4";
            label4.Size = new Size(102, 21);
            label4.TabIndex = 3;
            label4.Text = "Ejemplo Practico";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(67, 245);
            label5.Name = "label5";
            label5.Size = new Size(148, 21);
            label5.TabIndex = 4;
            label5.Text = "(2 * x^2 + 3) / (2 * x + 5)";
            // 
            // Info
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 305);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Info";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Info";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}