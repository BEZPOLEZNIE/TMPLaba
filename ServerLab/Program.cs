using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerLab
{
    internal class Program
    {
        static Random random = new Random();

        static List<Socket> officers = new List<Socket>();

        static Dictionary<string, string> accounts = new Dictionary<string, string>()
        {
            { "Фуфелшмерц", "корп" },
            { "Винсмоук", "Чопер" },
            { "1", "1" },
            { "Сидоров", "Колбасенко" }
        };

        static string[] events =
        {
            "Подключено неизвестное USB устройство",
            "Неудачная попытка Входа",
            "Попытка запуска Супер-Злобо-Инатора",
            "Обнаружен агент Пeрри возле лаборатории",
            "Подозрительная активность в секретном тоннеле",
            "Отключен корпоративный файрвол",
            "Обнаружен несанкционированный доступ к чертежам",
            "Зафиксирован критический уровень злoдейства",
            "Попытка активации Самоуничтожатора",
            "Обнаружено вторжение в отдел инаторов"
                
        };

        static string[] devices =
        {
            "Фуфел-01",
            "Фуфел_запасной-02",
            "Зло-03",
            "Инатор-04",
            "Инатор-05",
        };

        static string[] status =
        {
            "Онлайн",
            "Внимание",
            "Критический"
        };

        static object locker = new object();
        public static void Main(string[] args)
        {
            Socket listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 1488);

            listeningSocket.Bind(ep);
            listeningSocket.Listen(10);

            Thread eventThread = new Thread(GenerateEvents);
            eventThread.Start();

            Thread compThread = new Thread(GenerateComps);
            compThread.Start();

            while (true)
            {
                Console.WriteLine("Ожидание подключения клиента...");
                Socket officersSocket = listeningSocket.Accept();

                lock (locker)
                {
                    officers.Add(officersSocket);
                }
                Thread officersThread = new Thread(() => HandleClient(officersSocket));
                officersThread.Start();
                Console.WriteLine("Клиент подключен!");
            }
        }
        static void HandleClient(Socket officersSocket)
        {
            try
            {
                JSer auth = Serializer.ReceiveObject(officersSocket);

                string login = auth.Login;
                Console.WriteLine($"Получен логин: {login} в {DateTime.Now}");

                string password = auth.Password;
                Console.WriteLine($"Получен пароль: {password} в {DateTime.Now}");

                JSer answer = new JSer();

                if (accounts.ContainsKey(login) && accounts[login] == password)
                {
                    answer.Text = "OK";
                    Console.WriteLine("Успешная авторизация!");
                }
                else
                {
                    answer.Text = "ERR";
                    Console.WriteLine("Неверный логин или пароль. Доступ запрещен.");
                }

                Serializer.SendObject(officersSocket, answer);
                while (true)
                { 
                    JSer message = Serializer.ReceiveObject(officersSocket);

                    if (message.Type == "CHAT")
                    {
                        string login_chat = message.Login;
                        string text = message.Password;

                        JSer fullMessage = new JSer
                        {
                            Type = "CHAT",
                            Time = DateTime.Now.ToString("HH:mm:ss"),
                            Login = login,
                            Text = message.Text
                        };
                        
                        lock (locker)
                        {
                            foreach (Socket officer in officers)
                            {
                                try
                                {
                                    Serializer.SendObject(officer, fullMessage);

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Ошибка при отправке сообщения в чат: {ex.Message}");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                lock (locker)
                {
                    officers.Remove(officersSocket);
                }
                officersSocket.Close();
            }
        }

        static void GenerateEvents()
        {
            while (true)
            {
                string time = DateTime.Now.ToString("HH:mm:ss");
                string device = devices[random.Next(devices.Length)];
                string ev = events[random.Next(events.Length)];

                JSer message = new JSer
                {
                    Type = "EVENT",
                    Time = time,
                    Device = device,
                    Text = ev
                };

                foreach (Socket officer in officers)
                {
                    try
                    {
                        Serializer.SendObject(officer, message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при отправке события: {ex.Message}");
                    }
                }

                Thread.Sleep(4000);
            }
        }

        static void GenerateComps()
        {
            while (true)
            {
                try
                {
                    foreach (string device in devices)
                    {
                        int cpu = random.Next(1, 100);
                        int ram = random.Next(1, 100);

                        string stat = status[random.Next(status.Length)];

                        JSer message = new JSer
                        {
                            Type = "COMP",
                            Device = device,
                            Cpu = cpu,
                            Ram = ram,
                            Status = stat
                        };

                        lock (locker)
                        {
                            foreach (Socket officer in officers)
                            {
                                try
                                {
                                    Serializer.SendObject(officer, message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Ошибка при отправке статуса в сериализации: {ex.Message}");
                                }
                            }
                        }
                    }

                    Thread.Sleep(5000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при отправке статуса: {ex.Message}");
                }
            }
        }
    }
}
