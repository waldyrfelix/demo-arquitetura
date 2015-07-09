using System;

namespace Demo.Dominio.Exceptions
{
    public class DemoArquiteturaException : Exception
    {
        public DemoArquiteturaException(string mensagem)
            : base(mensagem) { }

        public DemoArquiteturaException(string mensagem, Exception exception)
            : base(mensagem, exception) { }
    }
}