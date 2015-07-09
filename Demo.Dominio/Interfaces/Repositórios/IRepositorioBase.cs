using System.Collections.Generic;

namespace Demo.Dominio.Interfaces.Repositórios
{
    public interface IRepositorioBase<TEntidade> where TEntidade : class
    {
        TEntidade Recuperar(int id);
        void Inserir(TEntidade obj);
        void Alterar(TEntidade obj);
        void Remover(TEntidade obj);
        void Remover(int id);
    }
}