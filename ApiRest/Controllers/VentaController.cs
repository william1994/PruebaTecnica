using ApiRest.DBContext;
using ApiRest.Model;
using ApiRest.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly ConnetionDbContext context;
        CrudVenta crudVenta;

        public VentaController(ConnetionDbContext context)
        {
            this.context = context;
            crudVenta = new CrudVenta(context);
        }

        [HttpPost]
        [Route("Comprar")]
        public IActionResult post([FromBody] Venta venta)
        {
            try
            {
                var idReserva = venta.IdReserva;
                var Request = crudVenta.InserVenta(idReserva);
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
