using Conservatoire.DAL;
using Conservatoire.modele;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogin1()
        {
            Assert.AreEqual(true, LoginApi.verifLogin("GuilhermeAdmin", "m4,h2.tCe1H5R#", LoginApi.recupJson()));
        }

        [TestMethod]
        public void TestLogin2()
        {
            Assert.AreEqual(false, LoginApi.verifLogin("ufiguf", "fpafgapap", LoginApi.recupJson()));
        }

        [TestMethod]
        public void TestLogin3()
        {
            Assert.AreEqual(false, LoginApi.verifLogin("", "", LoginApi.recupJson()));
        }
    }
}
