using System;
using System.Collections.Generic;
using DbConnection;

namespace Simple_CRUD_with_MySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build a Read function that displays all current users information when the app starts and after every insert.
            SelectUsersFromDB();
            CreateUserFromTerminal();
        }

        static void SelectUsersFromDB()
        {
            List<Dictionary<string, object>> users = DbConnector.Query("SELECT * FROM users");
            Console.WriteLine("Current users:");
            foreach(var user in users)
            {
                Console.WriteLine($"{user["FirstName"]} {user["LastName"]} {user["FavoriteNumber"]}");
            }
        }
        static void CreateUserFromTerminal()
        {
            Console.WriteLine("Enter your first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter your favorite number:");
            string favoriteNumber = Console.ReadLine();
            // Console.WriteLine($"{firstName} {lastName} {favoriteNumber}");

            string insertQuery = $"INSERT INTO users (FirstName, LastName, FavoriteNumber) VALUES ('{firstName}', '{lastName}', '{favoriteNumber}')";
            DbConnector.Execute(insertQuery);
            SelectUsersFromDB();
        }
    }
}
