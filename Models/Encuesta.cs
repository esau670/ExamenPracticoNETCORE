using System.ComponentModel.DataAnnotations;

namespace PruebaEncuesta.Models
{
    public class Encuesta
    {
        //[Key]
        public int Id { get; set; }
        //para que el campo nombre sea requerido
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Campo> Campos { get; set; }
    }
}
