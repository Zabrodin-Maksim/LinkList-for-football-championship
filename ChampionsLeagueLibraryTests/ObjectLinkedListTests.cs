using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChampionsLeagueLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChampionsLeagueLibrary.Tests.TestUtils;

namespace ChampionsLeagueLibrary.Tests
{
    [TestClass()]
    public class ObjectLinkedListTests
    {
        private Type? type;
        private object? instance;
        private Type? entity;
        private object? pl1, pl2, pl3, pl4, pl5;

        [TestInitialize()]
        public void InitializeType()
        {
            type = typeof(FootballClub).Assembly.GetType("ChampionsLeagueLibrary.ObjectLinkedList");
            Assert.IsNotNull(type);

            instance = New(type);
            Assert.IsNotNull(instance);

            entity = typeof(FootballClub).Assembly.GetType("ChampionsLeagueLibrary.Player");
            Assert.IsNotNull(entity);

            pl1 = New(entity, "Peter", FootballClub.RealMadrid, 10);
            pl2 = New(entity, "John", FootballClub.Barcelona, 67);
            pl3 = New(entity, "Martin", FootballClub.Barcelona, 22);
            pl4 = New(entity, "Leo", FootballClub.Arsenal, 43);
            pl5 = New(entity, "Poe", FootballClub.Chelsea, 21);
        }

        [TestMethod()]
        public void ClassRealizesRequiredInterfacesTest()
        {
            var ienumerableType = type.GetInterface("IEnumerable");
            Assert.IsNotNull(ienumerableType);

            var icollectionType = type.GetInterface("ICollection");
            Assert.IsNotNull(icollectionType);

            var ilistType = type.GetInterface("IList");
            Assert.IsNotNull(ilistType);
        }


        [TestMethod()]
        public void IsSynchronizedPropertyTest()
        {
            bool actual = (bool)GetProperty(instance, "IsSynchronized");
            Assert.IsFalse(actual);
        }


        [TestMethod()]
        public void SyncRootPropertyTest()
        {
            object actual = (object)GetProperty(instance, "SyncRoot");
            Assert.AreSame(instance, actual);
        }

        [TestMethod()]
        public void IsFixedSizePropertyTest()
        {
            bool actual = (bool)GetProperty(instance, "IsFixedSize");
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void IsReadOnlyPropertyTest()
        {
            bool actual = (bool)GetProperty(instance, "IsReadOnly");
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void CountPropertyTest()
        {
            int actual = (int)GetProperty(instance, "Count");
            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        public void AddAndGetThroughIndexerTest()
        {
            Invoke(instance, "Add", pl1);

            Assert.AreEqual(1, GetProperty(instance, "Count"));
            Assert.AreEqual(pl1, IndexBy(instance, 0));
        }

        [TestMethod()]
        public void AddAndGetThroughIndexerWithDetailedIndexerTest()
        {
            Assert.IsNull(IndexBy(instance, -1));
            Assert.IsNull(IndexBy(instance, 0));
            Assert.IsNull(IndexBy(instance, 1));
            Assert.IsNull(IndexBy(instance, 2));

            Invoke(instance, "Add", pl1);

            Assert.AreEqual(1, GetProperty(instance, "Count"));
            
            Assert.IsNull(IndexBy(instance, -1));
            Assert.AreEqual(pl1, IndexBy(instance, 0));
            Assert.IsNull(IndexBy(instance, 1));
            Assert.IsNull(IndexBy(instance, 2));

            Invoke(instance, "Add", pl2);

            Assert.AreEqual(2, GetProperty(instance, "Count"));

            Assert.IsNull(IndexBy(instance, -1));
            Assert.AreEqual(pl1, IndexBy(instance, 0));
            Assert.AreEqual(pl2, IndexBy(instance, 1));
            Assert.IsNull(IndexBy(instance, 2));

            SetIndexBy(instance, 1, pl3);

            Assert.AreEqual(2, GetProperty(instance, "Count"));

            Assert.IsNull(IndexBy(instance, -1));
            Assert.AreEqual(pl1, IndexBy(instance, 0));
            Assert.AreEqual(pl3, IndexBy(instance, 1));
            Assert.IsNull(IndexBy(instance, 2));

            SetIndexBy(instance, 2, pl4);

            Assert.AreEqual(2, GetProperty(instance, "Count"));

            Assert.IsNull(IndexBy(instance, -1));
            Assert.AreEqual(pl1, IndexBy(instance, 0));
            Assert.AreEqual(pl3, IndexBy(instance, 1));
            Assert.IsNull(IndexBy(instance, 2));
        }

        [TestMethod()]
        public void ClearTest()
        {
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            SetIndexBy(instance, 1, pl3);

            Invoke(instance, "Clear");

            Assert.AreEqual(0, GetProperty(instance, "Count"));

            Assert.IsNull(IndexBy(instance, -1));
            Assert.IsNull(IndexBy(instance, 0));
            Assert.IsNull(IndexBy(instance, 1));
            Assert.IsNull(IndexBy(instance, 2));
        }

        [TestMethod()]
        public void ContainsTest()
        {
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            SetIndexBy(instance, 1, pl3);

            Assert.IsTrue((bool)Invoke(instance, "Contains", pl1));
            Assert.IsTrue((bool)Invoke(instance, "Contains", pl3));
            Assert.IsFalse((bool)Invoke(instance, "Contains", pl2));
            Assert.IsFalse((bool)Invoke(instance, "Contains", pl4));
        }

        [TestMethod()]
        public void CopyToTest()
        {
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            SetIndexBy(instance, 1, pl3);

            object?[] actual = new object?[5];
            object?[] expected = new object?[5] { null, pl1, pl3, null, null };

            Invoke(instance, "CopyTo", actual, 1);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            SetIndexBy(instance, 1, pl3);

            AssertByEnumerator(instance, pl1, pl3);
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            SetIndexBy(instance, 1, pl3);

            Assert.AreEqual(-1, Invoke(instance, "IndexOf", pl2));
            Assert.AreEqual(-1, Invoke(instance, "IndexOf", pl4));
            Assert.AreEqual(0, Invoke(instance, "IndexOf", pl1));
            Assert.AreEqual(1, Invoke(instance, "IndexOf", pl3));
        }

        [TestMethod()]
        public void InsertInvalidIndexesTest()
        {
            Invoke(instance, "Insert", -1, pl4);
            Assert.AreEqual(0, GetProperty(instance, "Count"));

            Invoke(instance, "Insert", 2, pl4);
            Assert.AreEqual(0, GetProperty(instance, "Count"));

            Invoke(instance, "Insert", 1, pl4);
            Assert.AreEqual(0, GetProperty(instance, "Count"));

            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);

            Invoke(instance, "Insert", 3, pl4);
            Assert.AreEqual(2, GetProperty(instance, "Count"));
        }


        [TestMethod()]
        public void InsertAtTheEndTest()
        {
            Invoke(instance, "Insert", 0, pl1);
            Assert.AreEqual(1, GetProperty(instance, "Count"));
            AssertByEnumerator(instance, pl1);

            Invoke(instance, "Insert", 1, pl2);
            Assert.AreEqual(2, GetProperty(instance, "Count"));
            AssertByEnumerator(instance, pl1, pl2);

            Invoke(instance, "Insert", 2, pl3);
            Assert.AreEqual(3, GetProperty(instance, "Count"));
            AssertByEnumerator(instance, pl1, pl2, pl3);
        }


        [TestMethod()]
        public void InsertAtTheBeginningTest()
        {
            Invoke(instance, "Insert", 0, pl1);
            Assert.AreEqual(1, GetProperty(instance, "Count"));
            AssertByEnumerator(instance, pl1);

            Invoke(instance, "Insert", 0, pl2);
            Assert.AreEqual(2, GetProperty(instance, "Count"));
            AssertByEnumerator(instance, pl2, pl1);

            Invoke(instance, "Insert", 0, pl3);
            Assert.AreEqual(3, GetProperty(instance, "Count"));
            AssertByEnumerator(instance, pl3, pl2, pl1);
        }

        [TestMethod()]
        public void InsertIntTheMiddleTest()
        {
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            Invoke(instance, "Add", pl3);

            Invoke(instance, "Insert", 1, pl4);
            AssertByEnumerator(instance, pl1, pl4, pl2, pl3);

            Invoke(instance, "Insert", 2, pl5);
            AssertByEnumerator(instance, pl1, pl4, pl5, pl2, pl3);

            Assert.AreEqual(5, GetProperty(instance, "Count"));
        }

        [TestMethod()]
        public void RemoveNonExistentObjectTest()
        {
            Invoke(instance, "Remove", pl5);

            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            Invoke(instance, "Add", pl3);

            Invoke(instance, "Remove", pl5);

            AssertByEnumerator(instance, pl1, pl2, pl3);
            Assert.AreEqual(3, GetProperty(instance, "Count"));
        }

        [TestMethod()]
        public void RemoveFromOneElementListTest()
        {
            Invoke(instance, "Add", pl1);
            
            Invoke(instance, "Remove", pl1);

            AssertByEnumerator(instance);
            Assert.AreEqual(0, GetProperty(instance, "Count"));
        }

        [TestMethod()]
        public void RemoveFromBeginningTest()
        {
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            Invoke(instance, "Add", pl3);

            Invoke(instance, "Remove", pl1);

            AssertByEnumerator(instance, pl2, pl3);
            Assert.AreEqual(2, GetProperty(instance, "Count"));
        }

        [TestMethod()]
        public void RemoveFromEndTest()
        {
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            Invoke(instance, "Add", pl3);

            Invoke(instance, "Remove", pl3);

            AssertByEnumerator(instance, pl1, pl2);
            Assert.AreEqual(2, GetProperty(instance, "Count"));
        }

        [TestMethod()]
        public void RemoveFromMiddleTest()
        {
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            Invoke(instance, "Add", pl3);

            Invoke(instance, "Remove", pl2);

            AssertByEnumerator(instance, pl1, pl3);
            Assert.AreEqual(2, GetProperty(instance, "Count"));
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            Invoke(instance, "RemoveAt", 0);

            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            Invoke(instance, "Add", pl3);

            Invoke(instance, "RemoveAt", 1);

            AssertByEnumerator(instance, pl1, pl3);
            Assert.AreEqual(2, GetProperty(instance, "Count"));

            Invoke(instance, "RemoveAt", 1);

            AssertByEnumerator(instance, pl1);
            Assert.AreEqual(1, GetProperty(instance, "Count"));

            Invoke(instance, "RemoveAt", 0);

            AssertByEnumerator(instance);
            Assert.AreEqual(0, GetProperty(instance, "Count"));
        }

        [TestMethod()]
        public void ComplexModificationsTest()
        {
            Invoke(instance, "Add", pl1);
            Invoke(instance, "Add", pl2);
            Invoke(instance, "Add", pl3);
            // 1 2 3
            Invoke(instance, "Remove", pl2);
            // 1 3
            Invoke(instance, "Insert", -1, pl1);
            Invoke(instance, "Insert", 0, pl1);
            // 1 1 3
            Invoke(instance, "Add", pl3);
            // 1 1 3 3
            Invoke(instance, "Add", pl4);
            Invoke(instance, "Add", pl5);
            // 1 1 3 3 4 5
            Invoke(instance, "Remove", pl4);
            Invoke(instance, "RemoveAt", 1);
            // 1 3 3 5
            Invoke(instance, "RemoveAt", 2);
            // 1 3 5
            Invoke(instance, "Insert", 1, pl2);
            // 1 2 3 5
            Invoke(instance, "Insert", 4, pl4);
            // 1 2 3 5 4
            Invoke(instance, "Remove", pl5);
            // 1 2 3 4
            Invoke(instance, "Insert", 5, pl5);
            Invoke(instance, "Insert", 4, pl5);
            // 1 2 3 4 5
            Invoke(instance, "Insert", 0, pl5);
            // 5 1 2 3 4 5

            AssertByEnumerator(instance, pl5, pl1, pl2, pl3, pl4, pl5);
            Assert.AreEqual(6, GetProperty(instance, "Count"));

            Invoke(instance, "RemoveAt", 5);
            // 5 1 2 3 4

            AssertByEnumerator(instance, pl5, pl1, pl2, pl3, pl4);
            Assert.AreEqual(5, GetProperty(instance, "Count"));
        }
    }
}