using Demo.Dominio.Interfaces.Infraestrutura;
using Microsoft.Practices.ServiceLocation;

namespace Demo.Infra.Repositorio.Configuracao
{
    public class UnidadeDeTrabalhoEF : IUnidadeDeTrabalho
    {
        private ContextoBanco _contexto;

        #region IUnidadeDeTrabalho Members

        public void Iniciar()
        {
            var gerenciador = ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>()
                              as GerenciadorDeRepositorioHttp;

            _contexto = gerenciador.Contexto;
        }

        public void Persistir()
        {
            _contexto.SaveChanges();
        }

        #endregion
    }
}