using SRP_Employee_Validate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Employee_Validate.Common
{
    public class NullorEmptyControl
    {
        public static bool Controlling(Employee employee)

        {
            if (string.IsNullOrEmpty(employee.FirstName))
            {
                Messages.ErrorMessage("Ad");

                return false;

            }
            else if (string.IsNullOrEmpty(employee.LastName))
            {
                Messages.ErrorMessage("Soyad");
                return false;

            }
            else if (string.IsNullOrEmpty(employee.Email))
            {
                Messages.ErrorMessage("Email");
                return false;
            }
            return true;


        }

    }
}
