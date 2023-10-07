using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChampionsLeagueLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static ChampionsLeagueLibrary.Tests.TestUtils;

namespace ChampionsLeagueLibrary.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        private Type? playerType;

        [TestInitialize]
        public void InitializeType()
        {
            playerType = typeof(FootballClub).Assembly.GetType("ChampionsLeagueLibrary.Player");

            Assert.IsNotNull(playerType);
        }

        [TestMethod()]
        public void NamePropertyTest()
        {
            dynamic? player = New(playerType, "Peter", FootballClub.RealMadrid, 123);
            Assert.AreEqual("Peter", player?.Name);
        }

        [TestMethod()]
        public void ClubPropertyTest()
        {
            dynamic? player = New(playerType, "Peter", FootballClub.RealMadrid, 123);
            Assert.AreEqual(FootballClub.RealMadrid, player?.Club);
        }

        [TestMethod()]
        public void GoalCountPropertyTest()
        {
            dynamic? player = New(playerType, "Peter", FootballClub.RealMadrid, 123);
            Assert.AreEqual(123, player?.GoalCount);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            object? pl1 = New(playerType, "Peter", FootballClub.RealMadrid, 123);
            object? pl1_0 = New(playerType, "Peter", FootballClub.RealMadrid, 123);
            object? pl2 = New(playerType, "John", FootballClub.Arsenal, 100);
            
            object? pl1_a = New(playerType, "Peter1", FootballClub.RealMadrid, 123);
            object? pl1_b = New(playerType, "Peter", FootballClub.Arsenal, 123);
            object? pl1_c = New(playerType, "Peter", FootballClub.RealMadrid, 122);

            Assert.IsTrue((bool)Invoke(pl1, "Equals", pl1));
            Assert.IsTrue((bool)Invoke(pl1, "Equals", pl1_0));
            //Assert.IsFalse((bool)Invoke(pl1, "Equals", null));
            Assert.IsFalse((bool)Invoke(pl1, "Equals", pl2));

            Assert.IsFalse((bool)Invoke(pl1, "Equals", pl1_a));
            Assert.IsFalse((bool)Invoke(pl1, "Equals", pl1_b));
            Assert.IsFalse((bool)Invoke(pl1, "Equals", pl1_c));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            object? pl1 = New(playerType, "Peter", FootballClub.RealMadrid, 123);
            object? pl1_0 = New(playerType, "Peter", FootballClub.RealMadrid, 123);

            Assert.IsTrue((int)Invoke(pl1, "GetHashCode") == (int)Invoke(pl1, "GetHashCode"));
            Assert.IsTrue((int)Invoke(pl1, "GetHashCode") == (int)Invoke(pl1_0, "GetHashCode"));
        }
    }
}