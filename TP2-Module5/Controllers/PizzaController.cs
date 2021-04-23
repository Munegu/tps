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
         
                return View(pizzaViewModel);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(string id)
        {
            PizzaViewModel pizzaViewModel = new PizzaViewModel();

            pizzaViewModel.pizza = FakeDb.Instance.Pizzas.SingleOrDefault(pizza => pizza.Id == id);

            pizzaViewModel.Ingredients = Pizza.IngredientsDisponibles.Select(
            ingrédients => new SelectListItem { Text = ingrédients.Nom, Value = ingrédients.Id.ToString() }
            ).ToList();

            pizzaViewModel.Pates = Pizza.PatesDisponibles.Select(
               pates => new SelectListItem { Text = pates.Nom, Value = pates.Id.ToString() }
               ).ToList();

            if (pizzaViewModel.pizza.Ingredients != null && pizzaViewModel.pizza.Ingredients.Count > 0)
            {
                pizzaViewModel.IdIngredients = pizzaViewModel.pizza.Ingredients.Select(ingredient => ingredient.Id).ToList();
            }


            return View(pizzaViewModel);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaViewModel pizzaViewModel)
        {
            try
            {
                Pizza pizzaUpdate = FakeDb.Instance.Pizzas.SingleOrDefault(pizza => pizza.Id == pizzaViewModel.pizza.Id);

                pizzaUpdate.Pate = Pizza.PatesDisponibles.FirstOrDefault(pate => pate.Id == pizzaViewModel.IdPate);

                pizzaUpdate.Ingredients = Pizza.IngredientsDisponibles.Where(ingredient => pizzaViewModel.IdIngredients.Contains(ingredient.Id)).ToList();

                pizzaUpdate.Nom = pizzaViewModel.pizza.Nom;



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(string id)
        {
            Pizza pizza = FakeDb.Instance.Pizzas.SingleOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                Pizza pizza = FakeDb.Instance.Pizzas.SingleOrDefault(p => p.Id == id);
                FakeDb.Instance.Pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                Pizza pizza = FakeDb.Instance.Pizzas.SingleOrDefault(p => p.Id == id);
                return View(pizza);
            }
        }
    }
}
