using AutoMapper;
using Demo.Dominio;
using Demo.UI.Mvc.ViewModels;

namespace Demo.UI.Mvc.Infra
{
    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Venda, ItemDoGridDeVendaViewModel>()
                .ForMember(x => x.NomeDoCliente, x => x.MapFrom(v => v.Cliente.Nome))
                .ForMember(x => x.QuantidadeDeItens, x => x.MapFrom(v => v.ItensDaVenda.Count));
        }
    }
}