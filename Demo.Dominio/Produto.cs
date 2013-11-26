namespace Demo.Dominio
{
    public class Produto : Identificador
    {
        public int CodigoDeBarras { get; set; }

        public string Nome { get; set; }

        public decimal Preço { get; set; }
    }
}