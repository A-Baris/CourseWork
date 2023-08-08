using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Employee_Validate.Common
{
    public class Messages
    {
        public static void Message()
        {

            Console.WriteLine("Uygulamaya Hoşgeldiniz");

        }
        public static void ErrorMessage(string fieldName)
        {
            Console.WriteLine($"{fieldName}  boş geçilemez!");
        }

    }
}
