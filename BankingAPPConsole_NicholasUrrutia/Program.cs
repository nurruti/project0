using System;

namespace BankingAPPConsole_NicholasUrrutia
{
    class Program
    {
        static void Main(string[] args)
        {
            Accounts client01 = new Accounts(){
                accNo = 101,
                accName = "Nick",
                accType = "Loan",
                accBalance = 5000,
                accIsActive = true,
                accEmail = "debtlord@yahoo.com"
            };
            
            bool continueBanking = true;
            string keepBanking;

            while(continueBanking){
                DisplayMenu();

                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice){
                    #region Create New Account
                    case 1:
                        
                        break;
                    #endregion
                    #region Check Balance
                    case 2:
                        client01.CheckBalance();
                        break;
                    #endregion
                    #region Withdraw
                    case 3:
                        Console.WriteLine("Enter how much you'd like to withdraw.");
                        client01.Withdraw(Convert.ToDouble(Console.ReadLine()));
                        client01.CheckBalance();
                        break;
                    #endregion
                    #region Deposit
                    case 4:
                        Console.WriteLine("Enter how much you'd like to deposit.");
                        client01.Deposit(Convert.ToDouble(Console.ReadLine()));
                        client01.CheckBalance();
                        break;
                    #endregion
                    #region Get Account Details
                    case 5:
                        client01.getAccountDetails();
                        break;
                    #endregion
                    #region Exit
                    case 6:
                        System.Console.WriteLine("Thank you for banking with us and have a great day!");
                        continueBanking = false;
                        break;
                    #endregion
                    default:
                        System.Console.WriteLine("Invalid Input. System logout.");
                        continueBanking = false;
                        break;
                    
                    // Console.WriteLine("Would you like to continue banking? Y/N");
                    // keepBanking = Console.ReadLine();
                    // if(keepBanking.ToUpper() == "N"){
                    //     System.Console.WriteLine("Thank you for banking with us and have a great day!");
                    //     continueBanking = false; 
                    // }else if(keepBanking.ToUpper() == "Y"){
                    //     continue;
                    // }else {
                    //     System.Console.WriteLine("Invalid Input. System logout.");
                    //     continueBanking = false;
                    //}
                }
            }


            void DisplayMenu(){
            Console.WriteLine("1. Create New Account");
            Console.WriteLine("2. Check Balance");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Deposit");
            Console.WriteLine("5. Get Account Details");
            Console.WriteLine("6. Exit");
            Console.Write("\nEnter a number to indicate your choice: ");
            }

            // void KeepBanking(){
            //     Console.WriteLine("Would you like to continue banking? Y/N");
            //         keepBanking = Console.ReadLine();
            //         if(keepBanking.ToUpper() == "N"){
            //             System.Console.WriteLine("Thank you for banking with us and have a great day!");
            //             continueBanking = false; 
            //         }else if(keepBanking.ToUpper() == "Y"){
                        
            //         }else {
            //             System.Console.WriteLine("Invalid Input. System logout.");
            //             continueBanking = false;
            //         }
            // };

        }

        
    }
}
