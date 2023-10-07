using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChampionsLeagueLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChampionsLeagueLibrary.Tests.TestUtils;
using System.Threading;

namespace ChampionsLeagueLibrary.Tests
{
    [TestClass()]
    public class PlayersCountChangedEventArgsTests
    {
        private Type? type;

        [TestInitialize]
        public void InitializeType()
        {
            type = typeof(FootballClub).Assembly.GetType("ChampionsLeagueLibrary.PlayersCountChangedEventArgs");
            Assert.IsNotNull(type);
        }

        [TestMethod]
        public void PropertiesTest()
        {
            var oldcount = type.GetProperty("OldCount");
            Assert.IsNotNull(oldcount);
            Assert.AreEqual(typeof(int), oldcount.PropertyType);

            var newcount = type.GetProperty("NewCount");
            Assert.IsNotNull(newcount);
            Assert.AreEqual(typeof(int), newcount.PropertyType);
        }
    }

    [TestClass()]
    public class PlayersCountChangedEventHandlerTests
    {
        private Type? type;

        [TestInitialize]
        public void InitializeType()
        {
            type = typeof(FootballClub).Assembly.GetType("ChampionsLeagueLibrary.PlayersCountChangedEventHandler");
            Assert.IsNotNull(type);
        }

        [TestMethod]
        public void DelegateTest()
        {
            var invoke = type.GetMethod("Invoke");
            Assert.AreEqual(typeof(void), invoke.ReturnType);
            var parameters = invoke.GetParameters();
            Assert.AreEqual(2, parameters.Length);
            Assert.AreEqual(typeof(object), parameters[0].ParameterType);
            var ea = typeof(FootballClub).Assembly.GetType("ChampionsLeagueLibrary.PlayersCountChangedEventArgs");
            Assert.AreEqual(ea, parameters[1].ParameterType);
        }
    }

    [TestClass()]
    public class PlayersRecordsTests
    {
        private Type? type;
        private object? instance;

        private Type? entity;

        [TestInitialize]
        public void InitializeType()
        {
            type = typeof(FootballClub).Assembly.GetType("ChampionsLeagueLibrary.PlayersRecords");
            Assert.IsNotNull(type);
            instance = New(type);
            Assert.IsNotNull(instance);

            entity = typeof(FootballClub).Assembly.GetType("ChampionsLeagueLibrary.Player");
            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void AddPlayerAndGetUsingIndexerTest()
        {
            Assert.AreEqual(0, GetProperty(instance, "Count"));

            object pl = New(entity, "Peter", FootballClub.RealMadrid, 10);
            Invoke(instance, "Add", pl);
            object? actual = IndexBy(instance, 0);

            Assert.AreEqual(pl, actual);
            Assert.AreEqual(1, GetProperty(instance, "Count"));
        }

        [TestMethod]
        public void AddTwoPlayersAndGetUsingIndexerTest()
        {
            object pl1 = New(entity, "Peter", FootballClub.RealMadrid, 10);
            object pl2 = New(entity, "John", FootballClub.Barcelona, 67);
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);

            Assert.AreEqual(pl1, IndexBy(instance, 0));
            Assert.AreEqual(pl2, IndexBy(instance, 1));

            Assert.AreEqual(2, GetProperty(instance, "Count"));
        }

        [TestMethod]
        public void ExtensiveIndexerTest()
        {
            Assert.IsNull(IndexBy(instance, -1));
            Assert.IsNull(IndexBy(instance, 0));
            Assert.IsNull(IndexBy(instance, 1));
            Assert.IsNull(IndexBy(instance, 2));

            object pl1 = New(entity, "Peter", FootballClub.RealMadrid, 10);
            object pl2 = New(entity, "John", FootballClub.Barcelona, 67);
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);

            Assert.IsNull(IndexBy(instance, -1));
            Assert.AreEqual(pl1, IndexBy(instance, 0));
            Assert.AreEqual(pl2, IndexBy(instance, 1));
            Assert.IsNull(IndexBy(instance, 2));
        }

        [TestMethod]
        public void AddAddAddAddDeleteIndexerTest()
        {
            object pl1 = New(entity, "Peter", FootballClub.RealMadrid, 10);
            object pl2 = New(entity, "John", FootballClub.Barcelona, 67);
            object pl3 = New(entity, "Martin", FootballClub.Barcelona, 22);
            object pl4 = New(entity, "Leo", FootballClub.Arsenal, 43);

            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            Invoke(instance, "Add", pl3);
            Invoke(instance, "Add", pl4);

            Invoke(instance, "Delete", 1);

            Assert.AreEqual(pl1, IndexBy(instance, 0));
            Assert.AreEqual(pl3, IndexBy(instance, 1));
            Assert.AreEqual(pl4, IndexBy(instance, 2));
            Assert.IsNull(IndexBy(instance, 3));

            Assert.AreEqual(3, GetProperty(instance, "Count"));
        }


        [TestMethod]
        public void EventTest()
        {
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            int eventCallIndex = 0;
            var expectedValues = new (int, int)[]
            {
                (0, 1),
                (1, 2),
                (2, 3),
                (3, 4),
                (4, 3)
            };

            RegisterEvent(instance, "PlayersCountChanged", (object s, EventArgs e) =>
            {
                var (expectedOld, expectedNew) = expectedValues[eventCallIndex++];

                Assert.IsNotNull(s);
                Assert.IsNotNull(e);

                int actualOld = (int)GetProperty(e, "OldCount");
                int actualNew = (int)GetProperty(e, "NewCount");

                Assert.AreEqual(expectedOld, actualOld);
                Assert.AreEqual(expectedNew, actualNew);

                if (eventCallIndex == 5)
                    autoResetEvent.Set();
            });

            object pl1 = New(entity, "Peter", FootballClub.RealMadrid, 10);
            object pl2 = New(entity, "John", FootballClub.Barcelona, 67);
            object pl3 = New(entity, "Martin", FootballClub.Barcelona, 22);
            object pl4 = New(entity, "Leo", FootballClub.Arsenal, 43);

            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            Invoke(instance, "Add", pl3);
            Invoke(instance, "Add", pl4);

            Invoke(instance, "Delete", 1);

            Assert.IsTrue(autoResetEvent.WaitOne(2000));
        }

        [TestMethod()]
        public void FindBestClubsTest()
        {
            var findBestClubs = instance.GetType().GetMethod("FindBestClubs");
            var parameters = new object[2];
            bool result = (bool)findBestClubs.Invoke(instance, parameters);

            Assert.AreEqual(false, result);
            Assert.IsTrue(parameters[0] is FootballClub[]);
            Assert.IsTrue(parameters[1] is int);
            Assert.IsTrue(((FootballClub[])parameters[0]).Length == 0);
            Assert.IsTrue(((int)parameters[1]) == 0);

            object pl1 = New(entity, "Peter", FootballClub.RealMadrid, 10);
            object pl2 = New(entity, "John", FootballClub.Barcelona, 67);
            object pl3 = New(entity, "Martin", FootballClub.Arsenal, 50);
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            Invoke(instance, "Add", pl3);

            parameters = new object[2];
            result = (bool)findBestClubs.Invoke(instance, parameters);

            Assert.AreEqual(true, result);
            Assert.IsTrue(((FootballClub[])parameters[0]).Length == 1);
            Assert.IsTrue(((int)parameters[1]) == 67);
            Assert.IsTrue(((FootballClub[])parameters[0])[0] == FootballClub.Barcelona);

            object pl4 = New(entity, "Leo", FootballClub.Arsenal, 17);
            Invoke(instance, "Add", pl4);

            parameters = new object[2];
            result = (bool)findBestClubs.Invoke(instance, parameters);

            Assert.AreEqual(true, result);
            Assert.IsTrue(((FootballClub[])parameters[0]).Length == 2);
            Assert.IsTrue(((int)parameters[1]) == 67);
            var actualClubs = (FootballClub[])parameters[0];
            Assert.IsTrue((actualClubs[0] == FootballClub.Barcelona && actualClubs[1] == FootballClub.Arsenal) ||
                (actualClubs[1] == FootballClub.Barcelona && actualClubs[0] == FootballClub.Arsenal));

            object pl5 = New(entity, "Lee", FootballClub.RealMadrid, 100);
            Invoke(instance, "Add", pl5);

            parameters = new object[2];
            result = (bool)findBestClubs.Invoke(instance, parameters);

            Assert.AreEqual(true, result);
            Assert.IsTrue(((FootballClub[])parameters[0]).Length == 1);
            Assert.IsTrue(((int)parameters[1]) == 110);
            Assert.IsTrue(((FootballClub[])parameters[0])[0] == FootballClub.RealMadrid);
        }

        [TestMethod()]
        public void AttributePlayersShouldntBeArrayTypeTest()
        {
            var field = type.GetField("players", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var fieldType = field.FieldType;

            Assert.IsFalse(fieldType.IsArray);
            Assert.IsFalse(fieldType.IsGenericType);
        }


        [TestMethod()]
        public void ClassRealizesRequiredInterfacesTest()
        {
            var ienumerableType = type.GetInterface("IEnumerable");
            Assert.IsNotNull(ienumerableType);
        }
    }
}