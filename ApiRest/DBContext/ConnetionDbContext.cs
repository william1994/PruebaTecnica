using ApiRest.Model;
using ApiRest.Model.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.DBContext
{
    public class ConnetionDbContext : DbContext
    {

        public ConnetionDbContext(DbContextOptions<ConnetionDbContext> options):base(options){ 
        
        //
        }

        protected override void OnModelCreating(ModelBuilder model) {

            base.OnModelCreating(model);
            model.Entity<SelectMyBook>().HasNoKey();
        }


        /// <summary>
        /// Tablas 
        /// </summary>
        public DbSet<Libro> Libro { get; set; }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Reserva> Reserva { get; set; }

        public DbSet<Venta> Venta { get; set; }
        // ViewModel
        public DbSet<SelectMyBook> MyBooking { get; set; }

    }
}
