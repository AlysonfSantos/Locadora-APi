using Locadora.Domain.Interfaces.Repositories;
using Locadora.Domain.Models;
using Locadora.Infra.Data.EF;
using Locadora.Infra.Data.Repositoreis.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Locadora.Infra.Data.Repositoreis
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly LocadoraContext _context;

        public ClienteRepository(LocadoraContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ListarCliente() 
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> ClienteId(long id) 
        {
            return await _context.Clientes.FindAsync(id); 
        }
        public async Task CadastrarCliente(Cliente cliente) 
        {
            await _context.Clientes.AddAsync(cliente);
        }
        public async Task AtualizarCliente(Cliente cliente) 
        {
            await Task.FromResult(_context.Update(cliente));
        }
        public async Task DeletarCliente(Cliente cliente) 
        {
            await Task.FromResult(_context.Remove(cliente));
        }
    }
}
