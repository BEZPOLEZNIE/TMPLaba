namespace ClientLab
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridEvents = new DataGridView();
            ColumnTime = new DataGridViewTextBoxColumn();
            ColumnDevice = new DataGridViewTextBoxColumn();
            ColumnEvent = new DataGridViewTextBoxColumn();
            lbChat = new ListBox();
            Filter = new ComboBox();
            txtChat = new TextBox();
            btnSend = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridComp = new DataGridView();
            ColumnComp = new DataGridViewTextBoxColumn();
            ColumnCpu = new DataGridViewTextBoxColumn();
            ColumnRam = new DataGridViewTextBoxColumn();
            ColumnStatus = new DataGridViewTextBoxColumn();
            label4 = new Label();
            CompTimer = new System.Windows.Forms.Timer(components);
            EventTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridEvents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridComp).BeginInit();
            SuspendLayout();
            // 
            // dataGridEvents
            // 
            dataGridEvents.AllowUserToAddRows = false;
            dataGridEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEvents.Columns.AddRange(new DataGridViewColumn[] { ColumnTime, ColumnDevice, ColumnEvent });
            dataGridEvents.Location = new Point(12, 569);
            dataGridEvents.MultiSelect = false;
            dataGridEvents.Name = "dataGridEvents";
            dataGridEvents.ReadOnly = true;
            dataGridEvents.RowHeadersVisible = false;
            dataGridEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridEvents.Size = new Size(1144, 460);
            dataGridEvents.TabIndex = 0;
            // 
            // ColumnTime
            // 
            ColumnTime.HeaderText = "Время";
            ColumnTime.Name = "ColumnTime";
            ColumnTime.ReadOnly = true;
            // 
            // ColumnDevice
            // 
            ColumnDevice.HeaderText = "Компьютер";
            ColumnDevice.Name = "ColumnDevice";
            ColumnDevice.ReadOnly = true;
            // 
            // ColumnEvent
            // 
            ColumnEvent.HeaderText = "Событие";
            ColumnEvent.Name = "ColumnEvent";
            ColumnEvent.ReadOnly = true;
            // 
            // lbChat
            // 
            lbChat.FormattingEnabled = true;
            lbChat.Location = new Point(1162, 51);
            lbChat.Name = "lbChat";
            lbChat.Size = new Size(730, 949);
            lbChat.TabIndex = 1;
            // 
            // Filter
            // 
            Filter.FormattingEnabled = true;
            Filter.Location = new Point(1418, 17);
            Filter.Name = "Filter";
            Filter.Size = new Size(121, 23);
            Filter.TabIndex = 2;
            Filter.SelectedIndexChanged += Filter_SelectedIndexChanged;
            // 
            // txtChat
            // 
            txtChat.Location = new Point(1162, 1006);
            txtChat.Name = "txtChat";
            txtChat.Size = new Size(649, 23);
            txtChat.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(1817, 1006);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 4;
            btnSend.Text = "Отправить";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(12, 529);
            label1.Name = "label1";
            label1.Size = new Size(584, 37);
            label1.TabIndex = 5;
            label1.Text = "Мониторинг событий в Doofenshmirtz Evil Inc.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(1162, 12);
            label2.Name = "label2";
            label2.Size = new Size(250, 28);
            label2.TabIndex = 6;
            label2.Text = "Фильтры для событий -->";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(1635, 17);
            label3.Name = "label3";
            label3.Size = new Size(257, 28);
            label3.TabIndex = 7;
            label3.Text = "Сообщения для офицеров";
            // 
            // dataGridComp
            // 
            dataGridComp.AllowUserToAddRows = false;
            dataGridComp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridComp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridComp.Columns.AddRange(new DataGridViewColumn[] { ColumnComp, ColumnCpu, ColumnRam, ColumnStatus });
            dataGridComp.Location = new Point(12, 42);
            dataGridComp.MultiSelect = false;
            dataGridComp.Name = "dataGridComp";
            dataGridComp.ReadOnly = true;
            dataGridComp.RowHeadersVisible = false;
            dataGridComp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridComp.Size = new Size(1144, 460);
            dataGridComp.TabIndex = 8;
            // 
            // ColumnComp
            // 
            ColumnComp.HeaderText = "Компьютер";
            ColumnComp.Name = "ColumnComp";
            ColumnComp.ReadOnly = true;
            // 
            // ColumnCpu
            // 
            ColumnCpu.HeaderText = "Нагрузка на процессор";
            ColumnCpu.Name = "ColumnCpu";
            ColumnCpu.ReadOnly = true;
            // 
            // ColumnRam
            // 
            ColumnRam.HeaderText = "Нагрузка на память";
            ColumnRam.Name = "ColumnRam";
            ColumnRam.ReadOnly = true;
            // 
            // ColumnStatus
            // 
            ColumnStatus.HeaderText = "Статус";
            ColumnStatus.Name = "ColumnStatus";
            ColumnStatus.ReadOnly = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F);
            label4.Location = new Point(12, 2);
            label4.Name = "label4";
            label4.Size = new Size(649, 37);
            label4.TabIndex = 9;
            label4.Text = "Мониторинг компьютеров в Doofenshmirtz Evil Inc.";
            // 
            // CompTimer
            // 
            CompTimer.Enabled = true;
            CompTimer.Interval = 2000;
            CompTimer.Tick += CompTimer_Tick;
            // 
            // EventTimer
            // 
            EventTimer.Interval = 5000;
            EventTimer.Tick += EventTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(label4);
            Controls.Add(dataGridComp);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSend);
            Controls.Add(txtChat);
            Controls.Add(Filter);
            Controls.Add(lbChat);
            Controls.Add(dataGridEvents);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridEvents).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridComp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridEvents;
        private ListBox lbChat;
        private ComboBox Filter;
        private TextBox txtChat;
        private Button btnSend;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridComp;
        private Label label4;
        private DataGridViewTextBoxColumn ColumnComp;
        private DataGridViewTextBoxColumn ColumnCpu;
        private DataGridViewTextBoxColumn ColumnRam;
        private DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.Timer CompTimer;
        private DataGridViewTextBoxColumn ColumnTime;
        private DataGridViewTextBoxColumn ColumnDevice;
        private DataGridViewTextBoxColumn ColumnEvent;
        private System.Windows.Forms.Timer EventTimer;
    }
}