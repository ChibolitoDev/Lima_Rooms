using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.Implementacion;
using Entity;

namespace WALimaRooms.Controllers
{
    public class InmobiliarioController : Controller
    {

        private IImboliarioService inmobiliarioService = new InmobiliarioService();
        public ActionResult Index()
        {
            return View(inmobiliarioService.FindAll());
        }


        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmobiliario inmobi = inmobiliarioService.FindById(id);
            if (inmobi == null)
            {
                return HttpNotFound();
            }
            return View(inmobi);
        }

        //Get: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.inmobi = inmobiliarioService.FindAll();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Inmobiliario inmobi)
        {
            ViewBag.inmobi = inmobiliarioService.FindAll();
            bool rptainsert = inmobiliarioService.insert(inmobi);

            if (rptainsert)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: Cliente/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Inmobiliario inmobi = inmobiliarioService.FindById(id);

            return View(inmobi);
        }

        // POST: Cliente/Edit
        [HttpPost]
        public ActionResult Edit(Inmobiliario client)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = inmobiliarioService.Update(client);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Inmobiliario inmobi = inmobiliarioService.FindById(id);
            if (inmobi == null)
            {
                return HttpNotFound();
            }
            return View(inmobi);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Inmobiliario inmobi = inmobiliarioService.FindById(id);
                inmobiliarioService.Delete(id);
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
