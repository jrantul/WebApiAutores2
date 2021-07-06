using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAutores2.Entidades;

namespace WebApiAutores2.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }
        /*
        [HttpGet]
        public ActionResult<List<Autor>> Get()
        {
            return new List<Autor>() {
                new Autor() { id = 1, Nombre = "Felipe"},
                new Autor() { id = 2, Nombre = "Claudia"}
            };
        }*/

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await context.Autores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post (Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] //    api/autores/id
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.id != id)
            {
                return BadRequest("El id del autor no cincide con el id de la URL");
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
