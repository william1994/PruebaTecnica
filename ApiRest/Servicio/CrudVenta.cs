using ApiRest.DBContext;
using ApiRest.Model;

namespace ApiRest.Servicio
{
    public class CrudVenta
    {
        private readonly ConnetionDbContext context;

        public CrudVenta(ConnetionDbContext context)
        {
            this.context = context;
        }

        public int InserVenta(int idReserva) {

            Venta venta = new Venta();

            venta.IdReserva = idReserva;



            
            var resultTotal = context.Reserva.FirstOrDefault(x => x.IdReserva == idReserva);


            var consulta = context.Libro.FirstOrDefault(x => x.IdLibro == resultTotal.IdLibro);

            var operacion = consulta.Precio * resultTotal.Cantidad;
            venta.Total = operacion;


            context.Venta.Add(venta);

            context.SaveChanges();

            var result = context.Reserva.FirstOrDefault(x=>x.IdReserva == idReserva);

            var restulLibro = result.Cantidad;


            var idLibro = result.IdLibro;
            var restultBook = context.Libro.FirstOrDefault(x=>x.IdLibro== idLibro);
            var totalCantidad = restultBook.Cantidad;

            restultBook.Cantidad = (totalCantidad -restulLibro);

            context.Libro.Update(restultBook);
            context.SaveChanges();
            return 1;
        }


    }
}
