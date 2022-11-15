using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace lokalniIzboriVVSGrupa3Tim2
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Glasac g = new Glasac("Merim", "Kulovac", Convert.ToDateTime("08/28/1999"), "Dzinde 23", "28AJK32S", 2808999170065, Pol.muski);
            // NA NIVOU JEDNE OPCINE ?!


            // Neki podaci:
            
            Glasac g1 = new Glasac("Glasac1", "Proba1", new DateTime(2000, 9, 9), "adresa1", "223456789", 1234567890123, Pol.muski);
            Glasac g2 = new Glasac("Glasac2", "Proba2", new DateTime(1978, 11, 22), "adresa1", "323456789", 1234567890123, Pol.muski);
            Glasac g3 = new Glasac("Glasac3", "Proba3", new DateTime(1978, 9, 22), "adresa1", "423456789", 1234567890123, Pol.muski);
            Glasac g4 = new Glasac("Glasac4", "Proba4", new DateTime(1978, 9, 21), "adresa1", "523456789", 1234567890123, Pol.muski);

            //glprad321222mu

            List<Glasac> glasaci = new List<Glasac>();
            glasaci.Add(g1);
            glasaci.Add(g2);
            glasaci.Add(g3);
            glasaci.Add(g4);

            Biografija b1 = new Biografija("kandidat1", "proba1", new DateTime(1999, 1, 1), "dasdasdas", "dasdasda", "dadada");
            Biografija b2 = new Biografija("kandidat2", "proba2", new DateTime(1999, 1, 31), "dasdasdas", "dasdasda", "dadada");
            Stranka s1 = new Stranka("SDA", "DADASDASDASDSA");
            Pozicija p1 = new Pozicija(NazivPozicije.nacelnik, "dasdasdsa", 33);
            Kandidat k1 = new Kandidat(b1, s1, p1, 33);
            Kandidat k2 = new Kandidat(b2, s1, p1, 11);

            List<Kandidat> kandidati = new List<Kandidat>();
            kandidati.Add(k1);
            kandidati.Add(k2);

            


            LokalniIzbori lokalniIzbori = new LokalniIzbori();

            lokalniIzbori.Glasaci = glasaci;
            lokalniIzbori.Kandidati = kandidati;

            Console.WriteLine("Pozdrav!\nDobrodošli na naš informacioni sistem za lokalne izbore u Sarajevu\nKoja je Vaša uloga? (pritisnite odgovarajuću tipku na tastaturi za izbor):\n1 - Glasac\n2 - Supervizor\n3 - Trenutno stanje na izborima\n0 - izlaz\n");
            int unos = -1; // sigurnost
            unos = Convert.ToInt32(Console.ReadLine());
            //Dodati while petlju tako da se ne prekine program sve dok se ne izabere izlaz iz programa (0) - Ibrahim Efendic
            if (unos == 0)
            {
                Console.WriteLine("Hvala Vam!");
                Environment.Exit(0);
            }
            else if (unos == 1)
            {
                
                bool postojiGlasac = false;
                Console.WriteLine("\nMolim vas da unesete vas JEDINSTVENI IDENTIFIKACIONI KOD: ");
                string jik = Console.ReadLine();
                // Console.WriteLine("Molim vas da unesete vas JEDINSTVENI IDENTIFIKACIONI KOD: "); 
                Glasac g = null;
                foreach (Glasac glasac in lokalniIzbori.Glasaci)
                {
                    if (jik.Equals(glasac.Jik))
                    {
                        postojiGlasac = true;
                        g = glasac;
                        break;
                    }
                }

                if(!postojiGlasac)
                    Console.WriteLine("Niste unijeli dobar JIK ili niste registrovani za glasanje. Pokusajte ponovo.\n");


                if (postojiGlasac)
                {
                    Console.WriteLine("\nDobrodosli " + g.Ime + " " + g.Prezime + "! U nastavku izaberite sljedeće opcije za glasanje\n 1 - za gradonacelnika\n 2 - za nacelnika \n 3 - glasanje za vijecnika/vijecnike \n 4 - glasanje za stranku");
                    int unosZaGlasanje = Convert.ToInt32(Console.ReadLine());
                    if (unosZaGlasanje == 1)
                    {
                        if (g.GlasaoZaGradonacelnika == false)
                        {
                            Console.WriteLine("\nKandidati za gradonacelnika su: \n");
                            foreach (Kandidat gradonacelnik in lokalniIzbori.Kandidati)
                            {
                                if (gradonacelnik.PozicijaKandidata.NazivPozicije.ToString().Equals("gradonacelnik"))
                                {
                                    if (gradonacelnik.StrankaKandidata != null)
                                        Console.WriteLine(gradonacelnik.BrojNaListi + " - " + gradonacelnik.BiografijaKandidata.ImeKandidata + " " + gradonacelnik.BiografijaKandidata.PrezimeKandidata + " - " + gradonacelnik.StrankaKandidata.NazivStranke);
                                    else
                                        Console.WriteLine(gradonacelnik.BrojNaListi + " - " + gradonacelnik.BiografijaKandidata.ImeKandidata + " " + gradonacelnik.BiografijaKandidata.PrezimeKandidata + " - nezavisni kandidat");
                                }
                            }
                            int redniBrojG = Int32.Parse(Console.ReadLine());
                            foreach (Kandidat k in lokalniIzbori.Kandidati)
                            {
                                if (k.BrojNaListi == redniBrojG)
                                {
                                    g.GlasaoZaGradonacelnika = true; // zbog neznanja da li je ovo duboka kopija ili nije mora se provjeriti da li ce ovaj glasac promijeniti sebe u listi glasaci u klasi lokalniizbori
                                    k.BrojGlasova++;
                                    if (k.StrankaKandidata != null)
                                        k.StrankaKandidata.BrojGlasova++;
                                    lokalniIzbori.Glasovi.Add(new Glas(g, k, DateTime.Now));
                                    break;
                                }
                            }
                        }
                        else
                            Console.WriteLine("Vec ste glasali za gradonacelnika. Izaberite jednu od preostale dvije opcije!"); // sa ovim se treba pozabaviti kasnije
                    }
                    else if (unosZaGlasanje == 2)
                    {
                        if (g.GlasaoZaNacelnika == false) 
                        {
                            Console.WriteLine("\nKandidati za nacelnika su: \n");
                            foreach (Kandidat nacelnik in lokalniIzbori.Kandidati)
                            {
                                if (nacelnik.PozicijaKandidata.NazivPozicije.ToString().Equals("nacelnik"))
                                {
                                    if (nacelnik.StrankaKandidata != null)
                                        Console.WriteLine(nacelnik.BrojNaListi + " - " + nacelnik.BiografijaKandidata.ImeKandidata + " " + nacelnik.BiografijaKandidata.PrezimeKandidata + " - " + nacelnik.StrankaKandidata.NazivStranke);
                                    else
                                        Console.WriteLine(nacelnik.BrojNaListi + " - " + nacelnik.BiografijaKandidata.ImeKandidata + " " + nacelnik.BiografijaKandidata.PrezimeKandidata + " - nezavisni kandidat");
                                }
                            }

                            Console.WriteLine("\nUnesite redni broj kandidata sa liste: ");
                            
                            int redniBrojN = Int32.Parse(Console.ReadLine());
                            foreach (Kandidat k in lokalniIzbori.Kandidati)
                            {
                                if (k.BrojNaListi == redniBrojN)
                                {
                                    g.GlasaoZaNacelnika = true; // zbog neznanja da li je ovo duboka kopija ili nije mora se provjeriti da li ce ovaj glasac promijeniti sebe u listi glasaci u klasi lokalniizbori
                                    k.BrojGlasova++;
                                    if(k.StrankaKandidata != null)
                                        k.StrankaKandidata.BrojGlasova++;
                                    lokalniIzbori.Glasovi.Add(new Glas(g, k, DateTime.Now));
                                    Console.WriteLine(g.GlasaoZaNacelnika + " " + k.BrojGlasova);
                                    break;
                                }
                            }                            
                        }
                        else
                            Console.WriteLine("\nVec ste glasali za nacelnika. Izaberite jednu od preostale dvije opcije!"); // sa ovim se treba pozabaviti kasnije
                    }
                    else if (unosZaGlasanje == 3)
                    {
                        if (g.GlasaoZaVijecnika == false)
                        {
                            Console.WriteLine("Mozete glasati za jednog ili vise vijecnika s liste (ukoliko glasate za vise vijecnika, oni moraju biti iz iste stranke");
                            // USLOVI ZA JENDOG ILI VISE VIJECNIKA - NEK URADI NEKO DRUGI ILI CU SUTRA JA 
                        }
                        else
                            Console.WriteLine("Vec ste glasali za vijecnika. Izaberite jednu od preostale dvije opcije!"); // sa ovim se treba pozabaviti kasnije
                    }
                    else if (unosZaGlasanje == 4)
                    {
                        // ako se glasa za stranku onda svi kandidati iz te stranke dobijaju glasove, ali to vrijedi samo za vijecnike koliko znam iz nasih izbora ?!
                        if(g.GlasaoZaVijecnika == false)
                        {
                            Console.WriteLine("Unesite naziv stranke: ");
                            string nazivStranke = Console.ReadLine();
                            // sta ako nije dobro naziv unesen ?!
                            bool provjera = false;
                            while(!provjera)
                            {
                                Console.WriteLine("Unesite naziv stranke: ");
                                foreach (Stranka s in lokalniIzbori.Stranke)
                                {
                                    if (s.NazivStranke.Equals(nazivStranke))
                                    {
                                        provjera = true;
                                        s.BrojGlasova++;
                                        break;
                                    }
                                }
                                if(!provjera)
                                    Console.WriteLine("Unijeli ste nepostojecu stranku. Pokusajte ponovo!");
                            }
                            
                            if(provjera)
                            {
                                foreach (Kandidat k in lokalniIzbori.Kandidati)
                                {
                                    if(k.StrankaKandidata.NazivStranke.Equals(nazivStranke))
                                        k.BrojGlasova++;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ne moze se glasati za stranku ukoliko ste vec glasali za vijecnike!");
                        }
                    }
                }
            }
            else if(unos == 2)
            {
                int unosSupervizora = -1;
                // supervizor ili admin sta vec
                Console.WriteLine("Dobro dosli! Potvrdite svoj identitet tako sto cete upisati svoju sifru!");
                if(Console.ReadLine() == "pw")
                {
                    //Visak razmak ispred druge opcije prilikom odabira opcija supervizora - Ibrahim Efendic
                    Console.WriteLine("Vi ste supervizor! Supervizor ne moze da manipulise sa glasacima! Izaberite sljedece opcije: \n 1 - Dodaj kandidata \n  2 - Izbrisi kandidata \n 3 - Dodaj stranku \n 4 - Izmijeni stranku \n 5 - Izbrisi stranku \n 6 - Provjeri glasaca");
                    unosSupervizora = Int32.Parse(Console.ReadLine());
                    if (unosSupervizora == 1)
                    {
                        Console.WriteLine("Unesite ime kandidata: ");
                        string ime = Console.ReadLine();
                        
                        Console.WriteLine("Unesite prezime kandidata: ");
                        string prezime = Console.ReadLine();
                       
                        Console.WriteLine("Unesite datum rodjenja:  ");
                        string datumString = Console.ReadLine();
                        
                        Console.WriteLine("Unesite adresu kandidata: ");
                        string adresa = Console.ReadLine();
                        
                        Console.WriteLine("Unesite strucnu spremu kandidata: ");
                        string ssk = Console.ReadLine();
                        
                        Console.WriteLine("Unesite opis kandidata: ");
                        string opis = Console.ReadLine();
                        
                        Console.WriteLine("Unesite naziv stranke kandidata (skracenicu): "); // kriticno, moze stranka da ne postoji
                        string nazivStranke = Console.ReadLine();
                        
                        Console.WriteLine("Pozicija kandidata (gradonacelnik, nacelnik ili vijecnik): "); // kriticno jer moze unijeti nesto sklj, ne mogu se peglati sa tim
                        string pozicija = Console.ReadLine();
                        NazivPozicije poz = NazivPozicije.vijecnik ; //
                        if (pozicija == "vijecnik")
                            poz = NazivPozicije.vijecnik;
                        else if (pozicija == "nacelnik")
                            poz = NazivPozicije.nacelnik;
                        else if (pozicija == "gradonacelnik")
                            poz = NazivPozicije.gradonacelnik;
                        
                        Console.WriteLine("Redni broj na listi: "); // kriticno, moze da se ponovi (unose isti broj) trebalo bi gledati sljedeci slobodni
                        int broj = Int32.Parse(Console.ReadLine());
                        
                        Stranka s = null;
                        foreach (Stranka str in lokalniIzbori.Stranke)
                        {
                            if (str.NazivStranke.Equals(nazivStranke))
                            {
                                s = str;
                                break;
                            }
                        }

                        Biografija b = new Biografija(ime, prezime, DateTime.Parse(datumString), adresa, ssk, opis);
                        
                        Pozicija p = new Pozicija(poz, "", broj);

                        lokalniIzbori.Kandidati.Add(new Kandidat(b, s, p, broj)); 
                        
                        Console.WriteLine("Kandidat uspjesno dodan!");
                    }
                    else if(unosSupervizora == 2)
                    {
                        int redniBrojNaListi = Int32.Parse(Console.ReadLine());
                        bool izbrisan = false;
                        //Potrebno naznačiti supervizoru po kojem kriteriju se brise kandidat (redni broj na listi) - Ibrahim Efendic
                        //Potrebna provjera ukoliko unos nije broj, jer dolazi do Unhandled Exception-a - Ibrahim Efendic
                        foreach (Kandidat k in lokalniIzbori.Kandidati)
                        {
                            if (k.BrojNaListi == redniBrojNaListi)
                            {
                                lokalniIzbori.Kandidati.Remove(k);
                                izbrisan = true;
                                break;
                            }
                        }
                        if (izbrisan)
                            Console.WriteLine("Kandidat uspjesno izbrisan!");
                        else
                            Console.WriteLine("Kandidat ne postoji!");
                    }
                    else if(unosSupervizora == 3)
                    {

                        
                        // unesi stranku
                        string naziv = Console.ReadLine();

                        bool pronasao = true;
                        while(pronasao)
                        {
                            Console.WriteLine("Unesite naziv stranke: \n");
                            foreach (Stranka s in lokalniIzbori.Stranke)
                            {
                                if (s.NazivStranke.Equals(naziv))
                                    pronasao = true;
                            }
                            if (pronasao)
                                Console.WriteLine("Postoji ta stranka vec!");
                            else
                                pronasao = false;
                        }

                        
                        Console.WriteLine("Unesite opis stranke: \n");
                        string opis = Console.ReadLine();

                        lokalniIzbori.Stranke.Add(new Stranka(naziv, opis));
                        Console.WriteLine("Stranka uspjesno dodana!");
                       
                    }
                    else if (unosSupervizora == 4)
                    {
                        // izmijeni stranku
                        Console.WriteLine("Unesite naziv stranke: ");
                        string naziv = Console.ReadLine();

                        bool provjera = false;
                        while(!provjera)
                        {
                            foreach(Stranka s in lokalniIzbori.Stranke)
                            {
                                if (s.NazivStranke.Equals(naziv))
                                {
                                    provjera = true;
                                    Console.WriteLine("Unesite novi naziv stranke: ");
                                    string noviNaziv = Console.ReadLine();
                                    Console.WriteLine("Unesite novi opis stranke: ");
                                    string noviOpis = Console.ReadLine();
                                    s.NazivStranke = noviNaziv;
                                    s.OpisStranke = noviOpis;
                                    break;
                                }
                            }
                        }
                    }
                    else if (unosSupervizora == 5)
                    {

                        //Potrebno naznačiti supervizoru po kojem kriteriju se brise stranka (skraceni naziv) - Ibrahim Efendic
                        // izbrisi stranku
                        string naziv = Console.ReadLine();
                        bool izbrisan = false;
                        foreach(Stranka s in lokalniIzbori.Stranke)
                        {
                            if(s.NazivStranke.Equals(naziv))
                            {
                                lokalniIzbori.Stranke.Remove(s);
                                izbrisan = true;
                                break;
                            }
                        }
                        if (izbrisan)
                            Console.WriteLine("Stranka uspjesno izbrisana!");
                        else
                            Console.WriteLine("Stranka ne postoji!");
                        
                    }
                    else if (unosSupervizora == 6)
                    {
                        bool pronadjiJik = false;
                            Console.WriteLine("Unesite JIK glasaca: ");
                        string jik = Console.ReadLine();
                        foreach (Glasac glasac in lokalniIzbori.Glasaci)
                        {
                            if (jik.Equals(glasac.Jik))
                            {
                                Console.WriteLine("Postoji glasac sa tim JIK-om!"); 
                            }
                            else
                            {
                                Console.WriteLine("Niste unijeli dobar JIK ili niste registrovani za glasanje. Pokusajte ponovo.\n");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Pogresna sifra! Pokusajte ponovo!");
                }
            }
            else if(unos == 3)
            {
                if (lokalniIzbori.Glasaci.Count == 0 || lokalniIzbori.Kandidati.Count == 0 || lokalniIzbori.Glasovi.Count == 0)
                {
                    Console.WriteLine("Glasanje nije pocelo");
                    return;
                }
                
                // rezultati glasanja
                Console.WriteLine("Prikaz rezultata glasanja:\n");

                Console.Write("Ukupno postoji " + lokalniIzbori.Glasaci.Count + " glasaca.\n");
                Console.Write("Za gradonacelnika je glasalo: ");
                int brojacZaGradonacelnika = 0, brojacZaNacelnika = 0, brojacZaVijecnike = 0, brojacZaStranke = 0;
                foreach (Glasac g in lokalniIzbori.Glasaci)
                {
                    if (g.GlasaoZaGradonacelnika)
                        brojacZaGradonacelnika++;
                    if (g.GlasaoZaNacelnika)
                        brojacZaNacelnika++;
                    if (g.GlasaoZaVijecnika)
                        brojacZaVijecnike++;
                }

                foreach(Stranka s in lokalniIzbori.Stranke)
                {
                    brojacZaStranke += s.BrojGlasova;
                }

                Console.WriteLine("Od ukupno " + lokalniIzbori.Glasaci.Count + " glasalo je " + brojacZaGradonacelnika + " za gradonacelnika, " + brojacZaNacelnika + " za nacelnika, " + brojacZaVijecnike + " za vijecnike i " + brojacZaStranke + " za stranke generalno.\n");
                Console.WriteLine("Odnosno u postocima je to: " + (brojacZaGradonacelnika / lokalniIzbori.Glasaci.Count) * 100 + "% za gradonacelnika, " + (brojacZaNacelnika / lokalniIzbori.Glasaci.Count) * 100 + "% za nacelnika, " + (brojacZaVijecnike / lokalniIzbori.Glasaci.Count) * 100 + "% za vijecnike i " + (brojacZaStranke / lokalniIzbori.Glasaci.Count) * 100 + "% za stranke generalno.");

                lokalniIzbori.Kandidati.Sort((k1, k2) => k1.BrojGlasova.CompareTo(k2.BrojGlasova));
    
                Console.WriteLine("Gradonacelnik je: ");
                Kandidat x = null;
                int brojacMjesta = 0;
                foreach (Kandidat k in lokalniIzbori.Kandidati)
                {
                    if(k.PozicijaKandidata.NazivPozicije == NazivPozicije.gradonacelnik)
                    {
                        // Console.WriteLine(k.BiografijaKandidata.ImeKandidata + " " + k.BiografijaKandidata.PrezimeKandidata + " stranka: " + k.StrankaKandidata.NazivStranke + ", broj glasova: " + k.BrojGlasova + "\n");
                        // break;
                        x = lokalniIzbori.Kandidati.ElementAt(0);
                        k.RedniBrojOsvojenogMjesta = brojacMjesta + 1;
                    }
                }
                
                Console.WriteLine(x.BiografijaKandidata.ImeKandidata + " " + x.BiografijaKandidata.PrezimeKandidata + " stranka: " + x.StrankaKandidata.NazivStranke + ", broj glasova: " + x.BrojGlasova + "\n");

                brojacMjesta = 0;
                Console.WriteLine("Nacelnik je: ");
                foreach (Kandidat k in lokalniIzbori.Kandidati)
                {
                    if (k.PozicijaKandidata.NazivPozicije == NazivPozicije.nacelnik)
                    {
                        // Console.WriteLine(k.BiografijaKandidata.ImeKandidata + " " + k.BiografijaKandidata.PrezimeKandidata + " stranka: " + k.StrankaKandidata.NazivStranke + ", broj glasova: " + k.BrojGlasova + "\n");
                        // break;
                        x = lokalniIzbori.Kandidati.ElementAt(0);
                        k.RedniBrojOsvojenogMjesta = brojacMjesta + 1;
                    }
                }

                Console.WriteLine(x.BiografijaKandidata.ImeKandidata + " " + x.BiografijaKandidata.PrezimeKandidata + " stranka: " + x.StrankaKandidata.NazivStranke + ", broj glasova: " + x.BrojGlasova + "\n");

                brojacMjesta = 0;
                Console.WriteLine("Rezultati vijecnika: ");
                foreach(Kandidat k in lokalniIzbori.Kandidati)
                {
                    if(k.PozicijaKandidata.NazivPozicije == NazivPozicije.vijecnik)
                    {
                        k.RedniBrojOsvojenogMjesta = brojacMjesta + 1;
                        Console.WriteLine(k.BiografijaKandidata.ImeKandidata + " " + k.BiografijaKandidata.PrezimeKandidata + " stranka: " + k.StrankaKandidata.NazivStranke + ", broj glasova: " + k.BrojGlasova + "\n");
                    }
                }

                brojacMjesta = 0;
                lokalniIzbori.Stranke.Sort((s1, s2) => s1.BrojGlasova.CompareTo(s2.BrojGlasova));
                Console.WriteLine("Rezultati stranaka: ");
                foreach(Stranka s in lokalniIzbori.Stranke)
                {
                    Console.WriteLine(s.NazivStranke + " broj glasova: " + s.BrojGlasova + "\n");
                    s.RedniBrojMjesta = brojacMjesta + 1;
                }
            }
        }
    }
}
