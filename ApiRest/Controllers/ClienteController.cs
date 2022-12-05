using ApiRest.DBContext;
using ApiRest.Model;
using ApiRest.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        //Client controller
        //feature
        //Merge
        //new merge
        private readonly ConnetionDbContext context;
        CrudCliente Cliente;

        public ClienteController(ConnetionDbContext context)
        {
            this.context = context;
            Cliente = new CrudCliente(context);
        }

        [HttpPost]
        [Route("InsertCliente")]
        public IActionResult post([FromBody] Cliente ClienteInComming)
        {
            try
            {
                var Request = Cliente.InsertCliente(ClienteInComming);
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
