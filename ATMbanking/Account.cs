using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMbanking
{
    public class Account
    {
        private double balance;
        private const string correctPassword = "1234";
        public string CardNumber { get; private set; }

        public Account(double initialBalance, string cardNumber)
        {
            balance = initialBalance;
            CardNumber = cardNumber;
        }

        public bool ValidatePassword(string password)
        {
            return password == correctPassword;
        }

        public double GetBalance()
        {
            return balance;
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (amount > balance)
            {
                return false;
            }
            balance -= amount;
            return true;
        }
    }
}
