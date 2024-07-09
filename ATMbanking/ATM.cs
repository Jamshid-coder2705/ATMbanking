using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMbanking
{
    public class ATM
    {
        private Account account;

        public ATM(Account account)
        {
            this.account = account;
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bankomat dasturiga xush kelibsiz!");
                Console.WriteLine("A) Balans tekshirish");
                Console.WriteLine("B) Kartani to'ldirish");
                Console.WriteLine("C) Kartadan pul yechish");
                Console.WriteLine("D) Chiqish");
                Console.Write("Tanlang (A, B, C, D): ");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "D")
                {
                    Console.WriteLine("Dastur tugatildi.");
                    break;
                }

                Console.Write("Parolni kiriting: ");
                string password = Console.ReadLine();

                if (!account.ValidatePassword(password))
                {
                    Console.WriteLine("Noto'g'ri parol. Qayta urinib ko'ring.");
                    ReturnToMainMenu();
                    continue;
                }

                switch (choice)
                {
                    case "A":
                        CheckBalance();
                        break;
                    case "B":
                        DepositMoney();
                        break;
                    case "C":
                        WithdrawMoney();
                        break;
                    default:
                        Console.WriteLine("Noto'g'ri tanlov. Iltimos, qayta urinib ko'ring.");
                        ReturnToMainMenu();
                        break;
                }
            }
        }

        private void CheckBalance()
        {
            Console.WriteLine("Joriy balans: $" + account.GetBalance());
            ReturnToMainMenu();
        }

        private void DepositMoney()
        {
            Console.WriteLine("Balans: $" + account.GetBalance());
            Console.WriteLine("Karta raqami: " + account.CardNumber);
            Console.Write("To'ldiriladigan miqdorni kiriting: $");
            double amount = Convert.ToDouble(Console.ReadLine());
            account.Deposit(amount);
            Console.WriteLine("Balans yangilandi: $" + account.GetBalance());
            ReturnToMainMenu();
        }

        private void WithdrawMoney()
        {
            while (true)
            {
                Console.WriteLine("Joriy balans: $" + account.GetBalance());
                Console.WriteLine("Echilishi mumkin bo'lgan miqdorlar:");
                Console.WriteLine("1) $10");
                Console.WriteLine("2) $20");
                Console.WriteLine("3) $50");
                Console.WriteLine("4) $100");
                Console.WriteLine("5) Boshqa miqdor");
                Console.WriteLine("6) Chiqish");
                Console.Write("Tanlang (1-6): ");
                string choice = Console.ReadLine();

                double withdrawAmount = 0;

                switch (choice)
                {
                    case "1":
                        withdrawAmount = 10;
                        break;
                    case "2":
                        withdrawAmount = 20;
                        break;
                    case "3":
                        withdrawAmount = 50;
                        break;
                    case "4":
                        withdrawAmount = 100;
                        break;
                    case "5":
                        Console.Write("Miqdor kiriting: $");
                        withdrawAmount = Convert.ToDouble(Console.ReadLine());
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Noto'g'ri tanlov. Iltimos, qayta urinib ko'ring.");
                        continue;
                }

                if (!account.Withdraw(withdrawAmount))
                {
                    Console.WriteLine("Balans yetarli emas yoki noto'g'ri miqdor!");
                }
                else
                {
                    Console.WriteLine("$" + withdrawAmount + " muvaffaqiyatli yechildi.");
                    Console.WriteLine("Qolgan balans: $" + account.GetBalance());
                }

                Console.Write("Yana pul yechishni xohlaysizmi? (ha/yo'q): ");
                string response = Console.ReadLine().ToLower();
                if (response != "ha")
                {
                    break;
                }
            }
            ReturnToMainMenu();
        }

        private void ReturnToMainMenu()
        {
            Console.WriteLine("Bosh sahifaga qaytish uchun istalgan tugmani bosing...");
            Console.ReadKey();
        }
    }
}
