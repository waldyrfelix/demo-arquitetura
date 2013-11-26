using System.Collections.Generic;

namespace Demo.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntidade> where TEntidade : class
    {
        TEntidade RecuperarPorId(int id);
        TEntidade RecuperarUmPorExemplo(TEntidade filtro);
        IList<TEntidade> RecuperarPaginadoPorExemplo(TEntidade filtro, int paginaAtual, int tamanhoDaPagina);
        IList<TEntidade> RecuperarPaginado(int paginaAtual, int tamanhoDaPagina);
        void Inserir(TEntidade obj);
        void Alterar(TEntidade obj);
        void Remover(TEntidade obj);
        void Remover(int id);
    }
}