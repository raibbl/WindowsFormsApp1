using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void Lookupwho(String url)
        {
            StringBuilder stringBuilderResult = new StringBuilder();
            using (TcpClient tcpClinetWhois = new TcpClient("whois.internic.net", 43))
            {
                using (NetworkStream networkStreamWhois = tcpClinetWhois.GetStream())
                {
                    using (BufferedStream bufferedStreamWhois = new BufferedStream(networkStreamWhois))
                    {
                        StreamReader streamReaderReceive = new StreamReader(bufferedStreamWhois);
                        try
                        {


                            using (StreamWriter streamWriter = new StreamWriter(bufferedStreamWhois))
                            {
                                streamWriter.WriteLine(url);
                                streamWriter.Flush();
                                using ( streamReaderReceive)
                                {
                                    while (!streamReaderReceive.EndOfStream) stringBuilderResult.AppendLine(streamReaderReceive.ReadLine());
                                }
                            }
                        }
                        catch
                        {
                            Output.Text = stringBuilderResult.ToString();

                        }
                    }
                }
            }

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lookupwho(textBox1.Text);
        }
    }
}
