using System;
using System.Runtime.Serialization;

namespace MessengerCoreLib
{
    [Serializable]
    public class Message : ISerializable
    {
        public Message(int sender, int getter, string text, DateTime time)
        {
            SenderId = sender;
            RecipientId = getter;
            Text = text;
            Time = Time;
        }

        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        void ISerializable.GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            oInfo.AddValue("SenderId", SenderId);
            oInfo.AddValue("RecipientId", RecipientId);
            oInfo.AddValue("Text", Text);
            oInfo.AddValue("Time", Time.ToShortDateString() + "-" + Time.ToLongTimeString());
        }
    }
}