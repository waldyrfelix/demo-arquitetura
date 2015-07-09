using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Demo.Dominio;
using Demo.Dominio.Interfaces.Infraestrutura;
using Demo.Dominio.Interfaces.Repositórios;
using Demo.Infra.Repositorio.Configuracao;
using Microsoft.Practices.ServiceLocation;

namespace Demo.Infra.Repositorio
{
    public class RepositorioBase<TEntidade> : 
        IRepositorioBase<TEntidade> where TEntidade : Identificador
    {
        protected readonly ContextoBanco _contexto;

        public RepositorioBase()
        {
            var gerenciador = (GerenciadorDeRepositorioHttp) ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>();

            _contexto = gerenciador.Contexto;

            Debug.WriteLine("ID DO CONTEXTO EF: " + _contexto.GetHashCode());
        }

        #region IRepositorioBase<TEntidade> Members

        public TEntidade Recuperar(int id)
        {
            return _contexto.Set<TEntidade>().SingleOrDefault(x => x.Id == id);
        }

        public void Inserir(TEntidade obj)
        {
            _contexto.Set<TEntidade>().Add(obj);
        }

        public void Alterar(TEntidade obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
        }

        public void Remover(TEntidade obj)
        {
            _contexto.Set<TEntidade>().Remove(obj);
        }

        public void Remover(int id)
        {
            TEntidade obj = Recuperar(id);
            Remover(obj);
        }

        #endregion
    }
}