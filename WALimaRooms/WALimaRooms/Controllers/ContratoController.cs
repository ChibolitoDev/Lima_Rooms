using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.Implementacion;

namespace WALimaRooms.Controllers
{
    public class ContratoController : Controller
    {
        private IContratoService contrato = new ContratoService();
        // GET: Contrato
        public ActionResult Index()
        {
            return View();
        }
    }
}