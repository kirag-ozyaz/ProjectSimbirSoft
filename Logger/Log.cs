using System;
using System.IO;
using System.Text;

namespace Logger
{
    public static class Log
    {
        private static readonly string patchDir = "ServiceLog";
        private static object sync = new object();

        public static string PathFileLog { get ; set ; }

        static Log()
        {
            string patch = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, patchDir);
            if (!Directory.Exists(patch))
            {
                Directory.CreateDirectory(patch);
            }
            // string path = Path.Combine(patch, string.Format("{0}_{1:dd.MM.yyy}.log", AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
            PathFileLog = Path.Combine(patch, string.Format("{0}.log", AppDomain.CurrentDomain.FriendlyName));

        }
        public static void Write(LogLevel level, string message, string site = "", Exception ex = null)
        {
            try
            {
                string strError = "";
                if (ex != null)
                {
                    strError = string.Format(" >>ERROR: [{0}.{1}] {2}\r\n", ex.TargetSite.DeclaringType, ex.TargetSite.Name, ex.Message);
                }
                string contents = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}:{2}] ", new object[]
                {
                    DateTime.Now,
                    level.ToString(),
                    message
                });
                contents += site == "" ? "" : string.Format("   [{0}]", site);
                contents += strError == ""? "" : string.Format("    - {0}", strError);
                contents += " \r\n";

                object obj = Log.sync;
                lock (obj)
                {
                    File.AppendAllText(PathFileLog, contents, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch
            {
            }
        }
    }
}
