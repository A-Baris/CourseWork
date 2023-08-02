using CA_School.Models;
using CA_School.Repositories;

int choice = 0;
StudentRepository sr = new StudentRepository();

while (true)
{
    StudentMenu();
    choice = int.Parse(Console.ReadLine());

    switch (choice)
    {




        case 1:
            Console.WriteLine("Student List: ");
            foreach (Student s in sr.GetStudents())
            {
                Console.WriteLine($"Id: {s.StudentId} First Name: {s.FirstName} Last Name: {s.LastName}");
            }
            break;
        case 2:
            try
            {
                Student std = new Student();
                Console.WriteLine("First Name: ");
                std.FirstName = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                std.LastName = Console.ReadLine();
                Console.WriteLine("Birthdate: ");
                std.Birthdate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine(sr.AddStudent(std));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            break;
        case 3:
            try
            {
                Console.WriteLine("Enter a student ID to delete: ");
                int deletingId = int.Parse(Console.ReadLine());
                Console.WriteLine(sr.DeleteStudent(deletingId));
            }catch(Exception ex) { Console.WriteLine(ex.Message); }
            break;
        case 4:
            try
            {
                Console.WriteLine("Enter a student ID to update: ");
                int updatingId = int.Parse(Console.ReadLine());
                Student updatingStudent = new Student();
                updatingStudent.StudentId = updatingId;
                Console.WriteLine("First Name: ");
                updatingStudent.FirstName = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                updatingStudent.LastName = Console.ReadLine();
                Console.WriteLine("Birthdate: ");
                updatingStudent.Birthdate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine(sr.UpdateStudent(updatingStudent));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            break;

    }
    try
    {
        Console.WriteLine("Do you want to continue the functions? Y/N");
        char answer = char.Parse(Console.ReadLine().ToLower());
    
    if(answer != 'y')
    { break; }
    }
    catch (Exception ex) { Console.WriteLine(ex.Message); }
}
Console.Read();



    void StudentMenu()
    {
        string[] menuList = { "1-List", "2-Add Student", "3-Delete Student", "4-Update Student" };
        for (int i = 0; i < menuList.Length; i++)
        {
            Console.WriteLine(menuList[i]);
        }
    }
    
