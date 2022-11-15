using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lokalniIzboriVVSGrupa3Tim2
{
    public enum Pol { muski, zenski };

    public class Glasac
    {
        private string ime;
        private string prezime;
        private string adresa;
        private string brojLicneKarte;
        private string jik; // jik - jedinstveni identifikacioni kod (sadrzi prva dva karaktera svih podataka o korisniku)
        private long jmbg;
        private DateTime datumRodjenja;
        private Pol pol;
        private bool glasaoZaGradonacelnika = false;
        private bool glasaoZaNacelnika = false;
        private bool glasaoZaVijecnika = false;

        public Glasac(String ime, String prezime, DateTime datumRodjenja, String adresa, String brojLicneKarte, long jmbg, Pol pol)
        {
            this.Ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.adresa = adresa;
            this.brojLicneKarte = brojLicneKarte;
            this.jmbg = jmbg;
            this.pol = pol;
            FormirajJikGlasaca();
        }
        
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string BrojLicneKarte { get => brojLicneKarte; set => brojLicneKarte = value; }
        public string Jik { get => jik; set => jik = value; }
        public long Jmbg { get => jmbg; set => jmbg = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public Pol Pol { get => pol; set => pol = value; }
        public bool GlasaoZaGradonacelnika { get => glasaoZaGradonacelnika; set => glasaoZaGradonacelnika = value; }
        public bool GlasaoZaNacelnika { get => glasaoZaNacelnika; set => glasaoZaNacelnika = value; }
        public bool GlasaoZaVijecnika { get => glasaoZaVijecnika; set => glasaoZaVijecnika = value; }
        


        void FormirajJikGlasaca()
        {
            // ovdje treba formirati jik na nacin da se iz svih gore informacija uzima po dva pocetna karaktera osim spola
            string dan = "";
            string mjesec = "";
            if (datumRodjenja.Day < 10)
            {
                dan = "0" + datumRodjenja.Day.ToString();
            }
            else
            {
                dan = datumRodjenja.Day.ToString();
            }

            /*if(datumRodjenja.Month < 10)
            {
                mjesec = "0" + datumRodjenja.Month.ToString();
            }
            else
            {
                mjesec = datumRodjenja.Month.ToString();
             }*/
            jik = ime.Substring(0, 2) + prezime.Substring(0, 2) + adresa.Substring(0, 2) + brojLicneKarte.Substring(0, 2) + jmbg.ToString().Substring(0, 2) + dan.Substring(0, 2) + pol.ToString().Substring(0, 2);
            jik = jik.ToLower();
        }
    }
}
