using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ToDo.API.Data;
using ToDo.API.Models;

namespace ToDo.API.Controllers
{
    public class ToDoItemsController : ApiController
    {
        private ToDoDataContext db = new ToDoDataContext();

        // GET: api/ToDoItems
        public IQueryable<ToDoItem> GetToDoItems()
        {
            return db.ToDoItems;
        }

        // GET: api/ToDoItems/5
        [ResponseType(typeof(ToDoItem))]
        public IHttpActionResult GetToDoItem(int id)
        {
            ToDoItem toDoItem = db.ToDoItems.Find(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            return Ok(toDoItem);
        }

        // PUT: api/ToDoItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToDoItem(int id, ToDoItem toDoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDoItem.ToDoId)
            {
                return BadRequest();
            }

            db.Entry(toDoItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ToDoItems
        [ResponseType(typeof(ToDoItem))]
        public IHttpActionResult PostToDoItem(ToDoItem toDoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ToDoItems.Add(toDoItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = toDoItem.ToDoId }, toDoItem);
        }

        // DELETE: api/ToDoItems/5
        [ResponseType(typeof(ToDoItem))]
        public IHttpActionResult DeleteToDoItem(int id)
        {
            ToDoItem toDoItem = db.ToDoItems.Find(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            db.ToDoItems.Remove(toDoItem);
            db.SaveChanges();

            return Ok(toDoItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToDoItemExists(int id)
        {
            return db.ToDoItems.Count(e => e.ToDoId == id) > 0;
        }
    }
}