using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivosFijo.Controllers
{
    public class DepreciacionController : Controller
    {
        // GET: Depreciacion
        public ActionResult Index(int id, int years = 0)
        {
            using (var ctx = new Models.Activos_FijoEntities())
            {
                var activo = ctx.Activos_Fijos.FirstOrDefault(x => x.ID == id);
                ViewBag.Years = years;
                return View(activo);
            }            
        }
    }
}