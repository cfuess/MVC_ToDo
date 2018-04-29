using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Razor.Generator;

namespace MVC_ToDo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public int Priority { get; set; }

        public Todo()
        {
        }

        public Todo(int id, string title, int priority = 1, bool completed = false)
        {
            Id = id;
            Title = title;
            Completed = completed;
            Priority = priority;
        }
    }

    public static class Todos
    {
        public static List<Todo> Items { get; set; } = new List<Todo>();
        private static int _maxId;

        public static void Load()
        {
            Items.Add(new Todo(1, "Clean House"));
            Items.Add(new Todo(2, "Wash Car", 3));
            Items.Add(new Todo(3, "Drink Water"));
            Items.Add(new Todo(4, "Meditate", 2, true));
            Items.Add(new Todo(5, "Walk"));
            _maxId = 6;
        }

        public static void Add(Todo item)
        {
            Items.Add(new Todo(_maxId, item.Title, item.Priority, item.Completed));
            _maxId++;
        }

    }
}

