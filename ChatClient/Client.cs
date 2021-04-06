using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatClient
{
    public class Client
    {
        internal static Client CurrentClient = new Client();
        internal string Username { get; set; }
        internal string Ip { get; set; }
        internal int Port { get; set; }

        private TcpClient _client;
        private NetworkStream _stream;
        private int _bufferSize = 2048;

        private Client ()
        {
            Username = "username";
            Ip = "127.0.0.1";
            Port = 8888;
            CurrentClient = this;
            _client = new TcpClient();
        }

        internal void Connect()
        {
            _client.Connect(Ip, Port);
            _stream = _client.GetStream();
            byte[] connect = {0};
            SendTextMessage(new Message(connect, Message.MessageType.Text, Username, null));
            Thread messagesThread = new Thread(ReceiveMessages);
            messagesThread.Start();
        }

        internal void SendTextMessage(Message message)
        {
            byte[] protocolData = {(byte)Message.MessageType.Text, (byte)(Username.Length * 2)};
            _stream.Write(protocolData, 0, 2);
            _stream.Write(Encoding.Unicode.GetBytes(Username), 0, protocolData[1]);
            _stream.Write(message.Data, 0, message.Data.Length);
        }

        internal void SendFile(Message message)
        {
            
            byte[] protocolData = {(byte) message.Type, (byte) (message.Username.Length * 2)};
            _stream.Write(protocolData, 0, 2);
            _stream.Write(Encoding.Unicode.GetBytes(message.Username), 0, protocolData[1]);
            
            byte[] bytesLength = BitConverter.GetBytes(message.File.Filename.Length * 2);
            _stream.Write(bytesLength, 0, 4);
            _stream.Write(Encoding.Unicode.GetBytes(message.File.Filename), 0, message.File.Filename.Length * 2);
            
            byte[] fileSizeBytes = BitConverter.GetBytes(message.File.FileSize);
            _stream.Write(fileSizeBytes, 0, 4);
            
            using (FileStream file = File.Open(@".\Downloads\" + message.File.Filename, FileMode.Open))
            {
                byte[] buffer = new byte[_bufferSize];
                do
                {
                    int length = file.Read(buffer, 0, _bufferSize);
                    _stream.Write(buffer, 0, length);
                } while (file.Position != file.Length);
            }

        }

        void ReceiveMessages()
        {
            try
            {
                while (true)
                {
                    var message = GetMessage();
                    switch (message.Type)
                    {
                        case Message.MessageType.Text:
                            MainForm.Form.ShowTextMessage(message);
                            break;
                        case Message.MessageType.Binary:
                            MainForm.Form.ShowFileMessage(message);
                            break;
                        case Message.MessageType.Image:
                            MainForm.Form.ShowFileMessage(message);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Disconnect();
            }
        }
        
        Message GetMessage()
        {
            byte[] protocolData = new byte[2];
            _stream.Read(protocolData, 0, 2);
            //if (protocolData[0] == 0) return new Message(null, 0, null, null);
            byte[] usernameBytes = new byte[protocolData[1]];
            _stream.Read(usernameBytes, 0, protocolData[1]);
            string username = Encoding.Unicode.GetString(usernameBytes, 0, protocolData[1]);
            if (protocolData[0] == (int) Message.MessageType.Disconnect)
            {
                Disconnect();
            }
            if (protocolData[0] == (int)Message.MessageType.Binary || protocolData[0] == (int)Message.MessageType.Image)
            {
                return new Message(null, (Message.MessageType)protocolData[0], username, GetFile());
            }
            
            byte[] result = new byte[0];
            int resInd = 0;
            byte[] buffer = new byte[_bufferSize];
            int length;
            do
            {
                length = _stream.Read(buffer, 0, buffer.Length);
                Array.Resize(ref result, result.Length + length);
                for (int i = 0; i < length; i++)
                    result[resInd + i] = buffer[i];
            } while (_stream.DataAvailable);
            return new Message(result, (Message.MessageType) protocolData[0], username, null);
        }
        
        NetworkFile GetFile()
        {
            if (!Directory.Exists("./Downloads")) Directory.CreateDirectory("./Downloads");
            byte[] lengthBytes = new byte[4];
            _stream.Read(lengthBytes, 0, 4);
            int filenameLength = BitConverter.ToInt32(lengthBytes,0);
            
            byte[] filenameBytes = new byte[filenameLength];
            _stream.Read(filenameBytes, 0, filenameLength);
            string filename = Encoding.Unicode.GetString(filenameBytes, 0, filenameLength);
            
            byte[] sizeBytes = new byte[4];
            _stream.Read(sizeBytes, 0, 4);
            int fileSize = BitConverter.ToInt32(sizeBytes,0);
            
            using (FileStream file = File.Create("./Downloads/" + filename))
            {
                int point = 0;
                byte[] buffer = new byte[_bufferSize];
                while (point != fileSize)
                {
                    int length = _stream.Read(buffer, 0, Math.Min(_bufferSize, fileSize - point));
                    file.Write(buffer, 0, length);
                    point += length;
                }
            }
            return new NetworkFile(filename, fileSize);
        }
        
        internal void Disconnect()
        {
            try
            {
                byte[] protocolData = {(byte)Message.MessageType.Disconnect, (byte)(Username.Length * 2)};
                _stream.Write(protocolData, 0, 2);
                _stream.Write(Encoding.Unicode.GetBytes(Username), 0, protocolData[1]);
            }
            catch (Exception e)
            {
                Thread.CurrentThread.Abort();
            }
            Thread.CurrentThread.Abort();
        }
    }
}