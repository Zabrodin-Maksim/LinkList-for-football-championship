using System.Collections;
using System.Security.Cryptography;

namespace ChampionsLeagueLibrary;

#region Třída PlayersCountChangedEventArgs
// TODO: Vytvořte třídu PlayersCountChangedEventArgs (dědící z EventArgs)
public class PlayersCountChangedEventArgs : EventArgs
{
   public int OldCount { get; set; }
    public int NewCount { get; set; }

    public PlayersCountChangedEventArgs(int oldCount, int newCount)
    {
        OldCount = oldCount;
        NewCount = newCount;
    }
}
// - vlastnost int OldCount
// - vlastnost int NewCount

#endregion

// TODO: Vytvořte delegát pro událost PlayersCountChangedEventHandler (využijte výše definované event args)
public delegate void PlayersCountChangedEventHandler(object s, PlayersCountChangedEventArgs player);

#region Třída PlayerRecords
// TODO: Vytvořte třídu PlayersRecords
public class PlayersRecords : IEnumerable, IPlayersSaveableLoadable
{

    // TODO: Vytvořte atribut players typu Player[]

    ObjectLinkedList players;

    // TODO: Vytvořte vlastnost Count (pouze pro čtení), která vždy vrací aktuální velikost pole players
    public int Count { get; set; } = 0;

    // TODO: Vytvořte událost PlayersCountChanged (PlayersCountChangedEventHandler)
    public event PlayersCountChangedEventHandler PlayersCountChanged;

    // TODO: vytvořte indexer [int index], který umožňuje získat Player? z pole (pouze operace get)
    // - get - pokud je index neplatný, je vráceno null; jinak je vrácen objekt z pole
   public Player? this[int index] { get { if (index > -1 && index < Count) { return (Player)players[index]; } else return null; } set { if (index > -1 && index < Count) { players[index] = value; } } }

    // TODO: Vytvořte bezparametrický konstruktor
    // - inicializujte pole players na pole délky 0
    public PlayersRecords()
    {
        players = new ObjectLinkedList();
    }

    // TODO: Vytvořte metodu void Add(Player player)
    // - zvětšete velikost pole o jeden prvek
    // - na poslední index v poli je vložen nový hráč (player)
    // - vyvolejte událost PlayersCountChanged s příslušnými argumenty

    public void Add(Player player)
    {
        players.Add(player);
        Count = players.Count;
        PlayersCountChanged?.Invoke(this, new PlayersCountChangedEventArgs(players.Count -1, players.Count));
        //Player[] newPlayers = new Player[Count + 1];
        //for ( int i = 0; i < Count; i++ )
        //{
        //    newPlayers[i] = players[i];
        //}
        //int old = Count;
        //newPlayers[Count] = player;
        //players = newPlayers;
        //PlayersCountChanged?.Invoke(this, new PlayersCountChangedEventArgs(old , players.Length));
    }

    // TODO: Vytvořte metodu void Delete(int index)
    // - pokud je index neplatný - metoda nedělá nic
    // - odeberte vybraného hráče z pole, pole setřeste (posuňte hráče z vyšších indexů, tak aby byla zaplněna (null) mezera; zachovejte pořadí hráčů)
    // - zmenšete velikost pole o 1 prvek
    // - vyvolejte událost PlayersCountChanged s příslušnými argumenty
    public void Delete(int index)
    {
        players.RemoveAt(index);
        Count = players.Count;
        PlayersCountChanged?.Invoke(this, new PlayersCountChangedEventArgs(players.Count + 1, players.Count));
        //if(index < Count && index > -1)
        //{
        //    players[index] = null;
        //    for (int i = index; i < Count-1; i++ ) {
        //        players[i] = players[i+1];
        //    }

        //    Player[] newPlayers = new Player[Count - 1];
        //    for(int i = 0; i < Count-1;i++ )
        //    {
        //        newPlayers[i] = players[i];
        //    }
        //    int old = Count;
        //    players = newPlayers;

        //    PlayersCountChanged?.Invoke(this,new PlayersCountChangedEventArgs(old, players.Length));
        //}
    }
    // TODO: Vytvořte metodu bool FindBestClubs(...)
    // - výstupní parametr FootballClub[] clubs
    // - výstupní parametr int goalCount
    // - pokud je pole players prázdné - pak - clubs: prázdné pole, goalCount: 0, metoda vrací false
    // - sečtěte počty gólů podle klubů
    // - najděte maximální počet gólů a uložte jej do goalCount
    // - najděte všechny kluby, které mají celkově goalCount gólů a uložte je do clubs
    // - vraťte true
    public bool FindBestClubs(out FootballClub[] clubs, out int goalCount)
    {
        Console.WriteLine("Inter");
        if (Count == 0) {
            clubs = new FootballClub[0];
            goalCount = 0;
            Console.WriteLine("NULL");
            return false;
        }

        Dictionary<FootballClub, int> clubGoals = new Dictionary<FootballClub, int>();
        for(int i = 0; i < Count; i++)
        {
            Player pl = GetPlayer(i);
            if (!clubGoals.ContainsKey(pl.Club))
            {
                clubGoals[pl.Club] = 0;
            }

            clubGoals[pl.Club] += pl.GoalCount;
        }
        goalCount = clubGoals.Values.Max();
        int n = goalCount;
        clubs = clubGoals.Where(x => x.Value == n)
                         .Select(x => x.Key)
                         .ToArray();
        return true;
    }
    public Player GetPlayer(int index)
    {
        return (Player)players[index];
    }

    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)players).GetEnumerator();
    }

    public Player[] Save()
    {
        Player[] arrayOfPlayers = new Player[Count];
        for (int i = 0; i < Count; i++)
        {
            arrayOfPlayers[i] = (Player)players[i];
        }
        return arrayOfPlayers;
    }

    public void Load(Player[] loadedPlayers)
    {
        players.Clear();
        Count = 0;

        foreach (Player player in loadedPlayers)
        {
            if(player != null) { players.Add(player); }
            
        }
        Count = players.Count;
    }
}



#endregion