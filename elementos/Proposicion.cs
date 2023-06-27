using System;
using System.Collections.Generic;
using System.Text;

namespace TablasDeVerdad.elementos
{
    class Proposicion
    {
        public string name;
        public string Identificador { get; set; }
        public bool[] Values { get; set; }

        public Proposicion(string name)
        {
            this.name = name;
            Identificador = name;
        }

        public Proposicion GetProposicionNegada()
        {
            Proposicion copia = new Proposicion(name);

            copia.Identificador = Identificador;
            copia.Values = logica.Logica.Negar(Values);
            
            return copia;
        }



    }
}
