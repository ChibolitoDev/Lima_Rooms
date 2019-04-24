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
    public class ContratoController : Controller
    {
        private IContratoService contratoService = new ContratoService();
        public ActionResult Index()
        {
            return View(contratoService.FindAll());
        }


        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //Get: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.cliente = contratoService.FindAll();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Contrato contrato)
        {
            ViewBag.cliente = contratoService.FindAll();
            bool rptainsert = contratoService.insert(contrato);

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
            Contrato contrato = contratoService.FindById(id);

            return View(contrato);
        }

        // POST: Cliente/Edit
        [HttpPost]
        public ActionResult Edit(Contrato contrato)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = contratoService.Update(contrato);
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
