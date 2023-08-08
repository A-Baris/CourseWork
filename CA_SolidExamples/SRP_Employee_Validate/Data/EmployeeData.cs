using SRP_Employee_Validate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Employee_Validate.Data
{
    public class EmployeeData
    {
        public static List<Employee> Employees = new List<Employee>();


     public static Employee AddPerson()
        {
            
            Employee employee = new Employee();
            Console.WriteLine("İsim giriniz ");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Soyisim giriniz ");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("Email giriniz ");
            employee.Email = Console.ReadLine();
            EmployeeData.Employees.Add(employee);
            return employee;



        }

        public static void GetList() 
        {
            foreach (Employee emp in Employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Email}");

            }
        
        
        }


    }
}

