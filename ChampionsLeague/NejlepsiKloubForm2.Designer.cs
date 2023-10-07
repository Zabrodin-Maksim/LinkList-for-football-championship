namespace ChampionsLeague
{
    partial class NejlepsiKloubForm2
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
            listView1 = new ListView();
            textBox1 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(92, 21);
            label1.TabIndex = 0;
            label1.Text = "Počet gólů:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(116, 21);
            label2.TabIndex = 1;
            label2.Text = "Nejlepší kluby:";
            // 
            // listView1
            // 
            listView1.AutoArrange = false;
            listView1.Location = new Point(12, 91);
            listView1.Name = "listView1";
            listView1.Size = new Size(279, 196);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(110, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(170, 310);
            button1.Name = "button1";
            button1.Size = new Size(121, 33);
            button1.TabIndex = 4;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // NejlepsiKloubForm2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 355);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(listView1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "NejlepsiKloubForm2";
            Text = "NejlepsiKloubForm2";
            Load += NejlepsiKloubForm2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ListView listView1;
        private TextBox textBox1;
        private Button button1;
    }
}