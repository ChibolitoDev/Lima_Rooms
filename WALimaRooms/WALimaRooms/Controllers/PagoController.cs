using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.Implementacion;

namespace WALimaRooms.Controllers
{
    public class PagoController : Controller
    {

        private IPagoService Pago = new PagoService();
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
    }
}