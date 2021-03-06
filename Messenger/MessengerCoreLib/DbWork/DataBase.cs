﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MessengerCoreLib.Components;
using MessengerCoreLib.Interfaces;
using MySql.Data.MySqlClient;

namespace MessengerCoreLib.DbWork
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

        public IRequester Dbquery = new DataBaseRequester();

        // Проверка существования пользователя
        private bool CheckUser(string query)
        {
            var result = Dbquery.ExecuteRequest(query);
            
            return result.Readable;
        }


        // Проверка по имени
        public bool IfUserExists(string username)
        {
            return
                CheckUser("SELECT * FROM " + DataBaseLinker.DbPrefix + "users WHERE name='" +
                          MySqlHelper.EscapeString(username) + "'");
        }


        // Проверка по айди
        public bool IfUserExists(int id)
        {
            return CheckUser("SELECT * FROM " + DataBaseLinker.DbPrefix + "users WHERE id='" + id + "'");
        }


        // Вход пользователя в чат
        public User Login(string username)
        {
            // если пользователя нет в базе логинемся
            if (!IfUserExists(username))
            {
                Dbquery.ExecuteRequest("INSERT INTO " + DataBaseLinker.DbPrefix + "users (`name`) VALUES (\"" +
                                       MySqlHelper.EscapeString(username) +
                                       "\")");
            }
            else
            {
                // выбираем рефреш тайм
                var refreshtime =
                    Dbquery.ExecuteRequest("SELECT refreshtime FROM " + DataBaseLinker.DbPrefix + "users WHERE name='" +
                                           MySqlHelper.EscapeString(username) + "'");

                var hour = ((DateTime) refreshtime.DataResult[0][1]).Hour;
                var minute = ((DateTime) refreshtime.DataResult[0][1]).Minute;
                var day = ((DateTime) refreshtime.DataResult[0][1]).Day;

                Trace.WriteLine(hour);
                Trace.WriteLine(minute);
                Trace.WriteLine(day);

                var nowHour = DateTime.Now.Hour;
                var nowMinute = DateTime.Now.Minute;
                var nowDay = DateTime.Now.Day;

                // правильно или нет ????
                if (day == nowDay && nowHour == hour && Math.Abs(nowMinute - minute) < 15)
                    throw new Exception("User is already Online");

            }

            var result = Dbquery.ExecuteRequest("SELECT * FROM " + DataBaseLinker.DbPrefix + "users WHERE name='" + MySqlHelper.EscapeString(username) + "'");
            Trace.WriteLine(result.DataResult[0][1].ToString());

            return !result.Readable ? null : new User((int)result.DataResult[0][0], true, (string)result.DataResult[0][1].ToString());
        }


        // Получение всех пользователей чата
        public IEnumerable<User> GetUsers(int userId)
        {
            if (!IfUserExists(userId))
                return null;

            Dbquery.ExecuteRequest("UPDATE " + DataBaseLinker.DbPrefix + "users SET refreshtime = NOW() WHERE id='" + userId + "'");

            var result = Dbquery.ExecuteRequest("SELECT * FROM " + DataBaseLinker.DbPrefix + "users");

            return result.DataResult.Select(user => new User((int)user[0], (Int32)(DateTime.UtcNow.AddHours(4).Subtract((DateTime)user[2]).TotalSeconds) < 5, (string)user[1])).ToList();
        }


        // Добавление нового сообщения в базу данных
        public void AddMessage(Message message)
        {
            Dbquery.ExecuteRequest("INSERT INTO " + DataBaseLinker.DbPrefix + "messages (`sender`, `reciever`, `text`) VALUES (" + message.SenderId + ", " + message.RecipientId + ", \"" + MySqlHelper.EscapeString(message.Text) + "\")");
        }


        // Очистка сообщения из базы данных
        public void DeleteMessage(int messageId)
        {
            Dbquery.ExecuteRequest("DELETE FROM " + DataBaseLinker.DbPrefix + "messages WHERE id=" + messageId);
        }


        // Получение имени 
        public string GetUserName(int userId)
        {
            var result = Dbquery.ExecuteRequest("SELECT name FROM " + DataBaseLinker.DbPrefix + "users WHERE id=" + userId);

            return (!result.Readable) ? "NONAME" : (string)result.DataResult[0][0];
        }


        // Получение сообщений
        public IEnumerable<Message> GetMessages(int sender, int reciever)
        {
            var result =
                Dbquery.ExecuteRequest("SELECT `time`, `text` FROM " + DataBaseLinker.DbPrefix + "messages WHERE `reciever`=" + reciever + "AND `sender`=" + sender);
            var messages =
                result.DataResult.Select(
                    message => new Message(sender, reciever, (string)message[1], (DateTime)message[0])).ToList();


            //нужно ли хранить сообщения )))) 
            Dbquery.ExecuteRequest("DELETE FROM " + DataBaseLinker.DbPrefix + "messages WHERE `reciever`=" + reciever +
                            " AND `sender`=" + sender);

            return messages;
        }

        
    }
}
