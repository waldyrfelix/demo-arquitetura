using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Demo.UI.Mvc.ViewModels
{
    public class FiltroListarVendasViewModel
    {
        public FiltroListarVendasViewModel()
        {
            Vendas = new List<ItemDoGridDeVendaViewModel>();
        }

        [DisplayName("Data inicial")]
        public DateTime? DataInicial { get; set; }

        [DisplayName("Data final")]
        public DateTime? DataFinal { get; set; }

        [DisplayName("Código do cliente")]
        public int? IdDoCliente { get; set; }

        public IList<ItemDoGridDeVendaViewModel> Vendas { get; set; }
    }
}