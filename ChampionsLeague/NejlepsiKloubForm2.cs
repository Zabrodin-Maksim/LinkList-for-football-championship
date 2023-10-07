using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChampionsLeague
{
    public partial class NejlepsiKloubForm2 : Form
    {
        //public ChampionsLeagueForm MainForm;
        public PlayersRecords records;

        public NejlepsiKloubForm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NejlepsiKloubForm2_Load(object sender, EventArgs e)
        {
            object a;
            FootballClub[] clubs;
            int goul;
            records.FindBestClubs(out clubs, out goul);
            ListViewItem[] items = new ListViewItem[clubs.Length];
            for (int i = 0; i < clubs.Length; i++)
            {
                items[i] = new ListViewItem(FootballClubInfo.GetName(clubs[i]));
            }
            listView1.Items.AddRange(items);
            textBox1.Text = Convert.ToString(goul);
        }
    }
}
