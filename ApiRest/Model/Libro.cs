using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Model
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public int IdEditorial { get; set; }
        public string Edicion { get; set; }
        public string Detalle { get; set; }

        public int Cantidad { get; set; }

        public decimal? Precio { get; set; }

    }
}
