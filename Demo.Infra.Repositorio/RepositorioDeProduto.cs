using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Dominio;
using Demo.Dominio.Interfaces.Repositorio;

namespace Demo.Infra.Repositorio
{
    public class RepositorioDeProduto
        : RepositorioBase<Produto>, IRepositorioDeProduto
    {
        #region IRepositorioDeProduto Members

        public Produto ObterProdutoPorNome(string nome)
        {
            return entidades.Produtos.Single(x => x.Nome == nome);
        }

        public IList<Produto> RecuperarTodos()
        {
            return entidades.Produtos.ToList();
        }

        public bool ProdutoJáExiste(string nome)
        {
            return entidades.Produtos.Any(x =>
                                          x.Nome.Equals(nome, StringComparison.InvariantCultureIgnoreCase));
        }

        public void RemoverPorNome(string nome)
        {
            Produto produto = ObterProdutoPorNome(nome);
            entidades.Produtos.Remove(produto);
        }

        #endregion
    }
}