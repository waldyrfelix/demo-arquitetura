using System;
namespace Demo.Aplicacao
{
    public interface IServicoDeAplicacaoDaTransportadora
    {
        System.Collections.Generic.IList<Demo.Dominio.Transportadora> RecuperarTodasAsTransportadoras();
    }
}
