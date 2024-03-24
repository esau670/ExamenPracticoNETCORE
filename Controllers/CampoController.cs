using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaEncuesta.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaEncuesta.Controllers
{
    [Route("api/campo")]
    [ApiController]
    public class CampoController : ControllerBase
    {

        //llamamos la configuración de la base de datos
        private readonly ApplicationDBContext context;

        public CampoController(ApplicationDBContext context)
        {
            this.context = context;
        }

        // GET: api/<CampoController>
        [HttpGet]
        public async Task<ActionResult<List<Campo>>> Get()
        {
            return await context.Campo.Include(x => x.Valor).ToListAsync();
        }

        // GET api/<CampoController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Campo>> Get(int id)
        {
            var campo = await context.Campo.Include(x => x.Valor).FirstOrDefaultAsync(x => x.Id == id);
            if (campo == null)
            {
                return NotFound();
            }
            return Ok(campo);
        }

        // POST api/<CampoController>
        [HttpPost]
        public async Task<ActionResult> Post(Campo campo)
        {
            context.Add(campo);
            await context.SaveChangesAsync();
            return Ok();

        }

        // PUT api/<CampoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Campo campo, int id)
        {
            //validamos que sea tipo int
            if (campo.Id != id)
            {
                return BadRequest("El id del campo no coincide con el id de la URL");
            }
            // validamos que exista la encuesta el db
            var existe = await context.Campo.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Update(campo);
            await context.SaveChangesAsync();
            return Ok();

        }

        // DELETE api/<CampoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Campo.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Campo { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
