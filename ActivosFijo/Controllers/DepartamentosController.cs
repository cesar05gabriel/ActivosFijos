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
    public class DepartamentosController : ApiController
    {
        private Activos_FijoEntities db = new Activos_FijoEntities();
        
        [HttpGet]
        [Route("api/Departamentos/UpdateDepartamento")]
        public bool UpdateDepartamento(int ID, string Descripcion, bool Estado)
        {
            var dep = db.Departamentos.FirstOrDefault(x => x.ID == ID);
            dep.Descripcion = Descripcion;
            dep.Estado = Estado;

            db.SaveChanges();


            return true;
        }

        // GET: api/Departamentos
        public IQueryable<Departamentos> GetDepartamentos()
        {
            return db.Departamentos.Where(x => !x.Desechado);
        }

        // GET: api/Departamentos/5
        [ResponseType(typeof(Departamentos))]
        public IHttpActionResult GetDepartamentos(int id)
        {
            Departamentos departamentos = db.Departamentos.FirstOrDefault(x => x.ID == id);
            if (departamentos == null)
            {
                return NotFound();
            }

            var _departamentos = new {
                ID = departamentos.ID,
                Descripcion = departamentos.Descripcion,
                Estado = departamentos.Estado
            };

            return Ok(_departamentos);
        }

        // PUT: api/Departamentos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartamentos(int id, Departamentos departamentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departamentos.ID)
            {
                return BadRequest();
            }

            //var departamento = db.Departamentos.FirstOrDefault(x => x.ID == id);

            //departamento.Desechado = true;

            db.Entry(departamentos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentosExists(id))
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

        // POST: api/Departamentos
        [ResponseType(typeof(Departamentos))]
        public IHttpActionResult PostDepartamentos(Departamentos departamentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departamentos.Add(departamentos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = departamentos.ID }, departamentos);
        }

        // DELETE: api/Departamentos/5
        [ResponseType(typeof(Departamentos))]
        public IHttpActionResult DeleteDepartamentos(int id)
        {
            Departamentos departamentos = db.Departamentos.Find(id);
            if (departamentos == null)
            {
                return NotFound();
            }

            db.Departamentos.Remove(departamentos);
            db.SaveChanges();

            return Ok(departamentos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartamentosExists(int id)
        {
            return db.Departamentos.Count(e => e.ID == id) > 0;
        }
    }
}