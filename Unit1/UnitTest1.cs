using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab9;

namespace _1test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            CarParking expected = new CarParking();
            //Act
            CarParking actual = new CarParking();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_IncrementElse()
        {
            CarParking expected = new CarParking(1, 1);
            CarParking actual = new CarParking(1, 1);
            actual++;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_IncrementIf()
        {
            CarParking expected = new CarParking(2, 3);
            CarParking actual = new CarParking(1, 3);
            actual++;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_DicrementElse()
        {
            CarParking expected = new CarParking(0, 1);
            CarParking actual = new CarParking(0, 1);
            actual--;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_DicrementIf()
        {
            CarParking expected = new CarParking(1, 2);
            CarParking actual = new CarParking(2, 2);
            actual--;
            Assert.AreEqual(expected, actual);
        }
        public void TestMethod_OperetorPlus()
        {
            CarParking expected = new CarParking(5, 20);
            CarParking actual1 = new CarParking(2, 10);
            CarParking actual2 = new CarParking(3, 10);
            CarParking actual = actual1 + actual2;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod_NegativeNumSlots()
        {
            CarParking p = new CarParking();
            Assert.ThrowsException<Exception>(() => { new CarParking(1, -2); });
        }
        [TestMethod]
        public void TestMethod_NegativeNumCars()
        {
            CarParking p = new CarParking();
            Assert.ThrowsException<Exception>(() => { new CarParking(-1, 6); });
        }
        [TestMethod]
        public void TestMethod_CarsMoreSlots()
        {
            CarParking p = new CarParking();
            Assert.ThrowsException<Exception>(() => { new CarParking(6, 2); });
        }

        [TestMethod]
        public void TestMethod_Copy()
        {
            CarParking actual = new CarParking();
            CarParking expected = new CarParking(actual);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethod_explicit()
        {
            CarParking expected = new CarParking(6, 10);
            CarParking actual = new CarParking(2, 10);
            int Actual = (int)actual;
            Assert.AreEqual(expected.NumCars, Actual);
        }
        [TestMethod]
        public void TestMethod_implicit()
        {
            bool expected = true;
            CarParking actual = new CarParking(2, 10);
            bool Actual = actual;
            Assert.AreEqual(expected, Actual);
        }

        [TestMethod]
        public void TestMethod_OperatorMore() // >
        {
            bool expected = true;
            CarParking p1 = new CarParking(2, 20);
            CarParking p2 = new CarParking(2, 10);
            bool Actual = p1 > p2;
            Assert.IsTrue(expected == Actual);
        }

        [TestMethod]
        public void TestMethod_OperatorLess()  // <
        {
            bool expected = true;
            CarParking p1 = new CarParking(2, 5);
            CarParking p2 = new CarParking(2, 10);
            bool Actual = p1 < p2;
            Assert.AreEqual(expected, Actual);
        }

        //Class2
        [TestMethod]
        public void TestMethod_DepthCollection()
        {
            CarParkingArray cp = new CarParkingArray(3);
            Assert.ThrowsException<Exception>(() => { new CarParking(cp[10]); });
        }
        [TestMethod]
        public void TestMethod_Length()
        {
            CarParkingArray expected = new CarParkingArray();
            CarParkingArray actual = new CarParkingArray();
            Assert.AreEqual(expected.Length, actual.Length);
        }
        [TestMethod]
        public void TestMethod_Params()
        {
            CarParking CP1 = new CarParking(1, 2);
            CarParking CP2 = new CarParking(3, 4);
            CarParkingArray expected = new CarParkingArray(CP1, CP2);
            Assert.AreEqual(expected.Length, 2);
        }
        [TestMethod]
        public void TestMethod_CopyArray()
        {
            CarParkingArray expected = new CarParkingArray(2);
            CarParkingArray actual = new CarParkingArray(expected);
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }
        [TestMethod]
        public void TestMethod_NegativeIndex()
        {
            CarParkingArray cp = new CarParkingArray(3);
            Assert.ThrowsException<Exception>(() => { new CarParking(cp[-1]); });
        }
    }
}
