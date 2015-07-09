using System.Collections.Generic;

namespace Demo.Dominio.Interfaces.Repositórios
{
    public interface IRepositorioDeCliente : IRepositorioBase<Cliente>
    {
        IList<Cliente> RecuperarPorLimiteDeCredito(decimal limiteInicial, decimal limiteFinal);
    }
}