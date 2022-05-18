using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // DataTable
using System.Threading;
using BUS;
using DTO;

namespace GUI
{
    class Program
    {
        private static AutomailBUS Automail = new AutomailBUS();
        private static RevisePromiseDateBUS Revise = new RevisePromiseDateBUS();

        static void Main(string[] args)
        {
            // load data Revise PD
            LoadRevisePD();

            // sleep 1 minite
            // Thread.Sleep(60000);

            while (true)
            {
                try
                {
                    // Phút thứ 5, 15, 25, 35
                    if ( (Convert.ToInt32(DateTime.Now.ToString("mm")) == 5) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 15) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 25) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 35))
                    {
                        // load data Revise PD
                        LoadRevisePD();
                    }
                }
                catch
                {
                    Console.WriteLine("Error");
                }

                // sleep 10s
                Thread.Sleep(10000);
            }
            
        }


        public static void LoadRevisePD()
        {
            var count = Revise.AddRevisePD();
            if (count > 0)
            {
                Console.WriteLine(count + " lines uploaded. DONE"); // 5   
            }
            else
            {
                Console.WriteLine(" FAILED");
            }

        }

    }
}
