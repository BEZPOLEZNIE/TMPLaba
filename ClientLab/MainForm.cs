using ClientLab.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using ClientLab.Services;

namespace ClientLab
{
    public partial class MainForm : Form
    {
        private FakeServer server = new FakeServer();
        private List<WorkComp> comps = new();
        private List<WorkEvent> events = new();
        private string login;
        public MainForm(string login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CompTimer.Start();
            EventTimer.Start();

            Filter.Items.Add("Все");

            Filter.Items.Add("USB");

            Filter.Items.Add("Вход");

            Filter.Items.Add("Инатор");

            Filter.Items.Add("Пeрри");

            Filter.SelectedIndex = 0;
        }
        private void RefreshComp()
        {
            dataGridComp.Rows.Clear();

            foreach (WorkComp comp in comps)
            {
                dataGridComp.Rows.Add(
                    comp.Name,
                    comp.Cpu + "%",
                    comp.Ram + "%",
                    comp.Status
                );
            }
        }
        private void RefreshEvents()
        {
            dataGridEvents.Rows.Clear();

            string filter = Filter.Text;

            foreach (WorkEvent ev in events)
            {
                bool show = false;

                if (filter == "Все")
                {
                    show = true;
                }
                else if (filter == "USB"
                         && ev.EventType.Contains("USB"))
                {
                    show = true;
                }
                else if (filter == "Вход"
                         && ev.EventType.Contains("вход"))
                {
                    show = true;
                }
                else if (filter == "Инатор"
                         && ev.EventType.Contains("инатор"))
                {
                    show = true;
                }
                else if (filter == "Пeрри"
                         && ev.EventType.Contains("Пeрри"))
                {
                    show = true;
                }

                if (show)
                    dataGridEvents.Rows.Add(
                    ev.Time.ToString("HH:mm:ss"),
                    ev.Device,
                    ev.EventType
                );
            }
        }
        private void CompTimer_Tick(object sender, EventArgs e)
        {
            comps = server.GetComps();
            RefreshComp();
        }

        private void EventTimer_Tick(object sender, EventArgs e)
        {
            WorkEvent ev = server.GetRandomEvent();

            events.Add(ev);

            RefreshEvents();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtChat.Text;

            if (string.IsNullOrWhiteSpace(msg))
                return;

            string fullMsg = $"[{DateTime.Now:HH:mm:ss}] {login}: {msg}";

            lbChat.Items.Add(fullMsg);

            txtChat.Clear();
        }

        private void Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshEvents();
        }
    }
}
