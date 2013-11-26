using System.Web;
using Demo.Dominio.Interfaces.Infra;

namespace Demo.Infra.Repositorio.Configuracao
{
    public class GerenciadorDeRepositorio : IGerenciadorDeRepositorioHttp
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

        #region IGerenciadorDeRepositorioHttp Members

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