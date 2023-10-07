using ChampionsLeagueLibrary;
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
    public partial class ChampionsLeagueForm : Form
    {
        static PlayersRecords records = new PlayersRecords();
        static bool flag = false;
        static private int indexx;
        public ChampionsLeagueForm()
        {

            InitializeComponent();
            records.PlayersCountChanged += Hraci_List_SelectedIndexChanged;

        }



        private void Vypis_Udalosti(object sender, PlayersCountChangedEventArgs e)
        {
            Vypis_Udalosti_Box.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " | " + $"Změna počtu hráčů z {e.OldCount} na {e.NewCount}");
        }

        public void Hraci_List_SelectedIndexChanged(object sender, PlayersCountChangedEventArgs e)
        {
            Vypis_Udalosti(sender, e);
            listView1.Items.Clear();
            for (int i = 0; i < records.Count; i++)
            {
                ListViewItem itm = new ListViewItem(records[i].Name);
                itm.SubItems.Add(records[i].Club.ToString());
                itm.SubItems.Add(records[i].GoalCount.ToString());
                listView1.Items.Add(itm);
            }

        }

        private void Pridat_Hrace_Click(object sender, EventArgs e)
        {
            flag = false;
            PridaniAndUpravaForm form1 = new PridaniAndUpravaForm();
            form1.MainForm = this;
            form1.ShowDialog();


        }

        internal void receiveData(Player player)
        {
            if (flag)
            {
                records[indexx] = player;
                listView1.Items.Clear();
                for (int i = 0; i < records.Count; i++)
                {
                    ListViewItem itm = new ListViewItem(records[i].Name);
                    itm.SubItems.Add(records[i].Club.ToString());
                    itm.SubItems.Add(records[i].GoalCount.ToString());
                    listView1.Items.Add(itm);
                }
            }
            else { records.Add(player); }
        }

        private void Upravit_Hrace_Click(object sender, EventArgs e)
        {
            try
            {
                flag = true;
                PridaniAndUpravaForm form = new PridaniAndUpravaForm();
                form.MainForm = this;
                indexx = listView1.SelectedIndices[0];
                form.zapis(records[indexx]);
                form.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Vyberte položku", "Chyba!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Smazat_Hrace_Click(object sender, EventArgs e)
        {
            try
            {
                records.Delete(listView1.SelectedIndices[0]);
            }
            catch
            {
                MessageBox.Show("Vyberte položku", "Chyba!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nejlepsi_Kluby_Click(object sender, EventArgs e)
        {
            NejlepsiKloubForm2 form = new NejlepsiKloubForm2();
            form.records = records;
            form.ShowDialog();
        }

        private void button_NACIST(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "players (*.players)|*.players|All files (*.*)|*.*";
            openFileDialog.Title = "Open players file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PlayersFileSerializerDeserializer playersFile =
                    new PlayersFileSerializerDeserializer(records, openFileDialog.FileName);
                playersFile.Load();
            }
        }

        private void button_ULOZIT(object sender, EventArgs e)
        {
            if (records.Count == 0)
            {

                MessageBox.Show("Neni zadan zadny hrac!", "Chyba!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "players (*.players)|*.players|All files (*.*)|*.*";
            saveFileDialog.Title = "Save players file";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                PlayersFileSerializerDeserializer playersFile =
                    new PlayersFileSerializerDeserializer(records, saveFileDialog.FileName);
                playersFile.Save();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
