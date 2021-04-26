using BO;
using com.sun.tools.doclint;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP2_Module5.Models
{
    public class PizzaViewModel
    {
        public Pizza pizza { get; set; }
        public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Pates { get; set; } = new List<SelectListItem>();

        public int? IdPate { get; set; }
        public List<int> IdIngredients { get; set; } = new List<int>();

    }
}