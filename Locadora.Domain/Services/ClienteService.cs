using Locadora.Domain.Interfaces.Repositories;
using Locadora.Domain.Interfaces.Services;
using Locadora.Domain.Models;
using Locadora.Domain.Models.Commands;

namespace Locadora.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> ListarCliente()
        {
            return await _clienteRepository.ListarCliente();
        }

        public async Task<Cliente> ClienteId(long id)
        {
            return await _clienteRepository.Get(x => x.Id == id);
        }
        public async Task<Cliente> CadastrarCliente(Cliente cliente)
        {
            await _clienteRepository.CadastrarCliente(cliente);
            if (!ValidaCPF.ValidarCPF(cliente.CPF)) return null;
            await _clienteRepository.UnitOfWork.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> AtualizarCliente(AtualizarClienteCommand command)
        {
            var cliente = await _clienteRepository.Get(x => x.Id == command.Id);
            if (cliente == null) return null;

            cliente.Atualizar(command.Nome,
               command.DataNascimento);

            await _clienteRepository.AtualizarCliente(cliente);
            await _clienteRepository.UnitOfWork.SaveChangesAsync();
            return cliente;
        }
        public async Task<bool> DeletarCliente(long id) 
        {
            var cliente = await _clienteRepository.Get(x => x.Id == id);
            if (cliente == null) return false;
            await _clienteRepository.DeletarCliente(cliente);
            await _clienteRepository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
