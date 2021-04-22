using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP2_Module5.Utils
{
    public class FakeDb
    {
        private static readonly Lazy<FakeDb> lazy = new Lazy<FakeDb>(() => new FakeDb());

        public static FakeDb Instance { get { return lazy.Value; } }

        private FakeDb()
        {
        }

        public List<Pizza> Pizzas { get; } = new List<Pizza>();

   
    }
}