using System;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager myManager = new Manager(){
                empNo = 101,
                empName = "Steve",
                empSalary = 70000,
                empIsPermanant = true
            };

            Developer myDeveloper = new Developer(){
                empNo = 321,
                empName = "John",
                empSalary = 45000,
                empIsPermanant = true
            };

            HR myHR = new HR(){
                empNo = 200,
                empName = "Carol",
                empSalary = 55000,
                empIsPermanant = true
            };

            Console.Clear();
            System.Console.WriteLine($"My manager {myManager.empName} has a salary of ${myManager.empSalary}.");
            System.Console.WriteLine($"With a 10% bonus, he makes ${myManager.getBonus(10)} during Christmas!\n");

            System.Console.WriteLine($"My developer friend {myDeveloper.empName} has a salary of ${myDeveloper.empSalary}.");
            System.Console.WriteLine($"With a 5% bonus, he makes ${myDeveloper.getBonus(5)} during Christmas!\n");

            System.Console.WriteLine($"My HR contact {myHR.empName} has a salary of ${myHR.empSalary}.");
            System.Console.WriteLine($"With a 7.5% bonus, she makes ${myHR.getBonus(7.5)} during Christmas!\n");
        }
    }
}
