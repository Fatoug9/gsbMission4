using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using gsbFatou;
namespace UnitTestProject_gsbMission4
{
    [TestClass]
    public class UnitTest1
    {
        GestionDate d = new GestionDate();

        [TestMethod]
        public void TestMethod1()
        {

            Assert.AreEqual("02/2021", d.moisPrecedent(), "Erreur");
            Assert.AreEqual("03/2021", d.dateJour(), "Erreur");
            Assert.AreEqual("04/2021", d.moisSuivant(), "Erreur");
        }
    }
}
