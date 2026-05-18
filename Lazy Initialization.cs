using System;
using System.Data.SqlClient;

namespace Lazy_Demo
{
    class Database
    {
        public SqlConnection Connection { get; }

        public Database()
        {
            Console.WriteLine("Connecting to DB...");
            Connection = new SqlConnection("Server=.;Database=TestDB;");
            Console.WriteLine("DB initialized");
        }
    }

    class Program
    {
        static Lazy<Database> db = new Lazy<Database>(() => new Database());

        static void Main()
        {
            Console.WriteLine("Program started");

            Console.WriteLine("DB not created yet");

            var conn = db.Value.Connection;

            Console.WriteLine("DB is now ready");
        }
    }
}