using System.Collections.Generic;

namespace Demo.Dominio
{
    public class Representante : Participante
    {
        public int PercentualDeComissao { get; set; }

        public IList<Cliente> Clientes { get; set; }
    }
}