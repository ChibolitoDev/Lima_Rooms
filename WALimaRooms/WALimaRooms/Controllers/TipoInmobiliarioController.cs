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
    public class TipoInmobiliarioController : Controller
    {
        private ITipoInmobiliarioService tipoInmobiliarioService = new TipoInmobiliarioService();
        // GET: TipoInmobiliario
        public ActionResult Index()
        {
            return View();
        }
        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //Get: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.cliente = tipoInmobiliarioService.FindAll();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(TipoInmobiliario tipoInmobiliario)
        {
            ViewBag.cliente = tipoInmobiliarioService.FindAll();
            bool rptainsert = tipoInmobiliarioService.insert(tipoInmobiliario);

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
            TipoInmobiliario cliente = tipoInmobiliarioService.FindById(id);

            return View(cliente);
        }

        // POST: Cliente/Edit
        [HttpPost]
        public ActionResult Edit(TipoInmobiliario tipoInmobiliario)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = tipoInmobiliarioService.Update(tipoInmobiliario);
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