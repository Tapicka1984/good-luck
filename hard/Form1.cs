using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*1. Ondra Zelený
        2. Jakub Volema
        3. Marti Sýrový
        4. Hynek Svobody 
        5. Pavel Štulhofer
        6. Tomáš Ružička
        7. Honza Šerminátor
        8. Štonda Tolfa*/

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != string.Empty)
                {
                    FileStream data = new FileStream("znamky.dat", FileMode.OpenOrCreate, FileAccess.Write);
                    BinaryWriter zapis = new BinaryWriter(data, Encoding.GetEncoding("windows-1250"));
                    string zaznam = (comboBox1.Text + "." + textBox2.Text + "." + textBox4.Text + "." + textBox3.Text + "|");
                    zapis.Write(zaznam);
                    zapis.Close();
                    data.Close();
                }
                else
                {
                    MessageBox.Show("vyber neco");
                }
            }
            catch
            {
                MessageBox.Show("ERROR!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream data = new FileStream("znamky.dat", FileMode.Open, FileAccess.Read);
            BinaryReader cteni = new BinaryReader(data, Encoding.GetEncoding("windows-1250"));
            data.Position = 0;
            char[] pole = (comboBox2.Text).ToCharArray();
            int cislo1 = pole[1] - 48;
            while (data.Position < data.Length)
            {
                string text = cteni.ReadString();
                char[] pole2 = text.ToCharArray();
                int cislo2 = pole2[1] - 48;
                if (cislo1 == cislo2)
                {
                    string[] pole3 = text.Split('.');
                    listBox1.Items.Add(pole3[0]);
                    listBox2.Items.Add("znamky: " + pole3[3] + " vahy:" + pole[2]);
                    textBox1.Text = pole3[0];

                }
            }
            data.Close();
            cteni.Close();
        }
    }
}
