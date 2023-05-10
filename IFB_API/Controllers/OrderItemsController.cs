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
using IFB_API.Models;

namespace IFB_API.Controllers
{
    public class OrderItemsController : ApiController
    {
        private IFB_Store db = new IFB_Store();

        // GET: api/OrderItems
        public IQueryable<OrderItem> GetOrderItems()
        {
            return db.OrderItems;
        }

        // GET: api/OrderItems/5
        [ResponseType(typeof(OrderItem))]
        public IHttpActionResult GetOrderItem(int id)
        {
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return Ok(orderItem);
        }

        // PUT: api/OrderItems/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutOrderItem(int id, OrderItem orderItem)
        //{
        //     if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != orderItem.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(orderItem).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/OrderItems
        [HttpPost]
        [ResponseType(typeof(OrderItem))]
        [Route("AddItemToOrder")]
        public IHttpActionResult PostOrderItem(int ItemId, int OrderId, int Quantity)
        {

            OrderItem new_item = new OrderItem();
            if (db.Orders.Where(o => o.OrderId == (decimal)OrderId).Count() == 0 || db.Items.Where(i => i.ItemId == ItemId).Count() == 0 || Quantity <= 0)
            {
                return Conflict();
            }


            new_item.Id = db.OrderItems.Max(oi => oi.Id) + 1;
            new_item.ItemId = ItemId;
            new_item.OrderId = (decimal)OrderId;
            new_item.Quantity = Quantity;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderItems.Add(new_item);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderItemExists(new_item.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = new_item.Id }, new_item);




        }

        // DELETE: api/OrderItems/5
        [ResponseType(typeof(OrderItem))]
        public IHttpActionResult DeleteOrderItem(int id)
        {
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            db.OrderItems.Remove(orderItem);
            db.SaveChanges();

            return Ok(orderItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderItemExists(int id)
        {
            return db.OrderItems.Count(e => e.Id == id) > 0;
        }
    }
}