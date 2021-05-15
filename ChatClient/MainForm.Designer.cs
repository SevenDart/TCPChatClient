namespace ChatClient
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
            this.username = new System.Windows.Forms.TextBox();
            this.usernameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.Ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IpButton = new System.Windows.Forms.Button();
            this.PortButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.sendFileButton = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.chatPage = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(114, 14);
            this.username.Margin = new System.Windows.Forms.Padding(2);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(342, 22);
            this.username.TabIndex = 0;
            this.username.Text = "username";
            // 
            // usernameButton
            // 
            this.usernameButton.Location = new System.Drawing.Point(462, 12);
            this.usernameButton.Margin = new System.Windows.Forms.Padding(2);
            this.usernameButton.Name = "usernameButton";
            this.usernameButton.Size = new System.Drawing.Size(106, 26);
            this.usernameButton.TabIndex = 1;
            this.usernameButton.Text = "Confirm";
            this.usernameButton.UseVisualStyleBackColor = true;
            this.usernameButton.Click += new System.EventHandler(this.SetUsername);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // messageBox
            // 
            this.messageBox.Enabled = false;
            this.messageBox.Location = new System.Drawing.Point(10, 414);
            this.messageBox.Margin = new System.Windows.Forms.Padding(2);
            this.messageBox.Name = "messageBox";
            this.messageBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.messageBox.Size = new System.Drawing.Size(450, 70);
            this.messageBox.TabIndex = 4;
            this.messageBox.Text = "";
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(470, 414);
            this.SendButton.Margin = new System.Windows.Forms.Padding(2);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(102, 32);
            this.SendButton.TabIndex = 6;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendMessage);
            // 
            // Ip
            // 
            this.Ip.Location = new System.Drawing.Point(46, 60);
            this.Ip.Margin = new System.Windows.Forms.Padding(2);
            this.Ip.Name = "Ip";
            this.Ip.Size = new System.Drawing.Size(122, 22);
            this.Ip.TabIndex = 7;
            this.Ip.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "IP:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IpButton
            // 
            this.IpButton.Location = new System.Drawing.Point(174, 60);
            this.IpButton.Margin = new System.Windows.Forms.Padding(2);
            this.IpButton.Name = "IpButton";
            this.IpButton.Size = new System.Drawing.Size(46, 22);
            this.IpButton.TabIndex = 9;
            this.IpButton.Text = "Set";
            this.IpButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.IpButton.UseVisualStyleBackColor = true;
            this.IpButton.Click += new System.EventHandler(this.SetIp);
            // 
            // PortButton
            // 
            this.PortButton.Location = new System.Drawing.Point(350, 60);
            this.PortButton.Margin = new System.Windows.Forms.Padding(2);
            this.PortButton.Name = "PortButton";
            this.PortButton.Size = new System.Drawing.Size(46, 22);
            this.PortButton.TabIndex = 12;
            this.PortButton.Text = "Set";
            this.PortButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PortButton.UseVisualStyleBackColor = true;
            this.PortButton.Click += new System.EventHandler(this.SetPort);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(234, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Port:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(290, 60);
            this.port.Margin = new System.Windows.Forms.Padding(2);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(54, 22);
            this.port.TabIndex = 10;
            this.port.Text = "8888";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(402, 54);
            this.connectButton.Margin = new System.Windows.Forms.Padding(2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(70, 31);
            this.connectButton.TabIndex = 13;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.Connect);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(478, 54);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(2);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(90, 31);
            this.disconnectButton.TabIndex = 14;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.Disconnect);
            // 
            // sendFileButton
            // 
            this.sendFileButton.Enabled = false;
            this.sendFileButton.Location = new System.Drawing.Point(470, 450);
            this.sendFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.sendFileButton.Name = "sendFileButton";
            this.sendFileButton.Size = new System.Drawing.Size(102, 33);
            this.sendFileButton.TabIndex = 5;
            this.sendFileButton.Text = "Send file...";
            this.sendFileButton.UseVisualStyleBackColor = true;
            this.sendFileButton.Click += new System.EventHandler(this.SendFile);
            // 
            // openFile
            // 
            this.openFile.Title = "Open File";
            // 
            // chatPage
            // 
            this.chatPage.Location = new System.Drawing.Point(10, 92);
            this.chatPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.chatPage.Name = "chatPage";
            this.chatPage.Size = new System.Drawing.Size(558, 317);
            this.chatPage.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(586, 499);
            this.Controls.Add(this.chatPage);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.PortButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.port);
            this.Controls.Add(this.IpButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ip);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.sendFileButton);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameButton);
            this.Controls.Add(this.username);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(604, 546);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(604, 546);
            this.Name = "MainForm";
            this.Text = "TCP Chat Client";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.WebBrowser chatPage;

        private System.Windows.Forms.OpenFileDialog openFile;

        private System.Windows.Forms.Button sendFileButton;

        private System.Windows.Forms.Button disconnectButton;

        private System.Windows.Forms.Button connectButton;

        private System.Windows.Forms.Button PortButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox port;

        private System.Windows.Forms.Button IpButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Ip;

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.RichTextBox messageBox;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button usernameButton;
        private System.Windows.Forms.TextBox username;

        #endregion
    }
}