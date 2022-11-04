using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lokalniIzboriVVSGrupa3Tim2
{
    public class Glas
    {
        private Glasac glasac;
        private Kandidat kandidat;
        private DateTime datumGlasanja;

        public Glas(Glasac glasac, Kandidat kandidat, DateTime datumGlasanja)
        {
            this.glasac = glasac;
            this.kandidat = kandidat;
            this.datumGlasanja = datumGlasanja;
        }

        public Glasac Glasac { get => glasac; set => glasac = value; }
        public Kandidat Kandidat { get => kandidat; set => kandidat = value; }
        public DateTime DatumGlasanja { get => datumGlasanja; set => datumGlasanja = value; }
    }
}
