using System;
namespace ArcadeAPPConsole_NicholasUrrutia
{
    abstract class Employee{
        public int empID { get; set; }
        public string empName { get; set; }
        //public double empPay { get; set; }
        
        public DateTime empHireDate { get; set; }

        public double empPayRate { get; set; }

        //public double hoursWorked { get; set; }

        // public double payWages(){
        //     double pay = hoursWorked * payRate;
        //     hoursWorked = 0.0d;
        //     return pay;
        // }

        // public double clockTime(double hours){
        //     return hoursWorked + hours;
        // }
    }
}