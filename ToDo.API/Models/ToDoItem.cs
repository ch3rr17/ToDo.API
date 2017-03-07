using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDo.API.Models
{
    public class ToDoItem
    {
        [Key]
        public int ToDoId { get; set; }
        public string ToDoText { get; set; }
        public int Priority { get; set; }
    }
}