using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // DataTable
using MySql.Data.MySqlClient;
using DTO;

namespace DAO
{
    public class PlannerCodeDAO : DBConnect
    {
        private static string _Table = "planning_promisedate_planner_code";

        public int CountAll()
        {
            if (_connMain.State != ConnectionState.Open)
                _connMain.Open();
            var count = 0;
            DataTable dt = new DataTable();
            try
            {
                var sql = "SELECT count(*) FROM " + _Table + ";";
                MySqlCommand Sqlcmd = new MySqlCommand(sql, _connMain);
                //dt.Load(Sqlcmd.ExecuteReader());
                count = Convert.ToInt32(Sqlcmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                // xử lý lỗi tại đây
                Console.WriteLine("Count All Data Error: ");
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (_connMain.State == ConnectionState.Open)
                {
                    _connMain.Close(); // close connection
                }
            }

            return count;
        }

        // read all data
        public DataTable ReadAll()
        {
            if (_connMain.State != ConnectionState.Open)
                _connMain.Open();

            DataTable dt = new DataTable();
            try
            {
                var sql = "SELECT * FROM " + _Table + " ORDER BY id ASC;";
                MySqlCommand Sqlcmd = new MySqlCommand(sql, _connMain);
                dt.Load(Sqlcmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                // xử lý lỗi tại đây
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (_connMain.State == ConnectionState.Open)
                    _connMain.Close(); // close connection
            }

            return dt;
        }


        // read data condition
        public DataTable ReadCondition(string factory_code, string planner_code)
        {
            if (_connMain.State != ConnectionState.Open)
                _connMain.Open();

            DataTable dt = new DataTable();
            try
            {
                string sql = @"SELECT * FROM " + _Table + " WHERE factory_code='{0}' AND planner_code='{1}' ORDER BY id ASC;";
                string Query = string.Format(sql, factory_code, planner_code);
                MySqlCommand Sqlcmd = new MySqlCommand(Query, _connMain);
                dt.Load(Sqlcmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                // xử lý lỗi tại đây
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (_connMain.State == ConnectionState.Open)
                    _connMain.Close(); // close connection
            }

            return dt;
        }


    }
}
