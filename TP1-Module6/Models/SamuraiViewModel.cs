using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP1_Module6.BO;

namespace TP1_Module6.Models
{
    public class SamuraiViewModel
    {
        public Samourai Samurai { get; set; }
        public List<Arme> Armes { get; set; }
        public int? IdSelectedArme { get; set; }
    }
}