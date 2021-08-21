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

namespace ProjectSimbirSoft
{
    public partial class frmLogger : Form
    {
        public frmLogger()
        {
            InitializeComponent();
        }

        public string PathFileLog { get; internal set; }

        private void frmLogger_Load(object sender, EventArgs e)
        {
            if (File.Exists(PathFileLog))
                using (StreamReader sr = new StreamReader(PathFileLog, Encoding.GetEncoding(1251)))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        rtbLogger.AppendText($"{s}\r\n");
                    }
                }
        }
    }
}
