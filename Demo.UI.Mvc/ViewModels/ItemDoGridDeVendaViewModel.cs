using System;

namespace Demo.UI.Mvc.ViewModels
{
    public class ItemDoGridDeVendaViewModel
    {
        public decimal ValorTotal { get; set; }
        public string NomeDoCliente { get; set; }
        public DateTime DataDaEmissao { get; set; }
        public int NumeroDaNota { get; set; }
        public bool FoiImpressa { get; set; }
        public int QuantidadeDeItens { get; set; }
    }
}