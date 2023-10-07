namespace ChampionsLeagueLibrary;

#region Třída Player
// TODO: Vytvořte třídu Player
public class Player
{
    public string Name { get; set; }

    public FootballClub Club { get; set; }

    public int GoalCount { get; set; }

    public Player(string name, FootballClub club, int goalCount)
    {
        Name = name;
        Club = club;
        GoalCount = goalCount;
    }

    public override bool Equals(Object? obj)
    {
        if (obj == null) return false;
        Player? other = obj as Player;

        if (this.Name == other?.Name &&
            this.Club == other?.Club &&
            this.GoalCount == other?.GoalCount)
        {
            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() * this.Club.GetHashCode() * this.GoalCount.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Name} {Club} {GoalCount}";
    }
}
// TODO: Vytvořte vlastnosti
// - string Name
// - FootballClub Club
// - int GoalCount

// TODO: Vytvořte parametrický konstruktor (name, club, goalCount)

#endregion
