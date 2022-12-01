using lokalniIzboriVVSGrupa3Tim2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace StrankaTest
{
    [TestClass]
    public class StrankaTest
    {
        [TestMethod]
        public void TestPrikazaInformacijaORukovodstvu()
        {
            Biografija b1 = new Biografija("kandidat1", "proba1", new DateTime(1999, 1, 1), "dasdasdas", "dasdasda", "dadada");
            Stranka s1 = new Stranka("SDA", "DADASDASDASDSA");
            Pozicija p1 = new Pozicija(NazivPozicije.nacelnik, "dasdasdsa", 33);
            Kandidat k = new Kandidat("Isko", "Iskić", new DateTime(2000, 9, 9), "adresa 23", "999T999", "0909000170065", Pol.muski, b1, s1, p1, 33);
            s1.Rukovodstvo.Add(k);
            StringAssert.StartsWith(s1.PrikazRezultataRukovodstva(), "Naziv stranke: SDA");
            StringAssert.Contains(s1.PrikazRezultataRukovodstva(), "Identifikacioni broj");
        }


        static IEnumerable<object[]> Stranke
        {
            get
            {
                return new[]
                {
                    new object[] { "SDA", "sdaaaaaaaa" },
                    new object[] { "SDP", "sdpppppppp" },
                    new object[] { "PDP", "pdpppppppp" },
                    new object[] { "NIP", "nipppppppp" },
                    new object[] { "HDZ", "hdzzzzzzzz" }
                };
            }
        }

        [TestMethod]
        [DynamicData("Stranke")]
        public void TestSettera(string naziv, string opis)
        {
            Stranka s = new Stranka(naziv, opis);
            s.NazivStranke = "PROBA";
            s.OpisStranke = "Probaaa";
            s.BrojGlasova = 200;
            s.RedniBrojMjesta = 30;
            Assert.AreEqual("PROBA", s.NazivStranke);
            Assert.AreEqual("Probaaa", s.OpisStranke);
            Assert.AreEqual(200, s.BrojGlasova);
            Assert.AreEqual(30, s.RedniBrojMjesta);
        }
    }
}
