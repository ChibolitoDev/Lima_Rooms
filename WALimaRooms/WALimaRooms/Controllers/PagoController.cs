using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.Implementacion;
using Entity;

namespace WALimaRooms.Controllers
{
    public class PagoController : Controller
    {

        private IPagoService pagoService = new PagoService();
        public ActionResult Index()
        {
            return View(pagoService.FindAll());
        }


        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //Get: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.cliente = pagoService.FindAll();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Pago pag)
        {
            ViewBag.cliente = pagoService.FindAll();
            bool rptainsert = pagoService.insert(pag);

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
            Pago pag = pagoService.FindById(id);

            return View(pag);
        }

        // POST: Cliente/Edit
        [HttpPost]
        public ActionResult Edit(Pago pag)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = pagoService.Update(pag);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
