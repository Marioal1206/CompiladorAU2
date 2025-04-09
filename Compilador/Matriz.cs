using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    public class Matriz
    {
		
		private int _intEstado;

		public int intEstado
		{
			get { return _intEstado; }
			set { _intEstado = value; }
		}

       //Metodo donde recorremos la Matriz y nos  devuelve  una lista de definiciones o errores  
		public List<string> Recorrido(string strCadena)//strCadena es nuestra cadena de entrada 
		{
			this.intEstado = 1;//Guadamos el estado inicial
			string strEsradoAceptado;//Texto de los CAT
			string Mensaje;
			Conexion miConexion = new Conexion();// creamos la conexion a la base de datos 
			DataTable datMatriz = miConexion.Consulta();//cremos un objeto DataTable que es como una matriz con la consulta previa
            
            //Creamos una arreglo (listaPalabras) donde almacenamos las palabras de nuestra cadena de entrada
            string[] listaPalabras = CadenaALista(strCadena);
            
            //pasamos el arreglo a una lista para poder manipularlo mejor
            List<string> listaDefiniciones = new List<string>();

            if (datMatriz != null)//verificamos que la Matriz si tenga datos 
			{

				for (int t = 0; t < listaPalabras.Length; t++)//ciclo para posisionarnos en cada palabra de la lista : listaDefiniciones
                {
					strCadena = listaPalabras[t];//strCadena Almacena las palabras de la lista una por una

                    for (int i = 0; i < strCadena.Length; i++)//Ciclo para recorrer cada caracter de la palabra 
                    {
                        char chrCarecter = strCadena[i];//chrCaracter almacena el caracter de la palabra uno por uno 
                        
                        for (int j = 1; j < datMatriz.Columns.Count - 3; j++)// ciclo para recorrer principal mente la cabecera de la matriz
                        {

                            if (chrCarecter != ' ')// verificamos que el caracter no sea vacio osea FDC
                            {
                                int intCodigoASCII = int.Parse(datMatriz.Columns[j].ColumnName);//Almacenamos el nombre de la columna 
                                
                                char chrColumna = (char)intCodigoASCII;//almacenamos en la variable chrColumna el nombre ya traducido de la columna
                                //MessageBox.Show("Caracter :" + chrColumna);
                                if (chrCarecter == chrColumna)//coparamos que el caracter este dentro de la matriz
                                {
                                    intEstado = int.Parse(datMatriz.Rows[intEstado - 1][j].ToString());//actualizamos la variable del estado
                                }
                            }
                            else
                            {
                                int PosicionFDC = datMatriz.Columns.Count - 2;//almacenamos la posicion de la columna donde se encuentran los FDC
                                int PosicionCAT = datMatriz.Columns.Count - 1;//Almacenamos la Pocicion de la Columna donde se encuentran los CAT

                                //Aqui verificamoes que en el estado actual donde nos encontramos no sea un erro ademas verificamos qiue el estado si tenga un fin de cadena
                                if (( datMatriz.Rows[intEstado - 1][PosicionFDC].ToString() != "") && (datMatriz.Rows[intEstado - 1][PosicionFDC].ToString() != "ERROR") && (datMatriz.Rows[intEstado - 1][PosicionFDC].ToString() != "' '"))
                                {
                                    //almacenamos el estado donde esta la aceptacion 
                                    try
                                    {
                                        intEstado = int.Parse(datMatriz.Rows[intEstado - 1][PosicionFDC].ToString());
                                    }catch(Exception ex)
                                    {

                                    }
                                }
                                string strFDC = datMatriz.Rows[intEstado - 1][PosicionFDC].ToString(); //Almacenamo el contenido de FDC
                                if (strFDC == "Acepta")//si lo acepta...
                                {
                                    //almacenamos la definicion en la lista 
                                    listaDefiniciones.Add(datMatriz.Rows[intEstado - 1][PosicionCAT].ToString());
									intEstado = 1; //volvemos a inicializar la variable intEstado para la siguente palabra
									break; //Salimos del ciclo

                                }
                                else
                                {
                                    //si no lo acepta almacenamos el error
                                    listaDefiniciones.Add(strFDC + " " + datMatriz.Rows[intEstado - 1][PosicionCAT].ToString());
									intEstado = 1; //volvemos a inicializar la variable intEstado para la siguente palabra
                                    break;//Salimos del ciclo

                                }
                            }
                        }

                    }
                }
				
				
				return listaDefiniciones;//Devolvemos la lista
                
            }
			else 
			{
				listaDefiniciones.Add("ERROR: Matriz Vacia");
				return listaDefiniciones;
            }

			
		}

		//Metodo para pasar la cadena de entrada a un arreglo
		public string[] CadenaALista(string strmiCadena)
		{
            //Aqui detectamos los espacios en blanco de la cadena y los separamos en elementos individuales aguardandolos en el arreglo:listaIdentificadores
            string[] listaIdentificadores = strmiCadena.Split(" ", StringSplitOptions.RemoveEmptyEntries);
			
			//Aqui les agregamos un espacio en balnco a cada elemento del arreglo para indentificar el fin de cadena 
			for(int i = 0; i < listaIdentificadores.Length;i++)
			{
				listaIdentificadores[i] = listaIdentificadores[i] + " ";
			}
			return listaIdentificadores;//devolvemos la lista 	
		}

    }
}
