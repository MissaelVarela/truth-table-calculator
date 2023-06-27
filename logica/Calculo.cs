using System;

namespace TablasDeVerdad.logica
{
    class Calculo
    {
        public Calculo() { }

        // Calcula una operacion logica introducida mediante una cadena de texto.
        // Retorna un objeto tipo Operacion.
        public static Operacion Calcular(string entrada)
        {
            Operacion operacion = new Operacion(entrada);
            ControlOperaciones operaciones = new ControlOperaciones(operacion);

            if (operacion.VerificarSintaxis())
                operacion.Inicializar();
            else
                throw new Exception("Error de sintaxis en la operacion.");

            operaciones.AgregarElemento("");

            for (int i = 0; i < entrada.Length; i++)
            {

                if(operaciones.ActualEsNegacion)
                {
                    if(Logica.EsOperador(entrada[i]))
                    {
                        operaciones.OperarActual();
                    }
                }

                switch (entrada[i])
                {
                    case Logica.SEPARADORAPERTURA:
                        operaciones.AgregarElemento("");
                        break;

                    case Logica.SEPARADORCIERRE:
                        operaciones.OperarActual();
                        break;

                    case Logica.NEGACION:
                        operaciones.AgregarElemento(Logica.NEGACION.ToString());
                        break;

                    default:
                        operaciones.Añadir(entrada[i].ToString());
                        break;

                }

                if (operaciones.ActualEsNegacion)
                {
                    if (!(i + 1 < entrada.Length) || entrada[i + 1].Equals(Logica.SEPARADORCIERRE))
                    {
                        operaciones.OperarActual();
                    }
                }
            }

            operacion.SetResultado(operaciones.OperarActual());

            return operacion;  
        }
        
    }
}
