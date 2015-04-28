using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MessengerCoreLib
{
    [Serializable]
    public class User : ISerializable
    {
        public User(int id, bool online, string name)
        {
            Username = name;
            Online = online;
            Id = id;
        }

        public string Username { get; set; }
        public bool Online { get; set; }
        public int Id { get; set; }

        public string UserStatus { get; set; }

        void ISerializable.GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            oInfo.AddValue("UserName", Username);
            oInfo.AddValue("Online", Online);
            oInfo.AddValue("UserID", Id);
            oInfo.AddValue("Status", UserStatus);
        }

        public bool Equals(User other)
        {
            return string.Equals(Username, other.Username) && Online.Equals(other.Online) && Id == other.Id;
        }
    }
}
