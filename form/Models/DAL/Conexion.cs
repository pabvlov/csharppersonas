using System;
using System.Data.SqlClient;

namespace form.Models.DAL
{
    public class Conexion
    {
        public static String ip { get; set; } = "localhost\\MSSQLSERVER";
        public static string username { get; set; } = "uwu";
        public static string password { get; set; } = "Pablo123!";
        public static string database { get; set; } = "master";
        //public string connectionString = "Server="+ ip + ";Database=" + database + ";User Id=" + username + ";Password=" + password + ";";

        public string GetConnectionString()
        {
            return "server=DESKTOP-G4D9G3N; database=master; integrated security=true";
            //return "Server=" + ip + ";Initial Catalog=" + database + ";User ID=" + username + ";Password='';Trusted_Connection=false;Encrypt=False;Connection Timeout=30;";
            //return "Server=MSSQLSERVER01;Database=master;Trusted_Connection=False;";
        }

    }
}
