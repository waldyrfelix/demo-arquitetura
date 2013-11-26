using AutoMapper;

namespace DemoMVC.Infra
{
    public class ConfiguraçãoAutoMapper
    {
        public static void Inicializar()
        {
            Mapper.Initialize(i => { i.AddProfile<AutoMapperProfile>(); });
        }
    }
}