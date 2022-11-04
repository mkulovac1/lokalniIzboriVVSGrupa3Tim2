using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lokalniIzboriVVSGrupa3Tim2
{
    public class Biografija
    {
        private string imeKandidata;
        private string prezimeKandidata;
        private DateTime datumRodjenjaKandidata;
        private string adresaKandidata;
        private string strucnaSpremaKandidata;
        private string opisKandidata;

        public Biografija(string imeKandidata, string prezimeKandidata, DateTime datumRodjenjaKandidata, string adresaKandidata, string strucnaSpremaKandidata, string opisKandidata)
        {
            this.imeKandidata = imeKandidata;
            this.prezimeKandidata = prezimeKandidata;
            this.datumRodjenjaKandidata = datumRodjenjaKandidata;
            this.adresaKandidata = adresaKandidata;
            this.strucnaSpremaKandidata = strucnaSpremaKandidata;
            this.opisKandidata = opisKandidata;
        }

        public string ImeKandidata { get => imeKandidata; set => imeKandidata = value; }
        public string PrezimeKandidata { get => prezimeKandidata; set => prezimeKandidata = value; }
        public DateTime DatumRodjenjaKandidata { get => datumRodjenjaKandidata; set => datumRodjenjaKandidata = value; }
        public string AdresaKandidata { get => adresaKandidata; set => adresaKandidata = value; }
        public string StrucnaSpremaKandidata { get => strucnaSpremaKandidata; set => strucnaSpremaKandidata = value; }
        public string OpisKandidata { get => opisKandidata; set => opisKandidata = value; }
    }
}
