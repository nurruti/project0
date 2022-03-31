using System;
namespace ArcadeAPPConsole_NicholasUrrutia
{
    class Attendant : Employee{

        public double hoursWorked { get; set; }
        public double payWages(){
            double pay = hoursWorked * empPayRate;
            hoursWorked = 0.0;
            return pay;
        }

        public double clockTime(double hours){
            return hoursWorked + hours;
        }
    }
}