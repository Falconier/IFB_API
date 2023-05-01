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
    public class ItemsController : ApiController
    {
        private IFB_Store db = new IFB_Store();

        // GET: api/Items
        public IQueryable<Item> GetItems()
        {
            return db.Items;
        }

        // GET: api/Items/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult GetItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        //// PUT: api/Items/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutItem(int id, Item item)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != item.ItemId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(item).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ItemExists(id))
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

        #region Posts

        //// POST: api/Items
        //[HttpPost]
        //[ResponseType(typeof(Item))]
        //[Route("TestItem")]
        //public IHttpActionResult PostItem(Item item)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Items.Add(item);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ItemExists(item.ItemId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = item.ItemId }, item);
        //}

        //POST: api/NewItem
        [HttpPost]
        [ResponseType(typeof(Item))]
        [Route("NewItem")]
        public IHttpActionResult NewItem(int UPC, int SKU, string Description, decimal UnitPrice, int OnHand)
        {
            Item new_item = new Item();
            int new_id = db.Items.Max(i => i.ItemId) + 1;
            new_item.ItemId = new_id;
            new_item.UPC = UPC;
            new_item.SKU = SKU;
            new_item.Description = Description;
            new_item.Unit_Price = UnitPrice;
            new_item.On_Hand = OnHand;

            db.Items.Add(new_item);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if(ItemExists(new_item.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = new_item.ItemId }, new_item);
        }

        // POST: api/Items/
        [HttpPost]
        [ResponseType(typeof(Item))]
        [Route("NewItemNoDescription")]
        public IHttpActionResult NewItem(int UPC, int SKU, decimal UnitPrice, int OnHand)
        {
            Item new_item = new Item();
            int new_id = db.Items.Max(i => i.ItemId) + 1;
            new_item.ItemId = new_id;
            new_item.UPC = UPC;
            new_item.SKU = SKU;
            new_item.Unit_Price = UnitPrice;
            new_item.On_Hand = OnHand;

            db.Items.Add(new_item);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if(ItemExists(new_item.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = new_item.ItemId }, new_item);
        }

        #endregion

        //// DELETE: api/Items/5
        //[ResponseType(typeof(Item))]
        //public IHttpActionResult DeleteItem(int id)
        //{
        //    Item item = db.Items.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Items.Remove(item);
        //    db.SaveChanges();

        //    return Ok(item);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Items.Count(e => e.ItemId == id) > 0;
        }
    }
}