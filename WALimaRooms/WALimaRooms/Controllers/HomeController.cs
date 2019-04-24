using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WALimaRooms.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your aplicativo description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateCliente()
        {
            ViewBag.Message = "Creacion de un nuevo cliente";

            return View();
        }

        public ActionResult CreateTipoInmobiliario()
        {
            ViewBag.Message = "Creacion de un nuevo Tipo de Inmobiliario";

            return View();
        }

        public ActionResult ListCliente()
        {
            ViewBag.Message = "Listar todos los clientes";

            return View();
        }

        public ActionResult ListTipoInmobiliario()
        {
            ViewBag.Message = "Listar todos los Tipos de Inmobiliario";

            return View();
        }
        public ActionResult DeleteCliente()
        {
            ViewBag.Message = "Listar todos los clientes";

            return View();
        }
        public ActionResult DeleteTipoInmobiliario()
        {
            ViewBag.Message = "Eliminar uno o más tipo inmobiliario";

            return View();
        }
    }
}