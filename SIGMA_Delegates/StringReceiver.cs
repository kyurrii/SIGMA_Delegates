using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGMA_Delegates
{
    public class StringReceiver
    {
        public delegate void StringReceivedEventHandler(string str);
        public event StringReceivedEventHandler StringReceived;
         public string val;

       

        public string EnquireRecord()
        {
            string newRecord;

            Console.Write("Enter new string: ");
            newRecord = Console.ReadLine();

            return newRecord;
        }

        public void StringReceive(string str)
        {
           
          

           onStringReceived(str);
          // return val;

           
        }

        protected virtual void onStringReceived(string str)
        {
            if (StringReceived != null)
                StringReceived( str);

                StringReceived = null;

        }
    }
}
