using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MessengerCoreLib.WorkWithBase
{
    public class DataBaseRequester : IRequester
    {
        public DataBaseGetter Execute(string request)
        {
            var command = new MySqlCommand
            {
                // какой язык ставит равно впритык?? Конечно же сквиэль
                Connection = new MySqlConnection("Database=" +    DataBaseLinker.DbName + ";" +
                                                 "Data Source=" + DataBaseLinker.DbHost + ";" +
                                                 "User Id=" +     DataBaseLinker.DbUser + ";" +
                                                 "Password=" +    DataBaseLinker.DbPass),
                CommandText = request
            };

            command.Connection.Open();

            var reader = command.ExecuteReader();

            var result = new List<List<object>>();
            var readable = false;

            while (reader.Read())
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
