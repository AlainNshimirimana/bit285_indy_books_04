using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IndyBooks.Models;
using IndyBooks.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndyBooks.Controllers
{
    [Route("api/[controller]")]
    public class WriterController : ControllerBase
    {
        private IndyBooksDataContext _db;
        public WriterController(IndyBooksDataContext db) 
        { 
            _db = db; 
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            //entire list of writers (without book information)
            var writers = _db.Writers.Select(w => new {w.Id, w.Name});
            return Ok(writers);
        }


        // GET api/Writer/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            //The info for a SINGLE writer(without book information)
            var writers = _db.Writers.Select(w => new { w.Id, w.Name })
                .Where( w => w.Id == id);
            return Ok(writers);
        }
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
