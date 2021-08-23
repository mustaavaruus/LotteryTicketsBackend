using LotteryTicketsV1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryTicketsV1.DataAccess
{
    public class DBStore
    {
        private MySqlConnection connection;


        public DBStore()
        {
            this.connection = new MySqlConnection("datasource=127.0.0.1;Initial Catalog=lotteryticketsrybakovv2;port=3306;username=root;password=1234;SSL Mode=none");
        }

        public DBStore(string connectionString)
        {
            this.connection = new MySqlConnection(connectionString);
        }

        public void connect()
        {
            this.connection.Open();
        }

        public void execute(string sqlText)
        {
            //sqlText = "INSERT INTO lotteryticketsdb.tickets(number, circulation, choosed) VALUES ('b7f009b4-0281-11ec-9a03-0242ac130003', 1 , 2)";
            MySqlCommand cmd = new MySqlCommand(sqlText, this.connection);
            cmd.ExecuteNonQuery();
        }

        public void executeSP(string procedureName, List<ProcedureParameter> parameters)
        {

            //sqlText = "INSERT INTO lotteryticketsdb.tickets(number, circulation, choosed) VALUES ('b7f009b4-0281-11ec-9a03-0242ac130003', 1 , 2)";
            MySqlCommand cmd = new MySqlCommand(procedureName, this.connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Clear();

            for (var i = 0; i < parameters.Count; i++)
            {
                cmd.Parameters.AddWithValue(parameters[i].key, parameters[i].value);
            }
            
            cmd.ExecuteNonQuery();
        }

        public MySqlDataReader getDataReader(string procedureName)
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, this.connection);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public MySqlDataReader getDataReaderSP(string procedureName, List<String> parameters)
        {
            procedureName = "get_all_tickets";
            MySqlCommand cmd = new MySqlCommand(procedureName, this.connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public void disconnect()
        {
            this.connection.Close();
        }
    }
}
