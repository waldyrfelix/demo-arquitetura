using System.Collections.Generic;
using System.Linq;
using Demo.Dominio;
using Demo.Dominio.Interfaces.Repositorio;

namespace Demo.Infra.Repositorio
{
    public class RepositorioDeCliente : RepositorioBase<Cliente>, IRepositorioDeCliente
    {
        #region IRepositorioDeCliente Members

        public IList<Cliente> RecuperarPorLimiteDeCredito(decimal limiteInicial, decimal limiteFinal)
        {
            return entidades.Clientes
                .Where(c => c.LimiteDeCredito >= limiteInicial && c.LimiteDeCredito <= limiteFinal)
                .ToList();
        }

        #endregion
    }
}