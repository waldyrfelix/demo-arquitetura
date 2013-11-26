using AutoMapper;

namespace DemoMVC.Infra
{
    public static class ConversorHelper
    {
        public static TObjSaida Mapear<TObjEntrada, TObjSaida>(TObjEntrada obj)
        {
            return Mapper.Map<TObjEntrada, TObjSaida>(obj);
        }
    }
}