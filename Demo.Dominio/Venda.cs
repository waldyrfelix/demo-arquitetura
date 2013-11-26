using System;
using System.Collections.Generic;

namespace Demo.Dominio
{
    public class Venda : Identificador
    {
        public Transportadora Transportadora { get; set; }

        public Transportadora Despachante { get; set; }

        public virtual Cliente Cliente { get; set; }

        public List<Comissao> Comissoes { get; set; }

        public List<ContaAReceber> ContasAReceber { get; set; }

        public int NumeroDaNota { get; set; }

        public virtual DateTime DataDaEmissao { get; set; }

        public virtual DateTime DataDaSaida { get; set; }

        public virtual decimal ValorTotal { get; set; }

        public virtual List<ItemDaVenda> ItensDaVenda { get; set; }

        public string Descricao { get; set; }

        public bool FoiImpressa { get; set; }

        public DateTime? DataDaImpressao { get; set; }

        public string ChaveDeAcessoNFE { get; set; }

        public virtual List<Comissao> GerarComissoes()
        {
            return null;
        }

        public virtual List<ContaAReceber> GerarContasAReceber()
        {
            return null;
        }
    }
}