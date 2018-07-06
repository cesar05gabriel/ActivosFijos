using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ActivosFijo.Models;

namespace ActivosFijo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpleadosController : ApiController
    {
        
        private Activos_FijoEntities db = new Activos_FijoEntities();

        // GET: api/Empleados
        public IQueryable<Empleados> GetEmpleados()
        {
            return db.Empleados.Where(x => !x.Desechado);
        }

        // GET: api/Empleados/5
        [ResponseType(typeof(Empleados))]
        public IHttpActionResult GetEmpleados(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return NotFound();
            }

            return Ok(empleados);
        }

        // PUT: api/Empleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleados(int id, Empleados empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleados.ID)
            {
                return BadRequest();
            }

            db.Entry(empleados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empleados
        [ResponseType(typeof(Empleados))]
        public IHttpActionResult PostEmpleados(Empleados empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empleados.Add(empleados);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleados.ID }, empleados);
        }

        // DELETE: api/Empleados/5
        [ResponseType(typeof(Empleados))]
        public IHttpActionResult DeleteEmpleados(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return NotFound();
            }

            empleados.Desechado = true;
            db.SaveChanges();

            return Ok(empleados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadosExists(int id)
        {
            return db.Empleados.Count(e => e.ID == id) > 0;
        }
    }
}