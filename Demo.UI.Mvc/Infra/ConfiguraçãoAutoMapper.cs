using AutoMapper;

namespace Demo.UI.Mvc.Infra
{
    public class ConfiguraçãoAutoMapper
    {
        public static void Inicializar()
        {
            Mapper.Initialize(i => i.AddProfile<AutoMapperProfile>());
        }
    }
}