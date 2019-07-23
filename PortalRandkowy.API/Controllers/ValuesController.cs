using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalRandkowy.API.Data;
using PortalRandkowy.API.Models;

namespace PortalRandkowy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DataContext context { get; }
        public ValuesController(DataContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public IActionResult GetValues()
        {
            var values = context.Values.ToList();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value = context.Values.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddValue([FromBody] Value value)
        {
            context.Values.Add(value);
            context.SaveChanges();
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult EditValue(int id, [FromBody] Value value)
        {
            var data = context.Values.Find(id);
            data.Name = value.Name;
            context.SaveChanges();
            return Ok(data);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteValue(int id)
        {
            var data = context.Values.Find(id);
            if (data == null)
                return NoContent();
            context.Values.Remove(data);
            context.SaveChanges();
            return Ok(data);
        }
    }
}
