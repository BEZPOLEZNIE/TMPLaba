using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace ClientLab
{
    public static class Serializer
    {
        public static void SendObject(Socket socket, JSer obj)
        {
            string json = JsonSerializer.Serialize(obj);

            byte[] data = Encoding.UTF8.GetBytes(json);
            byte[] length = BitConverter.GetBytes(data.Length);

            socket.Send(length);
            socket.Send(data);
        }

        public static JSer ReceiveObject(Socket socket)
        {
            byte[] lengthBuffer = new byte[4];
            socket.Receive(lengthBuffer);
            int length = BitConverter.ToInt32(lengthBuffer, 0);

            byte[] dataBuffer = new byte[length];
            socket.Receive(dataBuffer);
            string json = Encoding.UTF8.GetString(dataBuffer);

            return JsonSerializer.Deserialize<JSer>(json);
        }
    }
}
