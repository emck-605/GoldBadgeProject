using KomodoCafePOCO;
using KomodoCafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeUnitTest
{
    [TestClass]
    public class CafeTests
    {
        [TestClass]
        public class Tests
        {
            private CafeRepo _contentRepo;
            private CafeMenu _content;

            [TestInitialize]
            public void Initialize()
            {
                _contentRepo = new CafeRepo();
                _content = new CafeMenu(4, "French Fries", "Hot and ready french fries.", "fried sliced potatoes");
            }

            [TestMethod]
            public void AddContentToList()
            {
                _contentRepo.AddItem(_content);
                int expected = 1;
                int actual = _contentRepo.ListItems().Count;
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void RemoveContentFromList()
            {
                CafeRepo contentRepo = new CafeRepo();
                contentRepo.AddItem(_content);
                bool wasRemoved = contentRepo.RemoveItem(_content);
                Assert.IsTrue(wasRemoved);
            }

            [TestMethod]
            public void POCOTest()
            {
                CafeMenu newitem = new CafeMenu(1, "Hot Dog", "Hot Dog with your choice of toppings.", "hot dog inside of a fresh bun with a choice of ketchup, mustard, relish, and/or chili sauce.");
                Assert.AreEqual(1, newitem.ItemNumber);
                Assert.AreEqual("Hot Dog", newitem.Name);
                Assert.AreEqual("Hot Dog with your choice of toppings.", newitem.Description);
                Assert.AreEqual("hot dog inside of a fresh bun with a choice of ketchup, mustard, relish, and/or chili sauce.", newitem.Ingredients);
            }
        }
    }
}
