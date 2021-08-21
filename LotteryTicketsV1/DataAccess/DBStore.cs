using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            this.connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;SSL Mode=none");
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

        public MySqlDataReader getDataReader(string sqlText)
        {
            sqlText = "SELECT * FROM lotteryticketsdb.tickets";
            MySqlCommand cmd = new MySqlCommand(sqlText, this.connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public void disconnect()
        {
            this.connection.Close();
        }
    }
}
