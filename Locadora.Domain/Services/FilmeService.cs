using Locadora.Domain.Interfaces.Repositories;
using Locadora.Domain.Interfaces.Services;
using Locadora.Domain.Models;
using Locadora.Domain.Models.Commands;
using System;
using System.Collections.Generic;

namespace Locadora.Domain.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmerepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmerepository = filmeRepository;
        }
        public async Task<IEnumerable<Filme>> ListarFilme()
        {
            return await _filmerepository.ListarFilme();
        }
        public async Task<Filme> FilmeId(long id)
        {
            return await _filmerepository.Get(x => x.Id == id);
        }
        public async Task<Filme> CadastrarFilme(Filme filme)
        {
            await _filmerepository.CadastrarFilme(filme);
            await _filmerepository.UnitOfWork.SaveChangesAsync();
            return filme;
        }
        public async Task<Filme> AtualizarFilme(AtualizarFilmeCommand command)
        {
            var filme = await _filmerepository.Get(x => x.Id == command.Id);
            if (filme == null) return null;

            filme.Atualizar(command.Titulo,
                command.Lancamento,
                command.ClassificacaoIndicativa);

            await _filmerepository.AtualizarFilme(filme);
            await _filmerepository.UnitOfWork.SaveChangesAsync();
            return filme;     
        }

        public async Task<bool> DeletarFilme(long id) 
        {
            var filme = await _filmerepository.Get(x => x.Id == id);
            if (filme == null) return false;
            await _filmerepository.DeletarFilme(filme);
            await _filmerepository.UnitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
