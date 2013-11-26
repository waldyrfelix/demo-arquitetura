using System.Collections.Generic;

namespace Demo.Dominio
{
    public class Cliente : Participante
    {
        public decimal LimiteDeCredito { get; set; }

        public IList<Representante> Representantes { get; set; }
    }
}