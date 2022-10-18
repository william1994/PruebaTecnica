namespace ApiRest.Model.ViewModel
{
    public class SelectMyBook
    {

        public int IdReserva { get; set; }
        public int IdLibro { get; set; }
        public string NombreCliente { get; set; }
        public string NombreLibro { get; set; }

        public int Cantidad { get; set; }
        public decimal? Precio { get; set; }



    }
}
