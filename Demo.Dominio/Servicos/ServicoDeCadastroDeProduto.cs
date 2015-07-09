using Demo.Dominio.Exceptions;
using Demo.Dominio.Interfaces.Domínio;
using Demo.Dominio.Interfaces.Repositórios;

namespace Demo.Dominio.Servicos
{
    public class ServicoDeCadastroDeProduto : IServicoDeCadastroDeProduto
    {
        private readonly IRepositorioDeProduto _repositorioDeProduto;

        public ServicoDeCadastroDeProduto(IRepositorioDeProduto repositorioDeProduto)
        {
            _repositorioDeProduto = repositorioDeProduto;
        }

        #region IServicoDeCadastroDeProduto Members

        public void CadastrarProduto(Produto produto)
        {
            if (_repositorioDeProduto.ProdutoJáExiste(produto.Nome))
            {
                throw new ProdutoException("Já existe um produto com o nome " + produto.Nome);
            }

            _repositorioDeProduto.Inserir(produto);
        }

        #endregion
    }
}