using System;
using System.Collections.Generic;
using System.Text;
using TablasDeVerdad.elementos;

namespace TablasDeVerdad.logica
{
    class ControlOperaciones
    {

        private Stack<string> operaciones;
        private Operacion operacionPrincipal;

        public bool ActualEsNegacion 
        {
            get 
            {
                if (operaciones.Count != 0 && operaciones.Peek().StartsWith(Logica.NEGACION.ToString()))
                {
                    return true;
                }
                else return false;
            } 
        }

        public ControlOperaciones(Operacion operacion)
        {
            operacionPrincipal = operacion;
            operaciones = new Stack<string>();
        }
        
        public void AgregarElemento(string cadena)
        {
            operaciones.Push(cadena);
        }

        // Calcula la sub-operacion actual en el stack de operaciones.
        // Añade/concatena el resultado, con un nuevo identificador, al elemento anterios del stack.
        // Se debe agregar tambien el resultado a las proposiciones y que se pueda localizar con el identificador.
        public Proposicion OperarActual()
        {
            Proposicion resultado = Logica.Operar(operaciones.Pop(), operacionPrincipal.Proposiciones);

            // Si el resultado llega como null significa que la operacion solo contenia una proposicion unicamente.
            // Ejemplo: "A", "B", "12"
            if (resultado.Values != null)
            {
                if(operaciones.Count != 0)
                {
                    string nuevoIdentificador = operacionPrincipal.Proposiciones.Count.ToString();

                    resultado.Identificador = nuevoIdentificador;

                    Añadir(nuevoIdentificador);

                    operacionPrincipal.Proposiciones.Add(resultado);
                }
            }
            else
            {
                resultado.Values = Operacion.GetValoresProposicion(operacionPrincipal.Proposiciones, resultado.name);

                if (operaciones.Count != 0)
                {
                    Añadir(resultado.name);
                }     
            }

            return resultado;
        }

        public void Añadir(string cadena)
        {
            string save = operaciones.Pop();
            operaciones.Push(save + cadena);
        }

    }
}
