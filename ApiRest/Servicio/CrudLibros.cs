using ApiRest.DBContext;
using ApiRest.Model;

namespace ApiRest.Servicio
{
    public class CrudLibros
    {
        private readonly ConnetionDbContext context;
       // CrudReserva CrudReserva;
       

        public CrudLibros(ConnetionDbContext context)
        {
            this.context = context;
          //  CrudReserva = new CrudReserva(context);
        }

        public Libro findBook(int id){
           var listar = context.Libro.FirstOrDefault(x => x.IdLibro == id);
            return listar;
        }
        public IEnumerable<Libro> GetAllBook() {


            return context.Libro.ToList();
        }

       
        public int InsertBook(Libro BookInComming) {

            try
            {
                Libro Book = new Libro();

                Book.NombreLibro = BookInComming.NombreLibro;
                Book.IdEditorial = BookInComming.IdEditorial;
                Book.Edicion = BookInComming.Edicion;
                Book.Detalle = BookInComming.Detalle;
                Book.Cantidad = BookInComming.Cantidad;
                Book.Precio = BookInComming.Precio;
                context.Libro.Add(Book);
                context.SaveChanges();
                return 1;
            }
            catch (Exception ex) {

                return 0;
            }

    }

        
        public int UpdateBook(Libro BookUpdate) {
            try
            {
                Libro Book = new Libro();
                var result = context.Libro.FirstOrDefault(x => x.IdLibro == BookUpdate.IdLibro);

                result.NombreLibro = BookUpdate.NombreLibro;
                result.IdEditorial = BookUpdate.IdEditorial;
                result.Edicion = BookUpdate.Edicion;
                result.Detalle = BookUpdate.Detalle;
                result.Cantidad = BookUpdate.Cantidad;
                result.Precio = BookUpdate. Precio;
                context.Libro.Update(result);
                context.SaveChanges();
                return 1;
            }
            catch (Exception ex) {
                return 0;
            
            }

        }
        public int DeleteBook(int BookDelete) {
            try
            {

                int IDBook = BookDelete;

                var result = context.Libro.FirstOrDefault(x => x.IdLibro == IDBook);
                context.Libro.Remove(result);
                context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

    }
}
