using lokalniIzboriVVSGrupa3Tim2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RezultatiGlasanjaTest
{
    [TestClass]
    public class RezultatiGlasanjaTest
    {
        [TestMethod]
        public void TestiranjeRezultataGlasanjaZaSveStranke()
        {
            LokalniIzbori lokalniIzbori = new LokalniIzbori();
            lokalniIzbori.KreirajIzbore();
            lokalniIzbori.IspisiInformacijeZaStranke();

            // provjera ko je pobijedio na izborima:
            Kandidat pobjednikGradonacelnik = lokalniIzbori.PobjednikGradonacelnik();
            Kandidat pobjednikNacelnik = lokalniIzbori.PobjednikNacelnik();
            List<Kandidat> pobjedniciVijecnici = lokalniIzbori.VratiDelegate();

            // Prema podacima gradonacelnik je Ismar Visca, nacelnik je Emir Ramadanovic, a vijecnik prvi je WT, a zadnji je Mera
            // TESTIRANJE POBJEDNIKA IZBORA:
            Assert.AreEqual(pobjednikGradonacelnik.Ime, "Ismar");
            StringAssert.Contains(pobjednikGradonacelnik.Ime, "sm");
            Assert.AreEqual(pobjednikNacelnik.Ime, "Emir");
            StringAssert.StartsWith("Em", "Emir".Substring(0, 2));
            Assert.AreEqual(pobjedniciVijecnici[0].Ime, "WTWTWT");
            StringAssert.EndsWith("WT", pobjedniciVijecnici[0].Ime.Substring(4, 2));
            Assert.AreEqual(pobjedniciVijecnici[9].Ime, "Mera");

            // TESTIRANJE BROJA GLASOVA KANDIDATA I STRANAKA (UKUPAN BROJ)
            Assert.AreEqual(233, lokalniIzbori.UkupanBrojGlasovaZaKandidate());
            Assert.AreEqual(103, lokalniIzbori.UkupanBrojGlasovaStranaka());

            // TESTIRANJE BROJA MANDATA PO STRANKAMA U SKUPŠTINI
            Dictionary<string, int> mandati = lokalniIzbori.BrojManadataPoStranici(pobjedniciVijecnici);
            Assert.AreEqual(3, mandati["SDA"]); // CASE-SENSITIV KEY !
            Assert.AreNotEqual(10, mandati["OSMORKA"]);
        }

        [TestMethod]
        public void TestiranjeRezultataZaJednuStranku()
        {
            LokalniIzbori lokalniIzbori = new LokalniIzbori();
            lokalniIzbori.KreirajIzbore();
            Stranka sda = new Stranka("SDA", "sklj");
            lokalniIzbori.IspisiInformacijeZaStranku(sda);

            // Provjera da li su pobjednici iz stranke SDA
            Kandidat pobjednikGradonacelnik = lokalniIzbori.PobjednikGradonacelnik();
            Kandidat pobjednikNacelnik = lokalniIzbori.PobjednikNacelnik();
            List<Kandidat> pobjedniciVijecnici = lokalniIzbori.VratiDelegate();
            Assert.AreEqual("SDA", pobjednikGradonacelnik.StrankaKandidata.NazivStranke);
            Assert.AreEqual("SDA", pobjednikGradonacelnik.StrankaKandidata.NazivStranke);
            Assert.AreNotEqual("SDA", pobjedniciVijecnici[0].StrankaKandidata.NazivStranke);
            Assert.AreNotEqual("SDA", pobjedniciVijecnici[9].StrankaKandidata.NazivStranke);

            // Gubitnicka stranka za nacelnik i gradonacelnika:
            Stranka osmorka = new Stranka("OSMORKA", "sklj");
            Assert.AreNotEqual("OSMORKA", pobjednikGradonacelnik.StrankaKandidata.NazivStranke);
            Assert.AreNotEqual("OSMORKA", pobjednikGradonacelnik.StrankaKandidata.NazivStranke);
        }
    }
}
