using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SIGMA_Delegates
{
    public class Collector
    {
        private List<string> numColl;

        public Collector()
        {
            this.numColl = new List<string>();

        }

        public void AddToList(string recordStr)
        {
            numColl.Add(recordStr);
        }

       

        public void Dispaly()
        {


            Console.WriteLine("Data from Class:{0}", GetType().Name);   // this.GetType().FullName.ToString()

            foreach (var item in numColl)
            {
                Console.WriteLine(item);
            }

          //  Console.ReadKey();
        }

       
        
        

    }
}
