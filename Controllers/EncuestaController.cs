using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaEncuesta.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaEncuesta.Controllers
{
    [ApiController]
    [Route("api/encuesta")]
    public class EncuestaController : ControllerBase
    {
        //llamamos la configuración de la base de datos
        private readonly ApplicationDBContext context;

        public EncuestaController(ApplicationDBContext context)
        {
            this.context = context;
        }
        // GET: api/<EncuestaController>
        [HttpGet]
        public async Task<ActionResult<List<Encuesta>>> Get()
        {
            return await context.Encuestas.Include(x => x.Campos).ToListAsync();
        }

        // GET api/<EncuestaController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Encuesta>> Get(int id)
        {
            var encuesta = await context.Encuestas.FirstOrDefaultAsync(x => x.Id == id);
            if (encuesta==null)
            {
                return NotFound();
            }
            return Ok(encuesta);
        }

        // POST api/<EncuestaController>
        [HttpPost]
        
        public async Task<ActionResult> Post(Encuesta encuesta)
        {
            context.Add(encuesta);
            await context.SaveChangesAsync();
            return Ok();
           
        }

        // PUT api/<EncuestaController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Encuesta encuesta, int id)
        {
            //validamos que sea tipo int
            if(encuesta.Id != id)
            {
                return BadRequest("El id de la encuesta no coincide con el id de la URL");
            }
            // validamos que exista la encuesta el db
            var existe = await context.Encuestas.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Update(encuesta);
            await context.SaveChangesAsync();
            return Ok();

        }

        // DELETE api/<EncuestaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Encuestas.AnyAsync(x => x.Id == id);
            if (!existe )
            {
                return NotFound();
            }

            context.Remove(new Encuesta { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
