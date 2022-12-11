using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using lokalniIzboriVVSGrupa3Tim2;
using System.Formats.Asn1;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;

namespace UnitTest1
{
    [TestClass]
    public class GlasacTest
    {
        [TestMethod]
        public void TestIspravnogKonstruktoraKlaseGlasac1()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
            Assert.AreEqual("Merim", g.Ime);
            Assert.AreEqual("Kulovac", g.Prezime);
            Assert.AreEqual(new DateTime(1999, 8, 28), g.DatumRodjenja);
            Assert.AreEqual("Hrasnicka cesta 23", g.Adresa);
            Assert.AreEqual("321T999", g.BrojLicneKarte);
            Assert.AreEqual("2808999170065", g.Jmbg);
            Assert.AreEqual(Pol.muski, g.Pol);
        }

        [TestMethod]
        public void TestIspravnogKonstruktoraKlaseGlasac2()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 8), "Hrasnicka cesta 23", "321T999", "0808999170065", Pol.muski);
            Assert.AreEqual("Merim", g.Ime);
            Assert.AreEqual("Kulovac", g.Prezime);
            Assert.AreEqual(new DateTime(1999, 8, 8), g.DatumRodjenja);
            Assert.AreEqual("Hrasnicka cesta 23", g.Adresa);
            Assert.AreEqual("321T999", g.BrojLicneKarte);
            Assert.AreEqual("0808999170065", g.Jmbg);
            Assert.AreEqual(Pol.muski, g.Pol);
            Assert.IsFalse(g.GlasaoZaVijecnika);
            Assert.IsFalse(g.GlasaoZaGradonacelnika);
            Assert.IsFalse(g.GlasaoZaNacelnika);
        }

        [TestMethod]
        public void TestIspravnogKonstruktoraKlaseGlasac3()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 11, 28), "Hrasnicka cesta 23", "321T999", "2811999170065", Pol.muski);
            Assert.AreEqual("Merim", g.Ime);
            Assert.AreEqual("Kulovac", g.Prezime);
            Assert.AreEqual(new DateTime(1999, 11, 28), g.DatumRodjenja);
            Assert.AreEqual("Hrasnicka cesta 23", g.Adresa);
            Assert.AreEqual("321T999", g.BrojLicneKarte);
            Assert.AreEqual("2811999170065", g.Jmbg);
            Assert.AreEqual(Pol.muski, g.Pol);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDuzineImenaIzuzetak1()
        {
            Glasac g1 = new Glasac("M", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);        
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDuzineImenaIzuzetak2()
        {
            Glasac g = new Glasac("Mdasdsadsadasljkasdjkljksljkladsjklsajkldajjkasdjkasdasjdkwkdsakdsakdsadsadasdwdawdwadawdadwadaajkldjksadjksajkdajkdasjdaskdjkasjdaskddkswq", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPraznoImeIzuzetak()
        {
            Glasac g = new Glasac("", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestImeNullIzuzetak()
        {
            Glasac g = new Glasac(null, "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestImeCrticaIzuzetak()
        {
            Glasac g = new Glasac("Merim-Mera-Miki", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestImeNisuKarakteriIzuzetak()
        {
            Glasac g = new Glasac("Merim123", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDuzinePrezimenaIzuzetak1()
        {
            Glasac g1 = new Glasac("Merim", "K", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDuzinePrezimenaIzuzetak2()
        {
            Glasac g = new Glasac("Merim", "dasdsadsadasljkasdjkljksljkladsjklsajkldajjkasdjkasdasjdkwkdsakdsakdsadsadasdwdawdwadawdadwadaajkldjksadjksajkdajkdasjdaskdjkasjdaskddkswqdasdsadasdasdsa", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPraznoPrezimeIzuzetak()
        {
            Glasac g = new Glasac("Merim", "", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPrezimeNullIzuzetak()
        {
            Glasac g = new Glasac("Merim", null, new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPrezimeCrticaIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac-Kula-Kulic", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPrezimeNisuKarakteriIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac123", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] // baca pogresan izuzetak ?!
        public void TestAdresaNullIzuzetak1()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), null, "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPraznaAdresaIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDatumUBuducnostiIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(2031, 8, 28), "", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestPunoljetniGlasacIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(2008, 8, 28), "", "321T999", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestProvjeraJikaIzuzetak1()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka Cesta 23", "321T999", "2808999170065", Pol.muski);       
            g.ProvjeriJIK("mmkuhr322828");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestProvjeraJikaIzuzetak2()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka Cesta 23", "321T999", "2808999170065", Pol.muski); g.ProvjeriJIK("mmkuhr322828");
            g.ProvjeriJIK("mekkhr322828");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestProvjeraJikaIzuzetak3()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka Cesta 23", "321T999", "2808999170065", Pol.muski); g.ProvjeriJIK("mmkuhr322828");
            g.ProvjeriJIK("mekuhh322828");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestProvjeraJikaIzuzetak4()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka Cesta 23", "321T999", "2808999170065", Pol.muski); g.ProvjeriJIK("mmkuhr322828");
            g.ProvjeriJIK("mekuhr112828");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestProvjeraJikaIzuzetak5()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka Cesta 23", "321T999", "2808999170065", Pol.muski); g.ProvjeriJIK("mmkuhr322828");
            g.ProvjeriJIK("mekuhr321128");
            g.ProvjeriJIK("mekuhr322811");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestProvjeraJikaIzuzetak6()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka Cesta 23", "321T999", "2808999170065", Pol.muski); 
            g.ProvjeriJIK("mekuhr322811");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestProvjeraJikaIzuzetak7()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 1), "Hrasnicka Cesta 23", "321T999", "0108999170065", Pol.muski);
            g.ProvjeriJIK("mekuhr322811");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] //
        public void TestLicneKarteNullIzuzetak1()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka Cesta 23", null, "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLicneKarteDuzinaIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka Cesta 23", "123456789101212", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLicneKarteCifraNijeNaMjestuIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka Cesta 23", "E11T113", "2808999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestLicneKarteSredinaIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka Cesta 23", "212X113", "2808999170065", Pol.muski);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJmbgaNullIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", null, Pol.muski);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestJmbgaDuzinaIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "1", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestJmbgaOblikIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "28089991700mm", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestJmbgaDanIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 8), "Hrasnicka cesta 23", "321T999", "1008999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestJmbgaMjesecIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 8), "Hrasnicka cesta 23", "321T999", "2811999170065", Pol.muski);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestJmbgaGodinaIzuzetak()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 11, 8), "Hrasnicka cesta 23", "321T999", "2811999170065", Pol.muski);
        }

        [TestMethod]
        public void TestSetterImena()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
            g.Ime = "Kerim";
            Assert.AreEqual("Kerim", g.Ime);
            StringAssert.StartsWith(g.Ime, "K");
            StringAssert.EndsWith(g.Ime, "m");
            StringAssert.Contains(g.Ime, "eri");
        }

        [TestMethod]
        public void TestSetterPrezimena()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
            g.Prezime = "Kulovic";
            Assert.AreEqual("Kulovic", g.Prezime);
            StringAssert.StartsWith(g.Prezime, "K");
            StringAssert.EndsWith(g.Prezime, "c");
            StringAssert.Contains(g.Prezime, "lov");    
        }

        [TestMethod]
        public void TestSetterAdrese()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
            g.Adresa = "Zmaj od Bosne";
            Assert.AreEqual("Zmaj od Bosne", g.Adresa);
            StringAssert.StartsWith(g.Adresa, "Z");
            StringAssert.EndsWith(g.Adresa, "e");
            StringAssert.Contains(g.Adresa, "maj");
        }

        [TestMethod]
        public void TestSetterLicneKarte()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
            g.BrojLicneKarte = "123T123";
            Assert.AreEqual("123T123", g.BrojLicneKarte);
        }

        [TestMethod]
        public void TestSetterDatumaRodjenja1()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
            g.DatumRodjenja = new DateTime(2000, 1, 1);
            Assert.AreEqual(new DateTime(2000, 1, 1), g.DatumRodjenja);
            Assert.AreEqual("0101000170065", g.Jmbg);
        }

        [TestMethod]
        public void TestSetterDatumaRodjenja2()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
            g.DatumRodjenja = new DateTime(2000, 1, 21);
            Assert.AreEqual(new DateTime(2000, 1, 21), g.DatumRodjenja);
            Assert.AreEqual("2101000170065", g.Jmbg);
        }


        [TestMethod]
        public void TestSetterDatumaRodjenja3()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
            g.DatumRodjenja = new DateTime(2000, 12, 1);
            Assert.AreEqual(new DateTime(2000, 12, 1), g.DatumRodjenja);
            Assert.AreEqual("0112000170065", g.Jmbg);
        }



        [TestMethod]
        public void TestSetterJmbg1()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
            g.DatumRodjenja = new DateTime(2000, 1, 1);
            g.Jmbg = "0101000170065";
            Assert.AreEqual("0101000170065", g.Jmbg);
        }


        [TestMethod]
        public void TestSetterJika()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
            g.Jik = "mekuhr322828";
            Assert.AreEqual("mekuhr322828", g.Jik);
        }


        // DDT

        static IEnumerable<object[]> Glasaci
        {
            get
            {
                return new[]
                {
                    new object[] { "Merim123", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski },
                    new object[] { "Kerim", "Kulovic123", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski },
                    new object[] { "Kerim", "Kulovac", new DateTime(1999, 8, 28), "", "321T999", "2808999170065", Pol.muski },
                    new object[] { "Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "dsadsadasdasd", "2808999170065", Pol.muski },
                    new object[] { "Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "dsadsadasdasd", "2", Pol.muski }
                };
            }
        }
        static IEnumerable<object[]> GlasaciLegalni
        {
            get
            {
                return new[]
                {
                    new object[] { "Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski },
                    new object[] { "Kerim", "Kulovic", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski },
                    new object[] { "Kerim", "Kulovac", new DateTime(1999, 8, 28), "Ulica 123", "321T999", "2808999170065", Pol.muski },
                    new object[] { "Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski },
                    new object[] { "Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski }
                };
            }
        }

        [TestMethod]
        [DynamicData("Glasaci")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestKonstruktoraGlasacaIzuzetak(string ime, string prezime, DateTime rodjenje, string adresa, string licnaKarta, string jmbg, Pol pol)
        {
            Glasac g = new Glasac(ime, prezime, rodjenje, adresa, licnaKarta, jmbg, pol);
        }

        public static IEnumerable<object[]> UcitajPodatkeCSV()
        {
            using (var reader = new StreamReader("glasaci.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1], elements[2], elements[3], elements[4], elements[5], elements[6] };
                }
            }
        }
        public static IEnumerable<object[]> UcitajLegalnePodatkeCSV()
        {
            using (var reader = new StreamReader(@"C:\Users\Admin\source\repos\lokalniIzboriVVSGrupa3Tim2\GlasacTest\glasaciLegalni.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1], elements[2], elements[3], elements[4], elements[5], elements[6] };
                }
            }
        }

        static IEnumerable<object[]> GlasaciCSV
        {
            get
            {
                return UcitajPodatkeCSV();
            }
        }
        static IEnumerable<object[]> GlasaciLegalniCSV
        {
            get
            {
                return UcitajLegalnePodatkeCSV();
            }
        }


        [TestMethod]
        [DynamicData("GlasaciCSV")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestKonstruktoraGlasacaIzuzetakCSV(string ime, string prezime, DateTime rodjenje, string adresa, string licnaKarta, string jmbg, Pol pol)
        {
            Glasac g = new Glasac(ime, prezime, rodjenje, adresa, licnaKarta, jmbg, pol);
        }

        // SLJEDECE TESTOVE JE PISAO IBRAHIM EFENDIC


        [TestMethod]
        [DynamicData("GlasaciLegalni")]
        public void TestResetSvihGlasanja(string ime, string prezime, DateTime rodjenje, string adresa, string licnaKarta, string jmbg, Pol pol)
        {

            
            Glasac g = new Glasac(ime, prezime,rodjenje, adresa, licnaKarta, jmbg, pol);
            LokalniIzbori lokalniIzbori = new LokalniIzbori();
            Biografija b1 = new Biografija("kandidat1", "proba1", new DateTime(1999, 1, 1), "dasdasdas", "dasdasda", "dadada");
            Biografija b2 = new Biografija("kandidat2", "proba2", new DateTime(1999, 1, 31), "dasdasdas", "dasdasda", "dadada");
            Stranka s1 = new Stranka("SDA", "DADASDASDASDSA");
            Pozicija p1 = new Pozicija(NazivPozicije.nacelnik, "dasdasdsa", 33);
            Pozicija p2 = new Pozicija(NazivPozicije.gradonacelnik, "dasdasdsa", 33);
            Pozicija p3 = new Pozicija(NazivPozicije.vijecnik, "dasdasdsa", 33);

            Kandidat k1 = new Kandidat("Isko", "Iskiæ", new DateTime(2000, 9, 9), "adresa 23", "999T999", "0909000170065", Pol.muski, b1, s1, p1, 33);
            Kandidat k2 = new Kandidat("Neda", "Nediæ", new DateTime(1978, 11, 22), "adresa1", "323E789", "2211978890123", Pol.muski, b2, s1, p2, 11);
            Kandidat k3 = new Kandidat("Neda", "Nediæ", new DateTime(1978, 11, 22), "adresa1", "323E789", "2211978890123", Pol.muski, b2, s1, p3, 12);
            k1.BrojGlasova = 10;
            k2.BrojGlasova = 12;
            k3.BrojGlasova = 15;
            s1.BrojGlasova = 100;
            List<Kandidat> kandidati = new List<Kandidat>();
            kandidati.Add(k1);
            kandidati.Add(k2);
            kandidati.Add(k3);
            lokalniIzbori.Kandidati = kandidati;

            List<Glasac> glasaci = new List<Glasac>();
            glasaci.Add(g);
            lokalniIzbori.Glasaci = glasaci;

            lokalniIzbori.Glasovi.Add(new Glas(g, k1, DateTime.Now));
            lokalniIzbori.Glasovi.Add(new Glas(g, k2, DateTime.Now));
            lokalniIzbori.Glasovi.Add(new Glas(g, k3, DateTime.Now));

            //g.GlasaoZaGradonacelnika = true;
            //g.GlasaoZaNacelnika = true;
            //g.GlasaoZaVijecnika = true;
            lokalniIzbori.ResetGlasanjaZaGradonacelnika(g);
            lokalniIzbori.ResetGlasanjaZaNacelnika(g);
            lokalniIzbori.ResetGlasanjaZaVijecnika(g);
            

            Assert.AreEqual(10, k1.BrojGlasova);
            Assert.AreEqual(12, k2.BrojGlasova);
            Assert.AreEqual(15, k3.BrojGlasova);
            Assert.AreEqual(100, s1.BrojGlasova);
        }
        [TestMethod]
        [DynamicData("GlasaciLegalni")]
        public void TestUnosaSifre(string ime, string prezime, DateTime rodjenje, string adresa, string licnaKarta, string jmbg, Pol pol)
        {
            Glasac g = new Glasac(ime, prezime, rodjenje, adresa, licnaKarta, jmbg, pol);
            bool validanJik1 = true;
            bool validanJik2 = false;

            string tajnaSifra1 = "Pogresnasifra123";
            string tajnaSifra2 = "VVS20222023";

            Assert.AreEqual(true, g.ProvjeraSifre(tajnaSifra2, validanJik1));
            Assert.AreEqual(false, g.ProvjeraSifre(tajnaSifra1, validanJik1));
            Assert.AreEqual(false, g.ProvjeraSifre(tajnaSifra1, validanJik2));
            Assert.AreEqual(false, g.ProvjeraSifre(tajnaSifra2, validanJik2));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestZamjenskiObjekat()
        {
            Glasac g = new Glasac("Merim", "Kulovac", new DateTime(1999, 8, 28), "Hrasnicka cesta 23", "321T999", "2808999170065", Pol.muski);
            Spy temp = new Spy();
            temp.Glasao = false;
            Assert.IsTrue(g.VjerodostojnostGlasaca(temp));
            temp.Glasao = true;
            Assert.IsTrue(g.VjerodostojnostGlasaca(temp));
        }
    }
}
