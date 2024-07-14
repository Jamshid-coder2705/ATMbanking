using ATMbanking;

class Program
{
    static void Main(string[] args)
    {
        Account account = new Account(100, "8600132991929148");
        ATM atm = new ATM(account);
        atm.Start();
    }
}