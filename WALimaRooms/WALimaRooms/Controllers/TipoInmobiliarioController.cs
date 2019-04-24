using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.Implementacion;


namespace WALimaRooms.Controllers
{
    public class TipoInmobiliarioController : Controller
    {
        private ITipoInmobiliarioService TipoI = new TipoInmobiliarioService();
        // GET: TipoInmobiliario
        public ActionResult Index()
        {
            return View();
        }
    }
}