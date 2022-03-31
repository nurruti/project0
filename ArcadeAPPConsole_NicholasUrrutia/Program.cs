using System;

namespace ArcadeAPPConsole_NicholasUrrutia
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Constructors
            Manager myManager = new Manager(){
                empID = 101,
                empName = "Bill Smith",
                empPayRate = 15.00,
                empHireDate = new DateTime(2012, 11, 27)
            };

            Attendant myAttendant = new Attendant(){
                empID = 200,
                empName = "Joe Connors",
                empPayRate = 12.00,
                empHireDate = new DateTime(2016, 07, 15)
            };
            
            CardDetails crDetails = new CardDetails();
            ProductDetails prDetails = new ProductDetails();
            #endregion

            //bool isMngr = false;
            bool continueInteraction = true;
            bool isLoggedIn = false;

            if (isLoggedIn == false)
            {
                System.Console.Write("Username: ");
                string username = Console.ReadLine();
                System.Console.Write("Password: ");
                string password = Console.ReadLine();
                Security sObj = new Security();
                
                bool loginResult = sObj.Login(username,password);
                if(loginResult == false)
                {   
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Invalid Input. System logout.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    isLoggedIn = true;

                    while(continueInteraction){
                        DisplayMenuHeader();
                        DisplayAttendantMenu();

                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch(choice){
                            #region Issue New Card
                            case 1:
                                System.Console.WriteLine("Enter Customer's Name");
                                string name =Console.ReadLine();
                                System.Console.WriteLine("Enter Customer's email");
                                string email = Console.ReadLine();
                                //System.Console.WriteLine("Enter Card Tier");
                                //int tier = Convert.ToInt32(Console.ReadLine());
                                System.Console.WriteLine("How much do they wish to put on the card?");
                                double credits = Convert.ToDouble(Console.ReadLine());
                                //System.Console.WriteLine("Enter Ticket Balance");
                                //int Tickets = Convert.ToInt32(Console.ReadLine());

                                CardDetails newCard = new CardDetails();
                                newCard.cName = name;
                                newCard.cEmail = email;
                                newCard.cTier = 1; //default before upgrades
                                newCard.cDateSubbed = DateTime.Now;
                                newCard.AddFunds(credits); //Change for AddFunds();
                                newCard.cTickets = 0; //fresh start
                                System.Console.WriteLine(crDetails.AddNewCard(newCard));
                                break;
                            #endregion
                            #region Check Card
                            case 2:
                                System.Console.Write("Enter Card ID to search details: ");
                                int cId2 = Convert.ToInt32(Console.ReadLine());
                                CardDetails cr = crDetails.GetCardById(cId2);
                                System.Console.WriteLine("Card ID: " + cr.cId);
                                System.Console.WriteLine("Card Name: " + cr.cName);
                                System.Console.WriteLine("Card Email: " + cr.cEmail);
                                System.Console.WriteLine("Card Tier: " + cr.cTier);
                                System.Console.WriteLine("Card Subscribed on: " + cr.cDateSubbed);
                                System.Console.WriteLine("Card Credit Balance: " + cr.cBalance);
                                System.Console.WriteLine("Card Ticket Balance: " + cr.cTickets);
                                break;
                            #endregion
                            #region Edit Card
                            case 3:
                                System.Console.WriteLine("Enter Customer's Name");
                                string name2 =Console.ReadLine();
                                System.Console.WriteLine("Enter Customer's email");
                                string email2 = Console.ReadLine();
                                System.Console.WriteLine("Enter Card Tier");
                                int tier2 = Convert.ToInt32(Console.ReadLine());
                                System.Console.WriteLine("Enter Credit Balance");
                                double credits2 = Convert.ToDouble(Console.ReadLine());
                                System.Console.WriteLine("Enter Ticket Balance");
                                int tickets2 = Convert.ToInt32(Console.ReadLine());

                                System.Console.WriteLine("Enter Card Id");
                                int id = Convert.ToInt32(Console.ReadLine());
                                CardDetails cardChange = new CardDetails();
                                cardChange.cId = id;
                                cardChange.cName = name2;
                                cardChange.cTier = tier2;
                                cardChange.cBalance = credits2;
                                cardChange.cTickets = tickets2;
                            
                                System.Console.WriteLine(crDetails.EditCard(cardChange));
                                break;
                            #endregion
                            #region Delete Card
                            case 4:
                                System.Console.Write("Enter Card Id to delete the product: ");
                                int cId = Convert.ToInt32(Console.ReadLine());
                                System.Console.WriteLine(crDetails.DeleteCard(cId));
                                break;
                            #endregion
                            #region Issue Prizes
                            case 5:
                                Console.ForegroundColor = ConsoleColor.Red;
                                System.Console.WriteLine("Currently out of Order");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            #endregion
                            #region Create Maintenance Ticket
                            case 6:
                                Console.ForegroundColor = ConsoleColor.Red;
                                System.Console.WriteLine("Currently out of Order");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            #endregion
                            #region Logout
                            case 7:
                                Console.ForegroundColor = ConsoleColor.Green;
                                System.Console.WriteLine("Thank you for playing with us and have a great day!");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                continueInteraction = false;
                                break;
                            #endregion
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                System.Console.WriteLine("Invalid Input. System logout.");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                continueInteraction = false;
                                break; 
                        }
                    }

                #region Methods
                    void DisplayMenuHeader(){
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        Console.Clear();
                        //Console.BackgroundColor = ConsoleColor.DarkBlue;
                        //Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("                                              ");
                        Console.WriteLine("              Welcome to ArtCade              ");
                        Console.WriteLine("                                              ");
                        //Console.BackgroundColor = ConsoleColor.Black;
                        //Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    void DisplayAttendantMenu(){
                    Console.WriteLine("\t\tAttendant Menu\t\t\n");
                    Console.WriteLine("1. Issue New Card");
                    Console.WriteLine("2. Check Card");
                    Console.WriteLine("3. Edit Card");
                    Console.WriteLine("4. Delete Card");
                    Console.WriteLine("5. Issue Prizes");
                    Console.WriteLine("6. Create Maintenance Ticket");
                    Console.WriteLine("7. Logout");
                    Console.Write("\nEnter a number to indicate your choice: ");
                    }

                    //This is for when the managers log in. They will have more options.
                    /*void DisplayManagerMenu(){
                    Console.WriteLine("\t\tManager Menu\t\t\n");
                    Console.WriteLine("1. Issue New Card");
                    Console.WriteLine("2. Check Card");
                    Console.WriteLine("3. Edit Card");
                    Console.WriteLine("4. Upgrade Card");
                    Console.WriteLine("5. Issue Prizes");
                    Console.WriteLine("6. Create Maintenance Ticket");
                    Console.WriteLine("7. Inventory");
                    Console.WriteLine("8. Payroll");
                    Console.WriteLine("9. Logout");
                    Console.Write("\nEnter a number to indicate your choice: ");
                    }*/
                }
                #endregion
            }
        }
    }
}
