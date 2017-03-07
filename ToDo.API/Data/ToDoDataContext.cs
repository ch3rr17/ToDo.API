using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToDo.API.Models;



namespace ToDo.API.Data
{
    public class ToDoDataContext : DbContext
    {
        public ToDoDataContext(): base("ToDo")
        {
        }

        public IDbSet<ToDoItem> ToDoItems { get; set; }
    }
}