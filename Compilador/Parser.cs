using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    public class Parser
    {
        //public List<string> listaTokens;

        public List<string> ComprobarCadena(List<string> listaTokens)
        {
            // Definición de reglas gramaticales
            string[] COND = { "OPLOG", "OPREL" };
            string[] OPLOG = { "OPREL OLOG OPREL","DEL1 OPLOG DEL2", "OPLOG OPLOG", "COND OLOG COND" };
            String[] OPLOG1 = { "OPL3 OPREL", "OPL3 OPER" };
            string[] OPREL = { "OPAR OREL OPER", "OPER OREL OPAR", "OPAR OREL OPAR", "OPER OREL OPER", "DEL1 OPREL DEL2","OPER OLOG OPER"};
            string[] OPAR = { "OPAR OAR OPER", "OPER OAR PAR", "OPAR OAR OPAR", "OPER OAR OPER" };
            string[] OPER = { "CNUM", "VAR" };
            string[] OAR = { "OPAS", "OPAR", "OPAM", "OPAD", "OPAE" };
            string[] OLOG = { "OPL1", "OPL2" };
            string[] OREL = { "OPR1", "OPR2", "OPR3", "OR4", "OPR5", "OR6" };

            // Transformar tokens según las reglas gramaticales

            listaTokens = ReemplazarTokens(listaTokens, OREL, "OREL");
            //RecorrerLista(listaTokens);
            listaTokens = ReemplazarTokens(listaTokens, OLOG, "OLOG");
            //RecorrerLista(listaTokens);
            listaTokens = ReemplazarTokens(listaTokens, OAR, "OAR");
            //RecorrerLista(listaTokens);
            listaTokens = ReemplazarTokens(listaTokens, OPER, "OPER");
            //RecorrerLista(listaTokens);
            // Validar combinaciones gramaticales
            listaTokens = ValidarReglas(listaTokens, OPAR, "OPAR");
            //RecorrerLista(listaTokens);
            listaTokens = ValidarReglas(listaTokens, OPREL, "OPREL");
           // RecorrerLista(listaTokens);
            listaTokens = ValidarReglas(listaTokens, OPREL, "OPREL");
            //RecorrerLista(listaTokens);
            listaTokens = ValidarReglas(listaTokens, OPREL, "OPREL");
            //RecorrerLista(listaTokens);
            listaTokens = ValidarReglas(listaTokens, OPREL, "OPREL");
            //RecorrerLista(listaTokens);
            listaTokens = ValidarReglasOPLOG1(listaTokens, OPLOG1, "OPLOG");
            //RecorrerLista(listaTokens);
            listaTokens = ValidarReglas(listaTokens, OPLOG, "OPLOG");
            //RecorrerLista(listaTokens);
            listaTokens = ValidarReglas(listaTokens, OPLOG, "OPLOG");
            //RecorrerLista(listaTokens);
            listaTokens = ValidarReglasOPLOG1(listaTokens, OPLOG1, "OPLOG");
            //RecorrerLista(listaTokens);
            listaTokens = ValidarReglas(listaTokens, OPREL, "OPREL");
            //RecorrerLista(listaTokens);
            

            //listaTokens = ReemplazarTokens(listaTokens, COND, "COND");
            listaTokens = ReemplazarTokens(listaTokens, COND, "COND");
            
            listaTokens = ValidarReglas(listaTokens, OPLOG, "OPLOG");
            //RecorrerLista(listaTokens);

            listaTokens = ReemplazarTokens(listaTokens, COND, "COND");
            RecorrerLista(listaTokens);
            return listaTokens;
        }

        private List<string> ReemplazarTokens(List<string> tokens, string[] reglas, string nuevoToken)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                foreach (var regla in reglas)
                {
                    if (tokens[i] == regla)
                    {
                        tokens[i] = nuevoToken;
                        break;
                    }
                }
            }
            return tokens;
        }

        private List<string> ValidarReglas(List<string> tokens, string[] reglas, string nuevoToken)
        {
            for(int j = 0; j < 2; j++)
            {
                for (int i = 0; i <= tokens.Count - 3; i++)
                {
                    string secuencia = string.Join(" ", tokens.GetRange(i, 3));

                    foreach (var regla in reglas)
                    {
                        if (secuencia == regla)
                        {
                            tokens[i] = nuevoToken;

                            tokens.RemoveAt(i + 1);
                            tokens.RemoveAt(i + 1);
                            break;
                        }
                    }
                }
            }
            return tokens;
        }

        private List<string> ValidarReglasOPLOG1(List<string> tokens, string[] reglas, string nuevoToken)
        {
            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i <= tokens.Count - 2; i++)
                {
                    string secuencia = string.Join(" ", tokens.GetRange(i, 2));

                    foreach (var regla in reglas)
                    {
                        if (secuencia == regla)
                        {
                            tokens[i] = nuevoToken;

                            tokens.RemoveAt(i + 1);
                            
                            break;
                        }
                    }
                }
            }
            return tokens;
        }

        public void RecorrerLista(List<string> lista)
        {
            int contador = 0;
            foreach (string elemento in lista)
            {
                MessageBox.Show("Elemento " + contador + " ES " + elemento);
                contador++;
            }



        }
    }



    

    
    

    
}
