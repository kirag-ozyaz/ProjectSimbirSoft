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
using Logger;
/// <summary>
/// Приложение, которое позволяет парсить произвольную HTML-страницу и выдает статистику по
/// количеству уникальных слов.
/// </summary>
namespace ProjectSimbirSoft
{
    public partial class FrmSimbirSoft : Form
    {
        public FrmSimbirSoft()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Web files(*.html;*.htm)|*.html|All files(*.*)|*.*";
            txtLink.Text = @"https://www.simbirsoft.com/";
        }

        private void Analiz_Click(object sender, EventArgs e)
        {
            /// дата регистрации статистики
            DateTime DateTimeStatic = DateTime.Now;
           
            // проверим адрес
            Uri uri = null;
            try
            {
                uri = new Uri(txtLink.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK);
                Log.Write(LogLevel.Error, $"Ошибка: {ex.Message}", txtLink.Text, ex);
                return;
            }
            // 0. разберем страницу на массивы
            var myListWeb = GetListInnerText(uri);
            
            // теперь занесем все это в базу данных
            // 1. Ищем в справочнике сайтов сайт и заносим его по необходимости
            // 2. сформируем документ регистрации статистики (анализа сайта)
            // 3. заполним уникальными словами и количеством документ регистрации статистики (подчиненная таблица)
            int idWebSite = GetElementDictionaryWeb(uri);
            if (idWebSite == -1) return;

            int idStatic = CreateDokumentStatic(uri, idWebSite, DateTimeStatic);
            if (idStatic == -1) return;

            if (!FillDokumentStatic(uri, idStatic, DateTimeStatic, myListWeb)) return;

            frmSimbirSoft_fill();

            dgvStatic.CurrentCell = dgvStatic.Rows[dgvStatic.Rows.Count-1].Cells.OfType<DataGridViewCell>().First(c => c.Visible);
        }

        private void frmSimbirSoft_Load(object sender, EventArgs e)
        {
            /// сформируем список кодировок веб-страниц
            cbEncoding.Items.Add("AutoDetectEncoding"); // нулевая - поумолчанию
            foreach (EncodingInfo enum1 in Encoding.GetEncodings())
            {
                clEncoding item = new clEncoding(enum1.Name, enum1.CodePage, enum1.DisplayName);
                cbEncoding.Items.Add(item);
            }
            cbEncoding.SelectedIndex = 0;
            //
            frmSimbirSoft_fill();
            //
            Log.Write(LogLevel.Info, "Запуск системы");

        }
        /// <summary>
        /// подгрузим (обновим) адаптеры
        /// </summary>
        private void frmSimbirSoft_fill()
        {
            this.tblStaticTableAdapter1.Fill(this.dsSimbirSoft1.tblStatic);
            this.tblWebsiteTableAdapter1.Fill(this.dsSimbirSoft1.tblWebsite);
            this.tblStaticCountTableAdapter1.Fill(this.dsSimbirSoft1.tblStaticCount);
            this.vStaticTableAdapter.Fill(this.dsSimbirSoft1.vStatic);
        }

        private void FrmSimbirSoft_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Write(LogLevel.Info, "Остановка системы");
        }

        private void btnLogger_Click(object sender, EventArgs e)
        {
            frmLogger frm = new frmLogger();
            frm.PathFileLog = Log.PathFileLog;
            frm.ShowDialog();
        }
        /// <summary>
        /// Разбор страницы
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        private IEnumerable<clListWeb> GetListInnerText(Uri uri)
        {
            // разберем страницу на массивы
            HtmlAgilityPack.HtmlDocument docWeb;
            HtmlWeb web = new HtmlWeb();
            try
            {
                if (cbEncoding.SelectedIndex != 0)
                {
                    web.OverrideEncoding = Encoding.GetEncoding(((clEncoding)cbEncoding.SelectedItem).CodePage);
                }

                docWeb = web.Load(uri);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка введенного адреса. {ex.Message}", "Ошибка", MessageBoxButtons.OK);
                Log.Write(LogLevel.Error, $"Ошибка введенного адреса: {ex.Message}", uri.ToString(), ex);
                return null;
            }
            Log.Write(LogLevel.Info, $"Кодировка страницы {docWeb.Encoding.EncodingName}", uri.ToString());
            if (web.OverrideEncoding != null)
                Log.Write(LogLevel.Info, $"Кодировка страницы для загрузки {web.OverrideEncoding.EncodingName }", uri.ToString());
            lbEnCodingWeb.Text = $"Текущая кодировка: {docWeb.Encoding.EncodingName} BodyName: {docWeb.Encoding.BodyName} HeaderName: {docWeb.Encoding.HeaderName} WindowsCodePage: {docWeb.Encoding.WindowsCodePage}";
            // текст веб-страницы
            string strWeb = docWeb.DocumentNode.InnerText;
            Log.Write(LogLevel.Info, $"Получили текст с сайта: {uri.ToString()}", uri.ToString());
            // уберем лишнее (можно и одной строкой)
            strWeb = new Regex(@"&nbsp;+").Replace(strWeb, " ").Trim();
            strWeb = new Regex(@"&nbsp+").Replace(strWeb, " ").Trim();
            strWeb = new Regex(@"&lt;+").Replace(strWeb, "<").Trim();
            strWeb = new Regex(@"&gt;+").Replace(strWeb, ">").Trim();
            strWeb = new Regex(@"&amp;+").Replace(strWeb, "&").Trim();
            strWeb = new Regex(@"&quot;+").Replace(strWeb, ">").Trim();
            strWeb = new Regex(@"&gt;+").Replace(strWeb, "\"").Trim();
            // разобъем строку на подстроки по разделителям
            string[] myStringWeb = strWeb.Split(new Char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            // сформируем сгруппированный список по уникальным словам и сделаем расчет их количества
            var myListWeb = myStringWeb.ToList().GroupBy(p => p).Select(g => new clListWeb { Name = g.Key, Count = g.Count() });
            Log.Write(LogLevel.Info, $"Разобрали текст с сайта: {uri.ToString()}", uri.ToString());

            return myListWeb;
        }
        /// <summary>
        /// Найдем уже введенный сайт или введем новый
        /// </summary>
        private int GetElementDictionaryWeb(Uri uri)
        {
            int idWebSite = -1;

            var dtWebsite = dsSimbirSoft1.tblWebsite;
            tblWebsiteTableAdapter1.Fill(dtWebsite);

            var rowWS = dtWebsite.AsEnumerable().Where(w => w.Name == uri.ToString());

            if (rowWS.Count() > 0)
            {
                idWebSite = rowWS.First().Id;
                Log.Write(LogLevel.Info, $"В справочнике сайтов нашли : {uri.ToString()}");
            }
            else
            {
                DataRow row = dtWebsite.NewRow();
                row["Name"] = uri.ToString();
                dtWebsite.Rows.Add(row);

                try
                {
                    tblWebsiteTableAdapter1.Update(dtWebsite);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка обновления WebSite Data Table {ex.Message}");
                    Log.Write(LogLevel.Error, $"Ошибка обновления WebSite Data Table: {ex.Message}", uri.ToString(), ex);
                    return -1;
                }

                idWebSite = (int)row["Id"];
                Log.Write(LogLevel.Info, $"В справочнике сайтов создали : {uri.ToString()}", uri.ToString());
            }

            return idWebSite;
        }
        /// <summary>
        /// сформируем документ регистрации статистики (анализа сайта)
        /// </summary>
        /// <returns></returns>
        private int CreateDokumentStatic(Uri uri, int idWebSite, DateTime dateTimeDokument)
        {
            dsSimbirSoft.tblStaticDataTable dtStatic = dsSimbirSoft1.tblStatic;
            tblStaticTableAdapter1.Fill(dtStatic);

            DataRow row1 = dtStatic.NewRow();
            row1["idWebSite"] = idWebSite;
            row1["DataCreate"] = dateTimeDokument;
            dtStatic.Rows.Add(row1);

            try
            {
                tblStaticTableAdapter1.Update(dtStatic);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления Static Data Table {ex.Message}");
                Log.Write(LogLevel.Error, $"Ошибка обновления Static Data Table: {ex.Message}", uri.ToString(), ex);
                return -1;
            }
            // id текущей статистики
            int idDokument = (int)row1["Id"];
            Log.Write(LogLevel.Info, $"Создали документ регистрации статистики : #{idDokument} от {dateTimeDokument.ToString()}", uri.ToString());

            return idDokument;
        }
        /// <summary>
        /// заполним уникальными словами и количеством документ регистрации статистики (подчиненная таблица)
        /// </summary>
        private bool FillDokumentStatic(Uri uri, int idDokument, DateTime DateTimeDokument, IEnumerable<clListWeb> ListWeb)
        { 
            dsSimbirSoft.tblStaticCountDataTable dtStaticCount = dsSimbirSoft1.tblStaticCount;
            tblStaticCountTableAdapter1.Fill(dtStaticCount);
            foreach (var enum1 in ListWeb)
            {
                DataRow row2 = dtStaticCount.NewRow();
                row2["idStatic"] = idDokument;
                row2["Name"] = enum1.Name;
                row2["Count"] = enum1.Count;
                dtStaticCount.Rows.Add(row2);
            }
            try
            {
                tblStaticCountTableAdapter1.Update(dtStaticCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления таблицы уникальных слов  {ex.Message}");
                Log.Write(LogLevel.Error, $"Ошибка обновления таблицы уникальных слов: {ex.Message}", uri.ToString(), ex);
                return false;
            }
            Log.Write(LogLevel.Info, $"Заполнили словами документ регистрации статистики : #{idDokument} от {DateTimeDokument.ToString()}", uri.ToString());
            return true;
        }
    }
    /// <summary>
    /// класс для отображения кодировки веб-страниц
    /// </summary>
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
    class clListWeb
    {
        public string Name;
        public int Count;
    }
}
