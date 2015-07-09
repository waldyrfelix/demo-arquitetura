using System.Collections.Generic;

namespace Demo.Dominio.Interfaces.Repositórios
{
    public interface IRepositorioDeTransportadora : IRepositorioBase<Transportadora>
    {
        IList<Transportadora> RecuperarTodos();
    }
}