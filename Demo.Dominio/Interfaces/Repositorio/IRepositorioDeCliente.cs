using System.Collections.Generic;

namespace Demo.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioDeCliente : IRepositorioBase<Cliente>
    {
        IList<Cliente> RecuperarPorLimiteDeCredito(decimal limiteInicial, decimal limiteFinal);
    }
}