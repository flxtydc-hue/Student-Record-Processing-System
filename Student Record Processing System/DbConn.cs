using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Student_Record_Processing_System
{
    public static class DbConn
    {
        public const string ConnectionString = "server=localhost;user id=root;password=mingyu0406;database=student_record;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }


        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);

                var sb = new StringBuilder();
                foreach (byte b in hash) sb.Append(b.ToString("x2"));   // lowercase hex
                return sb.ToString();
            }
        }
    }
}
