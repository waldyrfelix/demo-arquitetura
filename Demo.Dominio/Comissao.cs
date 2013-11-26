namespace Demo.Dominio
{
    public class Comissao : Identificador
    {
        public Representante Representante { get; set; }

        public decimal Valor { get; set; }

        public decimal ValorDaVenda { get; set; }

        public int PercentualDaComissao { get; set; }
    }
}