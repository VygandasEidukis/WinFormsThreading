using System;
using System.Configuration;
using System.Data.OleDb;
using System.Threading.Tasks;
using WinformsThreading_Common.Models;

namespace WinformsThreading_DataAccess
{
    public class AccessContext
    {
        public string connectionString { get; set; }
        public OleDbConnection connection { get; set; } 

        public AccessContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["_accessDB"].ToString();
            connection = new OleDbConnection(connectionString);
        }

        public async Task Insert(ThreadDto dto)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = $@"INSERT INTO Thread(ThreadID, ExecutionTime,DataRow) values (@tID,@date,@text);";
                command.Parameters.Add("@tID", OleDbType.Integer).Value = dto.ThreadID;
                command.Parameters.Add("@date", OleDbType.Date).Value = dto.CurrentDate;
                command.Parameters.Add("@text", OleDbType.VarChar).Value = dto.Text;
                await command.ExecuteNonQueryAsync();
            } finally
            {
                connection.Close();
            }
            
        }
    }
}
