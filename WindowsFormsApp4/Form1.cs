using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSimbirSoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Web files(*.html;*.htm)|*.html|All files(*.*)|*.*";
            txtLink.Text = @"https://www.simbirsoft.com/";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.RestoreDirectory = true;
            // выберем имя файла для сохранения страницы
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            
            WebRequest request = WebRequest.Create(txtLink.Text);
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader responseReader = new StreamReader(response.GetResponseStream()))
                {
                    string responseData = responseReader.ReadToEnd();
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        writer.Write(responseData);
                       
                    }
                }
            }
            // получим текс из полученного файла
            // распарсим файл
        }
    }
}
