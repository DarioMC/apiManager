using apiManager.Context;
using apiManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : Controller
    {
        private readonly AppDbContext context;
        public ManagerController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ManagerController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.manager_bd.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ManagerController>/5
        [HttpGet("{id}", Name = "GetManager")]
        public ActionResult Get(int id)
        {
            try
            {
                var manager = context.manager_bd.FirstOrDefault(g => g.id == id);
                return Ok(manager);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ManagerController>
        [HttpPost]
        public ActionResult Post([FromBody] Manager_bd manager)
        {
            try
            {
                context.manager_bd.Add(manager);
                context.SaveChanges();
                return CreatedAtRoute("GetManager", new { id = manager.id }, manager);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ManagerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Manager_bd manager)
        {
            try
            {
                if (manager.id == id)
                {
                    context.Entry(manager).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetManager", new { id = manager.id }, manager);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // DELETE api/<ManagerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var manager = context.manager_bd.FirstOrDefault(g => g.id == id);
                if (manager != null)
                {
                    context.manager_bd.Remove(manager);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
