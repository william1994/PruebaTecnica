using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Model
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReserva { get; set; }
        public DateTime Fecha { get; set; }
        public String Descripcion { get; set; }
        public int IdCliente { get; set; }
        public bool Enable{ get; set; }

        public int IdLibro { get; set; }
        public int Cantidad { get; set; }
    }
}
