using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ServerLab
{
    internal class Program
    {   
        static List<Socket> officers = new List<Socket>();
        public static void Main(string[] args)
        {
            Socket listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 1488);

            listeningSocket.Bind(ep);
            listeningSocket.Listen(10);

            while (true)
            {
                Console.WriteLine("Ожидание подключения клиента...");
                Socket officersSocket = listeningSocket.Accept();

                officers.Add(officersSocket);
                Thread officersThread = new Thread(() => HandleClient(officersSocket));
                officersThread.Start();
                Console.WriteLine("Клиент подключен!");
            }

            static void HandleClient(Socket officersSocket)
            {
                try
                {
                    string login = Serializer.ReceiveString(officersSocket);
                    Console.WriteLine($"Получен логин: {login} в {DateTime.Now}");

                    string password = Serializer.ReceiveString(officersSocket);
                    Console.WriteLine($"Получен пароль: {password} в {DateTime.Now}");

                    string accounts;
                    if (login == "Фуфелшмерц" && password == "корп")
                    {
                        accounts = "OK";
                        Console.WriteLine("Успешная авторизация! c {login} в {DateTime.Now}");
                    }
                    else
                    {
                        accounts = "ERR";
                        Console.WriteLine("Неверный логин или пароль. Доступ запрещен.");
                    }

                    Serializer.SendString(officersSocket, accounts);
                    while (true) { Thread.Sleep(1000); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                finally
                {
                    officersSocket.Close();
                    Console.WriteLine("{login} отключен.");
                }
            }
        }
    }
}
