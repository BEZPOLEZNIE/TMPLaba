using ClientLab.Models;

namespace ClientLab.Services
{
    public class FakeServer
    {
        private Random random = new Random();

        private string[] events =
        {
            "Подключено неизвестное USB устройство",
            "Неудачная попытка входа",
            "Попытка запуска Супер-Злобо-Инатора",
            "Обнаружен агент Пёрри возле лаборатории",
            "Подозрительная активность в секретном тоннеле",
            "Отключен корпоративный файрвол",
            "Обнаружен несанкционированный доступ к чертежам",
            "Зафиксирован критический уровень злoдейства",
            "Попытка активации Самоуничтожатора",
            "Обнаружено вторжение в отдел инаторов"

        };

        private string[] devices =
        {
            "Фуфел-01",
            "Фуфел_запасной-02",
            "Зло-03",
            "Инатор-04",
            "Инатор-05",
        };

        public List<WorkComp> GetComps()
        {
            List<WorkComp> list = new();

            foreach (var name in devices)
            {
                list.Add(new WorkComp
                {
                    Name = name,
                    Cpu = random.Next(10, 100),
                    Ram = random.Next(10, 100),
                    Status = random.Next(0, 4) == 0 ? "ONLINE" : 
                             random.Next(0, 4) == 1 ? "WARNING" : 
                             random.Next(0, 4) == 2 ? "CRITICAL" : "INFO"
                });
            }

            return list;
        }

        public WorkEvent GetRandomEvent()
        {
            return new WorkEvent
            {
                Time = DateTime.Now,
                Device = devices[random.Next(devices.Length)],
                EventType = events[random.Next(events.Length)]
            };
        }
    }
}