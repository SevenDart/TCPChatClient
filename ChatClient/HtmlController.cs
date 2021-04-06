using System.IO;
using System.Text;
using System.Threading;

namespace ChatClient
{
    public class HtmlController
    {
        private string _name = "chat.html";

        private int _point = 72;
        private Mutex mutex = new Mutex();
        internal HtmlController()
        {
            using (FileStream stream = File.Create(_name))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write("<!DOCTYPE html>" +
                                 "<html lang=\"ru\">" +
                                 "<head>" +
                                 "<meta charset=\"UTF-8\">" +
                                 "</head>" +
                                 "<body>" +
                                 "</body>" +
                                 "</html>");
                }
            }
        }

        internal void AddMessage(Message message)
        {
            mutex.WaitOne();
            switch (message.Type)
            {
                case Message.MessageType.Text:
                    AddTextMessage(message);
                    break;
                case Message.MessageType.Image:
                    AddImageMessage(message);
                    break;
                case Message.MessageType.Binary:
                    AddFileMessage(message);
                    break;
            }
            mutex.ReleaseMutex();
        }

        void AddTextMessage(Message message)
        {
            using (FileStream stream = File.Open(_name, FileMode.Open))
            {
                stream.Seek(_point, SeekOrigin.Begin);
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string username = message.Username + ": ";
                    writer.Write(username);
                    string text = Encoding.Unicode.GetString(message.Data, 0, message.Data.Length) + "<br>";
                    writer.Write(text);
                    _point += username.Length + text.Length;
                    writer.Write("</body></html>");
                    writer.Flush();
                }
                stream.Close();
            }
        }

        void AddImageMessage(Message message)
        {
            using (FileStream stream = File.Open(_name, FileMode.Open))
            {
                stream.Seek(_point, SeekOrigin.Begin);
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string username = message.Username + ":" + "<br>";
                    writer.Write(username);
                    string text = "<img src=\".\\Downloads\\" + message.File.Filename + "\" width=300><br>";
                    writer.Write(text);
                    _point += username.Length + text.Length;
                    writer.Write("</body></html>");
                    writer.Flush();
                }
                stream.Close();
            }
        }

        void AddFileMessage(Message message)
        {
            using (FileStream stream = File.Open(_name, FileMode.Open))
            {
                stream.Seek(_point, SeekOrigin.Begin);
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string username = message.Username + ":" + "<br>";
                    writer.Write(username);
                    string text = "<a href=\".\\Downloads\\" + message.File.Filename + "\">"+ message.File.Filename +"</a><br>";
                    writer.Write(text);
                    _point += username.Length + text.Length;
                    writer.Write("</body></html>");
                    writer.Flush();
                }
            }
            
        }

        
        
    }
}