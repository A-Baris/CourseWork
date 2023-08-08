using SRP_Employee_Validate.Common;
using SRP_Employee_Validate.Data;
using SRP_Employee_Validate.Model;

Messages.Message();
Employee employee = EmployeeData.AddPerson();
NullorEmptyControl.Controlling(employee);
EmployeeData.GetList();

Console.Read();