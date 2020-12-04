using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Botnet
{
    class web
    {
        public static string GetHTML(string URI)
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            return wc.DownloadString(URI);
        }
        public static string DownloadFile(string URI)
        {
            string file_name = Path.GetFileName(URI);
            string temp_path = Path.GetTempPath();
            Console.WriteLine(file_name);
            string file_path = Path.Combine(temp_path, file_name);

            WebClient wc = new WebClient();
            wc.Proxy = null;

            wc.DownloadFile(URI, file_path);
            return file_path;
        }
    }
}
