using ActivosFijo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActivosFijo.Controllers
{
    public class LoginController : ApiController
    {
        public string Login(string username, string password)
        {
            var _access = "false";

            try
            {
                using (var ctx = new Activos_FijoEntities())
                {
                    //var empleado = ctx.Empleados.Where();
                }
            }
            catch (Exception ex)
            {
                _access = $"Error: {ex.Message}.";
            }

            return _access;
        }
    }
}
