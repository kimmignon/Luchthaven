using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luchthaven.Model
{
    public enum Vliegstatus { OpstijgenAanTeVragen, OpstijgenGoedgekeurd, Opgestegen }

    internal class Vliegtuig
    {
        private string Vluchtnummer;
        private Baan ToegewezenBaan;
        private Vliegstatus VliegStat = new Vliegstatus();


        //constructor
        public Vliegtuig()
        {
            VliegStat = Vliegstatus.OpstijgenAanTeVragen;
     
        }

        //Uitgebreide constructor: luchtnummer kan rechtstreeks worden toegevoegd bij aanmaak vliegtuig
        public Vliegtuig(string vluchtnummer)
        {
            this.Vluchtnummer = vluchtnummer;
            VliegStat = Vliegstatus.OpstijgenAanTeVragen;
        }

        //getters
        public string GetVluchtnummer() {  return this.Vluchtnummer; }
        public Baan GetBaan() { return this.ToegewezenBaan; }
        public Vliegstatus GetVliegstatus() { return this.VliegStat; }

        //setters: controletoren kan vluchtnummer, baan en vliegstatus kiezen
        public void SetVluchtnummer(string vluchtnummer) { this.Vluchtnummer = vluchtnummer; }
        public void SetBaan(Baan toegewezenBaan) { this.ToegewezenBaan = toegewezenBaan;  }
        public void SetVliegstatus(Vliegstatus vliegstatus) { this.VliegStat = vliegstatus; }


        public string StijgOp()
        {
           if(this.VliegStat == Vliegstatus.OpstijgenGoedgekeurd)
            {
                this.VliegStat = Vliegstatus.Opgestegen;
                this.ToegewezenBaan.changeVrij(true);
                this.ToegewezenBaan = null;
                return "Vliegtuig met vluchtnummer " + this.Vluchtnummer + " is opgestegen op baan " + this.ToegewezenBaan;
            }
            return "Opstijgen niet mogelijk, huidige status: " + this.VliegStat;
        }

        public string GeefOmschrijving()
        {   
            if(this.ToegewezenBaan == null)
            {
                return "Vliegtuig met vluchtnummer " + this.Vluchtnummer + ", vliegstatus: " + this.VliegStat + ", baan: / ";
            }
            return "Vliegtuig met vluchtnummer " + this.Vluchtnummer + ", vliegstatus: " + this.VliegStat + ", baan: " + this.ToegewezenBaan.GetCode();
        }

    }
}
