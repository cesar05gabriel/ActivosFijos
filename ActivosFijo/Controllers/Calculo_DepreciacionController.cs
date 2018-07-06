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
    public class Calculo_DepreciacionController : ApiController
    {
        private Activos_FijoEntities db = new Activos_FijoEntities();

        // GET: api/Calculo_Depreciacion
        public IQueryable<Calculo_Depreciacion> GetCalculo_Depreciacion()
        {
            return db.Calculo_Depreciacion;
        }

        // GET: api/Calculo_Depreciacion/5
        [ResponseType(typeof(Calculo_Depreciacion))]
        public IHttpActionResult GetCalculo_Depreciacion(int id)
        {
            Calculo_Depreciacion calculo_Depreciacion = db.Calculo_Depreciacion.Find(id);
            if (calculo_Depreciacion == null)
            {
                return NotFound();
            }

            return Ok(calculo_Depreciacion);
        }

        // PUT: api/Calculo_Depreciacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCalculo_Depreciacion(int id, Calculo_Depreciacion calculo_Depreciacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calculo_Depreciacion.ID)
            {
                return BadRequest();
            }

            db.Entry(calculo_Depreciacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Calculo_DepreciacionExists(id))
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

        // POST: api/Calculo_Depreciacion
        [ResponseType(typeof(Calculo_Depreciacion))]
        public IHttpActionResult PostCalculo_Depreciacion(Calculo_Depreciacion calculo_Depreciacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Calculo_Depreciacion.Add(calculo_Depreciacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = calculo_Depreciacion.ID }, calculo_Depreciacion);
        }

        // DELETE: api/Calculo_Depreciacion/5
        [ResponseType(typeof(Calculo_Depreciacion))]
        public IHttpActionResult DeleteCalculo_Depreciacion(int id)
        {
            Calculo_Depreciacion calculo_Depreciacion = db.Calculo_Depreciacion.Find(id);
            if (calculo_Depreciacion == null)
            {
                return NotFound();
            }

            db.Calculo_Depreciacion.Remove(calculo_Depreciacion);
            db.SaveChanges();

            return Ok(calculo_Depreciacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Calculo_DepreciacionExists(int id)
        {
            return db.Calculo_Depreciacion.Count(e => e.ID == id) > 0;
        }
    }
}