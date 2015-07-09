using Demo.Dominio;
using Demo.Dominio.Interfaces.Repositórios;

namespace Demo.Infra.Repositorio
{
    public class RepositorioDeRepresentante
        : RepositorioBase<Representante>, IRepositorioDeRepresentante
    {
    }
}