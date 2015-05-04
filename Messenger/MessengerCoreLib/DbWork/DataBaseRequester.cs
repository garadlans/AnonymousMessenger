using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MessengerCoreLib.DbWork
{
    class DataBaseRequester : IRequester
    {
        public DataBaseGetter ExecuteRequest(string request)
        {
            var connetionString = "Database=" + DataBaseLinker.DbName + ";" +
                                  "Data Source=" + DataBaseLinker.DbHost + ";" +
                                  "User Id=" + DataBaseLinker.DbUser + ";" +
                                  "Password=" + DataBaseLinker.DbPass;

            var command = new MySqlCommand
            {
                // какой язык ставит равно впритык?? Конечно же сквиэль
                Connection = new MySqlConnection(connetionString),
                CommandText = request
            };

            command.Connection.Open(); //TODO 

            var reader = command.ExecuteReader();

            var result = new List<List<object>>();
            var readable = false;

            for (; reader.Read(); )
            {
                readable = true;

                var current = new List<object>();
                for (var i = 0; i < reader.FieldCount; ++i)
                    current.Add(reader.GetValue(i));

                result.Add(current);

            }

            command.Connection.Close();

            return new DataBaseGetter(result, readable);
        }
    }
}
