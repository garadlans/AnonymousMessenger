using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MessengerCoreLib.WorkWithBase
{
    /*
     
     
     SELECT 
       [DISTINCT | DISTINCTROW | ALL]
       select_expression,...
   [FROM table_references]
     [WHERE where_definition]
     [GROUP BY {unsigned_integer | col_name | formula}]
     [HAVING where_definition]
     [ORDER BY {unsigned_integer | col_name | formula} [ASC | DESC], ...]

     */
    public class DataBase : IUsersStorage
    {
        
        // Интерфейс для базы данных
       
        public IRequester DBquery = new DataBaseRequester();

        // Проверка существования пользователя
        private bool CheckUser(string query)
        {
            var result = DBquery.Execute(query);
            return result.Readable;
        }

        
        /// Проверка по имени
        public bool IfUserExists(string username)
        {
            return
                CheckUser("SELECT * FROM " + DataBaseLinker.DBPrefix + "users WHERE name='" +
                          MySqlHelper.EscapeString(username) + "'");
        }

      
        /// Проверка по айди
        public bool IfUserExists(int id)
        {
            return CheckUser("SELECT * FROM " + DataBaseLinker.DBPrefix + "users WHERE id='" + id + "'");
        }

       
        /// Вход пользователя в чат
        public User Login(string username)
        {
            if (!IfUserExists(username))
                DBquery.Execute("INSERT INTO " + DataBaseLinker.DBPrefix + "users (`name`) VALUES (\"" + MySqlHelper.EscapeString(username) +
                                "\")");
            //else
            //{
            //    var refreshtime = DBquery.Execute("SELECT refreshtime FROM " + DataBaseLinker.DBPrefix + "users WHERE name='" + MySqlHelper.EscapeString(username) + "'");
            //    if ((IFIFIFIFIF)
            //        throw new Exception("Already Online!");
            //}

            var result = DBquery.Execute("SELECT * FROM " + DataBaseLinker.DBPrefix + "users WHERE name='" + MySqlHelper.EscapeString(username) + "'");

            return !result.Readable ? null : new User((int)result.DataResult[0][0], true, (string)result.DataResult[0][1].ToString());
        }

        
        /// Получение всех пользователей чата
        public IEnumerable<User> GetUsers(int userId)
        {
            if (!IfUserExists(userId))
                return null;

            DBquery.Execute("UPDATE " + DataBaseLinker.DBPrefix + "users SET refreshtime = NOW() WHERE id='" + userId + "'");

            var result = DBquery.Execute("SELECT * FROM " + DataBaseLinker.DBPrefix + "users");

            return result.DataResult.Select(user => new User((int)user[0], (Int32)(DateTime.UtcNow.AddHours(4).Subtract((DateTime)user[2]).TotalSeconds) < 5, (string)user[2])).ToList();
        }
           
        

       
        /// Добавление нового сообщения в базу данных
        public void AddMessage(Message message)
        {
            DBquery.Execute("INSERT INTO " + DataBaseLinker.DBPrefix + "messages (`sender`, `reciever`, `text`) VALUES (" + message.SenderId + ", " + message.RecipientId + ", \"" + MySqlHelper.EscapeString(message.Text) + "\")");
        }

        
        // Очистка сообщения из базы данных
        public void DeleteMessage(int messageId)
        {
            DBquery.Execute("DELETE FROM " + DataBaseLinker.DBPrefix + "messages WHERE id=" + messageId);
        }

       
        // Получение имени 
        public string GetUserName(int userId)
        {
            var result = DBquery.Execute("SELECT name FROM " + DataBaseLinker.DBPrefix + "users WHERE id=" + userId);

            return (!result.Readable) ? "NONAME" : (string) result.DataResult[0][0];
        }

       
        // Получение сообщений
        public IEnumerable<Message> GetMessages(int sender, int reciever)
        {
            var result =
                DBquery.Execute("SELECT `time`, `text` FROM " + DataBaseLinker.DBPrefix + 
                                "messages WHERE `reciever`=" + reciever + 
                                " AND `sender`=" + sender);
            var messages =
                result.DataResult.Select(
                    message => new Message(sender, reciever, (string) message[1], (DateTime) message[0] )).ToList();

            DBquery.Execute("DELETE FROM " + DataBaseLinker.DBPrefix + "messages WHERE `reciever`=" + reciever +
                            " AND `sender`=" + sender);

            return messages;
        }
    }
}
