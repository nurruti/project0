using System;
namespace ArcadeAPPConsole_NicholasUrrutia
{
    class Manager : Employee{

        public double salary { get; set; }
        public double payWages(){
            double pay = 40 * empPayRate;
            return pay;
        }
    }
}