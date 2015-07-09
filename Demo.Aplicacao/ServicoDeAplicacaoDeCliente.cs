using Demo.Dominio;
using Demo.Dominio.Interfaces.Aplicação;
using Demo.Dominio.Interfaces.Repositórios;

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
            return _repositorioDeCliente.Recuperar(id);
        }

        #endregion
    }
}