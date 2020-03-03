using System;
using System.Collections.Generic;
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

        public async Task InsertMultiple(List<ThreadDto> dto)
        {
            try
            {
                connection.Open();
                foreach(var t in dto)
                {
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = $@"INSERT INTO Thread(ThreadID, ExecutionTime,DataRow) values (@tID,@date,@text)";
                    command.Parameters.Add("@tID", OleDbType.Integer).Value = t.ThreadID;
                    command.Parameters.Add("@date", OleDbType.Date).Value = t.CurrentDate;
                    command.Parameters.Add("@text", OleDbType.VarChar).Value = t.Text; 
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
            
        }
    }
}
