using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChampionsLeagueLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using static ChampionsLeagueLibrary.Tests.TestUtils;

namespace ChampionsLeagueLibrary.Tests
{
    [TestClass()]
    public class FootballClubInfoTests
    {
        private Type? footballClubInfoType;

        [TestInitialize]
        public void InitializeType()
        {
            footballClubInfoType = typeof(FootballClub).Assembly.GetType("ChampionsLeagueLibrary.FootballClubInfo");

            Assert.IsNotNull(footballClubInfoType);
        }


        [TestMethod()]
        public void CountConstantTest()
        {
            var count = footballClubInfoType.GetField("Count", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            Assert.IsNotNull(count);

            int value = (int)count.GetValue(null);
            Assert.AreEqual(6, value);

        }

        [TestMethod()]
        public void ItemsPropertyTest()
        {
            var items = footballClubInfoType.GetProperty("Items", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            Assert.IsNotNull(items);

            Assert.AreEqual(typeof(IEnumerable), items.PropertyType);

            IEnumerable value = (IEnumerable)items.GetValue(null);
            List<object> actualItems = new();
            foreach (var item in value)
                actualItems.Add(item);

            List<object> expectedItems = new(new object[]{
                FootballClub.None,
                FootballClub.FCPorto,
                FootballClub.Arsenal,
                FootballClub.RealMadrid,
                FootballClub.Chelsea,
                FootballClub.Barcelona
            });

            CollectionAssert.AreEqual(expectedItems, actualItems);
        }

        [TestMethod()]
        public void GetNameMethodTest()
        {
            var getname = footballClubInfoType.GetMethod("GetName", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            Assert.IsNotNull(getname);

            Assert.AreEqual("", getname.Invoke(null, new object?[] { FootballClub.None }));
            Assert.AreEqual("FC Porto", getname.Invoke(null, new object?[] { FootballClub.FCPorto }));
            Assert.AreEqual("Arsenal", getname.Invoke(null, new object?[] { FootballClub.Arsenal }));
            Assert.AreEqual("Real Madrid", getname.Invoke(null, new object?[] { FootballClub.RealMadrid }));
            Assert.AreEqual("Chelsea", getname.Invoke(null, new object?[] { FootballClub.Chelsea }));
            Assert.AreEqual("Barcelona", getname.Invoke(null, new object?[] { FootballClub.Barcelona }));
        }
    }
}