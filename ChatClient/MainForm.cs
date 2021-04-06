using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class MainForm : Form
    {
        private HtmlController _htmlController;
        
        internal static MainForm Form;
        public MainForm()
        {
            InitializeComponent();
            Form = this;
            _htmlController = new HtmlController();
            chatPage.Navigate(Path.Combine(Directory.GetCurrentDirectory(), "chat.html"));
        }
        

        internal void ShowTextMessage(Message message)
        {
            _htmlController.AddMessage(message);
            chatPage.Refresh();
        }

        internal void ShowFileMessage(Message message)
        {
            _htmlController.AddMessage(message);
            chatPage.Refresh();
        }
        
        private void SetUsername(object sender, EventArgs e)
        {
            if (username.Text.Length < 127) 
                Client.CurrentClient.Username = username.Text;
            else
            {
                MessageBox.Show(
                    "too long username", 
                    "Error"
                );
            }
        }

        private void SetIp(object sender, EventArgs e)
        {
            Regex rx = new Regex("^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$");
            if (rx.IsMatch(Ip.Text))
            {
                Client.CurrentClient.Ip = Ip.Text;
            }
            else
            {
                Ip.Text = "";
                MessageBox.Show(
                    "incorrect IP-address", 
                    "Error"
                    );
            }
        }

        private void SetPort(object sender, EventArgs e)
        {
            int newPort = Convert.ToInt32(port.Text);
            if (newPort > 0 && newPort < 65356)
            {
                Client.CurrentClient.Port = newPort;
            }
            else
            {
                port.Text = "";
                MessageBox.Show(
                    "incorrect port",
                    "Error"
                );
            }
        }
        

        private void SendMessage(object sender, EventArgs e)
        {
            if (messageBox.Text == "") return;
            Message message = new Message(Encoding.Unicode.GetBytes(messageBox.Text), Message.MessageType.Text,
                Client.CurrentClient.Username, null);
            ShowTextMessage(message);
            Client.CurrentClient.SendTextMessage(message);
            messageBox.Text = "";
            
        }

        private void Connect(object sender, EventArgs e)
        {
            messageBox.Enabled = true;
            SendButton.Enabled = true;
            sendFileButton.Enabled = true;
            disconnectButton.Enabled = true;
            connectButton.Enabled = false;
            Ip.Enabled = false;
            port.Enabled = false;
            username.Enabled = false;
            Ip.Text = Client.CurrentClient.Ip;
            port.Text = Client.CurrentClient.Port.ToString();
            username.Text = Client.CurrentClient.Username;
            Client.CurrentClient.Connect();
            ShowTextMessage(new Message(Encoding.Unicode.GetBytes("Entered chat"), Message.MessageType.Text, Client.CurrentClient.Username, null));
        }

        private void Disconnect(object sender, EventArgs e)
        {
            Client.CurrentClient.Disconnect();
            messageBox.Enabled = false;
            SendButton.Enabled = false;
            sendFileButton.Enabled = false;
            disconnectButton.Enabled = false;
            connectButton.Enabled = true;
            Ip.Enabled = true;
            port.Enabled = true;
            username.Enabled = true;
            messageBox.Text = "";
        }

        private bool IsImage(string extension)
        {
            if (extension.Equals(".jpeg") || extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".gif") || extension.Equals(".bmp")) return true;
            return false;
        }

        private void SendFile(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.Cancel)
                return;
            
            string filename = openFile.FileName;
            int index = 0;
            int fileSize;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                fileSize = (int)fs.Length;
            }
            
            Message.MessageType type = IsImage(Path.GetExtension(filename)) ? Message.MessageType.Image
                : Message.MessageType.Binary;

            if (!Directory.Exists(@".\Downloads")) Directory.CreateDirectory(@".\Directory"); 
            
            if (!File.Exists(@".\Downloads\" + Path.GetFileName(filename))) File.Copy(filename, @".\Downloads\" + Path.GetFileName(filename));
            
            Message message = new Message(null, type, Client.CurrentClient.Username, 
                new NetworkFile(Path.GetFileName(filename), fileSize));
                
            Client.CurrentClient.SendFile(message);
            
            ShowFileMessage(message);
        }

        private void openFile_FileOk(object sender, CancelEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}