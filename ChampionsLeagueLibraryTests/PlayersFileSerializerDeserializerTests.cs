using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChampionsLeagueLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static ChampionsLeagueLibrary.Tests.TestUtils;

namespace ChampionsLeagueLibrary.Tests
{
    [TestClass()]
    public class PlayersFileSerializerDeserializerTests
    {
        private Type? type;
        private Type? playerRecordsType;
        private Type? entity;

        private object? records;
        private object? obj;
        private object? pl1, pl2, pl3, pl4;

        [TestInitialize]
        public void InitializeType()
        {
            type = typeof(FootballClub).Assembly.GetType("ChampionsLeagueLibrary.PlayersFileSerializerDeserializer");
            Assert.IsNotNull(type);

            playerRecordsType = typeof(FootballClub).Assembly.GetType("ChampionsLeagueLibrary.PlayersRecords");
            Assert.IsNotNull(playerRecordsType);

            entity = typeof(FootballClub).Assembly.GetType("ChampionsLeagueLibrary.Player");
            Assert.IsNotNull(entity);

            records = New(playerRecordsType);

            pl1 = New(entity, "Peter", FootballClub.RealMadrid, 10);
            pl2 = New(entity, "John", FootballClub.Barcelona, 67);
            pl3 = New(entity, "Martin", FootballClub.Barcelona, 22);
            pl4 = New(entity, "Leo", FootballClub.Arsenal, 43);

            Invoke(records, "Add", pl1);
            Invoke(records, "Add", pl2);
            Invoke(records, "Add", pl3);
            Invoke(records, "Add", pl4);
        }

        [TestMethod()]
        public void DeserializeSerializePlayerTest()
        {
            obj = New(type, records, "file.tmp");
            object? expectedPlayer = New(entity, "Peter", FootballClub.RealMadrid, 12);
            object? actualPlayer = InvokePrivateStatic(obj, "Deserialize", InvokePrivateStatic(obj, "Serialize", expectedPlayer));

            Assert.AreEqual(GetProperty(expectedPlayer, "Name"), GetProperty(actualPlayer, "Name"));
            Assert.AreEqual(GetProperty(expectedPlayer, "Club"), GetProperty(actualPlayer, "Club"));
            Assert.AreEqual(GetProperty(expectedPlayer, "GoalCount"), GetProperty(actualPlayer, "GoalCount"));

            expectedPlayer = New(entity, "%~P#téř th@t'$ \"h&rdly-serial*zable\", f°lks:_:; a.k.a^ student {[<(n|ghtm4r3)>]}?! /separator+hell\\name", FootballClub.RealMadrid, 12);
            actualPlayer = InvokePrivateStatic(obj, "Deserialize", InvokePrivateStatic(obj, "Serialize", expectedPlayer));

            Assert.AreEqual(GetProperty(expectedPlayer, "Name"), GetProperty(actualPlayer, "Name"));
            Assert.AreEqual(GetProperty(expectedPlayer, "Club"), GetProperty(actualPlayer, "Club"));
            Assert.AreEqual(GetProperty(expectedPlayer, "GoalCount"), GetProperty(actualPlayer, "GoalCount"));
        }

        [TestMethod()]
        public void SaveLoadIntegrationTest()
        {
            string tempFileName = Path.GetTempFileName();

            obj = New(type, records, tempFileName);
            Invoke(obj, "Save");

            records = New(playerRecordsType);

            obj = New(type, records, tempFileName);
            Invoke(obj, "Load");

            Assert.AreEqual(4, GetProperty(records, "Count"));
            Assert.AreEqual(pl1, IndexBy(records, 0));
            Assert.AreEqual(pl2, IndexBy(records, 1));
            Assert.AreEqual(pl3, IndexBy(records, 2));
            Assert.AreEqual(pl4, IndexBy(records, 3));
        }
    }
}