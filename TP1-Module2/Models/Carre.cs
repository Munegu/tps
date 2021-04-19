using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Module2.Models
{
    public class Carre: Forme
    {
        public int Longueur { get; set; }

        public override double Aire => Longueur * Longueur;

        public override double Perimetre =>  4 * Longueur;

        public override string ToString()
        {
            return $"Carré de côté={Longueur}" + Environment.NewLine + base.ToString();
        }

    }
}
