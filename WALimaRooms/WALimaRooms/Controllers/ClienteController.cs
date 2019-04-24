using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Implementacion;
using Business;
using Entity;
using System.Net;

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
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = clienteService.FindById(id);
            if(cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
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
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator."; 
            }
            Cliente cliente = clienteService.FindById(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Cliente cliente = clienteService.FindById(id);
                clienteService.Delete(id);
  
            }
            catch(Exception ex)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}