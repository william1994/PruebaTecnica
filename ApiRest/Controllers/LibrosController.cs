using ApiRest.DBContext;
using ApiRest.Model;
using ApiRest.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        // GET: LibrosController
        private readonly ConnetionDbContext context;
        CrudLibros libros;

        public LibrosController(ConnetionDbContext context)
        {
            this.context = context;
            libros = new CrudLibros(context);
        }

        [HttpGet]
        [Route("GetBookByID")]
        public Libro getBook(int id)
        {

            return libros.findBook(id);
        }

        [HttpGet]
        [Route("GetAllBook")]
        public IEnumerable<Libro> get()
        {

            return libros.GetAllBook();
        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult post([FromBody] Libro BookInComming)
        {
            try
            {
                var Request= libros.InsertBook(BookInComming);
            if (Request==1) {
                return Ok();
            }else
            {
                return BadRequest(Request);

            }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update([FromBody] Libro BookUpdate)
        {
            try {

                var Request = libros.UpdateBook(BookUpdate);

                if (Request == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            } catch (Exception ex) {
                                return BadRequest();
                    }
                }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int BookDelete)
        {

            try {
              

               var Request =  libros.DeleteBook(BookDelete);

                if (Request == 1)
                {
                    return Ok();
                }
                else {
                    return BadRequest();
                }

               
            } catch (Exception ex) {
                return BadRequest();
            }
        }

    }
}
