using System;
using System.Runtime.Serialization;

namespace MessengerCoreLib.Components
{
    [DataContract]
    public class User 
    {
        public User(int id, bool online, string name)
        {
            Username = name;
            Online = online;
            Id = id;
        }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public bool Online { get; set; }
        [DataMember]
        public int Id { get; set; }
        
        public bool Equals(User other)
        {
            return string.Equals(Username, other.Username) && Online.Equals(other.Online) && Id == other.Id;
        }
    }
}
