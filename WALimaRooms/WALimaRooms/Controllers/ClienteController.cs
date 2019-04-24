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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Cliente cliente = clienteService.FindById(id);

            return View(cliente);
        }

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
    }
}