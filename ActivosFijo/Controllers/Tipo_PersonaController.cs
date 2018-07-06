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
    public class Tipo_PersonaController : ApiController
    {
        private Activos_FijoEntities db = new Activos_FijoEntities();

        // GET: api/Tipo_Persona
        public IQueryable<Tipo_Persona> GetTipo_Persona()
        {
            return db.Tipo_Persona;
        }

        // GET: api/Tipo_Persona/5
        [ResponseType(typeof(Tipo_Persona))]
        public IHttpActionResult GetTipo_Persona(int id)
        {
            Tipo_Persona tipo_Persona = db.Tipo_Persona.Find(id);
            if (tipo_Persona == null)
            {
                return NotFound();
            }

            return Ok(tipo_Persona);
        }

        // PUT: api/Tipo_Persona/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipo_Persona(int id, Tipo_Persona tipo_Persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipo_Persona.ID)
            {
                return BadRequest();
            }

            db.Entry(tipo_Persona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipo_PersonaExists(id))
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

        // POST: api/Tipo_Persona
        [ResponseType(typeof(Tipo_Persona))]
        public IHttpActionResult PostTipo_Persona(Tipo_Persona tipo_Persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipo_Persona.Add(tipo_Persona);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Tipo_PersonaExists(tipo_Persona.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tipo_Persona.ID }, tipo_Persona);
        }

        // DELETE: api/Tipo_Persona/5
        [ResponseType(typeof(Tipo_Persona))]
        public IHttpActionResult DeleteTipo_Persona(int id)
        {
            Tipo_Persona tipo_Persona = db.Tipo_Persona.Find(id);
            if (tipo_Persona == null)
            {
                return NotFound();
            }

            db.Tipo_Persona.Remove(tipo_Persona);
            db.SaveChanges();

            return Ok(tipo_Persona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tipo_PersonaExists(int id)
        {
            return db.Tipo_Persona.Count(e => e.ID == id) > 0;
        }
    }
}