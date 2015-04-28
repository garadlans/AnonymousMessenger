using System;
using System.Collections.Generic;
using MessengerCoreLib.DbWork;
using Moq;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace MessengerCoreTests
{
    [TestFixture]
    public class Sample
    {
        [Test]
        public void DayabaseTestINSERT()
        {

            var DbName = "Messenger";
            var DbHost = "localhost";
            var DbUser = "root";
            var DbPass = "1099";
            var DbPrefix = "";
            
            var command = new MySqlCommand
            {
                // какой язык ставит равно впритык?? Конечно же сквиэль
                Connection = new MySqlConnection("Database=" +DbName + ";" +
                                                 "Data Source=" + DbHost + ";" +
                                                 "User Id=" + DbUser + ";" +
                                                 "Password=" + DbPass),
                CommandText = "INSERT INTO `messenger`.`users` (`name`) VALUES ('Name');" 
            };

            command.Connection.Open();

            var reader = command.ExecuteReader();
            Console.WriteLine(reader);

        }


        [Test]
        public void DayabaseTestGetName()
        {

            var DbName = "Messenger";
            var DbHost = "localhost";
            var DbUser = "root";
            var DbPass = "1099";
            var DbPrefix = "";

            var command = new MySqlCommand
            {
                // какой язык ставит равно впритык?? Конечно же сквиэль
                Connection = new MySqlConnection("Database=" + DbName + ";" +
                                                 "Data Source=" + DbHost + ";" +
                                                 "User Id=" + DbUser + ";" +
                                                 "Password=" + DbPass),
                CommandText = "SELECT name FROM " + DataBaseLinker.DbPrefix + "users WHERE id=12"
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

            Console.WriteLine(result[0][0].ToString());

        }
    }

}
