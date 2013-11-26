using Demo.Dominio;
using Demo.Dominio.Interfaces.Infra;
using Demo.Dominio.Interfaces.Repositorio;

namespace Demo.Aplicacao
{
    public class ServicoDeAplicacaoDeCliente : ServicoDeAplicacaoBase, IServicoDeAplicacaoDeCliente
    {
        private readonly IRepositorioDeCliente _repositorioDeCliente;

        public ServicoDeAplicacaoDeCliente(IRepositorioDeCliente repositorioDeCliente)
        {
            _repositorioDeCliente = repositorioDeCliente;
        }

        #region IServicoDeAplicacaoDeCliente Members

        public Cliente RecuperarClientePorId(int id)
        {
            //return new Cliente();
            return _repositorioDeCliente.RecuperarPorId(id);
        }

        #endregion
    }
}