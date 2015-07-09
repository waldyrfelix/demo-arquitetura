using System.Collections.Generic;
using Demo.Dominio;
using Demo.Dominio.Interfaces.Aplicação;
using Demo.Dominio.Interfaces.Domínio;
using Demo.Dominio.Interfaces.Repositórios;

namespace Demo.Aplicacao
{
    public class ServicoDeAplicacaoDeProduto : ServicoDeAplicacaoBase, IServicoDeAplicacaoDeProduto
    {
        private readonly IRepositorioDeProduto _repositorioDeProduto;
        private readonly IServicoDeCadastroDeProduto _servicoDeCadastroDeProduto;

        public ServicoDeAplicacaoDeProduto(IServicoDeCadastroDeProduto servicoDeCadastroDeProduto,
                                           IRepositorioDeProduto repositorioDeProduto)
        {
            _servicoDeCadastroDeProduto = servicoDeCadastroDeProduto;
            _repositorioDeProduto = repositorioDeProduto;
        }

        #region IServicoDeAplicacaoDeProduto Members

        public virtual void CadastrarProduto(Produto produto)
        {
            IniciarTransação();
            _servicoDeCadastroDeProduto.CadastrarProduto(produto);
            PersistirTransação();
        }

        public virtual IList<Produto> RecuperarTodosOsProdutos()
        {
            return _repositorioDeProduto.RecuperarTodos();
        }

        public virtual Produto RecuperarPorNome(string nome)
        {
            return _repositorioDeProduto.ObterProdutoPorNome(nome);
        }

        public virtual void RemoverPorNome(string nome)
        {
            IniciarTransação();
            _repositorioDeProduto.RemoverPorNome(nome);
            PersistirTransação();
        }

        #endregion
    }
}