using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2_Module5.Models;
using TP2_Module5.Utils;

namespace TP2_Module5.Controllers
{
    public class PizzaController : Controller
    {
        private readonly static List<Pizza> pizzas = FakeDb.Instance.Pizzas;

        // GET: Pizza
        public ActionResult Index()
        {
            return View(pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(string id)
        {
            return View(FakeDb.Instance.Pizzas.FirstOrDefault(pizza => pizza.Id == id));
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaViewModel pizzaViewModel = new PizzaViewModel();
            pizzaViewModel.Pates = Pizza.PatesDisponibles.Select(
                pates => new SelectListItem { Text = pates.Nom, Value = pates.Id.ToString()}
                ).ToList();

            pizzaViewModel.Ingredients = Pizza.IngredientsDisponibles.Select(
                ingrédients => new SelectListItem { Text = ingrédients.Nom, Value = ingrédients.Id.ToString() }
                ).ToList();
            return View(pizzaViewModel);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel pizzaViewModel)
        {
            try
            {
                pizzaViewModel.pizza.Id = Guid.NewGuid().ToString();

                pizzaViewModel.pizza.Pate = Pizza.PatesDisponibles.FirstOrDefault(pate => pate.Id == pizzaViewModel.IdPate);

                foreach (var id in pizzaViewModel.IdIngredients)
                {
                    pizzaViewModel.pizza.Ingredients.Add(Pizza.IngredientsDisponibles.FirstOrDefault(ingredient => ingredient.Id == id));
                }
                

                FakeDb.Instance.Pizzas.Add(pizzaViewModel.pizza);

                return RedirectToAction("Index");
            }
            catch
            {
               // pizzaViewModel.Ingredients = Pizza.IngredientsDisponibles.Select(ingredient => new SelectListItem()
               // { Text = ingredient.Nom, Value = ingredient.Id.ToString() }).ToList();
               // pizzaViewModel.Pates = Pizza.PatesDisponibles.Select(
               // pates => new SelectListItem { Text = pates.Nom, Value = pates.Id.ToString() }
               // ).ToList();
                return View(pizzaViewModel);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
