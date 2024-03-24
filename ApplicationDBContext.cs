using Microsoft.EntityFrameworkCore;
using PruebaEncuesta.Models;

namespace PruebaEncuesta
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) 
        {
        }
        //crear las tablas de autores en sqlserver
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<Campo> Campo { get; set; }

        public DbSet<Valor> Valor { get; set; }

    }
}
