using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace DSED03.Data
{
    public static class Database
    {
        public static SQLiteConnection Con;
        public static string dbPath;
        public static string dbName;

        static Database()
        {
            dbName = "hangmanDB.sqlite";
            dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);
            if (dbPath != null)
            {
                Con = new SQLiteConnection(dbPath);
            }
        }

        public static List<Users> LoadUsers()
        {

            try
            {
                return Con.Table<Users>().ToList();
            }
            catch (Exception)
            {
                Con.CreateTable<Users>();
                return Con.Table<Users>().ToList();
            }
        }

        public static List<Users> LoadActiveUser()
        {
            try
            {
                return Con.Query<Users>($"SELECT * FROM Users WHERE active = 'true'").ToList();
            }
            catch (Exception)
            {
                Con.CreateTable<Users>();
                return Con.Query<Users>($"SELECT * FROM Users WHERE active = 'true'").ToList();
            }


        }

        public static List<Users> loginActiveUser(string username)
        {
            List<Users> user = Con.Query<Users>($"SELECT * FROM Users WHERE username = '{username}'").ToList();
            if (user.Count < 1)
            {
                CreateUser(username);
            }
            else
            {
                UpdateUser(user);
            }
            return LoadActiveUser();
        }

        public static void LogoutActiveUser(List<Users> activeUser)
        {
            try
            {
                var editData = new Users() { username = activeUser[0].username, active = "false", wins = activeUser[0].wins, loses = activeUser[0].loses, score = activeUser[0].score, id = activeUser[0].id };
                Con.Update(editData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Update Error:" + e.Message);
            }
        }

        public static void AddItem(string username, int wins, int loses)
        {
            try
            {
                var insertData = new tblLeaderboard() { Username = username, Wins = wins, Loses = loses };
                Con.Insert(insertData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error:" + e.Message);
            }
        }

        public static void CreateUser(string username)
        {
            Users newUser = new Users() { username = username, active = "true", wins = 0, loses = 0, score = 0 };
            Con.Insert(newUser);
        }

        public static void UpdateUser(List<Users> activeUser)
        {
            try
            {
                var editData = new Users() { username = activeUser[0].username, active = "true", wins = activeUser[0].wins, loses = activeUser[0].loses, score = activeUser[0].score, id = activeUser[0].id };

                Con.Update(editData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Update Error:" + e.Message);
            }
        }
    }
}