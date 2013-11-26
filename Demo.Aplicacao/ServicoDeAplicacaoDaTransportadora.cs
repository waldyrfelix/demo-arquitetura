using System.Collections.Generic;
using Demo.Dominio;
using Demo.Dominio.Interfaces.Repositorio;

namespace Demo.Aplicacao
{
    public class ServicoDeAplicacaoDaTransportadora : ServicoDeAplicacaoBase, Demo.Aplicacao.IServicoDeAplicacaoDaTransportadora
    {
        private readonly IRepositorioDeTransportadora _repositorioDeTransportadora;

        public ServicoDeAplicacaoDaTransportadora(IRepositorioDeTransportadora repositorioDeTransportadora)
        {
            _repositorioDeTransportadora = repositorioDeTransportadora;
        }

        #region IServicoDeAplicacaoDaTransportadora Members

        public IList<Transportadora> RecuperarTodasAsTransportadoras()
        {
            return _repositorioDeTransportadora.RecuperarTodos();
        }

        #endregion
    }
}