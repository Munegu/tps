using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1_Module6.BO
{
    public class Samourai : IdEntity
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }

        public virtual List<ArtMartial> ArtMartials { get; set; } = new List<ArtMartial>();
    }
}