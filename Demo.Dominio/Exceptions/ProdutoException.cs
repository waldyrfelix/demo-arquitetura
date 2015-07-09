using System;

namespace Demo.Dominio.Exceptions
{
    public class ProdutoException : DemoArquiteturaException
    {
        public ProdutoException(string mensagem)
            : base(mensagem) { }

        public ProdutoException(string mensagem, Exception exception)
            : base(mensagem, exception) { }
    }
}