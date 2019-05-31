using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGMA_Delegates
{

    public delegate void EventHandler();

    class Program
    {
 
        public static event EventHandler DisplayRecords;

        public static void Main(string[] args)
        {
           AlphaNumbericCollector alphaNumbericCollector = new AlphaNumbericCollector();
           StringCollector stringCollector = new StringCollector();
            StringReceiver stringReceiver = new StringReceiver();

            Func<string> PromptRecord = stringReceiver.EnquireRecord;
            Action<string> ReceiveRecord = stringReceiver.StringReceive;

            string val;
            Console.WriteLine("To finish entering, type: end");
            Console.WriteLine();
            val = PromptRecord();  // stringReceiver.EnquireRecord();


            while (val!="end")
            {

                Predicate<string> isNumberPresent = IsNumberInString;    // Use of Predicate Delegate
                bool numberPresent = isNumberPresent(val);

                if (numberPresent)
                {
                    stringReceiver.StringReceived += alphaNumbericCollector.AddToList;

                }

                else
                {
                    stringReceiver.StringReceived += stringCollector.AddToList;

                }
                     ReceiveRecord(val); //    Used Action type delegate
                     val = PromptRecord(); // Used Func type delegate


                if (val == "end")
                {
                    Console.WriteLine();
                    Console.WriteLine("Data recorded in Classes:");
                    Console.WriteLine();

                    DisplayRecords += new EventHandler(alphaNumbericCollector.Dispaly);
                    DisplayRecords += new EventHandler(stringCollector.Dispaly);
                    DisplayRecords.Invoke();

                    Console.ReadKey();
                }
            }
          


        }

        public static bool IsNumberInString(string rec)
        {
            bool numberPresent = rec.Any( char.IsNumber);
            return numberPresent;
        }


        
    }
}
