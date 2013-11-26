using System.Collections.Generic;

namespace Demo.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioDeTransportadora : IRepositorioBase<Transportadora>
    {
        IList<Transportadora> RecuperarTodos();
    }
}