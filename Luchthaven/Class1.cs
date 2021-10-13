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
        public bool getVrij() {  return this.Vrij; }





    }
}
