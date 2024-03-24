using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaEncuesta.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaEncuesta.Controllers
{
    [Route("api/valor")]
    [ApiController]
    public class ValorController : ControllerBase
    {
        //llamamos la configuración de la base de datos
        private readonly ApplicationDBContext context;

        public ValorController(ApplicationDBContext context)
        {
            this.context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<Valor>>> Get()
        {
            return await context.Valor.ToListAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Valor>> Get(int id)
        {
            var valor = await context.Valor.FirstOrDefaultAsync(x => x.Id == id);
            if (valor == null)
            {
                return NotFound();
            }
            return Ok(valor);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post(Valor valor)
        {
            context.Add(valor);
            await context.SaveChangesAsync();
            return Ok();

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Valor valor, int id)
        {
            //validamos que sea tipo int
            if (valor.Id != id)
            {
                return BadRequest("El id del valor no coincide con el id de la URL");
            }
            // validamos que exista la encuesta el db
            var existe = await context.Valor.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Update(valor);
            await context.SaveChangesAsync();
            return Ok();

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Valor.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Valor { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
