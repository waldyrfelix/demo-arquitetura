using System;
namespace Demo.Aplicacao
{
    public interface IServicoDeAplicacaoDeCliente
    {
        Demo.Dominio.Cliente RecuperarClientePorId(int id);
    }
}
