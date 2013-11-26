using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Demo.Dominio;
using Demo.Dominio.Interfaces.Infra;
using Demo.Dominio.Interfaces.Repositorio;
using Demo.Infra.Repositorio.Configuracao;
using Microsoft.Practices.ServiceLocation;

namespace Demo.Infra.Repositorio
{
    public class RepositorioBase<TEntidade>
        : IRepositorioBase<TEntidade> where TEntidade : Identificador
    {
        protected ContextoBanco entidades;

        public RepositorioBase()
        {
            var gerenciador = ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorioHttp>()
                              as GerenciadorDeRepositorio;

            entidades = gerenciador.Contexto;

            Debug.WriteLine("ID DO CONTEXTO EF: " + entidades.GetHashCode());
        }

        #region IRepositorioBase<TEntidade> Members

        public TEntidade RecuperarPorId(int id)
        {
            return entidades.Set<TEntidade>()
                .Where(x => x.Id == id)
                .SingleOrDefault();
        }

        public TEntidade RecuperarUmPorExemplo(TEntidade filtro)
        {
            throw new NotImplementedException();
        }

        public IList<TEntidade> RecuperarPaginadoPorExemplo(TEntidade filtro, int paginaAtual, int tamanhoDaPagina)
        {
            throw new NotImplementedException();
        }

        public IList<TEntidade> RecuperarPaginado(int paginaAtual, int tamanhoDaPagina)
        {
            return entidades.Set<TEntidade>()
                .Skip(paginaAtual*tamanhoDaPagina)
                .Take(tamanhoDaPagina)
                .ToList();
        }

        public void Inserir(TEntidade obj)
        {
            entidades.Set<TEntidade>().Add(obj);
        }

        public void Alterar(TEntidade obj)
        {
            entidades.Entry(obj).State = EntityState.Modified;
        }

        public void Remover(TEntidade obj)
        {
            entidades.Set<TEntidade>().Remove(obj);
        }

        public void Remover(int id)
        {
            TEntidade obj = RecuperarPorId(id);
            Remover(obj);
        }

        #endregion
    }
}