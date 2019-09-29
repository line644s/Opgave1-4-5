using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace TCP_Server
{
    internal class Worker
    {
        static List<Bog> books = new List<Bog>()
        {
            new Bog("Soulless", "Gail Carriger", 352, "123456789abcd"),
            new Bog("Harry Potter", "J.K. Rowling", 195, "dcba987654321"),
            new Bog("Changeless", "Gail Carriger", 354, "23456789abcde")
        };

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);

            server.Start();

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                DoClient(socket);
            }
        }

        private void DoClient(TcpClient socket)
        {
            bool iGang = true;
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                while (iGang)
                {
                    string str1 = sr.ReadLine().ToUpper();
                    if (str1 == "STOP")
                    {
                        sw.WriteLine("Farvel");
                        iGang = false;
                    }
                    else
                    {
                        string str2 = sr.ReadLine();
                        if (str1 == "HENTALLE")
                        {
                            foreach (Bog bog in books)
                            {
                                sw.WriteLine(JsonConvert.SerializeObject(bog));
                            }

                        }
                        else
                        {
                            if (str1 == "HENT")
                            {
                                Bog bog = books.Find(b => b.Isbn13 == str2);
                                if (bog != null)
                                {
                                    sw.WriteLine(JsonConvert.SerializeObject(bog));
                                }
                                
                            }
                            else if (str1 == "GEM")
                            {
                                //Der kunne tilføjes om den er blevet tilføjet noget til listen
                                //int antal = books.Count;
                                books.Add(JsonConvert.DeserializeObject<Bog>(str2));
                                //if (books.Count == antal + 1)
                                //{
                                //    sw.WriteLine("bogen er gemt");

                                //}
                                //else
                                //{
                                //    sw.WriteLine("Noget gik galt");
                                //}

                            }
                            else
                            {
                                sw.WriteLine("Skriv HentAlle, Hent isbn13 eller Gem");
                            }
                        }
                    }

                    sw.Flush();
                }
            }
        }
    }
}