using Microsoft.Data.Sqlite;
namespace SixthProject
{
    public class DatabaseInitializer
    {
        public static void Initialize()
        {
            //Connect to SQLite database file
            using var connection = new SqliteConnection("Data Source =Database/questionbank.db");
            connection.Open();

            // Execution of each command
            foreach(var cmd in commands)
            {
                using var commmand = new SqliteCommand(cmd, connection);
                command.ExecuteNonQuery();
            }
            //  using = X connection.Close() 
        }
    }
}
