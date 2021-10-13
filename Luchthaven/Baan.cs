using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luchthaven
{
    internal class Baan
    {
        public string Code;
        public bool Vrij;

        public Baan (string Code)
        {
            this.Code = Code;
            this.Vrij = false;
        }

        public string getCode() { return this.Code; }
        public bool isVrij() {  return this.Vrij; }

        public string geefOmschrijving()
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
