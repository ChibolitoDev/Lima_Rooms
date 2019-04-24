using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Implementacion;
using Business;
using Entity;

namespace WALimaRooms.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteService clienteService = new ClienteService();
        // GET: Cliente
        public ActionResult Index()
        {
            return View(clienteService.FindAll());
        }


        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //Get: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.cliente = clienteService.FindAll();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            ViewBag.cliente = clienteService.FindAll();
            bool rptainsert = clienteService.insert(cliente);

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
            Cliente cliente = clienteService.FindById(id);

            return View(cliente);
        }

        // POST: Cliente/Edit
        [HttpPost]
        public ActionResult Edit(Cliente client)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = clienteService.Update(client);
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