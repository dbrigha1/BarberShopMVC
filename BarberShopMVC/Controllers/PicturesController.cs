using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarberShopMVC.Models;
using BarberShopMVC.Models.Entities;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace BarberShopMVC.Controllers
{
    public class PicturesController : Controller
    {
       
        private readonly IHttpClientWrapper _clientWrapper;

        public PicturesController(IHttpClientWrapper clientWrapper)
        {
            _clientWrapper = clientWrapper;
        }

        public async Task<ActionResult> Index()
        {
            var results = new List<Picture>();
           
                var response = await _clientWrapper.GetAll("api/picturesapi");

                if(response.IsSuccessStatusCode)
                {
                    var serializedResult = response.Content.ReadAsStringAsync().Result;

                    results = JsonConvert.DeserializeObject< List < Picture >> (serializedResult);
                    return View(results);
                 }

            return View("Error"); 
               
        }

        
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            return View();
        }

        //POST: Pictures/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "PictureId,Name")]Picture picture)
        {
            if (!ModelState.IsValid)
            {
                View("Error");
            }
           
            var response = await _clientWrapper.CreateAsync("api/picturesapi", picture);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            return View("Error");           
        }

        // GET: Pictures/Details/5
        public async Task<ActionResult> Details(int id)
        {
            
            var response = await _clientWrapper.GetPicture("api/picturesapi", id);
            if (response.IsSuccessStatusCode)
            {
                var jsonModel = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Picture>(jsonModel);
                return View(model);
            }
            return View("Error");
        }

        // Post: Pictures/Delete/5
        public async Task<ActionResult> Delete(int id)
        {            
            var response = await _clientWrapper.Delete("api/picturesapi", id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }

       

        //// GET: Pictures/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}


        //// GET: Pictures/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Picture picture = await db.Pictures.FindAsync(id);
        //    if (picture == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(picture);
        //}

        //// POST: Pictures/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "PictureId,Name")] Picture picture)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(picture).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(picture);
        //}

        //// GET: Pictures/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Picture picture = await db.Pictures.FindAsync(id);
        //    if (picture == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(picture);
        //}

        //// POST: Pictures/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Picture picture = await db.Pictures.FindAsync(id);
        //    db.Pictures.Remove(picture);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
