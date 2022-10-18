using ApiRest.DBContext;
using ApiRest.Model;
using ApiRest.Model.ViewModel;
using ApiRest.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {

        private readonly ConnetionDbContext context;
        CrudReserva Reserva;

        public ReservaController(ConnetionDbContext context)
        {
            this.context = context;
            Reserva = new CrudReserva(context);
        }

        [HttpGet]
        [Route("GetReserveByID")]
        public Reserva GetReserveById(int IdReserva)
        {

            return Reserva.FindUpdateReserva(IdReserva);
        }

        [HttpPost]
        [Route("UpdateReserve")]
        public IActionResult Update([FromBody] Reserva ReservaUpdate)
        {
            try
            {

                var Request = Reserva.UpdateReserva(ReservaUpdate);

                if (Request == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetMyBooking")]
        public IEnumerable<SelectMyBook> get(int idClient)
        {

            return Reserva.findMyBooking(idClient);
        }


        [HttpPost]
        [Route("Reservar")]
        public IActionResult post([FromBody] Reserva BookInComming)
        {
            try
            {
                var Request = Reserva.InsertarReserva(BookInComming);
                if (Request == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(Request);

                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
