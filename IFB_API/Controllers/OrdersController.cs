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
    public class OrdersController : ApiController
    {
        private IFB_Store db = new IFB_Store();

        // GET: api/Orders
        public IQueryable<Order> GetOrders()
        {
            return db.Orders;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(decimal id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        //// PUT: api/Orders/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutOrder(decimal id, Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != order.OrderId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
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

        // POST: api/NewOrder
        [HttpPost]
        [ResponseType(typeof(Order))]
        [Route("NewOrder")]
        public IHttpActionResult PostOrder(int? OrderId = null, int? CustomerId = null)
        {

            Order new_order = new Order();
            if(OrderId != null)
            {
                if(db.Orders.Where(o => o.OrderId == OrderId).Count() != 0)
                {
                    return Conflict();
                }
                else
                {
                    new_order.OrderId = (decimal) OrderId;
                }
            }
            else
            {
                decimal new_id = db.Orders.Max(o => o.OrderId) + (decimal) 1;
                new_order.OrderId = new_id;
            }

            new_order.CustomerId = CustomerId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(new_order);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(new_order.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = new_order.OrderId }, new_order);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(decimal id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(decimal id)
        {
            return db.Orders.Count(e => e.OrderId == id) > 0;
        }
    }
}