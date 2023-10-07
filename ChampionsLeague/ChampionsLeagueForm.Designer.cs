namespace ChampionsLeague
{
    partial class ChampionsLeagueForm
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
            Pridat_Hrace = new Button();
            Upravit_Hrace = new Button();
            Smazat_Hrace = new Button();
            Nejlepsi_Kluby = new Button();
            Vypis_Udalosti_Box = new ListBox();
            listView1 = new ListView();
            NameColumn = new ColumnHeader();
            ClubColumn = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // Pridat_Hrace
            // 
            Pridat_Hrace.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Pridat_Hrace.Location = new Point(695, 61);
            Pridat_Hrace.Margin = new Padding(3, 4, 3, 4);
            Pridat_Hrace.Name = "Pridat_Hrace";
            Pridat_Hrace.Size = new Size(285, 56);
            Pridat_Hrace.TabIndex = 1;
            Pridat_Hrace.Text = "Přidat hráče";
            Pridat_Hrace.UseVisualStyleBackColor = true;
            Pridat_Hrace.Click += Pridat_Hrace_Click;
            // 
            // Upravit_Hrace
            // 
            Upravit_Hrace.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Upravit_Hrace.Location = new Point(695, 125);
            Upravit_Hrace.Margin = new Padding(3, 4, 3, 4);
            Upravit_Hrace.Name = "Upravit_Hrace";
            Upravit_Hrace.Size = new Size(285, 56);
            Upravit_Hrace.TabIndex = 2;
            Upravit_Hrace.Text = "Upravit hráče";
            Upravit_Hrace.UseVisualStyleBackColor = true;
            Upravit_Hrace.Click += Upravit_Hrace_Click;
            // 
            // Smazat_Hrace
            // 
            Smazat_Hrace.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Smazat_Hrace.Location = new Point(695, 189);
            Smazat_Hrace.Margin = new Padding(3, 4, 3, 4);
            Smazat_Hrace.Name = "Smazat_Hrace";
            Smazat_Hrace.Size = new Size(285, 56);
            Smazat_Hrace.TabIndex = 3;
            Smazat_Hrace.Text = "Smazat hráče";
            Smazat_Hrace.UseVisualStyleBackColor = true;
            Smazat_Hrace.Click += Smazat_Hrace_Click;
            // 
            // Nejlepsi_Kluby
            // 
            Nejlepsi_Kluby.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Nejlepsi_Kluby.Location = new Point(695, 312);
            Nejlepsi_Kluby.Margin = new Padding(3, 4, 3, 4);
            Nejlepsi_Kluby.Name = "Nejlepsi_Kluby";
            Nejlepsi_Kluby.Size = new Size(285, 55);
            Nejlepsi_Kluby.TabIndex = 4;
            Nejlepsi_Kluby.Text = "Nejlepší kluby";
            Nejlepsi_Kluby.UseVisualStyleBackColor = true;
            Nejlepsi_Kluby.Click += Nejlepsi_Kluby_Click;
            // 
            // Vypis_Udalosti_Box
            // 
            Vypis_Udalosti_Box.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Vypis_Udalosti_Box.FormattingEnabled = true;
            Vypis_Udalosti_Box.ItemHeight = 28;
            Vypis_Udalosti_Box.Location = new Point(14, 604);
            Vypis_Udalosti_Box.Margin = new Padding(3, 4, 3, 4);
            Vypis_Udalosti_Box.Name = "Vypis_Udalosti_Box";
            Vypis_Udalosti_Box.Size = new Size(965, 172);
            Vypis_Udalosti_Box.TabIndex = 6;
            // 
            // listView1
            // 
            listView1.BackColor = SystemColors.Window;
            listView1.Columns.AddRange(new ColumnHeader[] { NameColumn, ClubColumn, columnHeader1 });
            listView1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(14, 16);
            listView1.Margin = new Padding(3, 4, 3, 4);
            listView1.Name = "listView1";
            listView1.Size = new Size(674, 579);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // NameColumn
            // 
            NameColumn.Text = "Name";
            NameColumn.Width = 300;
            // 
            // ClubColumn
            // 
            ClubColumn.Text = "Club";
            ClubColumn.TextAlign = HorizontalAlignment.Center;
            ClubColumn.Width = 160;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Goals";
            columnHeader1.TextAlign = HorizontalAlignment.Right;
            columnHeader1.Width = 125;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(695, 420);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(285, 55);
            button1.TabIndex = 8;
            button1.Text = "Uložit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button_ULOZIT;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(695, 483);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(285, 55);
            button2.TabIndex = 9;
            button2.Text = "Načíst";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button_NACIST;
            // 
            // ChampionsLeagueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 825);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(Vypis_Udalosti_Box);
            Controls.Add(Nejlepsi_Kluby);
            Controls.Add(Smazat_Hrace);
            Controls.Add(Upravit_Hrace);
            Controls.Add(Pridat_Hrace);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ChampionsLeagueForm";
            Text = "ChampionsLeagueForm";
            ResumeLayout(false);
        }

        #endregion
        private Button Pridat_Hrace;
        private Button Upravit_Hrace;
        private Button Smazat_Hrace;
        private Button Nejlepsi_Kluby;
        private ListBox Vypis_Udalosti_Box;
        private ListView listView1;
        private ColumnHeader NameColumn;
        private ColumnHeader ClubColumn;
        private ColumnHeader columnHeader1;
        private Button button1;
        private Button button2;
    }
}