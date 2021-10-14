using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luchthaven.Model
{
    internal class Baan
    {
        private string Code;
        private bool Vrij;

        //Constructor: code van de baan valt te kiezen, baan wordt standaard als bezet aangemaakt
        public Baan (string code)
        {
            this.Code = code;
            this.Vrij = true;
        }

        //getters
        public string GetCode() { return this.Code; }
        public bool IsVrij() {  return this.Vrij; }

        //setter voor status van bezetting, moet kunnen worden aangepast indien baan vrijkomt
        public void changeVrij(bool vrij)
        {
            this.Vrij = vrij;
        }


        public string GeefOmschrijving()
        {
            string result = "Baan met code " + this.Code + ", status: ";
            if (this.Vrij)
            {
                return result + "vrij.";
            }
            return result + "bezet.";
        }

      







    }
}
