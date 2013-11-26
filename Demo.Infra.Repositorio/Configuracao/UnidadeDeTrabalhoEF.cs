using Demo.Dominio.Interfaces.Infra;
using Microsoft.Practices.ServiceLocation;

namespace Demo.Infra.Repositorio.Configuracao
{
    public class UnidadeDeTrabalhoEF : IUnidadeDeTrabalho
    {
        private ContextoBanco contexto;

        #region IUnidadeDeTrabalho Members

        public void Iniciar()
        {
            var gerenciador = ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorioHttp>()
                              as GerenciadorDeRepositorio;

            contexto = gerenciador.Contexto;
        }

        public void Persistir()
        {
            contexto.SaveChanges();
        }

        #endregion
    }
}