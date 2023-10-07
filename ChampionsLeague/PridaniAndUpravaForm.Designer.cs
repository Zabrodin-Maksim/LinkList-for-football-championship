namespace ChampionsLeague
{
    partial class PridaniAndUpravaForm
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
            Jmeno = new TextBox();
            PocetGolu = new TextBox();
            comboBox1 = new ComboBox();
            Storno = new Button();
            OkPridani = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(50, 30);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Jméno:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(64, 76);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 1;
            label2.Text = "Klub:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(23, 125);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 2;
            label3.Text = "Počet gólů:";
            // 
            // Jmeno
            // 
            Jmeno.Location = new Point(114, 27);
            Jmeno.Name = "Jmeno";
            Jmeno.Size = new Size(231, 23);
            Jmeno.TabIndex = 3;
            // 
            // PocetGolu
            // 
            PocetGolu.Location = new Point(114, 122);
            PocetGolu.Name = "PocetGolu";
            PocetGolu.Size = new Size(231, 23);
            PocetGolu.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.Window;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(114, 73);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(231, 23);
            comboBox1.TabIndex = 5;
            // 
            // Storno
            // 
            Storno.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            Storno.Location = new Point(23, 184);
            Storno.Name = "Storno";
            Storno.Size = new Size(110, 32);
            Storno.TabIndex = 6;
            Storno.Text = "Storno";
            Storno.UseVisualStyleBackColor = true;
            Storno.Click += Storno_Click;
            // 
            // OkPridani
            // 
            OkPridani.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            OkPridani.Location = new Point(248, 184);
            OkPridani.Name = "OkPridani";
            OkPridani.Size = new Size(110, 32);
            OkPridani.TabIndex = 7;
            OkPridani.Text = "OK";
            OkPridani.UseVisualStyleBackColor = true;
            OkPridani.Click += OkPridani_Click;
            // 
            // PridaniAndUpravaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 239);
            Controls.Add(OkPridani);
            Controls.Add(Storno);
            Controls.Add(comboBox1);
            Controls.Add(PocetGolu);
            Controls.Add(Jmeno);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "PridaniAndUpravaForm";
            Text = "PridaniAndUpravaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox Jmeno;
        private TextBox PocetGolu;
        private ComboBox comboBox1;
        private Button Storno;
        private Button OkPridani;
    }
}