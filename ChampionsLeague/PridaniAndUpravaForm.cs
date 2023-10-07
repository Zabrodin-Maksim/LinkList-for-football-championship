using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChampionsLeague
{
    public partial class PridaniAndUpravaForm : Form
    {
        public ChampionsLeagueForm MainForm { get; set; }
        public PridaniAndUpravaForm()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new object[] { FootballClubInfo.GetName(FootballClub.Arsenal), FootballClubInfo.GetName(FootballClub.Barcelona), FootballClubInfo.GetName(FootballClub.Chelsea), FootballClubInfo.GetName(FootballClub.FCPorto), FootballClubInfo.GetName(FootballClub.RealMadrid), "None" });
        }



        private void Storno_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void zapis(Player player)
        {
            Jmeno.Text = player.Name;
            comboBox1.Text = FootballClubInfo.GetName(player.Club);
            PocetGolu.Text = player.GoalCount.ToString();
        }
        
        private void OkPridani_Click(object sender, EventArgs e)
        {
            ChampionsLeagueForm ChampionsLeagueForm = MainForm;
            try { 
                switch (comboBox1.Text)
                {
                    case "":
                        ChampionsLeagueForm.receiveData(new Player(Jmeno.Text, FootballClub.None, int.Parse(PocetGolu.Text)));
                        break;
                    case "FC Porto":
                        ChampionsLeagueForm.receiveData(new Player(Jmeno.Text, FootballClub.FCPorto, int.Parse(PocetGolu.Text)));
                        break;
                    case "Arsenal":
                        ChampionsLeagueForm.receiveData(new Player(Jmeno.Text, FootballClub.Arsenal, int.Parse(PocetGolu.Text)));
                        break;
                    case "Real Madrid":
                        ChampionsLeagueForm.receiveData(new Player(Jmeno.Text, FootballClub.RealMadrid, int.Parse(PocetGolu.Text)));
                        break;
                    case "Chelsea":
                        ChampionsLeagueForm.receiveData(new Player(Jmeno.Text, FootballClub.Chelsea, int.Parse(PocetGolu.Text)));
                        break;
                    case "Barcelona":
                        ChampionsLeagueForm.receiveData(new Player(Jmeno.Text, FootballClub.Barcelona, int.Parse(PocetGolu.Text)));
                        break;

                }
            }
            catch
            {
                MessageBox.Show("Špatný formát", "Chyba!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            Close();
        }
    }
}
