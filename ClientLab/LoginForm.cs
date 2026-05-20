using System.Net.Sockets;
using System.Text;

namespace ClientLab
{
    public partial class LoginForm : Form
    {
        private TcpClient client;
        private NetworkStream stream;

        public LoginForm()
        {
            InitializeComponent();
        }

        public async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                labelStatus.Text = "Подключение...";

                client = new TcpClient();

                await client.ConnectAsync("127.0.0.1", 5000);

                stream = client.GetStream();

                string login = txtLogin.Text;
                string password = txtPassword.Text;

                string message = $"LOGIN|{login}|{password}";

                byte[] data = Encoding.UTF8.GetBytes(message);

                await stream.WriteAsync(data);

                byte[] responseBuffer = new byte[1024];

                int responseBytes = await stream.ReadAsync(responseBuffer);

                string response = Encoding.UTF8.GetString(
                    responseBuffer,
                    0,
                    responseBytes
                );

                if (response == "OK")
                {
                    labelStatus.Text = "Авторизация успешна";

                    MainForm mainForm = new MainForm(login);

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
                MessageBox.Show(ex.Message);

                labelStatus.Text = "Ошибка подключения";
            }
        }
    }
}
