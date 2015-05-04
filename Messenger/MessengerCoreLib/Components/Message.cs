using System;
using System.Runtime.Serialization;

namespace MessengerCoreLib.Components
{
    [DataContract]
    public class Message 
    {
        public Message(int sender, int getter, string text, DateTime time)
        {
            SenderId = sender;
            RecipientId = getter;
            Text = text;
            Time = Time;
        }
        [DataMember]
        public int SenderId { get; set; }
        [DataMember]
        public int RecipientId { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public DateTime Time { get; set; }

    }
}
