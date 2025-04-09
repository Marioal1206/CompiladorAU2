using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Compilador
{
    public partial class Form1 : Form
    {
        List<string[]> listERRORES = new List<string[]>();


        public Form1()
        {
            InitializeComponent();
            dtgDefiniciones.Columns.Add("Linea", "Linea");
            dtgDefiniciones.Columns.Add("Definicion", "Definicion");
            // No permitir agregar ni eliminar renglones
            dtgDefiniciones.AllowUserToAddRows = false;
            dtgDefiniciones.AllowUserToDeleteRows = false;
            // Autoajustar el ancho de las columnas
            dtgDefiniciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Seleccionar un renglón completo al hacer click
            dtgDefiniciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDefiniciones.MultiSelect = false;
            // Modo de solo lectura
            dtgDefiniciones.ReadOnly = true;

            dtgTablaSintactica.Columns.Add("Linea", "Linea");
            dtgTablaSintactica.Columns.Add("Mensaje", "Mensaje");
            // No permitir agregar ni eliminar renglones
            dtgTablaSintactica.AllowUserToAddRows = false;
            dtgTablaSintactica.AllowUserToDeleteRows = false;
            // Autoajustar el ancho de las columnas
            dtgTablaSintactica.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Seleccionar un renglón completo al hacer click
            dtgTablaSintactica.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgTablaSintactica.MultiSelect = false;
            // Modo de solo lectura
            dtgTablaSintactica.ReadOnly = true;

            dtgTablaSematica.Columns.Add("Linea", "Linea");
            dtgTablaSematica.Columns.Add("Mensaje", "Mensaje");
            // No permitir agregar ni eliminar renglones
            dtgTablaSematica.AllowUserToAddRows = false;
            dtgTablaSematica.AllowUserToDeleteRows = false;
            // Autoajustar el ancho de las columnas
            dtgTablaSintactica.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Seleccionar un renglón completo al hacer click
            dtgTablaSematica.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgTablaSematica.MultiSelect = false;
            // Modo de solo lectura
            dtgTablaSematica.ReadOnly = true;


            dtgSimbolos.Columns.Add("NUM", "NUM");
            dtgSimbolos.Columns.Add("NOMBRE", "NOMBRE");
            dtgSimbolos.Columns.Add("TIPO", "TIPO");
            dtgSimbolos.Columns.Add("DATO", "DATO");
            // No permitir agregar ni eliminar renglones
            dtgSimbolos.AllowUserToAddRows = false;
            dtgSimbolos.AllowUserToDeleteRows = false;
            // Autoajustar el ancho de las columnas
            dtgSimbolos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Seleccionar un renglón completo al hacer click
            dtgSimbolos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgSimbolos.MultiSelect = false;
            // Modo de solo lectura
            dtgSimbolos.ReadOnly = true;


            dtgErrores.Columns.Add("LINEA", "LINEA");
            dtgErrores.Columns.Add("ERROR", "ERROR");
            // No permitir agregar ni eliminar renglones
            dtgErrores.AllowUserToAddRows = false;
            dtgErrores.AllowUserToDeleteRows = false;
            // Autoajustar el ancho de las columnas
            dtgErrores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Seleccionar un renglón completo al hacer click
            dtgErrores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgErrores.MultiSelect = false;
            // Modo de solo lectura
            dtgErrores.ReadOnly = true;
            txtNumLinea.Text = "00 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40";
            txtNumLinea.Enabled = false;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            listERRORES.Add(new string[] { "ERROR IDVAL", "error de identificador valido: Recuerda que no acepta letras minusculas  y la primera letra tiene que ser MAYUSCULA " });
            listERRORES.Add(new string[] { "ERROR OPARI", "error de operador aritmetico: Recuerda que todos los oeradores deben de ester separdos EJEMPLO(NUMERO + 1) , Los operadores aritmeticos que manejamos son (+,-,/* )  " });
            listERRORES.Add(new string[] { "ERROR OPLOG", "error de operador logico: Recuerda que todos los oeradores deben de ester separdos EJEMPLO(NUMERO > 1), Los operadores aritmeticos que manejamos son (>,<,>=,==,<=) " });
            listERRORES.Add(new string[] { "ERROR OPREL", "error de operador relacional: EJEMPLO: === NOTAS: SE AGREGO UN CARACTER LO QUE PROVOCA EL ERROR " });
            listERRORES.Add(new string[] { "ERROR OPASI", "error de operador de asignacion: EJEMPLO:~@ NOTA: UN SIMBOLO DE CUALQUIER TIPO LEUGO DEL OPERADOR DE ASIGNACION" });
            listERRORES.Add(new string[] { "ERROR CONUM", "error de constante numerica EJEMPLO: 25E, 25.3R@ NOTAS: LA INTERVENCION DE CUALQUIER LETRA DENTRO DE LA CONSTANTE NUMERICA EXERCE EL ERROR" });
            listERRORES.Add(new string[] { "ERROR CDN", "error de cadena: EJEMPLO: PEPE PICA PAPAS NOTAS: NO SE PUEDE PONER ESPACIO POR MAS QUE QUE SE DEBE" });
            listERRORES.Add(new string[] { "ERROR CARESP", "error de caracter especial : EJEMPLO: CINC%O NOTAS: SOLO SE PUEDEN USAR EN COMENTARIOS Y EN CADENAS " });
            listERRORES.Add(new string[] { "ERROR COMEN", "error de comentario:EJEMPLO: %%ROBERTO QUIERE UN PALO CIRCULAR NOTA: CUALQUIER ESPACIO DENTRO DE COMENTARIOS LO MANDA A UN ERROR" });
            listERRORES.Add(new string[] { "ERROR DELERR", "error de delimitador: EJEMPLO:(+ NOTAS: CUALQUIER CARACTER DESPUES DEL DELIMITADOR" });



            string strContenido = txtCodigo.Text;
            Matriz miMatriz = new Matriz();//creamos un objeto de tipo Matriz
            int intEncrementoID = 1;
            List<string> listaVAR = new List<string>();
            dtgSimbolos.Rows.Clear();//Borramos la tabla de Identificadores validos
            dtgDefiniciones.Rows.Clear();//Borramos la tabla de tokens 
            dtgErrores.Rows.Clear();//Borramos la tabla de errores
            List<string[]> matrizVAR = new List<string[]>();
            List<Simbolo> listaSimbolosObj = new List<Simbolo>();


            List<string> listaSimbolos = new List<string>();// cremaos una lista que contenga los tokens pot linea 

            string[] arreglolineas = txtCodigo.Lines;// este arreglo almacena el contenido de cada linea de texto

            //foreach (string Linea in arreglolineas)
            //{
            //MessageBox.Show(Linea);
            //}

            for (int i = 0; i < arreglolineas.Length; i++)// recorremos linea por linea
            {
                bool Bandera = false;
                bool Bandera2 = false;
                /*almacenamos en la lista de definiciones todos los tokens de la linea i*/
                List<string> listaDefiniciones = miMatriz.Recorrido(arreglolineas[i]);
                //almacenamos cada palabra de la linea en el arreglo arregloPalabrasLinea
                string[] arregloPalabrasLinea = miMatriz.CadenaALista(arreglolineas[i]);

                for (int j = 0; j < listaDefiniciones.Count; j++)//recorremos la lista de tokens
                {
                    if (listaDefiniciones[j] == "VAR")//si es un identificador valido
                    {
                        if (matrizVAR == null)
                        {
                            matrizVAR.Add(new string[] { arregloPalabrasLinea[j], listaDefiniciones[j] + intEncrementoID.ToString() });
                            listaDefiniciones[j] = listaDefiniciones[j] + intEncrementoID.ToString();

                            intEncrementoID++;
                        }
                        else
                        {
                            string palabra = arregloPalabrasLinea[j];
                            foreach (var fila in matrizVAR)
                            {
                                if (palabra == fila[0])
                                {
                                    listaDefiniciones[j] = fila[1];
                                    Bandera2 = true;
                                }
                            }
                            if (Bandera2 == false)
                            {
                                matrizVAR.Add(new string[] { arregloPalabrasLinea[j], listaDefiniciones[j] + intEncrementoID.ToString() });
                                listaDefiniciones[j] = listaDefiniciones[j] + intEncrementoID.ToString();
                                intEncrementoID++;
                            }


                        }

                        if (listaSimbolosObj == null)
                        {
                            Simbolo miSimbolo = new Simbolo();
                            miSimbolo.intID = intEncrementoID;
                            miSimbolo.strNombre = arregloPalabrasLinea[j].ToString();

                            if (!(j + 2 >= arregloPalabrasLinea.Length))
                            {
                                if (listaDefiniciones[j + 1] == "OPASG")
                                    miSimbolo.strValor = arregloPalabrasLinea[j + 2];
                                switch (listaDefiniciones[j + 2])
                                {
                                    case "CAD":
                                        miSimbolo.strTipoValor = "string";
                                        break;
                                    case "CNUM":
                                        miSimbolo.strTipoValor = "int";
                                        break;
                                    case "CNUMD":
                                        miSimbolo.strTipoValor = "float";
                                        break;
                                }


                            }
                            listaSimbolosObj.Add(miSimbolo);
                            //intEncrementoID++;



                        }
                        else
                        {
                            string palabra = arregloPalabrasLinea[j];
                            for (int t = 0; t < listaSimbolosObj.Count; t++)//recorremos la lista de simbolos en busca de que no se repita 
                            {
                                if (palabra == listaSimbolosObj[t].strNombre)
                                {
                                    //listaSimbolos.Add("REPETICION " + t.ToString());//agregamos a la lista la posision de la palabra que se repitio

                                    Bandera = true;
                                    break;
                                }
                            }
                            if (Bandera == false)
                            {
                                Simbolo miSimbolo = new Simbolo();
                                miSimbolo.intID = intEncrementoID;
                                miSimbolo.strNombre = arregloPalabrasLinea[j].ToString();

                                if (!(j + 2 >= arregloPalabrasLinea.Length))
                                {
                                    if (listaDefiniciones[j + 1] == "OPASG")
                                        miSimbolo.strValor = arregloPalabrasLinea[j + 2];
                                    switch (listaDefiniciones[j + 2])
                                    {
                                        case "CAD":
                                            miSimbolo.strTipoValor = "cadena";
                                            break;
                                        case "CNUM":
                                            miSimbolo.strTipoValor = "entero";
                                            break;
                                        case "CNUMD":
                                            miSimbolo.strTipoValor = "decimal";
                                            break;
                                    }


                                }
                                listaSimbolosObj.Add(miSimbolo);
                                //intEncrementoID++;

                            }

                        }



                        if (listaSimbolos == null)//checamos que la lista este vacia
                        {
                            //agregamos la la palabra que conincida con la pocicion del token de identificador valido a la lista de simbolos 
                            listaSimbolos.Add(arregloPalabrasLinea[j]);
                            //listaDefiniciones[j] = listaDefiniciones[j]=intEncrementoID.ToString();
                            //intEncrementoID++;


                        }
                        else
                        {
                            string palabra = arregloPalabrasLinea[j];
                            for (int t = 0; t < listaSimbolos.Count; t++)//recorremos la lista de simbolos en busca de que no se repita 
                            {
                                if (palabra == listaSimbolos[t])
                                {
                                    //listaSimbolos.Add("REPETICION " + t.ToString());//agregamos a la lista la posision de la palabra que se repitio

                                    Bandera = true;
                                    break;
                                }
                            }
                            if (Bandera == false)
                            {
                                listaSimbolos.Add(palabra);// si no se repitio agregamos la palabra 

                            }
                        }
                        //dtgSimbolos.Rows.Add(i, arregloPalabrasLinea[j]);
                    }
                    if (listaDefiniciones[j].StartsWith("ERROR"))//aqui buscamos los errores de la lista de tokens
                    {
                        dtgErrores.Rows.Add(i, listaDefiniciones[j]);//agregamos el error a la tabla de errores 


                    }
                }

                string strDefinicionRenglon = "";//variable donde almacenamos los tokens por linea 
                foreach (string Palabra in listaDefiniciones)// juntamos los tokes de la linea en una cadena de texto
                {
                    strDefinicionRenglon = strDefinicionRenglon + Palabra + " ";
                }
                dtgDefiniciones.Rows.Add(i, strDefinicionRenglon);//agregamos la cadena de texto a la tabla 

            }
            int Contador = 1;//variable del contador
            foreach (Simbolo miSimbolo in listaSimbolosObj)//recorremos la lista de simbolos para imprimir en la tabla de simbolos 
            {
                dtgSimbolos.Rows.Add(Contador, miSimbolo.strNombre, miSimbolo.strTipoValor, miSimbolo.strValor);
                Contador++;
            }





            string strContenedor = "";
            foreach (DataGridViewRow fila in dtgErrores.Rows)
            {
                string strError = fila.Cells["ERROR"].Value!.ToString();

                foreach (var error in listERRORES)
                {
                    if (strError == error[0])
                    {
                        strContenedor = "Tiene un ERROR en la linea " + fila.Cells["Linea"].Value!.ToString() + " " + error[1] + " ";
                    }
                }
            }

            txtinfo.Text = strContenedor;



            /*List<string> listaDefiniciones = miMatriz.Recorrido("caso == 20");

            foreach(string palabra in listaDefiniciones)
            {
                MessageBox.Show(palabra);
            }*/



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDescargar_Click(object sender, EventArgs e)
        {
            List<string> listaTokens = new List<string>();
            string strContenidoLinea = "";


            foreach (DataGridViewRow fila in dtgDefiniciones.Rows)
            {
                if (!fila.IsNewRow)
                {
                    strContenidoLinea = fila.Cells["Linea"].Value!.ToString() + " " + fila.Cells["Definicion"].Value!.ToString();
                    listaTokens.Add(strContenidoLinea);

                }
            }

            string strRutaArchivo = "Tokens.txt";

            using (StreamWriter escribirTexto = new StreamWriter(strRutaArchivo))
            {
                foreach (string linea in listaTokens)
                {
                    escribirTexto.WriteLine(linea);
                }
            }

            List<string> listaTokens2 = new List<string>();
            string strContenidoLinea2 = "";


            foreach (DataGridViewRow fila in dtgDefiniciones.Rows)
            {
                if (!fila.IsNewRow)
                {
                    strContenidoLinea2 = fila.Cells["Definicion"].Value!.ToString();
                    listaTokens2.Add(strContenidoLinea2);

                }
            }

            string strRutaArchivo2 = "TokensTipo.txt";

            using (StreamWriter escribirTexto2 = new StreamWriter(strRutaArchivo2))
            {
                foreach (string linea in listaTokens2)
                {
                    escribirTexto2.WriteLine(linea);
                }
            }




        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Crear un cuadro de diálogo para guardar archivos
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt",
                Title = "Guardar archivo de texto"
            };

            // Mostrar el diálogo al usuario
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Obtener la ruta seleccionada
                    string rutaArchivo = saveFileDialog.FileName;

                    // Guardar el contenido en el archivo
                    File.WriteAllText(rutaArchivo, txtCodigo.Text);

                    // Mostrar un mensaje de éxito
                    MessageBox.Show("Archivo guardado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error si algo sale mal
                    MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt",
                Title = "Abrir archivo de texto"
            };

            // Mostrar el cuadro de diálogo al usuario
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Leer el contenido del archivo
                    string contenidoArchivo = File.ReadAllText(openFileDialog.FileName);

                    // Mostrar el contenido en el TextBox
                    txtCodigo.Text = contenidoArchivo;

                    // Mostrar un mensaje de éxito
                    MessageBox.Show("Archivo abierto con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error si algo sale mal
                    MessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLeerArchivoTokens_Click(object sender, EventArgs e)
        {
            //========================[ GRAMATICA ]================================================
            LecturaArchivoTokensGramatica();

            //========================[ SEMANTICA ]================================================
            LecturaArchivoTokensSemantica();









        }

        private void LecturaArchivoTokensGramatica()
        {
            string inputFilePath = "Tokens.txt"; // Ruta del archivo de entrada

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("El archivo no existe: " + inputFilePath);
                return;
            }
            dtgTablaSintactica.Rows.Clear();
            // Leer el archivo y procesar las líneas
            var lines = File.ReadAllLines(inputFilePath);
            var tokenList = new List<string>();
            int linea = 0;
            foreach (var line in lines)
            {
                string processedLine = ProcessLine(line);
                //MessageBox.Show(processedLine);
                if (!string.IsNullOrWhiteSpace(processedLine))
                {
                    // Dividir las palabras en la línea procesada y agregarlas a la lista
                    tokenList = new List<string>(processedLine.Split(' ', StringSplitOptions.RemoveEmptyEntries));




                }

                Gramatica miGramatica = new Gramatica(tokenList, ConversorTXT_Matriz("Gramatica.txt"));
                //List<List<string>> mPrueba = ConversorTXT_Matriz();
                //MessageBox.Show(mPrueba[0][3]);
                string strMensaje = miGramatica.ManejadorRespuesta();
                //MessageBox.Show(linea.ToString() + strMensaje);
                //tokenList = null;
                dtgTablaSintactica.Rows.Add(linea, strMensaje);
                linea++;
            }

        }

        private void LecturaArchivoTokensSemantica()
        {
            string inputFilePath = "TokensTipo.txt"; // Ruta del archivo de entrada

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("El archivo no existe: " + inputFilePath);
                return;
            }

            dtgTablaSematica.Rows.Clear();
            // Leer el archivo y procesar las líneas
            var lines = File.ReadAllLines(inputFilePath);
            var tokenList = new List<string>();
            int linea = 0;
            foreach (var line in lines)
            {
                string processedLine = ProcessLineSemantico(line);
                //MessageBox.Show(processedLine);
                if (!string.IsNullOrWhiteSpace(processedLine))
                {
                    // Dividir las palabras en la línea procesada y agregarlas a la lista
                    tokenList = new List<string>(processedLine.Split(' ', StringSplitOptions.RemoveEmptyEntries));




                }

                if (tokenList[0] != "S") {
                    if (tokenList[0].Substring(0, 2) != "VA")
                    {
                        Gramatica miGramatica = new Gramatica(tokenList, ConversorTXT_Matriz("Semantica.txt"));
                        //List<List<string>> mPrueba = ConversorTXT_Matriz();
                        //MessageBox.Show(mPrueba[0][3]);
                        string strMensaje = miGramatica.ManejadorRespuesta();
                        //MessageBox.Show(linea.ToString() + strMensaje);
                        //tokenList = null;
                        dtgTablaSematica.Rows.Add(linea, strMensaje);
                        linea++;


                    }
                    else {
                        dtgTablaSematica.Rows.Add(linea, "Sintaxis Correcta");
                        linea++;

                    }

                }
                
                
                
               
            }

        }

        private static List<List<string>> ConversorTXT_Matriz(string strNombreArchivo)
        {
            string filePath = strNombreArchivo; // Ruta del archivo de texto
            List<List<string>> listaDeListas = new List<List<string>>();

            // Leer cada línea del archivo
            foreach (var line in File.ReadLines(filePath))
            {
                // Dividir la línea en elementos usando un separador (ejemplo: ',')
                List<string> elementos = new List<string>(line.Split(" "));
                listaDeListas.Add(elementos);
            }

            // Imprimir la lista de listas
            //foreach (var lista in listaDeListas)
            //{
            //Console.WriteLine(string.Join(" | ", lista));
            //}
            return listaDeListas;


        }

        private static string ProcessLine(string line)
        {
            // Eliminar el número inicial del renglón (si existe)
            string noNumberPrefix = Regex.Replace(line, "^\\d+\\s*", "");

            // Eliminar números al final de las palabras VAR (ejemplo: VAR1 -> VAR)
            string processedLine = Regex.Replace(noNumberPrefix, "\\bVAR\\d+\\b", "VAR");

            return processedLine.Trim();
        }

        static List<string[]> ParseTokens(string[] lines)
        {
            var tokens = new List<string[]>();
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    tokens.Add(line.Split(' '));
                }
            }
            return tokens;
        }
        private static string ProcessLineSemantico(string line)
        {
            // Eliminar el número inicial del renglón (si existe)
            string noNumberPrefix = Regex.Replace(line, "^\\d+\\s*", "");

            // Eliminar números al final de las palabras VAR (ejemplo: VAR1 -> VAR)
            // string processedLine = Regex.Replace(noNumberPrefix, "\\bVAR\\d+\\b", "VAR");

            return noNumberPrefix.Trim();
        }

        static List<string[]> ParseTokensSemantico(string[] lines)
        {
            var tokens = new List<string[]>();
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    tokens.Add(line.Split(' '));
                }
            }
            return tokens;
        }

        private void btnDescargarListaSimbolos_Click(object sender, EventArgs e)
        {
            List<string> listaSimbolos = new List<string>();
            string strContenidoLinea = "";


            foreach (DataGridViewRow fila in dtgSimbolos.Rows)
            {
                if (!fila.IsNewRow)
                {
                    strContenidoLinea = fila.Cells["NUM"].Value!.ToString() + " " + fila.Cells["NOMBRE"].Value!.ToString();
                    listaSimbolos.Add(strContenidoLinea);

                }
            }

            string strRutaArchivo = "Simbolos.txt";

            using (StreamWriter escribirTexto = new StreamWriter(strRutaArchivo))
            {
                foreach (string linea in listaSimbolos)
                {
                    escribirTexto.WriteLine(linea);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }

    class SyntaxAnalyzer
    {
        // Definir reglas de gramática
        private Dictionary<string, string> grammar = new Dictionary<string, string>
        {
            {"VAR", "Identificador válido"},
            {"OPASG", "Operador de asignación"},
            {"CNUM", "Constante numérica"},
            {"DEL1", "Delimitador inicial de bloque"},
            {"DEL2", "Delimitador final de bloque"},
            {"OPAS", "Operador aritmético"},
            {"OPR", "Operador relacional"},
        };

        public void Analyze(string[] tokens)
        {
            Stack<string> expectedTokens = new Stack<string>();

            // Simular análisis top-down
            foreach (var token in tokens)
            {
                if (grammar.ContainsKey(token))
                {
                    MessageBox.Show($"Token válido: {token} ({grammar[token]})");
                }
                else
                {
                    MessageBox.Show($"Token no reconocido: {token}");
                    expectedTokens.Push(token);
                }
            }

            // Verificar tokens faltantes
            if (expectedTokens.Count > 0)
            {
                MessageBox.Show("Tokens faltantes o incorrectos para completar la condición:");
                while (expectedTokens.Count > 0)
                {
                    MessageBox.Show(expectedTokens.Pop());
                }
            }
        }
    }
}
