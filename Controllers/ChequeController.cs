using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChequeAPI.Models;

namespace ChequeAPI.Controllers
{
    public class ChequeController : ApiController
    {
        branch_and_checks_Entities entities = new branch_and_checks_Entities();
        
        public IEnumerable<Check> GetChecks()
        {
            var check = entities.Checks.Select(p => p).ToList();
            return check;
            
            
        }

        public IHttpActionResult GetCheck(int id)
        {
            var ch_id = entities.Checks.FirstOrDefault((p) => p.Id_Checks == id);
            if (ch_id == null)
            {
                return NotFound();
            }
            return Ok(ch_id);
        }
    }
}
