using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ServerLab
{
    public static class Serializer
    {
        // string to bytes
        public static byte[] StringToBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        // bytes to string
        public static string BytesToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        // int to bytes
        public static byte[] IntToBytes(int value)
        {
            return BitConverter.GetBytes(value);
        }

        // bytes to int
        public static int BytesToInt(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0);
        }

        // отправка строк
        public static void SendString(Socket socket, string text)
        {
            byte[] data = StringToBytes(text);
            byte[] length = IntToBytes(data.Length);

            socket.Send(length);
            socket.Send(data);
        }

        // принятие строк
        public static string ReceiveString(Socket socket)
        {
            byte[] lengthBytes = new byte[4];
            socket.Receive(lengthBytes);
            int length = BytesToInt(lengthBytes);

            byte[] data = new byte[length];
            socket.Receive(data);
            return BytesToString(data);
        }
    }
}
