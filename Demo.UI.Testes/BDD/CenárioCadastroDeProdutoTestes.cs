using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Demo.UI.Testes.BDD
{
    [Binding]
    public class CenárioCadastroDeProdutoTestes
    {

        private readonly ChromeDriver _browser = new ChromeDriver();


        [Given(@"que eu estou na tela de listagem")]
        public void DadoQueEuEstouNaTelaDeListagem()
        {
            _browser.Navigate().GoToUrl("http://localhost:3603/Produto/Listar");
        }

        [Given(@"eu sou um usuário com permissão para cadastrar")]
        public void DadoEuSouUmUsuarioComPermissaoParaCadastrar()
        {
        }

        [When(@"eu clicar no link de Novo Produto")]
        public void QuandoEuClicarNoLinkDeNovoProduto()
        {
            _browser.FindElementByLinkText("Novo Produto").Click();
        }

        [When(@"preencher o nome do produto")]
        public void QuandoPreencherONomeDoProduto()
        {
            _browser.FindElementById("Nome").SendKeys( "mouse3");
        }

        [When(@"preencher o preço do produto")]
        public void QuandoPreencherOPrecoDoProduto()
        {
            _browser.FindElementById("Preco").SendKeys("100");
        }

        [When(@"clicar no botão create")]
        public void QuandoClicarNoBotaoCreate()
        {
            _browser.FindElementByCssSelector(".btn").Click();
        }

        [Then(@"deve direcionar para a tela de listagem com o produto cadastrado")]
        public void EntaoDeveDirecionarParaATelaDeListagemComOProdutoCadastrado()
        {
            var contains = _browser.PageSource.Contains("mouse3");
            Assert.IsTrue(contains);
        }

        [Then(@"deve mostrar uma mensagem de erro ""(.*)""")]
        public void EntaoDeveMostrarUmaMensagemDeErro(string p0)
        {
            var contains = _browser.PageSource.Contains("Já existe um produto com o nome");
            Assert.IsTrue(contains);
        }
    }
}
