using System.Collections.Generic;
using TablasDeVerdad.elementos;
using System;

namespace TablasDeVerdad.logica
{
    class Operacion
    {
        public string Text { set; get; }

        private List<Proposicion> proposiciones;
        public List<Proposicion> Proposiciones 
        { 
            set
            {
                proposiciones = value;
            }
            get
            {
                if (Invertir)
                {
                    List<Proposicion> temporal = new List<Proposicion>();

                    foreach (Proposicion proposicion in proposiciones)
                    {
                        temporal.Add(proposicion.GetProposicionNegada());
                    }

                    return temporal;
                }
                else
                {
                    return proposiciones;
                }
                
            }
        }
        public bool Invertir { set; get; }

        private Proposicion resultado;
        
        public Operacion(string operacion) 
        {
            Text = operacion;
            Invertir = false;
        }

        public void Inicializar()
        {
            List<Proposicion> proposiciones = new List<Proposicion>();
            string operacion = Text;

            //Inicializar columnas

            int columsCount = 0;

            for (int i = 0; i < operacion.Length; i++)
            {
                // Tenia antes ->  operacion[i] >= 'A' && operacion[i] <= 'Z' || operacion[i] >= 'a' && operacion[i] <= 'z'
                if (char.IsLetter(operacion[i]))
                {
                    columsCount++;
                    proposiciones.Add(new Proposicion(operacion[i].ToString()));
                    operacion = operacion.Replace(operacion[i], '#');
                }
            }

            //Inicializar filas

            int rowsCount = (int)(Math.Pow(2, columsCount));

            for (int i = 0; i < columsCount; i++)
            {
                bool valorInicial = false;

                int intervalo = rowsCount / ((int)(Math.Pow(2, i + 1)));
                proposiciones[i].Values = new bool[rowsCount];

                for (int j = 0; j < rowsCount; j++)
                {
                    proposiciones[i].Values[j] = valorInicial;
                    if ((j + 1) % intervalo == 0) valorInicial = !valorInicial;
                }
            }

            Proposiciones =  proposiciones;
        }
        internal void SetResultado(Proposicion result)
        {
            resultado = result;
            ArreglarNombres();
        }
        public Proposicion GetResultado()
        {
            if (resultado != null)
            {
                if (Invertir)
                {
                    return resultado.GetProposicionNegada();
                }
                else
                {
                    return resultado;
                }
            }   
            else
                throw new Exception("Aun no se ha calculado el resultado.");
        }

        //Va a verificar cada name de la lista de proposiciones.
        //Si encuentra un numero, va a remplazar ese numero por el name correcto 
        //(el numero hace referencia al index donde esta su verdadero nombre
        //(si el nombre referenciado contiene mas numero repetir recursivamente el proceso))
        //se agregra parentesis en los bordes del nombre nuevo y repmprazara el numero.
        //Se ejecutara al finalizar el calculo de una operacion automaticamente.
        private void ArreglarNombres()
        {
            foreach (Proposicion proposicion in proposiciones)
            {
                proposicion.name = CambiarIdentificadorPorName(proposicion.name);
            }

            resultado.name = Text;
        }
        private string CambiarIdentificadorPorName(string cadena)
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                if(char.IsNumber(cadena[i]))
                {
                    string numero = cadena[i].ToString();

                    //Solo puede detectar numeros de dos digitos porque es dificil que llegue a mas de 99 suboperaciones.
                    if(i + 1 < cadena.Length && char.IsNumber(cadena[i + 1]))
                    {
                        numero += cadena[i + 1];
                    }

                    string name = proposiciones[int.Parse(numero)].name;

                    cadena = cadena.Replace(numero, Logica.SEPARADORAPERTURA + name + Logica.SEPARADORCIERRE);

                    i--;
                }
            }

            return cadena;
        }
        public bool VerificarSintaxis()
        {
            return VerificarSintaxis(Text);
        }

        public static bool VerificarSintaxis(string text)
        {
            char estado = '1';
            bool esCorrecto = false;

            for (int i = 0; i < text.Length; i++)
            {

                esCorrecto = false;

                switch (estado)
                {
                    case '1':
                        if (text[i].Equals(Logica.NEGACION))
                        {
                            estado = '2';
                        }
                        else
                        if (char.IsLetter(text[i]))
                        {
                            estado = '3';
                            esCorrecto = true;
                        }
                        else
                        if (text[i].Equals(Logica.SEPARADORAPERTURA))
                        {
                            estado = '4';
                        }
                        else
                        {
                            return false;
                        }
                        break;

                    case '2':
                        if (char.IsLetter(text[i]))
                        {
                            estado = '3';
                            esCorrecto = true;
                        }
                        else
                        if (text[i].Equals(Logica.SEPARADORAPERTURA))
                        {
                            estado = '4';
                        }
                        else
                        {
                            return false;
                        }
                        break;

                    case '3':
                        if (Logica.EsOperador(text[i]))
                        {
                            estado = '1';
                        }
                        else
                        {
                            return false;
                        }
                        break;

                    case '4':
                        // (A+B)  ((A)+B)  (A+B  ((A+B)   ...  A+B)
                        int LengthSeparadorCierre = GetLengthSeparadorCierre(text.Substring(i));

                        if (LengthSeparadorCierre == -1)
                        {
                            return false;
                        }

                        string subOperacion = text.Substring(i, LengthSeparadorCierre);

                        if (VerificarSintaxis(subOperacion))
                        {
                            i += subOperacion.Length;
                            estado = '3';
                            esCorrecto = true;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
            }

            return esCorrecto;
        } 
        public static bool[] GetValoresProposicion(List<Proposicion> Proposiciones, string identificador)
        {
            foreach (var proposicion in Proposiciones)
            {
                if (proposicion.Identificador.Equals(identificador))
                    return proposicion.Values;
            }

            throw new Exception("No se encontro una proposicion con ese identificador.");
        }

        private static int GetLengthSeparadorCierre(string cadenaInicio)
        {// True: A+B)  (A)+B)  (A)+B)+C     False: A+B  (A+B)
            for (int i = 0; i < cadenaInicio.Length; i++)
            {
                if (cadenaInicio[i].Equals(Logica.SEPARADORAPERTURA))
                {
                    int j = GetLengthSeparadorCierre(cadenaInicio.Substring(i + 1));

                    if (j == -1)
                    {
                        return -1;
                    }
                    else
                    {
                        i += j + 1;
                    }
                }
                else
                if (cadenaInicio[i].Equals(Logica.SEPARADORCIERRE))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
