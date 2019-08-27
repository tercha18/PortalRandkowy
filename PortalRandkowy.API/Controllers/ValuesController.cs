﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetValues()
        {
            var values = await context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AddValue([FromBody] Value value)
        {
            context.Values.Add(value);
            await context.SaveChangesAsync();
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditValue(int id, [FromBody] Value value)
        {
            var data = await context.Values.FindAsync(id);
            data.Name = value.Name;
            await context.SaveChangesAsync();
            return Ok(data);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValue(int id)
        {
            var data = await context.Values.FindAsync(id);
            if (data == null)
                return NoContent();
            context.Values.Remove(data);
            await context.SaveChangesAsync();
            return Ok(data);
        }
    }
}
