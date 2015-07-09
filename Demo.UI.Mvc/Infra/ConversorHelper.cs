using AutoMapper;

namespace Demo.UI.Mvc.Infra
{
    public static class ConversorHelper
    {
        public static TObjSaida Mapear<TObjEntrada, TObjSaida>(TObjEntrada obj)
        {
            return Mapper.Map<TObjEntrada, TObjSaida>(obj);
        }
    }
}