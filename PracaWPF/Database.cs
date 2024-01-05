using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Input;
using System.Xml.Linq;
using System.Security.RightsManagement;
using PracaWPF.classes;
using System.Diagnostics.Contracts;
using System.Windows.Documents;

namespace PracaWPF
{
    public class Database
    {
        public static void InitializeDatabase()
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db");
            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                string tableCommand = "CREATE TABLE IF NOT EXISTS user (user_id INTEGER PRIMARY KEY AUTOINCREMENT,name TEXT NOT NULL,surname TEXT NOT NULL,birth_date TEXT NOT NULL,mail TEXT NOT NULL,telephone INTEGER NOT NULL,password_hash TEXT NOT NULL,is_admin INTEGER NOT NULL)";
                var createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                string tableCommand = "CREATE TABLE IF NOT EXISTS offer (offer_id INTEGER PRIMARY KEY AUTOINCREMENT,title TEXT NOT NULL,position TEXT NOT NULL,payment INTEGER NOT NULL,work_hours TEXT NOT NULL,responsibilities TEXT NOT NULL,requirements TEXT NOT NULL,benefits TEXT NOT NULL)";
                var createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }

        public static void CreateUser(User user)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                var insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO user (name, surname, birth_date, mail, telephone, password_hash, is_admin) VALUES(@name, @surname, @birth_date, @mail, @telephone, @password_hash, @is_admin)";

                insertCommand.Parameters.AddWithValue("@name", user.Name);
                insertCommand.Parameters.AddWithValue("@surname", user.Surname);
                insertCommand.Parameters.AddWithValue("@birth_date", user.BirthDate);
                insertCommand.Parameters.AddWithValue("@mail", user.Mail);
                insertCommand.Parameters.AddWithValue("@telephone", user.Telephone);
                insertCommand.Parameters.AddWithValue("@password_hash", user.Password);
                insertCommand.Parameters.AddWithValue("@is_admin", user.IsAdmin);
                insertCommand.ExecuteReader();
            }
        }

        public static void CreateOffer(Offer offer)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                var insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO offer(title, position, payment, work_hours, responsibilities, requirements, benefits) VALUES(@title, @position, @payment, @workHours, @responsibilities, @requirements, @benefits)";
                insertCommand.Parameters.AddWithValue("@title", offer.Title);
                insertCommand.Parameters.AddWithValue("@position", offer.Position);
                insertCommand.Parameters.AddWithValue("@payment", offer.Payment);
                insertCommand.Parameters.AddWithValue("@workHours", offer.WorkHours);
                insertCommand.Parameters.AddWithValue("@responsibilities", offer.Responsibilities);
                insertCommand.Parameters.AddWithValue("@requirements", offer.Requirements);
                insertCommand.Parameters.AddWithValue("@benefits", offer.Benefits);

                insertCommand.ExecuteNonQuery();
            }
        }



        public static List<User> ReadUser()
        {
            var entries = new List<User>();
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                string query = "SELECT * FROM user";
                var selectCommand = new SqliteCommand(query, db);

                SqliteDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();
                    user.Id = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.Surname = reader.GetString(2);
                    user.BirthDate = reader.GetString(3);
                    user.Mail = reader.GetString(4);
                    user.Telephone = reader.GetInt32(5);
                    user.Password = reader.GetString(6);
                    entries.Add(user);
                }
            }
            return entries;
        }

        public static User ReadUserByMail(string mail)
        {
            User user = null;
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                string query = "SELECT * FROM user WHERE Mail = @mail";
                var selectCommand = new SqliteCommand(query, db);
                selectCommand.Parameters.AddWithValue("@mail", mail);

                SqliteDataReader reader = selectCommand.ExecuteReader();

                if (reader.Read())
                {
                    user = new User();
                    user.Id = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.Surname = reader.GetString(2);
                    user.BirthDate = reader.GetString(3);
                    user.Mail = reader.GetString(4);
                    user.Telephone = reader.GetInt32(5);
                    user.Password = reader.GetString(6);
                }
            }
            return user;
        }

        public static List<Offer> ReadOffer()
        {
            var entries = new List<Offer>();
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                string query = "SELECT * FROM offer";
                var selectCommand = new SqliteCommand(query, db);

                SqliteDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Offer offer = new Offer();
                    offer.OfferId = reader.GetInt32(0);
                    offer.Title = reader.GetString(1);
                    offer.Position = reader.GetString(2);
                    offer.Payment = reader.GetInt32(3);
                    offer.WorkHours = reader.GetString(4);
                    offer.Responsibilities = reader.GetString(5);
                    offer.Requirements = reader.GetString(6);
                    entries.Add(offer);
                }
            }
            return entries;
        }

        public static void DeleteOffer(Offer offer)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                var deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;
                deleteCommand.CommandText = "DELETE FROM offer WHERE offer_id=@Id";

                deleteCommand.Parameters.AddWithValue("@Id", offer.OfferId);
                deleteCommand.ExecuteNonQuery();
            }
        }

        public static void DeleteUser(User user)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                var deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;
                deleteCommand.CommandText = "DELETE FROM user WHERE user_id=@Id";

                deleteCommand.Parameters.AddWithValue("@Id", user.Id);
                deleteCommand.ExecuteNonQuery();
            }
        }

        public static Offer OfferInfo(int id)
        {
            Offer offer = null;
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                string query = "SELECT * FROM offer WHERE offer_id=@Id";
                var selectCommand = new SqliteCommand(query, db);
                selectCommand.Parameters.AddWithValue("@Id", id);

                SqliteDataReader reader = selectCommand.ExecuteReader();

                if (reader.Read())
                {
                    offer = new Offer();
                    offer.OfferId = reader.GetInt32(0);
                    offer.Title = reader.GetString(1);
                    offer.Position = reader.GetString(2);
                    offer.Payment = reader.GetInt32(3);
                    offer.WorkHours = reader.GetString(4);
                    offer.Responsibilities = reader.GetString(5);
                    offer.Requirements = reader.GetString(6);
                }
            }
            return offer;
        }

        public static User UserInfo(int id)
        {
            User user = null;
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db");

            using (var db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                string query = "SELECT * FROM user WHERE user_id=@Id";
                var selectCommand = new SqliteCommand(query, db);
                selectCommand.Parameters.AddWithValue("@Id", id);

                SqliteDataReader reader = selectCommand.ExecuteReader();

                if (reader.Read())
                {
                    user = new User();
                    user.Id = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.Surname = reader.GetString(2);
                    user.BirthDate = reader.GetString(3);
                    user.Mail = reader.GetString(4);
                    user.Telephone = reader.GetInt32(5);
                    user.Password = reader.GetString(6);
                }
            }
            return user;
        }
    }
}
