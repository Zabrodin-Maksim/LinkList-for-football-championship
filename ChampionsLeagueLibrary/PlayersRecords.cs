using System.Collections;
using System.Security.Cryptography;

namespace ChampionsLeagueLibrary;

#region Třída PlayersCountChangedEventArgs
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


#endregion

public delegate void PlayersCountChangedEventHandler(object s, PlayersCountChangedEventArgs player);

#region Třída PlayerRecords
public class PlayersRecords : IEnumerable, IPlayersSaveableLoadable
{


    ObjectLinkedList players;

    public int Count { get; set; } = 0;

    public event PlayersCountChangedEventHandler PlayersCountChanged;

   public Player? this[int index] { get { if (index > -1 && index < Count) { return (Player)players[index]; } else return null; } set { if (index > -1 && index < Count) { players[index] = value; } } }

    public PlayersRecords()
    {
        players = new ObjectLinkedList();
    }

   
    public void Add(Player player)
    {
        players.Add(player);
        Count = players.Count;
        PlayersCountChanged?.Invoke(this, new PlayersCountChangedEventArgs(players.Count -1, players.Count));
        
    }

   
    public void Delete(int index)
    {
        players.RemoveAt(index);
        Count = players.Count;
        PlayersCountChanged?.Invoke(this, new PlayersCountChangedEventArgs(players.Count + 1, players.Count));
        
        
    }
    
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