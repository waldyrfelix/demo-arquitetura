namespace Demo.Dominio.Interfaces.Aplicação
{
    public interface IServicoDeAplicacaoDeProduto
    {
        void CadastrarProduto(Demo.Dominio.Produto produto);
        Demo.Dominio.Produto RecuperarPorNome(string nome);
        System.Collections.Generic.IList<Demo.Dominio.Produto> RecuperarTodosOsProdutos();
        void RemoverPorNome(string nome);
    }
}
