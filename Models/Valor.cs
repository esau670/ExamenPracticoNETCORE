namespace PruebaEncuesta.Models
{
    public class Valor
    {
        public int Id { get; set; }
        public string valor { get; set; }
        public int CampoId { get; set; }

        public Campo Campo { get; set; }

    }
}
