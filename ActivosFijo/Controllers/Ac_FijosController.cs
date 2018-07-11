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
    public class Ac_FijosController : ApiController
    {
        private Activos_FijoEntities db = new Activos_FijoEntities();

        // GET: api/Activos_Fijos
        public List<Activos_FijosViewModel> GetActivos_Fijos()
        {
            var model = db.Activos_Fijos.Where(x => !x.Desechado)
                .Select(x => new Activos_FijosViewModel
                {
                    ID = x.ID,
                    Departamento = x.Departamentos.Descripcion,
                    Depreciacion_Acumulada = x.Depreciacion_Acumulada,
                    Descripcion = x.Descripcion,
                    Fecha_Registro = x.Fecha_Registro,
                    Monto_Despreciado = x.Monto_Despreciado,
                    Periodo = x.Periodo,
                    Tipos_Activos = x.Tipos_Activos1.Descripcion,
                    Valor_Compra = x.Valor_Compra
                }).ToList();

            return model; 
        }

        // GET: api/Activos_Fijos/5
        [ResponseType(typeof(Activos_Fijos))]
        public IHttpActionResult GetActivos_Fijos(int id)
        {
            Activos_Fijos activos_Fijos = db.Activos_Fijos.Find(id);
            if (activos_Fijos == null)
            {
                return NotFound();
            }

            return Ok(activos_Fijos);
        }

        // PUT: api/Activos_Fijos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivos_Fijos(int id, Activos_Fijos activos_Fijos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activos_Fijos.ID)
            {
                return BadRequest();
            }

            db.Entry(activos_Fijos).State = EntityState.Modified;

            //var activo = db.Activos_Fijos.FirstOrDefault(x => x.ID == id);

            //activo.Desechado = true;

            try
            {
                db.SaveChanges();
      
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Activos_FijosExists(id))
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

        // POST: api/Activos_Fijos
        [ResponseType(typeof(Activos_Fijos))]
        public IHttpActionResult PostActivos_Fijos(Activos_Fijos activos_Fijos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Activos_Fijos.Add(activos_Fijos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = activos_Fijos.ID }, activos_Fijos);
        }

        // DELETE: api/Activos_Fijos/5
        [ResponseType(typeof(Activos_Fijos))]
        public IHttpActionResult DeleteActivos_Fijos(int id)
        {
            Activos_Fijos activos_Fijos = db.Activos_Fijos.Find(id);
            if (activos_Fijos == null)
            {
                return NotFound();
            }

            db.Activos_Fijos.Remove(activos_Fijos);
            db.SaveChanges();

            return Ok(activos_Fijos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Activos_FijosExists(int id)
        {
            return db.Activos_Fijos.Count(e => e.ID == id) > 0;
        }
    }
}