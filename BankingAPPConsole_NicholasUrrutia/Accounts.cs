using System;

class Accounts {
#region Properties
    public int accNo { get; set; }
    public string accName { get; set; }
    public string accType { get; set; }
    public double accBalance { get; set; }
    public bool accIsActive { get; set; }
    public string accEmail { get; set; }
#endregion

#region Account Methods
public double Withdraw(double amountWD){
    accBalance = accBalance - amountWD;
    return accBalance;
}

public double Deposit(double amountDP){
    accBalance = accBalance + amountDP;
    return accBalance;
}

public void getAccountDetails(){
    Console.WriteLine($"Account No: {accNo}\nName : {accName}\nType : {accType}\nBalance : {accBalance}\n Email : {accEmail}\n");
}

public void CheckBalance(){
    Console.WriteLine($"Account Balance is: {accBalance}\n");
}
#endregion

}