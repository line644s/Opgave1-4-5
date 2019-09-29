using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using ModelLib.Exceptions;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        private Bog bog;
        [TestInitialize]
        public void Initialize()
        {
            bog = new Bog("Soulless", "Gail Carriger", 352, "123456789abcd");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionTooSmall))]
        public void TestBogTitle()
        {
            bog = new Bog("S", "Gail Carriger", 352, "123456789abcd");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionTooSmall))]
        public void TestBogSidetal()
        {
            bog = new Bog("S", "Gail Carriger", 1, "123456789abcd");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionTooSmall))]
        public void TestBogIsbn13()
        {
            bog = new Bog("S", "Gail Carriger", 352, "123");
        }

        [TestMethod]
        public void TestTitle()
        {
            bog.Title = "So";
            Assert.AreEqual("So", bog.Title);
            bog.Title = "Sou";
            Assert.AreEqual("Sou", bog.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionTooSmall))]
        public void TestTitleException()
        {
            bog.Title = "s";
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionTooSmall))]
        public void TestTitleExceptionEmpty()
        {
            bog.Title = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionEmpty))]
        public void TestTitleExceptionNull()
        {
            bog.Title = null;
        }

        [TestMethod]
        public void TestSidetal()
        {
            bog.Sidetal = 10;
            Assert.AreEqual(10, bog.Sidetal);
            bog.Sidetal = 11;
            Assert.AreEqual(11, bog.Sidetal);
            bog.Sidetal = 1000;
            Assert.AreEqual(1000, bog.Sidetal);
            bog.Sidetal = 999;
            Assert.AreEqual(999, bog.Sidetal);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionTooSmall))]
        public void TestSidetalForLille()
        {
            bog.Sidetal = 9;
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionTooBig))]
        public void TestSidetalForStor()
        {
            bog.Sidetal = 1001;
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionTooSmall))]
        public void TestIsbn13ForLille()
        {
            bog.Isbn13 = "123456789abc";
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionTooBig))]
        public void TestIsbn13ForStor()
        {
            bog.Isbn13 = "123456789abcde";
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionEmpty))]
        public void TestIsbn13Null()
        {
            bog.Isbn13 = null;
        }
    }
}
