using Microsoft.VisualStudio.TestTools.UnitTesting;
using Turnierklassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen.Tests
{
    [TestClass()]
    public class VeranstaltungTests
    {
        [TestMethod()]
        public void Veranstaltung_Kann_Erstellt_Werden()
        {
            Veranstaltung TestVeranstaltung = new Veranstaltung();
        }

        [TestMethod()]
        public void Ein_Turnier_Kann_Hinzugefuegt_Werden()
        {
            Veranstaltung TestVeranstaltung = new Veranstaltung();

            TestVeranstaltung.Turniere.Add(new Turnier());

            Assert.AreEqual(1, TestVeranstaltung.Turniere.Count);
        }
    }
}