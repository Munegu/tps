﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP1_Module5.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            List<Models.Chat> chats = Models.Chat.GetMeuteDeChats();
            return View(chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

      
        // POST: Chat/Edit/5
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

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chat/Delete/5
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