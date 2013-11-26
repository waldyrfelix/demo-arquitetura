using AutoMapper;
using DemoMVC.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Useall.UI.Testes
{
    [TestClass]
    public class TesteDosMapementosDoAutomapper
    {
        [TestMethod]
        public void Verifica_Se_Configuração_Do_AutoMapper_Está_Correta()
        {
            ConfiguraçãoAutoMapper.Inicializar();
            Mapper.AssertConfigurationIsValid();
        }
    }
}