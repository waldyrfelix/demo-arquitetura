namespace Demo.Dominio
{
    public class ItemDaVenda : Identificador
    {
        public Produto Produto { get; set; }

        public decimal Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal PercentualIPI { get; set; }

        public decimal ValorDoIPI { get; set; }

        public Representante Representante { get; set; }

        public string Descricao { get; set; }

        public decimal ValorDoICMS { get; set; }

        public decimal BaseDeCalculoDoICMS { get; set; }

        public decimal PercentualDoICMS { get; set; }
    }
}