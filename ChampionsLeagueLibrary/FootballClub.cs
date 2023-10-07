using System.Collections;

namespace ChampionsLeagueLibrary;

public enum FootballClub
{
    None,
    FCPorto,
    Arsenal,
    RealMadrid,
    Chelsea,
    Barcelona
}

#region Třída FootballClubInfo
public static class FootballClubInfo
{
    public const int Count = 6;

    public static IEnumerable Items
    {
        get
        {
            List<FootballClub> list = new();
            list.Add(FootballClub.None);
            list.Add(FootballClub.FCPorto);
            list.Add(FootballClub.Arsenal);
            list.Add(FootballClub.RealMadrid);
            list.Add(FootballClub.Chelsea);
            list.Add(FootballClub.Barcelona);
            return list;
        }

    }
    public static string GetName(FootballClub footballClub)
    {
        switch(footballClub) {
            case FootballClub.None: return "";
            case FootballClub.FCPorto: return "FC Porto";
            case FootballClub.Arsenal: return "Arsenal";
            case FootballClub.RealMadrid: return "Real Madrid";
            case FootballClub.Chelsea: return "Chelsea";
            case FootballClub.Barcelona: return "Barcelona";
            default:
                return string.Empty;
        }
    }
}

#endregion
