namespace ChampionsLeagueLibrary
{
    public class PlayersFileSerializerDeserializer
    {
        readonly IPlayersSaveableLoadable players;
        readonly string file;

        public PlayersFileSerializerDeserializer(IPlayersSaveableLoadable players, string file)
        {
            this.players = players;
            this.file = file;
        }

        public void Save()
        {
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (Player player in players.Save())
                    {
                        sw.WriteLine(Serialize(player));
                    }
                }
            }

        }

        public void Load()
        {
            int count = 1;
            Player[] arrayOfPlayers = new Player[count];
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                using (StreamReader sw = new StreamReader(fs))
                {
                    while (sw.Peek() >= 0)
                    {
                        arrayOfPlayers[count - 1] = Deserialize(sw.ReadLine());
                        Array.Resize(ref arrayOfPlayers, ++count);
                    }
                }
            }
            players.Load(arrayOfPlayers);
        }

        private static string Serialize(Player p)
        {
            return $"{p.Name} {p.Club} {p.GoalCount}";
        }

        private static Player Deserialize(string s)
        {
            string[] str = s.Split(' ');
            string name = "";
            if (str.Length > 3)
            {
                for (int i = 0; i < str.Length - 2; i++)
                {
                    if (i == str.Length - 3)
                    {
                        name += str[i];
                        break;
                    }
                    name += str[i] + " ";
                }
                str[0] = name;
            }
            return new Player(str[0], StingToClub(str[str.Length - 2]), int.Parse(str[str.Length - 1]));
        }

        private static FootballClub StingToClub(string club)
        {
            switch (club)
            {
                case "None":
                    return FootballClub.None;
                case "FCPorto":
                    return FootballClub.FCPorto;
                case "Arsenal":
                    return FootballClub.Arsenal;
                case "RealMadrid":
                    return FootballClub.RealMadrid;
                case "Chelsea":
                    return FootballClub.Chelsea;
                case "Barcelona":
                    return FootballClub.Barcelona;
                default:
                    return FootballClub.None;
            }
        }
    }
}
