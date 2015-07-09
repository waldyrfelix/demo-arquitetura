using System.Collections.Generic;
using System.Linq;
using Demo.Dominio;
using Demo.Dominio.Interfaces.Repositórios;

namespace Demo.Infra.Repositorio
{
    public class RepositorioDeTransportadora
        : RepositorioBase<Transportadora>, IRepositorioDeTransportadora
    {
        #region IRepositorioDeTransportadora Members

        public IList<Transportadora> RecuperarTodos()
        {
            return _contexto.Transportadoras.ToList();
        }

        #endregion
    }
}