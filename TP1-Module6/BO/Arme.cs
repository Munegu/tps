using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1_Module6.BO
{
    public class Arme : IdEntity
    {
        public string Nom { get; set; }
        public int Degats { get; set; }
    }
}