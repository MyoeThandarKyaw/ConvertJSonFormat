using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        static class Global_Variable
        {
            public static int src_data_index = 0;
            public static string src_data = "";
            public static string trg_data = "";
            public static string open_file_name;
            public static string myfileDlg = null;
            public static string json_file_data_begin = "{\n \t\"Bubbles\": [\t";
        }
        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files|*.doc;*.docx;*.txt;*.text";
            openFileDialog1.InitialDirectory = @"E:\";
            openFileDialog1.Title = "Select a Text File";
            // Char[] chars=System.IO.Path.GetFileName(openFileDialog1.FileName.ToString()).ToCharArray();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {

                    file = new System.IO.StreamReader(openFileDialog1.FileName.ToString());
                    Global_Variable.open_file_name = System.IO.Path.GetFileName(openFileDialog1.FileName.ToString());
                    textBox1.Text += openFileDialog1.FileName.ToString();
                    // Console.WriteLine("open_file_name--------" + Global_Variable.open_file_name);
                    string line;
                    string[] separators = { ",", ":", "\"" };
                    string[] temp;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains("src"))
                        {
                            temp = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < temp.Length; i++)
                            {
                                if (!temp[i].Equals("src"))
                                    Global_Variable.src_data += temp[i].Trim();

                            }
                            Global_Variable.src_data += "\n";
                        }
                        else if (line.Contains("trg"))
                        {
                            temp = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < temp.Length; i++)
                            {
                                if (!temp[i].Equals("trg"))
                                    Global_Variable.trg_data += temp[i].Trim();

                            }
                            Global_Variable.trg_data += "\n";
                        }
                    }
                    Console.WriteLine("SRG_DATA-----" + Global_Variable.src_data);
                    Console.WriteLine("TRG_DATA-----" + Global_Variable.trg_data);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                finally
                {
                    file.Close();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter write_src = null;
            System.IO.StreamWriter write_trg = null;
            try
            {
                if (Global_Variable.open_file_name.Contains("txt"))
                {
                    string[] separators = { "." };
                    string[] temp;
                    temp = Global_Variable.open_file_name.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (!temp[i].Equals("txt"))
                            Global_Variable.open_file_name = temp[i].Trim();
                    }
                }
                //Pass the filepath and filename to the StreamWriter Constructor
                write_src = new System.IO.StreamWriter(@"E:\" + Global_Variable.open_file_name + ".src", false, Encoding.UTF8);
                //Pass the filepath and filename to the StreamWriter Constructor
                write_trg = new System.IO.StreamWriter(@"E:\" + Global_Variable.open_file_name + ".trg", false, Encoding.UTF8);

                //Write a line of text
                write_src.WriteLine(Global_Variable.src_data.Trim());
                write_trg.WriteLine(Global_Variable.trg_data.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                //Close the file
                write_src.Close();
                write_trg.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = null;
            OpenFileDialog openFileDialogforsrc = new OpenFileDialog();
            openFileDialogforsrc.Filter = "Text Files|*.doc;*.docx;*.txt;*.src;*.trg;*.text";
            openFileDialogforsrc.InitialDirectory = @"E:\";
            openFileDialogforsrc.Title = "Select a Src File";
            if (openFileDialogforsrc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {

                    file = new System.IO.StreamReader(openFileDialogforsrc.FileName.ToString());
                    Global_Variable.open_file_name = System.IO.Path.GetFileName(openFileDialogforsrc.FileName.ToString());
                    textBox2.Text += openFileDialogforsrc.FileName.ToString();
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        Global_Variable.src_data += line + "-";
                    }

                    Console.WriteLine("To write JSON SRG_DATA-----" + Global_Variable.src_data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                finally
                {
                    file.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = null;
            OpenFileDialog openFileDialogfortrg = new OpenFileDialog();
            openFileDialogfortrg.Filter = "Text Files|*.doc;*.docx;*.txt;*.src;*.trg;*.text";
            openFileDialogfortrg.InitialDirectory = @"E:\";
            openFileDialogfortrg.Title = "Select a Trg File";
            if (openFileDialogfortrg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {

                    file = new System.IO.StreamReader(openFileDialogfortrg.FileName.ToString());
                    Global_Variable.open_file_name = System.IO.Path.GetFileName(openFileDialogfortrg.FileName.ToString());
                    textBox3.Text += openFileDialogfortrg.FileName.ToString();
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        Global_Variable.trg_data += line + "-";
                    }

                    Console.WriteLine("To write JSON TRG_DATA-----" + Global_Variable.trg_data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                finally
                {
                    file.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter write_json = null;
            try
            {
                if (Global_Variable.open_file_name.Contains("src") || Global_Variable.open_file_name.Contains("trg"))
                {
                    string[] separators = { "." };
                    string[] temp;
                    temp = Global_Variable.open_file_name.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (!temp[i].Equals("txt") && !temp[i].Equals("src") && !temp[i].Equals("trg"))
                            Global_Variable.open_file_name = temp[i].Trim();
                    }
                }
                //Pass the filepath and filename to the StreamWriter Constructor
                write_json = new System.IO.StreamWriter(@"E:\" + Global_Variable.open_file_name + ".json", false, Encoding.UTF8);
                write_json.WriteLine(Global_Variable.json_file_data_begin);
                string[] src_file_separator = { "-" };
                string[] src_file_data, trg_file_data;
                src_file_data = Global_Variable.src_data.Split(src_file_separator, StringSplitOptions.RemoveEmptyEntries);
                trg_file_data = Global_Variable.trg_data.Split(src_file_separator, StringSplitOptions.RemoveEmptyEntries);
                if (src_file_data.Length == trg_file_data.Length)
                {
                    for (int i = 0; i < src_file_data.Length; i++)
                    {
                        write_json.WriteLine("\t{");
                        write_json.WriteLine("\t\"id\":  0,");
                        write_json.WriteLine("\t\"src\": \"" + src_file_data[i] + "\",");
                        write_json.WriteLine("\t\"trg\": \"" + trg_file_data[i] + "\"\n\t},");

                    }
                    write_json.WriteLine(" ]\n}");
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                //Close the file
                write_json.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}

      