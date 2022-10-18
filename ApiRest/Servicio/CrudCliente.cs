using ApiRest.DBContext;
using ApiRest.Model;

namespace ApiRest.Servicio
{
    public class CrudCliente
    {
        private readonly ConnetionDbContext context;

        public CrudCliente(ConnetionDbContext context)
        {
            this.context = context;
        }

        public int InsertCliente(Cliente clienteIncoming) {

            Cliente cliente = new Cliente();
            cliente.NombreCliente = clienteIncoming.NombreCliente;
            cliente.ApellidoCliente = clienteIncoming.ApellidoCliente;
            cliente.DUICliente = clienteIncoming.DUICliente;
            
            context.Cliente.Add(cliente);
            context.SaveChanges();

            return 1;
        }
    }
}
