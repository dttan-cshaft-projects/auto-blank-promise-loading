using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using System.Data;
using System.IO;
using DTO;
using DAO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BUS
{
    public class RevisePromiseDateBUS
    {
        // khai báo các biến sử dụng
        private static string DataFile = "Data.csv";


        private static AutoloadDAO Auto = new AutoloadDAO();
        private static VnsoDAO Vnso = new VnsoDAO();
        private static RevisePromiseDateDAO RevisePD = new RevisePromiseDateDAO();
        private static PlannerCodeDAO PlannerCode = new PlannerCodeDAO();

        // read all data
        public string GetSample(string packing)
        {
            string sample = "";

            for (int i = 0; i < packing.Length; i++)
            {
                if (Char.IsDigit(packing[i]))
                    sample += packing[i];
                else sample = "";
            }


            return sample;

        }

        // read all data
        public DataTable ReadAll()
        {
            return RevisePD.ReadAll();
        }

        // read pd empty data
        public DataTable ReadRevisePD()
        {
            return Vnso.ReadRevisePD();
        }

        public string ProductionLineList(DataTable Data )
        {

            string productionLine = "";
            foreach (DataRow row in Data.Rows)
            {
                productionLine = (row["production_line"].ToString().Trim()).ToUpper();
                break;
                
            }
            return productionLine;
        }

        
        // add data
        public int AddRevisePD()
        {
            // get PD empty data from automail
            DataTable Revise = ReadRevisePD();

            // int count = Revise.Rows.Count;

            Console.Write("Revise Update: Start... "); // 1

            // Xóa file Automail data nếu đã tồn tại
            if (File.Exists(DataFile)) File.Delete(DataFile);

            var result = 0;
            if (this.GetSourceFile(Revise))
            {
                Console.Write("Get File success ..."); // 2
                result = RevisePD.Add(DataFile);
            } else
            {
                Console.WriteLine("Errrrr");
            }

            return result;
        }


        // Get full source file: join from Automail files
        public bool GetSourceFile(DataTable Revise)
        {
            try
            {
                // Mở file đích muốn ghi dữ liệu
                using (StreamWriter writer = new StreamWriter(DataFile, true))
                {
                    //string NewLine = "";
                    //NewLine += "id" + "\t";
                    //NewLine += "status" + "\t";
                    //NewLine += "OU" + "\t";
                    //NewLine += "order_number" + "\t";
                    //NewLine += "line_number" + "\t";
                    //NewLine += "so_line" + "\t";

                    //NewLine += "customer_po_number" + "\t";
                    //NewLine += "customer_item" + "\t";
                    //NewLine += "item" + "\t";
                    //NewLine += "qty" + "\t";
                    //NewLine += "ordered_date" + "\t";

                    //NewLine += "request_date" + "\t";
                    //NewLine += "promise_date" + "\t";
                    //NewLine += "ship_to_customer" + "\t";
                    //NewLine += "bill_to_customer" + "\t";
                    //NewLine += "sold_to_customer" + "\t";

                    //NewLine += "cs" + "\t";
                    //NewLine += "order_type_name" + "\t";
                    //NewLine += "flow_status_code" + "\t";
                    //NewLine += "planner_code" + "\t";
                    //NewLine += "production_method" + "\t";

                    //NewLine += "production_ine" + "\t";
                    //NewLine += "packing_nstr" + "\t";
                    //NewLine += "packing_instructions" + "\t";
                    //NewLine += "shipment_number" + "\t";
                    //NewLine += "make_buy" + "\t";

                    //NewLine += "sample" + "\t";

                    //writer.WriteLine(NewLine);

                    int id = 0;
                    foreach (DataRow row in Revise.Rows)
                    {
                        id++;

                        // get data
                        string plannerCode = row["PLANNER_CODE"].ToString();
                        string orderNumber = row["ORDER_NUMBER"].ToString();
                        string lineNumber = row["LINE_NUMBER"].ToString();
                        string soLine = orderNumber + "-" + lineNumber;

                        string customerPoNumber = row["CUST_PO_NUMBER"].ToString();
                        customerPoNumber = (customerPoNumber.IndexOf("'") != -1) ? Regex.Escape(customerPoNumber).Replace("'", "\\'") : customerPoNumber;

                        string customerItem = row["CUSTOMER_ITEM"].ToString();
                        customerItem = (customerItem.IndexOf("'") != -1) ? Regex.Escape(customerItem).Replace("'", "\\'") : customerItem;
                        string item = row["ITEM"].ToString();

                        string qty = row["QTY"].ToString().Trim();

                        DateTime orderedDateTmp = DateTime.Parse(row["ORDERED_DATE"].ToString());
                        string orderedDate = orderedDateTmp.ToString("yyyy-MM-dd");

                        DateTime requestDateTmp = DateTime.Parse(row["REQUEST_DATE"].ToString());
                        string requestDate = requestDateTmp.ToString("yyyy-MM-dd");

                        string promiseDate = "";

                        string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        DateTime updatedDate = DateTime.Parse(currentDate);

                        string shipToCustomer = row["SHIP_TO_CUSTOMER"].ToString();
                        shipToCustomer = (shipToCustomer.IndexOf("'") != -1) ? Regex.Escape(shipToCustomer).Replace("'", "\\'") : shipToCustomer;

                        string billToCustomer = row["BILL_TO_CUSTOMER"].ToString();
                        billToCustomer = (billToCustomer.IndexOf("'") != -1) ? Regex.Escape(billToCustomer).Replace("'", "\\'") : billToCustomer;

                        string soldToCustomer = row["SOLD_TO_CUSTOMER"].ToString();
                        soldToCustomer = (soldToCustomer.IndexOf("'") != -1) ? Regex.Escape(soldToCustomer).Replace("'", "\\'") : soldToCustomer;

                        string cs = Regex.Escape(row["CS"].ToString());

                        string orderTypeName = Regex.Escape(row["ORDER_TYPE_NAME"].ToString());
                        string flowStatusCode = Regex.Escape(row["FLOW_STATUS_CODE"].ToString());
                        string productionMethod = Regex.Escape(row["PRODUCTION_METHOD"].ToString());

                        string packingInstr = row["PACKING_INSTR"].ToString();
                        packingInstr = (packingInstr.IndexOf("'") != -1) ? Regex.Escape(packingInstr).Replace("'", "\\'") : packingInstr;

                        string packingInstructions = row["PACKING_INSTRUCTIONS"].ToString();
                        packingInstructions = (packingInstructions.IndexOf("'") != -1) ? Regex.Escape(packingInstructions).Replace("'", "\\'") : packingInstructions;

                        string sample = (GetSample(packingInstructions).Length == 8) ? GetSample(packingInstructions) : "";

                        string shipmentNumber = Regex.Escape(row["SHIPMENT_NUMBER"].ToString());
                        string makeBuy = Regex.Escape(row["MAKEBUY"].ToString());

                        // theo yêu cầu từ Dung.Phan nối 2 cột LINE_NUMBER và SHIPMENT_NUMBER
                        lineNumber = lineNumber + '.' + shipmentNumber;

                        // check OU is VN or BNH
                        string OU = (plannerCode.IndexOf("BNH") != -1) ? "BNH" : "VN";

                        string factory_code = (OU == "VN") ? "LH" : "BN";

                        // get planner code 
                        DataTable PlannerCodeData = PlannerCode.ReadCondition(factory_code, plannerCode);

                        // get production line 
                        string productionLine = this.ProductionLineList(PlannerCodeData);

                        string status = "0";

                        string NewLine = "";
                        NewLine += id + "\t";
                        NewLine += status + "\t";
                        NewLine += OU + "\t";
                        NewLine += orderNumber + "\t";
                        NewLine += lineNumber + "\t";
                        NewLine += soLine + "\t";

                        NewLine += customerPoNumber + "\t";
                        NewLine += customerItem + "\t";
                        NewLine += item + "\t";
                        NewLine += qty + "\t";
                        NewLine += orderedDate + "\t";

                        NewLine += requestDate + "\t";
                        NewLine += promiseDate + "\t";
                        NewLine += shipToCustomer + "\t";
                        NewLine += billToCustomer + "\t";
                        NewLine += soldToCustomer + "\t";

                        NewLine += cs + "\t";
                        NewLine += orderTypeName + "\t";
                        NewLine += flowStatusCode + "\t";
                        NewLine += plannerCode + "\t";
                        NewLine += productionMethod + "\t";

                        NewLine += productionLine + "\t";
                        NewLine += packingInstr + "\t";
                        NewLine += packingInstructions + "\t";
                        NewLine += shipmentNumber + "\t";
                        NewLine += makeBuy + "\t";

                        NewLine += sample + "\t";

                        writer.WriteLine(NewLine);


                    }

                    //close file
                    writer.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }









    }
    
}
