using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientLab
{
    public partial class LoginForm : Form
    {
        public static string login;
        public LoginForm()
        {
            InitializeComponent();
        }

        private Socket officersSocket;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                labelStatus.Text = "Подключение...";

                officersSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                officersSocket.Connect(IPAddress.Parse("127.0.0.1"), 1488);

                login = txtLogin.Text;
                string password = txtPassword.Text;

                Serializer.SendString(officersSocket, login);
                Serializer.SendString(officersSocket, password);
                
                string answer = Serializer.ReceiveString(officersSocket);

            if (answer == "OK")
            {
                labelStatus.Text = "Авторизация успешна";

                MainForm mainForm = new MainForm(officersSocket);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                labelStatus.Text = "Ошибка авторизации";

                MessageBox.Show("Неверный логин или пароль");
            }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");

                labelStatus.Text = "Ошибка подключения";
            }
        }
    }
}
