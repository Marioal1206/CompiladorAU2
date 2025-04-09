using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    public class Semantica
    {
        public List<List<string>> matrizGramatica;
        public List<string> listaTokens;
        //Constructor de la Clase
        public Semantica(List<string> ListaTokens, List<List<string>> MatrizGramatica)
        {
            listaTokens = ListaTokens;
            matrizGramatica = MatrizGramatica;

        }

        //Metodo para verificar si la regla es igual a la lista de tokens
        bool CompararRegla(List<string> listaRegla, List<string> listaT)
        {
            for (int i = 0; i < listaRegla.Count; i++)
            {
                if (listaRegla[i] != listaT[i])
                {
                    return false;

                }


            }
            return true;

        }



        bool VerifivadorSintactico(int N)
        {
            for (int i = 0; i < matrizGramatica.Count; i++)
            {
                if (matrizGramatica[i].Count - 1 == N)
                {
                    string strTipoRglea = matrizGramatica[i][0];
                    List<string> listaRegla = matrizGramatica[i].GetRange(1, N);
                    bool Bandera2 = true;
                    int incrementa = 0;
                    List<string> listaT;
                    do
                    {
                        listaT = listaTokens.GetRange(incrementa, N);
                        if (CompararRegla(listaRegla, listaT))
                        {
                            listaTokens.RemoveRange(incrementa, N);
                            listaTokens.Insert(incrementa, strTipoRglea);
                            return true;

                        }
                        else if (N != listaTokens.Count)
                        {
                            if (incrementa + N < listaTokens.Count)
                            {
                                incrementa++;

                            }
                            else
                            {
                                Bandera2 = false;

                            }

                        }
                        else if (N == listaTokens.Count)
                        {
                            Bandera2 = false;

                        }



                    } while (Bandera2);

                }

            }
            return false;
        }

        public string ManejadorRespuesta()
        {

            int N = listaTokens.Count;

            while (true)
            {
                if (VerifivadorSintactico(N))
                {
                    N = listaTokens.Count;
                }
                else
                {
                    N--;
                    if (N <= 0)
                    {
                        break;
                    }
                }

            }
            bool bandera = true;
            string TextoListaTokens = "";
            for (int i = 0; i < listaTokens.Count; i++)
            {
                if (listaTokens[i] != "S")
                {
                    TextoListaTokens += " " + listaTokens[i];
                    bandera = false;
                }
                else
                {

                    TextoListaTokens += " " + listaTokens[i];
                }

            }
            if (bandera)
            {

                return "Sintaxis Correcta";

            }
            else
            {
                return "Sintaxis INCORRECTA no se encontro uan regla para los siguientes Tokens:\n" + TextoListaTokens;


            }


        }

    }
}
