using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInTheWoods.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LostInTheWoods.Factories
{
    // public class DbConnector
    // {
    //     static string server = "localhost";
    //     static string db = "lost_in_the_woods"; //Change to your schema name
    //     static string port = "3306"; //Potentially 8889
    //     static string user = "root";
    //     static string pass = "root";
    //     internal static IDbConnection Connection {
    //         get {
    //             return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
    //         }
    //     }
    // }
    public class TrailFactory : Controller, IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = @"
                server=localhost;
                userid=root;
                password=root;
                port=3306;
                database=lost_in_the_woods;
                SslMode=None;
                ";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public List<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                    dbConnection.Open();
                    return dbConnection.Query<Trail>("SELECT * FROM trails").ToList();
            }
        }
        public void Add(Trail trail)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO trails (name, length, description, longitude, latitude, elevation, created_at, updated_at) VALUES (@Name, @Length, @Description, @Longitude, @Latitude, @Elevation, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, trail);
            }
        }
        public Trail GetInfo(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

    }
}
