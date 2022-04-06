using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PromiseDateReviseDTO
    {
        private int status;
        private string OU;
        private string order_number;
        private string line_number;
        private string so_line;

        private string cust_po_number;
        private string customer_item;
        private string item;
        private string qty;
        private string ordered_date;
        private string request_date;
        private string promise_date;
        private string ship_to_customer;
        private string bill_to_customer;
        private string sold_to_customer;
        private string cs;
        private string order_type_name;
        private string flow_status_code;
        private string planner_code;
        private string production_method;
        private string production_line;
        private string packing_instr;
        private string packing_instructions;
        private string shipment_number;
        private string makebuy;

        private string sample;
        private string updated_by_name;
        private string updated_by_ip;

        private DateTime updated_date;

        // status
        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        // OU
        public string Ou
        {
            get
            {
                return OU;
            }

            set
            {
                OU = value;
            }
        }

        // production_line
        public string OrderNumber
        {
            get
            {
                return order_number;
            }

            set
            {
                order_number = value;
            }
        }

        // line_number
        public string LineNumber
        {
            get
            {
                return line_number;
            }

            set
            {
                line_number = value;
            }
        }

        // so_line
        public string SoLine
        {
            get
            {
                return so_line;
            }

            set
            {
                so_line = value;
            }
        }

        // cust_po_number
        public string CustPoNumber
        {
            get
            {
                return cust_po_number;
            }

            set
            {
                cust_po_number = value;
            }
        }

        // customer_item
        public string CustomerItem
        {
            get
            {
                return customer_item;
            }

            set
            {
                customer_item = value;
            }
        }

        // item
        public string Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }

        // qty
        public string Qty
        {
            get
            {
                return qty;
            }

            set
            {
                qty = value;
            }
        }

        // ordered_date
        public string OrderedDate
        {
            get
            {
                return ordered_date;
            }

            set
            {
                ordered_date = value;
            }
        }

        // request_date
        public string RequestDate
        {
            get
            {
                return request_date;
            }

            set
            {
                request_date = value;
            }
        }

        // promise_date
        public string PromiseDate
        {
            get
            {
                return promise_date;
            }

            set
            {
                promise_date = value;
            }
        }

        // ship_to_customer
        public string ShipToCustomer
        {
            get
            {
                return ship_to_customer;
            }

            set
            {
                ship_to_customer = value;
            }
        }

        // bill_to_customer
        public string BillToCustomer
        {
            get
            {
                return bill_to_customer;
            }

            set
            {
                bill_to_customer = value;
            }
        }

        // sold_to_customer
        public string SoldToCustomer
        {
            get
            {
                return sold_to_customer;
            }

            set
            {
                sold_to_customer = value;
            }
        }

        // cs
        public string Cs
        {
            get
            {
                return cs;
            }

            set
            {
                cs = value;
            }
        }

        // order_type_name
        public string OrderTypeName
        {
            get
            {
                return order_type_name;
            }

            set
            {
                order_type_name = value;
            }
        }


        // flow_status_code
        public string FlowStatusCode
        {
            get
            {
                return flow_status_code;
            }

            set
            {
                flow_status_code = value;
            }
        }


        // planner_code
        public string PlannerCode
        {
            get
            {
                return planner_code;
            }

            set
            {
                planner_code = value;
            }
        }

        // production_method
        public string ProductionMethod
        {
            get
            {
                return production_method;
            }

            set
            {
                production_method = value;
            }
        }

        // production_line
        public string ProductionLine
        {
            get
            {
                return production_line;
            }

            set
            {
                production_line = value;
            }
        }

        // packing_instr
        public string PackingInstr
        {
            get
            {
                return packing_instr;
            }

            set
            {
                packing_instr = value;
            }
        }

        // packing_instructions
        public string PackingInstructions
        {
            get
            {
                return packing_instructions;
            }

            set
            {
                packing_instructions = value;
            }
        }

        // shipment_number
        public string ShipmentNumber
        {
            get
            {
                return shipment_number;
            }

            set
            {
                shipment_number = value;
            }
        }

        // makebuy
        public string Makebuy
        {
            get
            {
                return makebuy;
            }

            set
            {
                makebuy = value;
            }
        }

        // sample
        public string Sample
        {
            get
            {
                return sample;
            }

            set
            {
                sample = value;
            }
        }

        // updated_by_name
        public string UpdatedByName
        {
            get
            {
                return updated_by_name;
            }

            set
            {
                updated_by_name = value;
            }
        }

        // updated_by_ip
        public string UpdatedByIp
        {
            get
            {
                return updated_by_ip;
            }

            set
            {
                updated_by_ip = value;
            }
        }

        // updated_date
        public DateTime UpdatedDate
        {
            get
            {
                return updated_date;
            }

            set
            {
                updated_date = value;
            }
        }

        // constructor
        public PromiseDateReviseDTO()
        {

        }

        // constructor full
        public PromiseDateReviseDTO(
            int Status, string Ou, string OrderNumber, string LineNumber, string SoLine, 
            string CustPoNumber, string CustomerItem, string Item, string Qty, string OrderedDate,
            string RequestDate, string PromiseDate, string ShipToCustomer, string BillToCustomer, string SoldToCustomer,
            string Cs, string OrderTypeName, string FlowStatusCode, string PlannerCode, string ProductionMethod,
            string ProductionLine, string PackingInstr, string PackingInstructions, string ShipmentNumber, string Makebuy, string Sample, string UpdatedByName, string UpdatedByIp
        )
        {
            this.Status = Status;
            this.Ou = Ou;
            this.OrderNumber = OrderNumber;
            this.LineNumber = LineNumber;
            this.SoLine = SoLine;

            this.CustPoNumber = CustPoNumber;
            this.CustomerItem = CustomerItem;
            this.Item = Item;
            this.Qty = Qty;
            this.OrderedDate = OrderedDate;

            this.RequestDate = RequestDate;
            this.PromiseDate = PromiseDate;
            this.ShipToCustomer = ShipToCustomer;
            this.BillToCustomer = BillToCustomer;
            this.SoldToCustomer = SoldToCustomer;

            this.Cs = Cs;
            this.OrderTypeName = OrderTypeName;
            this.FlowStatusCode = FlowStatusCode;
            this.PlannerCode = PlannerCode;
            this.ProductionMethod = ProductionMethod;

            this.ProductionLine = ProductionLine;
            this.PackingInstr = PackingInstr;
            this.PackingInstructions = PackingInstructions;
            this.ShipmentNumber = ShipmentNumber;
            this.Makebuy = Makebuy;

            this.Sample = Sample;
            this.UpdatedByName = UpdatedByName;
            this.UpdatedByIp = UpdatedByIp;
            
        }

    }
}
