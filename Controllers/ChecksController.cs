using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ChequeAPI.Models;

namespace ChequeAPI.Controllers
{
    public class ChecksController : ApiController
    {
        private branch_and_checks_Entities db = new branch_and_checks_Entities();

        
        public IQueryable<Check> GetChecks()
        {
            return db.Checks;
        }

        
        
        public IHttpActionResult GetCheck(int id)
        {
            Check check = db.Checks.Find(id);
            if (check == null)
            {
                return NotFound();
            }

            return Ok(check);
        }

        
        public IHttpActionResult PutCheck(int id, Check check)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != check.Id_Checks)
            {
                return BadRequest();
            }

            db.Entry(check).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckExists(id))
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

        
       

        
        public IHttpActionResult DeleteCheck(int id)
        {
            Check check = db.Checks.Find(id);
            if (check == null)
            {
                return NotFound();
            }

            db.Checks.Remove(check);
            db.SaveChanges();

            return Ok(check);
        }

        
    }
}