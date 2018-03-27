using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BarberShopMVC.Api_Logic;
using BarberShopMVC.Models;
using BarberShopMVC.Models.Entities;
using Unity;

namespace BarberShopMVC.Controllers.WebApi
{
    public class PicturesApiController : ApiController
    {
        private readonly IPictureLogic _logic;

        public PicturesApiController(IPictureLogic logic)
        {
            _logic = logic;
        }
        //private BarberShopContext db = new BarberShopContext();

        // GET: api/PicturesApi
        //public IQueryable<Picture> GetPictures()
        //{
        //    return db.Pictures;
            
            
        //}
        public async Task<IHttpActionResult> GetPictures()
        {
            try
            {
                var pictures = await _logic.GetPictures();
                if(pictures == null)
                {
                   return BadRequest();
                }

               return Ok(pictures);
            }
            catch(Exception e)
            {
               return InternalServerError(e);
            }
        }

        public async Task<IHttpActionResult> CreatePicture(Picture model)
        {
            try
            {
                
                if (model == null)
                {
                    return BadRequest();
                }
                await _logic.CreatePicture(model);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }



        // GET: api/PicturesApi/5
        [ResponseType(typeof(Picture))]
        public async Task<IHttpActionResult> GetPicture(int id)
        {
            Picture picture = await _logic.GetPicture(id);
            if (picture == null)
            {
                return NotFound();
            }

            return Ok(picture);
        }

        //// PUT: api/PicturesApi/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutPicture(int id, Picture picture)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != picture.PictureId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(picture).State = System.Data.Entity.EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PictureExists(id))
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

        //// POST: api/PicturesApi
        //[ResponseType(typeof(Picture))]
        //public async Task<IHttpActionResult> PostPicture(Picture picture)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Pictures.Add(picture);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = picture.PictureId }, picture);
        //}

        //// DELETE: api/PicturesApi/5
        [ResponseType(typeof(Picture))]
        public async Task<IHttpActionResult> DeletePicture(int id)
        {
            await _logic.DeletePicture(id);
            return Ok();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool PictureExists(int id)
        //{
        //    return db.Pictures.Count(e => e.PictureId == id) > 0;
        //}
    }
}