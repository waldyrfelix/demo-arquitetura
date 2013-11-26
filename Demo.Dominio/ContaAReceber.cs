using System;

namespace Demo.Dominio
{
    public class ContaAReceber : Identificador
    {
        public Cliente Cliente { get; set; }

        public string Numero { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataDeVencimento { get; set; }

        public DateTime DataDeEmissao { get; set; }
    }
}