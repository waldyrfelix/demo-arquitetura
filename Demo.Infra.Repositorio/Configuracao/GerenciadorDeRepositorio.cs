using System.Web;
using Demo.Dominio.Interfaces.Infraestrutura;

namespace Demo.Infra.Repositorio.Configuracao
{
    public class GerenciadorDeRepositorioHttp : IGerenciadorDeRepositorio
    {
        public const string ContextoHttp = "ContextoHttp";

        public ContextoBanco Contexto
        {
            get
            {
                if (HttpContext.Current.Items[ContextoHttp] == null)
                {
                    HttpContext.Current.Items[ContextoHttp] = new ContextoBanco();
                }
                return HttpContext.Current.Items[ContextoHttp] as ContextoBanco;
            }
        }

        #region IGerenciadorDeRepositorio Members

        public void Finalizar()
        {
            if (HttpContext.Current.Items[ContextoHttp] != null)
            {
                (HttpContext.Current.Items[ContextoHttp] as ContextoBanco).Dispose();
            }
        }

        #endregion
    }
}