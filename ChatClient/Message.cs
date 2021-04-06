using System;

namespace ChatClient
{
    internal class Message
    {
        internal enum MessageType : byte
        {
            Nothing,
            Text,
            Image,
            Binary,
            Disconnect
        }
        
        internal byte[] Data { get; }
        internal string Username { get; }
        internal MessageType Type { get; }
        internal NetworkFile File { get; }
        
        public Message(byte[] data, MessageType type, string username, NetworkFile file)
        {
            Data = data;
            Type = type;
            Username = username;
            File = file;
        }
    }

}