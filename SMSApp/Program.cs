using SignalWire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace SMSApp
{
    class Program
    {
        static WebApiRepository objService = new WebApiRepository();

        static void Main(string[] args)
        {
            var objSMS = new SMS();
            try
            {
                Console.WriteLine("Process started");

                var response = objSMS.Send("+12066561175", "This is a test for the application 05-05-2021");

                foreach(var Item in response)
                {
                    Console.WriteLine("Process fished with Id:" + Item.Sid);
                    Console.WriteLine("Status: " + Item.Status);
                    Console.WriteLine("Error: " + Item.ErrorMessage);
                    Console.WriteLine("=====================================");
                }

                Console.ReadLine();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            
        }
    }
}
