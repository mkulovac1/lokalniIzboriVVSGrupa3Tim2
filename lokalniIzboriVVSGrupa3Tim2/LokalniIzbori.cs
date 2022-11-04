using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lokalniIzboriVVSGrupa3Tim2
{
    public class LokalniIzbori
    {
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

    }
}
