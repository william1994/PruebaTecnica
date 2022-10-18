using ApiRest.DBContext;
using ApiRest.Model;
using ApiRest.Model.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace ApiRest.Servicio
{
    public class CrudReserva
    {

        private readonly ConnetionDbContext context;

        public CrudReserva(ConnetionDbContext context)
        {
            this.context = context;
        }



        public IEnumerable<SelectMyBook> findMyBooking(int Cilente) {

            //var resultado = context.

            var list = context.MyBooking.FromSqlRaw("EXEC [dbo].[GetMyBooks] @IdCliente" 
                ,new SqlParameter ("@IdCliente", Cilente)
                ).ToList();
                

            return list;
        }


        public Reserva FindUpdateReserva(int ReservaInComming)
        {

            var restultado = context.Reserva.FirstOrDefault(x => x.IdReserva == ReservaInComming);

        
            return restultado;
        }

        public int UpdateReserva(Reserva ReservaInComming) {

            var restultado = context.Reserva.FirstOrDefault(x=>x.IdReserva== ReservaInComming.IdReserva);

            restultado.Cantidad = ReservaInComming.Cantidad;


            context.Reserva.Update(restultado);
            context.SaveChanges();
            return 1;
        }
        public int InsertarReserva(Reserva ReservaInComming) {

            try
            {
                Reserva Reserva = new Reserva();

                Reserva.Fecha = ReservaInComming.Fecha;
                Reserva.Descripcion = ReservaInComming.Descripcion;
                Reserva.IdCliente = ReservaInComming.IdCliente;
                Reserva.Enable = true;
                Reserva.IdReserva = ReservaInComming.IdReserva;
                Reserva.Cantidad = ReservaInComming.Cantidad;
                Reserva.IdLibro = ReservaInComming.IdLibro;
                context.Reserva.Add(Reserva);
                context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return 0;
            }


            return 1;
        }
    }
}
