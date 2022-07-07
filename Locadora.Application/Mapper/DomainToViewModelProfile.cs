using AutoMapper;
using Locadora.Application.ViewModels.ClientesViewModel;
using Locadora.Application.ViewModels.FilmesViewModel;
using Locadora.Application.ViewModels.LocacaoViewModel;
using Locadora.Domain.Models;


namespace Locadora.Application.Mapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Filme, FilmeViewModel>();
            CreateMap<Locacao, LocacaoViewModel>();
        }
    }
}
