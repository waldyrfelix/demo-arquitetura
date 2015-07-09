using Demo.Dominio.Interfaces.Infraestrutura;
using Microsoft.Practices.ServiceLocation;

namespace Demo.Aplicacao
{
    public class ServicoDeAplicacaoBase
    {
        private IUnidadeDeTrabalho _unidadeDeTrabalho;

        public virtual void IniciarTransação()
        {
            _unidadeDeTrabalho = ServiceLocator.Current.GetInstance<IUnidadeDeTrabalho>();
            _unidadeDeTrabalho.Iniciar();
        }

        public virtual void PersistirTransação()
        {
            _unidadeDeTrabalho.Persistir();
        }
    }
}