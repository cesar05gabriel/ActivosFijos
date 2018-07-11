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
    public class Tipos_ActivosController : ApiController
    {
        private Activos_FijoEntities db = new Activos_FijoEntities();

        // GET: api/Tipos_Activos
        public IQueryable<Tipos_Activos> GetTipos_Activos()
        {
            return db.Tipos_Activos.Where(x => !x.Desechado); 
        }

        // GET: api/Tipos_Activos/5
        [ResponseType(typeof(Tipos_Activos))]
        public IHttpActionResult GetTipos_Activos(int id)
        {
            Tipos_Activos tipos_Activos = db.Tipos_Activos.Find(id);
            if (tipos_Activos == null)
            {
                return NotFound();
            }

            return Ok(tipos_Activos);
        }

        // PUT: api/Tipos_Activos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipos_Activos(int id, Tipos_Activos tipos_Activos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipos_Activos.ID)
            {
                return BadRequest();
            }

            db.Entry(tipos_Activos).State = EntityState.Modified;

            //var tactivo = db.Tipos_Activos.FirstOrDefault(x => x.ID == id);

            //tactivo.Desechado = true;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipos_ActivosExists(id))
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

        // POST: api/Tipos_Activos
        [ResponseType(typeof(Tipos_Activos))]
        public IHttpActionResult PostTipos_Activos(Tipos_Activos tipos_Activos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipos_Activos.Add(tipos_Activos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipos_Activos.ID }, tipos_Activos);
        }

        // DELETE: api/Tipos_Activos/5
        [ResponseType(typeof(Tipos_Activos))]
        public IHttpActionResult DeleteTipos_Activos(int id)
        {
            Tipos_Activos tipos_Activos = db.Tipos_Activos.Find(id);
            if (tipos_Activos == null)
            {
                return NotFound();
            }

            db.Tipos_Activos.Remove(tipos_Activos);
            db.SaveChanges();

            return Ok(tipos_Activos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tipos_ActivosExists(int id)
        {
            return db.Tipos_Activos.Count(e => e.ID == id) > 0;
        }
    }
}