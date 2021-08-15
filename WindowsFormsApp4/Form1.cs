using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
/// <summary>
/// Приложение, которое позволяет парсить произвольную HTML-страницу и выдает статистику по
/// количеству уникальных слов.
/// </summary>
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

        string strResult = "";
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
                    System.Text.RegularExpressions.Regex tag = new System.Text.RegularExpressions.Regex(@"\<.+?\>");
                    responseData = tag.Replace(responseData, String.Empty);


                    // Для удаления всех тегов html из строки вы можете использовать:
                    responseData = System.Text.RegularExpressions.Regex.Replace(responseData, "<[^>]*>", "");
                    // Для удаления определенного тега:
                    // responseData = System.Text.RegularExpressions.Regex.Replace(responseData, "(?i)<td[^>]*>", "");

                    responseData = System.Text.RegularExpressions.Regex.Replace(responseData, @"\s+", " ");
                    responseData = System.Text.RegularExpressions.Regex.Replace(responseData, @"[ ]+", " ");

                    //using (StreamWriter writer = new StreamWriter(filename))
                    //{
                    //    writer.Write(responseData);
                    //}
                }

            }

            // получим текс из полученного файла
            // распарсим файл
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                string url =    txtLink.Text;

                HtmlWeb web = new HtmlWeb();
                //web.AutoDetectEncoding = true;
                //web.OverrideEncoding = Encoding.UTF8;
                HtmlAgilityPack.HtmlDocument doc1 = web.Load(url);
                string str = doc1.DocumentNode.InnerText;
                str = str.Replace(@"&nbsp;", " ").Replace(@"&lt;", "<").Replace(@"&gt;", ">").Replace(@"&amp;", "&").Replace(@"&quot;", "\"");
                var multiCRRegex = new Regex(@"\n\n\n+");
                str = multiCRRegex.Replace(str, "\n\n");

                //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                //doc.LoadHtml(url);
                //HtmlNodeCollection q = doc.DocumentNode.SelectNodes(".//td[@class='TableText']//font");
                // var q = doc.DocumentNode.SelectNodes(".//td[@class='TableText']//font").Last();
                // string responseData =q.InnerText;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbEncoding.Items.Add("AutoDetectEncoding");
            foreach(var enum1 in cbEncoding.Items)
            {
                cbEncoding.Items.Add(enum1);
            }
        }
    }
}
