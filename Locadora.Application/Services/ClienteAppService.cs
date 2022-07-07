using AutoMapper;
using Locadora.Application.Services.Interfaces;
using Locadora.Application.ViewModels.ClientesViewModel;
using Locadora.Domain.Interfaces.Services;
using Locadora.Domain.Models;
using Locadora.Domain.Models.Commands;

namespace Locadora.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _cadastroService;
        private readonly IMapper _mapper;

        public ClienteAppService(IClienteService cadastroService, IMapper mapper)
        {
            _cadastroService = cadastroService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClienteViewModel>> ListarCliente()
        {
            var cliente = await _cadastroService.ListarCliente();
            return _mapper.Map<IEnumerable<ClienteViewModel>>(cliente);
        }
        public async Task<ClienteViewModel> ClienteId(long id) 
        {
            var cliente = await _cadastroService.ClienteId(id);
            return _mapper.Map<ClienteViewModel>(cliente);
        }
        public async Task<ClienteViewModel> CadastrarCliente(NovoClienteViewModel novoClienteViewModel) 
        {
            var novoCliente = new Cliente(novoClienteViewModel.Nome,
                novoClienteViewModel.CPF,
                novoClienteViewModel.DataNascimento);

            var ClienteCadastrado = await _cadastroService.CadastrarCliente(novoCliente);
            return _mapper.Map<ClienteViewModel>(ClienteCadastrado);    
        }
        public async Task<ClienteViewModel> AtualizarCliente(AtualizarClienteViewModel atualizarClienteViewModel) 
        {
            var command = new AtualizarClienteCommand
            {
                Id = atualizarClienteViewModel.Id,
                Nome = atualizarClienteViewModel.Nome,                
                DataNascimento = atualizarClienteViewModel.DataNascimento
            };
            var usuarioAtualizado = await _cadastroService.AtualizarCliente(command);   
            return _mapper.Map<ClienteViewModel>(usuarioAtualizado);
        }
        public async Task<bool> DeletarCliente(long id) 
        {
            return await _cadastroService.DeletarCliente(id);
        }
    }
}
