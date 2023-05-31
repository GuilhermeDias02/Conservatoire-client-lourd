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
        public void TestLogin()
        {
            Assert.AreEqual(true, LoginApi.verifLogin("GuilhermeAdmin", "m4,h2.tCe1H5R#", LoginApi.recupJson()));
        }
    }
}
