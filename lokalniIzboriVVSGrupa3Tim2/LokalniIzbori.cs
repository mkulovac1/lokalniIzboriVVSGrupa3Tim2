using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lokalniIzboriVVSGrupa3Tim2
{
    public class LokalniIzbori
    {

        //Potrebno dodati neke dummy podatke radi lakseg testiranja funkcionalnosti aplikacije - Ibrahim Efendic

        private List<Glasac> glasaci; 
        private List<Kandidat> kandidati;
        private List<Glas> glasovi;
        private List<Stranka> stranke;

        public LokalniIzbori()
        {
            glasaci = new List<Glasac>();
            kandidati = new List<Kandidat>();
            glasovi = new List<Glas>();
            stranke = new List<Stranka>();
        }

        public LokalniIzbori(List<Glasac> glasaci, List<Kandidat> kandidati, List<Glas> glasovi, List<Stranka> stranke)
        {
            this.glasaci = glasaci;
            this.kandidati = kandidati;
            this.glasovi = glasovi;
            this.stranke = stranke;
        }

        public List<Glasac> Glasaci { get => glasaci; set => glasaci = value; }
        public List<Kandidat> Kandidati { get => kandidati; set => kandidati = value; }
        public List<Glas> Glasovi { get => glasovi; set => glasovi = value; }
        public List<Stranka> Stranke { get => stranke; set => stranke = value; }

        private bool UkupniIzborniPragKandidata() // da li su izbori legalni
        {
            int ukupanBrojMogucihGlasova = Glasaci.Count();
            int ukupanBrojGlasova = 0;
            foreach (Glasac g in glasaci)
            {
                if (g.GlasaoZaGradonacelnika || g.GlasaoZaVijecnika || g.GlasaoZaNacelnika)
                    ukupanBrojGlasova++;
            }

            if (ukupanBrojGlasova >= ukupanBrojMogucihGlasova * 0.2)
                return true;
            else
                return false;
        }


        private int brojGlasovaZaNacelnika()
        {

            int brojGlasova = 0;
            foreach (Glasac g in glasaci)
            {
                if (g.GlasaoZaNacelnika)
                    brojGlasova++;
            }
            return brojGlasova;

        }

        private int brojGlasovaZaGradonacelnika()
        {

            int brojGlasova = 0;
            foreach (Glasac g in glasaci)
            {
                if (g.GlasaoZaGradonacelnika)
                    brojGlasova++;
            }
            return brojGlasova;
        }

        private int brojGlasovaZaVijecnika()
        {
            int brojGlasova = 0;
            foreach (Glasac g in glasaci)
            {
                if (g.GlasaoZaVijecnika)
                    brojGlasova++;
            }
            return brojGlasova;
        }

        public bool DaLiJeKandidatOsvojioMandat(Kandidat k)
        {
            // gleda se broj glasaca koji je glasao za odredjenu poziciju i onda se broj glasova kandidata uporedjuje sa tim brojem
            // dijelimo ovdje zavisni i nezavisni
            // zavisni mora osvojiti 20 % stranke glasova
            // nezavisni 2 %
            if (k.StrankaKandidata == null)
            {
                if (k.PozicijaKandidata.Equals(NazivPozicije.nacelnik) && k.BrojGlasova >= 0.02 * brojGlasovaZaNacelnika())
                    return true;
                else if (k.PozicijaKandidata.Equals(NazivPozicije.gradonacelnik) && k.BrojGlasova >= 0.02 * brojGlasovaZaGradonacelnika())
                    return true;
                else if (k.PozicijaKandidata.Equals(NazivPozicije.vijecnik) && k.BrojGlasova >= 0.02 * brojGlasovaZaVijecnika())
                    return true;
            }
            else // ako je u stranci
            {
                // nije bitno koja je pozicija
                if (k.BrojGlasova >= k.StrankaKandidata.BrojGlasova * 0.2)
                    return true;
            }

            return false;
        }

        public bool DaLiJeStrankaOsvojilaMandat(Stranka s)
        {
            // stranka da ima mandat mora osvojiti 2%
            // stranci se dodijeli glas samo prilikom glasanja za vijecnika/vijecnike!
            int brojGlasacaVijecnika = 0;

            foreach (Glasac g in glasaci)
            {
                if (g.GlasaoZaVijecnika)
                    brojGlasacaVijecnika++;
            }

            if (s.BrojGlasova >= 0.02 * brojGlasacaVijecnika)
                return true;
            else
                return false;
        }
    }
}
