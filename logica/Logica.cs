using System;
using System.Collections.Generic;
using TablasDeVerdad.elementos;

namespace TablasDeVerdad.logica
{
    class Logica
    {
        public const char SUMA = '+';
        public const char MULTIPLICACION = '*';
        public const char NEGACION = '!';

        public const char SEPARADORAPERTURA = '(';
        public const char SEPARADORCIERRE = ')';

        public Logica() { }

        //Opera una operacion logica sencilla (sin parentesis) en base a una lista de proposiciones ya definidas.
        //Retorna la proposicion resultado.
        public static Proposicion Operar(string operacion, List<Proposicion> proposiciones)
        {// A+B*(B+!C) --> !C !10 10+4  A+B*5.    B+2+12 A+(A)

            Proposicion resultado = new Proposicion(operacion);

            bool[] subresultado = null;

            bool[] vPrimera;
            bool[] vSegunda;

            string primera = "";
            string segunda = "";
            string temporal = "";

            char operador = 'N';

            for (int i = 0; i < operacion.Length; i++)
            {
                if (EsOperador(operacion[i]))
                {
                    if (primera.Equals(""))
                    {
                        primera = temporal;
                        temporal = "";
                    }
                    else
                    {
                        segunda = temporal;
                        temporal = "";
                    }
                }
                else
                {
                    temporal += operacion[i];
                }

                if (!primera.Equals("") && !segunda.Equals(""))
                {
                    // Si subresultado es null getVal... si no asignarlo.
                    vPrimera = subresultado ?? Operacion.GetValoresProposicion(proposiciones, primera);
                    vSegunda = Operacion.GetValoresProposicion(proposiciones, segunda);

                    subresultado = OperacionBasica(vPrimera, vSegunda, operador);

                    primera = "subR";
                    segunda = "";
                }

                if (EsOperador(operacion[i]))
                {
                    operador = operacion[i];
                }
            }

            if (primera.Equals(""))
            {
                if (temporal.StartsWith(NEGACION.ToString()))
                {
                    resultado.Values = Negar(Operacion.GetValoresProposicion(proposiciones, temporal.Substring(1)));
                    return resultado;
                }
                else
                {
                    //Solo hubo una proposicion
                    resultado.Values = null;
                    return resultado;
                }
            }

            vPrimera = subresultado ?? Operacion.GetValoresProposicion(proposiciones, primera);
            vSegunda = Operacion.GetValoresProposicion(proposiciones, temporal);

            resultado.Values = OperacionBasica(vPrimera, vSegunda, operador);

            return resultado;
        }

        private static bool[] OperacionBasica(bool[] primera, bool[] segunda, char operador)
        {
            bool[] resultado;

            switch (operador)
            {
                case SUMA:
                    resultado = Sumar(primera, segunda);
                    break;

                case MULTIPLICACION:
                    resultado = Multiplicar(primera, segunda);
                    break;

                default:
                    throw new Exception("No se encontro un operador predeterminado para la operacion.");
            }

            return resultado;
        }

        private static bool[] Sumar(bool[] primera, bool[] segunda)
        {
            bool[] resultado = new bool[primera.Length];

            for (int i = 0; i < primera.Length; i++)
            {
                resultado[i] = primera[i] || segunda[i];
            }

            return resultado;
        }
        private static bool[] Multiplicar(bool[] primera, bool[] segunda)
        {
            bool[] resultado = new bool[primera.Length];

            for (int i = 0; i < primera.Length; i++)
            {
                resultado[i] = primera[i] && segunda[i];
            }

            return resultado;
        }
        public static bool[] Negar(bool[] primera)
        {
            bool[] resultado = new bool[primera.Length];

            for (int i = 0; i < primera.Length; i++)
            {
                resultado[i] = !primera[i];
            }

            return resultado;
        }

        public static bool EsOperador(char caracter)
        {
            if (caracter.Equals(SUMA) || caracter.Equals(MULTIPLICACION))
            {
                return true;
            }   

            return false;
        }

    }
}
