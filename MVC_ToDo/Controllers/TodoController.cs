using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using MVC_ToDo.Models;

namespace MVC_ToDo.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo

        public ActionResult Index()
        {
            return View(Todos.Items);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(GetItem(id));
        }

        [HttpPost]
        public ActionResult Create(Todo changedItem)
        {
            Todos.Add(changedItem);
            return View(changedItem);
        }

        public ActionResult Edit(int id)
        {
            return View(GetItem(id));
        }

        [HttpPost]
        public ActionResult Edit(Todo changedItem)
        {
            Save(changedItem);
            return View(GetItem(changedItem.Id));
        }

        public ActionResult Delete(int id)
        {
            var item = GetItem(id);
            Todos.Items.Remove(item);
            return View("Index", Todos.Items);
        }

        private Todo GetItem(int id)
        {
            Todo matcheTodo = new Todo();
            foreach (var item in Todos.Items)
            {
                if (item.Id == id)
                {
                    matcheTodo = item;
                }
            }
            return matcheTodo;
        }

        private void Save(Todo changedItem)
        {
            var item = Todos.Items.First(l => l.Id == changedItem.Id);
            item.Title = changedItem.Title;
            item.Priority = changedItem.Priority;
            item.Completed = changedItem.Completed;
        }
    }
}