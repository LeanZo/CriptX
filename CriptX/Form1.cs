using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriptX
{
    public partial class Form1 : Form
    {
        string CriptXPath { get; set; }
        string[] fileLines { get; set; }
        string filePath { get; set; }
        string fileFolder { get; set; }
        byte[] byteLines { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Selecione um arquivo";
            openFileDialog1.InitialDirectory = "C:\\";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName; //Pega o Path completo do arquivo
                textBox_Procurar.Text = filePath;
                fileFolder = Path.GetDirectoryName(filePath); //Pega a pasta do arquivo

                textBox_PalavraChave.Enabled = true;
                btn_Encriptar.Enabled = true;
                btn_Decriptar.Enabled = true;
                radioButton_Texto.Enabled = true;
                radioButton_Outro.Enabled = true;
                menuStrip1.Enabled = true;
                avançadoToolStripMenuItem.Enabled = true;
                checkBox_Remontar.Enabled = true;
                Int64 fileSizeInBytes = new FileInfo(filePath).Length;
                if (fileSizeInBytes > 5242880)
                {
                    MessageBox.Show("AVISO: O arquivo tem mais de 5MB.\nTentar encriptar/decriptar este arquivo pode levar tempo.");
                }
            }
        }

        static string[,] gerarCifra()
        {
            int i3 = 0;

            string[] letrasBasicas = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            string[,] cifraVigenere = new string[26, 26]; //[linha, coluna]

            for (int i = 0; i <= 25; i++)
            {

                for (int i2 = 0; i2 <= 25; i2++)
                {
                    if (i == 0)
                    {
                        cifraVigenere[i2, i] = letrasBasicas[i2];
                    } else
                    {
                        if ((i2 + i) > 25)
                        {
                            cifraVigenere[i2, i] = letrasBasicas[i3];
                            i3++;
                        } else { 
                        cifraVigenere[i2, i] = letrasBasicas[i2 + i];
                        }
                    
                    }
                }
                i3 = 0;
            }

            return cifraVigenere;
        }

        public string[,] gerarCifraNumerica()
        {
            int i3 = 0;

            string[] numerosBasicos = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

            string[,] cifraVigenereNumerica = new string[10, 10]; //[linha, coluna]

            for (int i = 0; i <= 9; i++)
            {

                for (int i2 = 0; i2 <= 9; i2++)
                {
                    if (i == 0)
                    {
                        cifraVigenereNumerica[i2, i] = numerosBasicos[i2];
                    }
                    else
                    {
                        if ((i2 + i) > 9)
                        {
                            cifraVigenereNumerica[i2, i] = numerosBasicos[i3];
                            i3++;
                        }
                        else
                        {
                            cifraVigenereNumerica[i2, i] = numerosBasicos[i2 + i];
                        }

                    }
                }
                i3 = 0;
            }

            /*---Gerar cifraNumerica---------------------------------------------
            CriptXPath = fileFolder + @"\" + "CifraNumerica.txt"; //Path do arquivo encriptado

            File.Create(CriptXPath).Close();

            int p = 0;

            foreach (string numero in cifraVigenereNumerica)
            {
                if (p > 9)
                {
                    File.AppendAllText(CriptXPath, Environment.NewLine);
                    p = 0;
                }
                File.AppendAllText(CriptXPath, numero);
                p++;
            }
            ------------------------------------------------------------------*/
                return cifraVigenereNumerica;
        }

        static string[] encriptar(string[] fileLines, string palavraChave)
        {
            string[,] cifraVigenere = gerarCifra();
            string[] letrasBasicas = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int colunaID = 666;
            int linhaID = 666;
            string fraseEncriptada = null;
            int palavraChaveIndex = 0;
            int fileLinesEncriptadoIndex = 0;
            string[] fileLinesEncriptado = new string[fileLines.Length];

            foreach (string linha in fileLines)
            {
                foreach (char letra in linha)
                {
                    foreach (string alfabeto in letrasBasicas)
                    {
                        if (Convert.ToString(letra).ToUpper() == alfabeto)
                        {
                            colunaID = Array.IndexOf(letrasBasicas, alfabeto.ToUpper());
                            if (palavraChaveIndex < palavraChave.Length)
                            {
                                linhaID = Array.IndexOf(letrasBasicas, Convert.ToString(palavraChave[palavraChaveIndex]));
                                palavraChaveIndex++;
                            } else
                            {
                                palavraChaveIndex = 0;
                                linhaID = Array.IndexOf(letrasBasicas, Convert.ToString(palavraChave[palavraChaveIndex]));
                                palavraChaveIndex++;
                            }
                            break;
                        }
                    }
                    if (colunaID != 666)
                    {
                        if (Char.IsUpper(letra))
                        {
                            fraseEncriptada = fraseEncriptada + cifraVigenere[linhaID, colunaID];
                        } else
                        {
                            fraseEncriptada = fraseEncriptada + cifraVigenere[linhaID, colunaID].ToLower();
                        }
                        colunaID = 666;
                    } else
                    {
                        fraseEncriptada = fraseEncriptada + letra;
                    }
                }
                fileLinesEncriptado[fileLinesEncriptadoIndex] = fraseEncriptada;
                fraseEncriptada = null;
                fileLinesEncriptadoIndex++;
            }


            return fileLinesEncriptado;
        }

        static string[] decriptar(string[] fileLines, string palavraChave)
        {
            string[,] cifraVigenere = gerarCifra();
            string[] letrasBasicas = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int colunaID = 666;
            int linhaID = 666;
            string fraseDecriptada = null;
            int palavraChaveIndex = 0;
            int fileLinesDecriptadoIndex = 0;
            string[] fileLinesDecriptado = new string[fileLines.Length];
            bool isLetra = false;

            foreach (string linha in fileLines)
            {
                foreach (char letra in linha)
                {
                    isLetra = false;
                    foreach (string alfabeto in letrasBasicas)
                    {
                        if (Convert.ToString(letra).ToUpper() == alfabeto)
                        {
                            isLetra = true;
                            break;
                        }
                    }

                    if (isLetra)
                    {
                        if (palavraChaveIndex < palavraChave.Length)
                        {
                        linhaID = Array.IndexOf(letrasBasicas, Convert.ToString(palavraChave[palavraChaveIndex]));
                        palavraChaveIndex++;
                        }
                        else
                        {
                        palavraChaveIndex = 0;
                        linhaID = Array.IndexOf(letrasBasicas, Convert.ToString(palavraChave[palavraChaveIndex]));
                        palavraChaveIndex++;
                        }

                        for (int i = 0; i <= 25; i++)
                        {
                            if (Convert.ToString(letra).ToUpper() == cifraVigenere[linhaID, i])
                            {
                                colunaID = i;
                                break;
                            }

                        }

                        if (Char.IsUpper(letra))
                        {
                            fraseDecriptada = fraseDecriptada + letrasBasicas[colunaID];
                        } else
                        {
                            fraseDecriptada = fraseDecriptada + letrasBasicas[colunaID].ToLower();
                        }
                    }
                    else
                    {
                        fraseDecriptada = fraseDecriptada + letra;
                    }
                }

                fileLinesDecriptado[fileLinesDecriptadoIndex] = fraseDecriptada;
                fraseDecriptada = null;
                fileLinesDecriptadoIndex++;
            }

            return fileLinesDecriptado;
        }

        public void byteCript(string palavraChave)//Implementar a cifra numerica
        {
            byteLines = File.ReadAllBytes(filePath);

            if(!checkBox_Remontar.Checked)
            {
                string[,] cifraVigenere = gerarCifraNumerica();
                string[] letrasBasicas = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                int colunaID = 666;
                int linhaID = 666;
                string fraseEncriptada = null;
                int palavraChaveIndex = 0;
                int fileLinesEncriptadoIndex = 0;
                string[] byteLinesString = Array.ConvertAll(byteLines, Convert.ToString);
                string[] fileLinesEncriptado = new string[byteLines.Length];

                foreach (string linha in byteLinesString)
                {
                    foreach (char letra in linha)
                    {
                        foreach (string alfabeto in letrasBasicas)
                        {
                            if (Convert.ToString(letra).ToUpper() == alfabeto)
                            {
                                colunaID = Array.IndexOf(letrasBasicas, alfabeto.ToUpper());
                                if (palavraChaveIndex < palavraChave.Length)
                                {
                                    linhaID = Array.IndexOf(letrasBasicas, Convert.ToString(palavraChave[palavraChaveIndex]));
                                    palavraChaveIndex++;
                                }
                                else
                                {
                                    palavraChaveIndex = 0;
                                    linhaID = Array.IndexOf(letrasBasicas, Convert.ToString(palavraChave[palavraChaveIndex]));
                                    palavraChaveIndex++;
                                }
                                break;
                            }
                        }
                        if (colunaID != 666)
                        {
                            if (Char.IsUpper(letra))
                            {
                                fraseEncriptada = fraseEncriptada + cifraVigenere[linhaID, colunaID];
                            }
                            else
                            {
                                fraseEncriptada = fraseEncriptada + cifraVigenere[linhaID, colunaID].ToLower();
                            }
                            colunaID = 666;
                        }
                        else
                        {
                            fraseEncriptada = fraseEncriptada + letra;
                        }
                    }
                    fileLinesEncriptado[fileLinesEncriptadoIndex] = fraseEncriptada;
                    fraseEncriptada = null;
                    fileLinesEncriptadoIndex++;
                }


                Array.Reverse(fileLinesEncriptado);

                //---------------------
                CriptXPath = fileFolder + @"\" + Path.GetFileNameWithoutExtension(filePath) + Path.GetExtension(filePath); //Path do arquivo encriptado
              //  CriptXPath = CriptXPath.Replace(" - Decriptado", "");
                File.WriteAllLines(CriptXPath, Array.ConvertAll(fileLinesEncriptado, Convert.ToString));
                //----------------------
            } else
            {
                string[,] cifraVigenere = gerarCifraNumerica();
                string[] letrasBasicas = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                int colunaID = 666;
                int linhaID = 666;
                string fraseDecriptada = null;
                int palavraChaveIndex = 0;
                int fileLinesDecriptadoIndex = 0;
                fileLines = File.ReadAllLines(filePath);
                string[] fileLinesDecriptado = new string[fileLines.Length];
                bool isLetra = false;
                Array.Reverse(fileLines);

                foreach (string linha in fileLines)
                {
                    foreach (char letra in linha)
                    {
                        isLetra = false;
                        foreach (string alfabeto in letrasBasicas)
                        {
                            if (Convert.ToString(letra).ToUpper() == alfabeto)
                            {
                                isLetra = true;
                                break;
                            }
                        }

                        if (isLetra)
                        {
                            if (palavraChaveIndex < palavraChave.Length)
                            {
                                linhaID = Array.IndexOf(letrasBasicas, Convert.ToString(palavraChave[palavraChaveIndex]));
                                palavraChaveIndex++;
                            }
                            else
                            {
                                palavraChaveIndex = 0;
                                linhaID = Array.IndexOf(letrasBasicas, Convert.ToString(palavraChave[palavraChaveIndex]));
                                palavraChaveIndex++;
                            }

                            for (int i = 0; i <= 9; i++)
                            {
                                if (Convert.ToString(letra).ToUpper() == cifraVigenere[linhaID, i])
                                {
                                    colunaID = i;
                                    break;
                                }

                            }

                            if (Char.IsUpper(letra))
                            {
                                fraseDecriptada = fraseDecriptada + letrasBasicas[colunaID];
                            }
                            else
                            {
                                fraseDecriptada = fraseDecriptada + letrasBasicas[colunaID].ToLower();
                            }
                        }
                        else
                        {
                            fraseDecriptada = fraseDecriptada + letra;
                        }
                    }

                    fileLinesDecriptado[fileLinesDecriptadoIndex] = fraseDecriptada;
                    fraseDecriptada = null;
                    fileLinesDecriptadoIndex++;
                }

                //---------------------

                CriptXPath = fileFolder + @"\" + Path.GetFileNameWithoutExtension(filePath) + Path.GetExtension(filePath); //Path do arquivo encriptado
               // CriptXPath = CriptXPath.Replace(" - Encriptado", " - Decriptado");
                File.WriteAllBytes(CriptXPath, Array.ConvertAll(fileLinesDecriptado, Convert.ToByte));
                //--------------------
            }
            MessageBox.Show("Concluído!");

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //gerarCifraNumerica();
            /*----CRIA A CIFRA DE VIGENERE----------------------------------
            File.Create(CriptXPath).Close();

            int i = 0;

            foreach (string letra in cifraVigenere)
            {
                if (i > 25)
                {
                    File.AppendAllText(CriptXPath, Environment.NewLine);
                    i = 0;
                }
                File.AppendAllText(CriptXPath, letra);
                i++;
            }
            -----------------------------------------------------------*/

            //fileLines = File.ReadAllLines(filePath); // Le o arquivo e salva numa array

            CriptXPath = fileFolder + @"\" + Path.GetFileNameWithoutExtension(filePath) + Path.GetExtension(filePath); //Path do arquivo encriptado
           // CriptXPath = CriptXPath.Replace(" - Decriptado", "");
            if (!encriptarTextoToolStripMenuItem.Checked)
            {
                try {
                    byteLines = File.ReadAllBytes(filePath);
                    string palavraChave = textBox_PalavraChave.Text.ToUpper();

                    try
                    {
                        Convert.ToInt32(palavraChave);
                    }catch(System.FormatException)
                    {
                        throw new ArgumentException();
                    }

                    if (String.IsNullOrEmpty(palavraChave) || String.IsNullOrWhiteSpace(palavraChave))
                    {
                        throw new ArgumentNullException("palavraChave", "Senha Vazia");
                    }
                    byteCript(palavraChave);
                }
                catch (System.OutOfMemoryException)
                {
                    MessageBox.Show("ERRO: Arquivo muito grande. Sistema sem memória.");
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("ERRO: Arquivo não encontrado.");
                }
                catch (IOException)
                {
                    MessageBox.Show("ERRO: O Arquivo possui mais de 2GB.");
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("ERRO: Insira uma Senha.");
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("ERRO: A Senha deve ser composta apenas de números.");
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("ERRO: Não é possivel decriptar um arquivo já decriptado.");
                }
                catch (System.OverflowException)
                {
                    MessageBox.Show("ERRO: Senha incorreta.");
                }
              //  catch (Exception)
              //  {
              //      MessageBox.Show("ERRO: A Senha deve ser composta apenas de números.");
               // }
            }
            else
            {
                try {
                    string palavraChave = textBox_PalavraChave.Text.ToUpper();

                    if (String.IsNullOrEmpty(palavraChave) || String.IsNullOrWhiteSpace(palavraChave))
                    {
                        throw new ArgumentNullException("palavraChave", "Palavra-Chave Vazia");
                    }

                    fileLines = File.ReadAllLines(filePath, Encoding.GetEncoding("iso-8859-1"));// Le o arquivo e salva numa array, porem usando um encoding que possibilita ler caracteres especiais

                    string[] fileLinesEncriptado = encriptar(fileLines, palavraChave);

                    File.Create(CriptXPath).Close();//Cria o arquivo Encriptado

                    File.WriteAllLines(CriptXPath, fileLinesEncriptado, Encoding.GetEncoding("iso-8859-1")); //Escreve no arquivo Encriptado

                    MessageBox.Show("Concluído!");
                } catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("ERRO: Arquivo não encontrado.");
                } catch (ArgumentNullException)
                {
                    MessageBox.Show("ERRO: Insira uma Palavra-Chave.");
                } catch (Exception)
                {
                    MessageBox.Show("ERRO: Palavra-Chave deve ser composta apenas de letras.");
                }
            }            
        }

        private void btn_Decriptar_Click(object sender, EventArgs e)
        {
            CriptXPath = fileFolder + @"\" + Path.GetFileNameWithoutExtension(filePath) + Path.GetExtension(filePath); //Path do arquivo encriptado
            //CriptXPath = CriptXPath.Replace(" - Encriptado", " - Decriptado");
            //fileLines = File.ReadAllLines(filePath); // Le o arquivo e salva numa array
            try {
                string palavraChave = textBox_PalavraChave.Text.ToUpper();

                if (String.IsNullOrEmpty(palavraChave) || String.IsNullOrWhiteSpace(palavraChave))
                {
                    throw new ArgumentNullException("palavraChave", "Palavra-Chave Vazia");
                }

                fileLines = File.ReadAllLines(filePath, Encoding.GetEncoding("iso-8859-1")); // Le o arquivo e salva numa array, porem usando um encoding que possibilita ler caracteres especiais

                string[] fileLinesDecriptado = decriptar(fileLines, palavraChave);

                File.Create(CriptXPath).Close();//Cria o arquivo Decriptado

                File.WriteAllLines(CriptXPath, fileLinesDecriptado, Encoding.GetEncoding("iso-8859-1")); //Escreve no arquivo Decriptado

                MessageBox.Show("Concluído!");
            }
                                
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("ERRO: Arquivo não encontrado.");
            } catch (ArgumentNullException)
            {
                  MessageBox.Show("ERRO: Insira uma Palavra-Chave.");
            } catch (Exception)
            {
                MessageBox.Show("ERRO: Palavra-Chave deve ser composta apenas de letras.");
            }
        }

        private void radioButton_Texto_CheckedChanged(object sender, EventArgs e)
        {
        /*
        if (radioButton_Texto.Checked)
            {
                checkBox_Remontar.Checked = false;

                textBox_PalavraChave.Enabled = true;

                btn_Encriptar.Text = "Encriptar";

                label2.Text = "Palavra-Chave (Apenas letras, sem espaços)";

                //textBox_PalavraChave.Width = 179;

                btn_Encriptar.Location = new Point( 61, 89);

                checkBox_Remontar.Hide();

                btn_Decriptar.Show();

                btn_Decriptar.Text = "Decriptar";

                btn_Decriptar.Enabled = true;

            } else
            {
                byteLines = File.ReadAllBytes(filePath);

                label2.Text = "Senha (Apenas números, sem espaços)";

                btn_Encriptar.Location = new Point(107, 89);
                
                //textBox_PalavraChave.Width = 124;

                checkBox_Remontar.Show();

                btn_Encriptar.Text = "OK";

                btn_Decriptar.Hide();

                btn_Decriptar.Text = "...";

                btn_Decriptar.Enabled = false;
            }
        */
        }

        private void checkBox_Remontar_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void avançadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void encriptarTextoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (encriptarTextoToolStripMenuItem.Checked)
            {
                checkBox_Remontar.Checked = false;

                textBox_PalavraChave.Enabled = true;

                btn_Encriptar.Text = "Encriptar";

                textBox_PalavraChave.Text = "";

                label2.Text = "Palavra-Chave (Apenas letras, sem espaços)";

                //textBox_PalavraChave.Width = 179;

                btn_Encriptar.Location = new Point(61, 89);

                checkBox_Remontar.Hide();

                btn_Decriptar.Show();

                this.BackColor = Color.FromArgb(192, 192, 225);

                btn_Decriptar.Text = "Decriptar";

                btn_Decriptar.Enabled = true;
            }
            else
            {
                label2.Text = "Senha (Apenas números, sem espaços)";

                this.BackColor =  Color.FromArgb(224,224,224);

                btn_Encriptar.Location = new Point(107, 89);

                textBox_PalavraChave.Text = "";

                //textBox_PalavraChave.Width = 124;

                checkBox_Remontar.Show();

                btn_Encriptar.Text = "OK";

                btn_Decriptar.Hide();

                btn_Decriptar.Text = "...";

                btn_Decriptar.Enabled = false;
            }
        }
    }
    /*
         <runtime>
        <gcAllowVeryLargeObjects enabled="true" />    
    </runtime>
     */
}
