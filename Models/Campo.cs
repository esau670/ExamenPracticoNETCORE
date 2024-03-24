namespace PruebaEncuesta.Models
{
    public class Campo
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string titulo { get; set; }
        public Boolean requerido { get; set; }
        public string tipo { get; set; }
        public int EncuestaId { get; set; }

        public Encuesta Encuesta { get; set; }

        public List<Valor> Valor { get; set; }

    }
}
