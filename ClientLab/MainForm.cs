using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ClientLab
{
    public partial class MainForm : Form
    {
        private Socket officersSocket;
        private List<string[]> allEvents = new List<string[]>();
        public MainForm(Socket socket)
        {
            InitializeComponent();

            officersSocket = socket;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           Thread receiveThread = new Thread(ReceiveMessages);
            receiveThread.Start();

            Filter.Items.Add("Все");

            Filter.Items.Add("USB");

            Filter.Items.Add("Вход");

            Filter.Items.Add("Инатор");

            Filter.Items.Add("Пeрри");

            Filter.SelectedIndex = 0;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtChat.Text;

            if (string.IsNullOrWhiteSpace(msg))
                return;

            string message = $"CHAT|{LoginForm.login}|{msg}";

            Serializer.SendString(officersSocket, message);

            txtChat.Clear();
        }

        private void ReceiveMessages()
        {
            while (true)
            {
                try
                {
                    string message = Serializer.ReceiveString(officersSocket);
                    string[] parts = message.Split('|');

                    if (parts[0] == "EVENT")
                    {
                        this.Invoke(new Action(() =>
                        {
                            allEvents.Add(new string[] { parts[1], parts[2], parts[3] });

                            RefreshFilters();
                        }));

                        if (allEvents.Count > 100)
                        {
                            allEvents.RemoveAt(0);
                        }
                    }

                    if (parts[0] == "COMP")
                    {
                        this.Invoke(new Action(() =>
                        {
                            bool found = false;

                            foreach (DataGridViewRow row in dataGridComp.Rows)
                            {
                                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == parts[1])
                                {
                                    row.Cells[1].Value = parts[2] + "%";
                                    row.Cells[2].Value = parts[3] + "%";
                                    row.Cells[3].Value = parts[4];
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                dataGridComp.Rows.Add(parts[1], parts[2] + "%", parts[3] + "%", parts[4]);
                            }
                        }));
                    }

                    if (parts[0] == "CHAT")
                    {
                        this.Invoke(new Action(() =>
                        {
                            string msg = $"[{parts[1]}] ({parts[2]}): {parts[3]}";
                            lbChat.Items.Add(msg);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                } 
            }
        }

        private void RefreshFilters()
        {
            dataGridEvents.Rows.Clear();

            string filter = Filter.SelectedItem.ToString();

            foreach (string[] ev in allEvents)
            {
                bool show = false;

                if (filter == "Все")
                    { show = true; }
                else if(ev[2].Contains(filter))
                { show = true; }
                if (show)
                {
                    dataGridEvents.Rows.Add(ev[0], ev[1], ev[2]);
                }
            }
        }

        private void Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFilters();
        }
    }
}
