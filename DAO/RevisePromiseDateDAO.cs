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
    public class RevisePromiseDateDAO : DBConnect
    {
        private static string _Table = "planning_promisedate_revise";

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
                var sql = "SELECT * FROM " + _Table + " ORDER BY updated_date ASC;";
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

        // add item
        public bool Add22(PromiseDateReviseDTO Revise)
        {
            try
            {
                // connecting
                _connMain.Open();

                // Query string 
                string colsName = "(status, OU, order_number, line_number, so_line, cust_po_number, customer_item, item, qty, ordered_date, request_date, promise_date, ship_to_customer, bill_to_customer, sold_to_customer, cs, order_type_name, flow_status_code, planner_code, production_method, production_line, packing_instr, packing_instructions, shipment_number, makebuy, sample, updated_by_name, updated_by_ip )";

                string colsVal = "";
                for (int i=0;i<28;i++ )
                {
                    colsVal += ",'{"+i+"}'";
                }

                // xóa ký tự đầu tiên (dấu ',')
                colsVal = colsVal.TrimStart(','); 
                
                string sql = @"INSERT INTO " + _Table + colsName +" VALUES ("+ colsVal + ");";
                string Query = string.Format(sql, Revise.Status, Revise.Ou, Revise.OrderNumber, Revise.LineNumber, Revise.SoLine, Revise.CustPoNumber, Revise.CustomerItem, Revise.Item, Revise.Qty, Revise.OrderedDate, Revise.RequestDate, Revise.PromiseDate, Revise.ShipToCustomer, Revise.BillToCustomer, Revise.SoldToCustomer, Revise.Cs, Revise.OrderTypeName, Revise.FlowStatusCode, Revise.PlannerCode, Revise.ProductionMethod, Revise.ProductionLine, Revise.PackingInstr, Revise.PackingInstructions, Revise.ShipmentNumber, Revise.Makebuy, Revise.Sample, Revise.UpdatedByName, Revise.UpdatedByIp);
                // Console.WriteLine("Insert: " + Query);
                MySqlCommand Sqlcmd = new MySqlCommand(Query, _connMain);

                // Query and check
                Sqlcmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                // xử lý ngoại lệ
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
            finally
            {
                // Close connect
                _connMain.Close();
            }

            return false;

        }

        // add item
        public int Add(string DataFile)
        {
            var count = 0;
            try
            {
                // connecting
                if (_connMain.State != ConnectionState.Open)
                    _connMain.Open();

                Console.Write("Connected to database... "); // 3

                var check = true;

                // Kiểm tra nếu có dữ liệu thì xóa hết
                if (CountAll() > 0)
                {
                    //Console.Write("Deleting old data... ");
                    // delete all data in vnso talbe before This be insert
                    check = Truncate();

                    //Console.Write(check+"...");
                }


                // check is true, get data and insert
                if (check)
                {
                    Console.Write("Updating..."); // 4
                    // Insert data ... 
                    MySqlBulkLoader Loader = new MySqlBulkLoader(_connMain);
                    Loader.CharacterSet = "utf8";
                    Loader.TableName = _Table; // Vị trí bảng cần lưu
                    Loader.FieldTerminator = "\t"; // tách cột bằng ký tự "\t" (ký tự tab)
                    Loader.LineTerminator = "\n"; // tách dòng bằng ký tự "\n" (ký tự xuống dòng)
                    Loader.FileName = DataFile;
                    Loader.NumberOfLinesToSkip = 0;
                    Loader.Local = true;
                    count = Loader.Load();

                    return count;
                    // xóa file sau khi hoàn thành
                    // File.Delete(DataFile);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ");
                Console.WriteLine(ex.ToString()); // xử lý ngoại lệ
            }
            finally
            {
                if (_connMain.State == ConnectionState.Open)
                    _connMain.Close(); // Close connect
            }

            return count;

        }

        // delete item
        public bool Delete(PromiseDateReviseDTO Revise)
        {
            try
            {
                // connecting
                if (_connMain.State != ConnectionState.Open)
                    _connMain.Open();

                // Query string 
                string sql = "DELETE FROM " + _Table + " WHERE order_number={0} AND line_number={1} ;";
                string Query = string.Format(sql, Revise.OrderNumber, Revise.LineNumber);
                MySqlCommand Sqlcmd = new MySqlCommand(Query, _connMain);

                // Query and check
                Sqlcmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                // xử lý ngoại lệ
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Close connect
                _connMain.Close();
            }

            return false;
        }


        // add item
        public bool isAlreadyExist(PromiseDateReviseDTO Revise)
        {
            DataTable dt = new DataTable();

            try
            {
                // connecting
                if (_connMain.State != ConnectionState.Open)
                    _connMain.Open();

                string sql = @"SELECT order_number FROM " + _Table + " WHERE `order_number`={0} AND line_number={1};";
                string Query = string.Format(sql, Revise.OrderNumber, Revise.LineNumber);

                // Query and check
                MySqlCommand Sqlcmd = new MySqlCommand(Query, _connMain);
                dt.Load(Sqlcmd.ExecuteReader());

                int numberOfResults = dt.Rows.Count;

                if (numberOfResults > 0) return true;

            }
            catch (Exception ex)
            {
                // xử lý ngoại lệ
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
            finally
            {
                // Close connect
                _connMain.Close();
            }

            return false;

        }

        // truncate table
        public bool Truncate()
        {
            bool Result = false;
            try
            {
                int count = this.CountAll();

                if (this.CountAll() == 0)
                {
                    return true;
                }
                else
                {
                    // connecting
                    if (_connMain.State != ConnectionState.Open)
                        _connMain.Open();

                    // truncate
                    string sql = @"TRUNCATE TABLE " + _Table + ";";
                    MySqlCommand Sqlcmd = new MySqlCommand(string.Format(sql), _connMain);

                    // Query and check
                    Sqlcmd.ExecuteNonQuery();
                    Result = true;
                }

            }
            catch (Exception ex)
            {
                // xử lý ngoại lệ
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
            finally
            {
                // Close connect
                if (_connMain.State == ConnectionState.Open)
                    _connMain.Close();
            }

            return Result;

        }


        


    }
}
