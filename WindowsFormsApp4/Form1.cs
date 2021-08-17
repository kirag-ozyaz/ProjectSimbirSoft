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

        //string strResult = "";
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
            richTextBoxWeb.Clear();
            using (var client = new HttpClient())
            {
                string url =    txtLink.Text;
                if (!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                {
                    MessageBox.Show("некорректный формат адреса!","Ошибка",MessageBoxButtons.OK);
                    return;
                }

                HtmlWeb web = new HtmlWeb();
                //var Encodings = Encoding.GetEncodings();
                if (cbEncoding.SelectedIndex != 0)
                    web.OverrideEncoding = Encoding.GetEncoding(((clEncoding)cbEncoding.SelectedItem).CodePage);
                HtmlAgilityPack.HtmlDocument doc1 = web.Load(url);
                string str = doc1.DocumentNode.InnerText;
                //str = str.Replace(@"&nbsp;", " ").Replace(@"&lt;", "<").Replace(@"&gt;", ">").Replace(@"&amp;", "&").Replace(@"&quot;", "\"");

                str = new Regex(@"&nbsp;+").Replace(str, " ").Trim();
                str = new Regex(@"&nbsp+").Replace(str, " ").Trim();
                str = new Regex(@"&lt;+").Replace(str, "<").Trim();
                str = new Regex(@"&gt;+").Replace(str, ">").Trim();
                str = new Regex(@"&amp;+").Replace(str, "&").Trim();
                str = new Regex(@"&quot;+").Replace(str, ">").Trim();
                str = new Regex(@"&gt;+").Replace(str, "\"").Trim();

                //str = new Regex(@"\n+").Replace(str, " ").Trim();
                //str = new Regex(@"\t+").Replace(str, " ").Trim();
                //str = new Regex(@"\r+").Replace(str, " ").Trim();

                richTextBoxWeb.Text = str;

                string[] myString = str.Split(new Char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                //richTextBoxWeb.Clear();
                //foreach (string s1 in myString)
                //{
                //    richTextBoxWeb.AppendText($"{ s1}\n");

                //}

                var myList = myString.ToList().GroupBy(p => p).Select(g => new { Name = g.Key, Count = g.Count() });

                DataTable dt = new DataTable();
                dt.Columns.Add("Name", Type.GetType("System.String"));
                dt.Columns.Add("Count", Type.GetType("System.Int32"));
                foreach (var enum1 in myList)
                {
                    dt.Rows.Add(new object[] { enum1.Name, enum1.Count});
                }

                //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                //doc.LoadHtml(url);
                //HtmlNodeCollection q = doc.DocumentNode.SelectNodes(".//td[@class='TableText']//font");
                // var q = doc.DocumentNode.SelectNodes(".//td[@class='TableText']//font").Last();
                // string responseData =q.InnerText;
                lbEnCodingWeb.Text = $"Текущая кодировка:{doc1.Encoding.EncodingName} BodyName: {doc1.Encoding.BodyName} HeaderName: {doc1.Encoding.HeaderName} WindowsCodePage: {doc1.Encoding.WindowsCodePage}";

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbEncoding.Items.Add("AutoDetectEncoding");
            foreach (EncodingInfo enum1 in Encoding.GetEncodings())
            {
                clEncoding item = new clEncoding( enum1.Name, enum1.CodePage, enum1.DisplayName );
                cbEncoding.Items.Add(item);
            }
            cbEncoding.SelectedIndex = 0;

        }
    }
    class clEncoding
    {
        public string Name;
        public int CodePage;
        public string DisplayName;

        public clEncoding(string name, int codePage, string displayName)
        {
            Name = name;
            CodePage = codePage;
            DisplayName = displayName;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
