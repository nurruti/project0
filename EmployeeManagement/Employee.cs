using System;
namespace EmployeeManagement
{
    abstract class Employee{
        public int empNo { get; set; }
        public string empName { get; set; }
        public double empSalary { get; set; }
        public bool empIsPermanant { get; set; }

        public double getBonus(double percentage){
            return empSalary * (percentage/100);
        }
    }
}