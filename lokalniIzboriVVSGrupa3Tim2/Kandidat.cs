using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lokalniIzboriVVSGrupa3Tim2
{
    public class Kandidat : Glasac
    {
        private Biografija biografijaKandidata;
        private Stranka strankaKandidata;
        private Pozicija pozicijaKandidata;
        private int brojGlasova;
        private int redniBrojOsvojenogMjesta;
        private int brojNaListi;

        public Kandidat(String ime, String prezime, DateTime datumRodjenja, String adresa, String brojLicneKarte, string jmbg, Pol pol, Biografija biografijaKandidata, Stranka strankaKandidata, Pozicija pozicijaKandidata, int brojNaListi) : base(ime,prezime,datumRodjenja,adresa,brojLicneKarte,jmbg,pol)
        {
            this.biografijaKandidata = biografijaKandidata;
            this.strankaKandidata = strankaKandidata;
            this.pozicijaKandidata = pozicijaKandidata;
            this.brojNaListi = brojNaListi;
            brojGlasova = 0;
            redniBrojOsvojenogMjesta = 0;
        }

        public Biografija BiografijaKandidata { get => biografijaKandidata; set => biografijaKandidata = value; }
        public Stranka StrankaKandidata { get => strankaKandidata; set => strankaKandidata = value; }
        public Pozicija PozicijaKandidata { get => pozicijaKandidata; set => pozicijaKandidata = value; }
        public int RedniBrojOsvojenogMjesta { get => redniBrojOsvojenogMjesta; set => redniBrojOsvojenogMjesta = value; }
        public int BrojGlasova { get => brojGlasova; set => brojGlasova = value; }
        public int BrojNaListi { get => brojNaListi; set => brojNaListi = value; }
    }
}
