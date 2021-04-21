using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP1_Module5.Controllers
{
    public class ChatController : Controller
    {
        public List<Models.Chat> chats = Models.Chat.GetMeuteDeChats();

        // GET: Chat
        public ActionResult Index()
        {
            return View(chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Models.Chat chat = chats.Where(c => c.Id == id).FirstOrDefault();
            return View(chat);
        }

     

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Chat chat = chats.Where(c => c.Id == id).FirstOrDefault();
            return View(chat);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Models.Chat chat = chats.Where(c => c.Id == id).FirstOrDefault();
                chats.Remove(chat);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
