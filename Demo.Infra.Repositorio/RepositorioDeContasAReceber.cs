using Demo.Dominio;
using Demo.Dominio.Interfaces.Repositorio;

namespace Demo.Infra.Repositorio
{
    public class RepositorioDeContasAReceber
        : RepositorioBase<ContaAReceber>, IRepositorioDeContasAReceber
    {
    }
}