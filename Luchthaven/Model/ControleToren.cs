using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luchthaven.Model
{
    internal class ControleToren
    {
        public List<Vliegtuig> Vliegtuigen;
        public List<Baan> Banen;

        //constructor: bij aanmaak toren worden de lijsten aangemaakt
        public ControleToren()
        {
            this.Vliegtuigen = new List<Vliegtuig>();
            this.Banen = new List<Baan>();
        }

        //getters
        public List<Vliegtuig> GetVliegtuigen() {  return this.Vliegtuigen; }
        public List<Baan> GetBanen() {  return this.Banen; }

        public string RegistreerVliegtuig(Vliegtuig teRegistrerenVliegtuig)
        {
            string vluchtnummer = string.Empty;
            Random random = new Random();
            do
            {
                int asciiNr = random.Next(48, 91);
                if (asciiNr >= 58 && asciiNr < 65)
                {
                    continue;
                }
                vluchtnummer += (char)asciiNr;
            } while (vluchtnummer.Length < 6);
            teRegistrerenVliegtuig.SetVluchtnummer(vluchtnummer);
            teRegistrerenVliegtuig.SetVliegstatus(Vliegstatus.OpstijgenAanTeVragen);
            Vliegtuigen.Add(teRegistrerenVliegtuig);
            return "Vliegtuig werd geregistreerd. Vluchtnummer: " + vluchtnummer;
        }


        public Vliegtuig ZoekVliegtuig(string vluchtnummer)
        {
            foreach(Vliegtuig v in Vliegtuigen)
            {
                if (v.GetVluchtnummer() == vluchtnummer)
                {
                    return v;
                }
            }
            return null;
        }

        public Baan ZoekVrijeBaan()
        {
            foreach(Baan b in Banen)
            {
                if (b.IsVrij())
                {
                    return b;
                }
            }
            return null;
        }

        public string AanvraagTotOpstijgen(string vluchtnummer)
        {
            Vliegtuig vliegtuig = this.ZoekVliegtuig(vluchtnummer);
            Baan baan = this.ZoekVrijeBaan();
            if(vliegtuig == null)
            {
                return "Aanvraag tot opstijgen niet goedgekeurd.Vliegtuig niet aanwezig";
            }
            if(vliegtuig.GetVliegstatus() == Vliegstatus.OpstijgenAanTeVragen)
            {
                return "Aanvraag tot opstijgen niet goedgekeurd. Vliegtuig heeft geen aanvraag tot opstijgen";
            }
            if(baan == null)
            {
                return "Aanvraag tot opstijgen niet goedgekeurd, geen vrije banen meer";
            }

            vliegtuig.SetVliegstatus(Vliegstatus.OpstijgenGoedgekeurd);
            vliegtuig.SetBaan(baan);
            baan.changeVrij(false);
            return "Aanvraag tot opstijgen goedgekeurd voor vliegtuig met vluchtnummer " + vluchtnummer + ", baan " + baan.GetCode();
        }

        public string OverzichtVliegtuigen()
        {
            string result = "";
            foreach(Vliegtuig v in Vliegtuigen)
            {
                result += v.GeefOmschrijving() + "\n";
            }
            return result;
        }

        public string OverzichtBanen()
        {
            string result = "";
            foreach(Baan b in Banen)
            {
                result += b.GeefOmschrijving() + "\n";
            }
            return result;
        }


    }
}
