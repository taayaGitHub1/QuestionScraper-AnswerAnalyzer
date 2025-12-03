using Emgu.CV.CvEnum;
using iText.Layout.Element;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Data.Sqlite;
using System.Security.Cryptography.Xml;
using System.Xml;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
namespace SixthProject
{
    public class DatabaseInitializer
    {
        public static void Initialize()
        {
            //Connect to SQLite database file
            using var connection = new SqliteConnection("Data Source =Database/questionbank.db");
            connection.Open();

            string[] commands = {
                //--subjects table
               @"CREATE TABLE IF NOT EXISTS subjects{
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL UNIQUE
               };",
    
                //--questions table
                @"CREATE TABLE IF NOT EXISTS questions{
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
	                subjectId INTEGER,
                    questionText TEXT NOT NULL,
	                FOREIGN KEY(subjectId) REFERENCES subjects(id)
                };"
             };

            // Execution of each command
            foreach (var cmd in commands)
            {
                using var command = new SqliteCommand(cmd, connection);
                command.ExecuteNonQuery();
            }
            //  using = X connection.Close() 
        }
    }
}
