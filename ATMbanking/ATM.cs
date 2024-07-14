using System;

namespace ATMbanking
{
    public class ATM
    {
        
        private VTwoLogger LoggerTwo; //interface
        private ViOneLogger logger; // abstract

        private Account account;

        public ATM(Account account)
        {
            this.account = account;
        }

        public void Start()
        {
            LoggerTwo = new VTwoLogger(); // interface
            logger = new ViOneLogger(); // abstract
            while (true)
            {
                Console.Clear();

                LoggerTwo.LogIn("ATM dasturiga xush kelibsiz!");
                LoggerTwo.LogIn("A) Balans tekshirish");
                LoggerTwo.LogIn("B) Kartani to'ldirish");
                LoggerTwo.LogIn("C) Kartadan pul yechish");
                LoggerTwo.LogIn("D) Chiqish");
                Console.Write("Tanlang (A, B, C, D): ");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "D")
                {
                    LoggerTwo.LogIn("Dastur tugatildi.");
                    break;
                }

                Console.Write("Parolni kiriting: ");
                string password = Console.ReadLine();

                if (!account.ValidatePassword(password))
                {
                    LoggerTwo.LogIn("Noto'g'ri parol. Qayta urinib ko'ring.");
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
                        LoggerTwo.LogIn("Noto'g'ri tanlov. Iltimos, qayta urinib ko'ring.");
                        ReturnToMainMenu();
                        break;
                }
            }
        }

        private void CheckBalance()
        {
            LoggerTwo.LogIn("Joriy balans: $" + account.GetBalance());
            ReturnToMainMenu();
        }

        private void DepositMoney()
        {
            LoggerTwo.LogIn("Balans: $" + account.GetBalance());
            LoggerTwo.LogIn("Karta raqami: " + account.CardNumber);
            Console.Write("To'ldiriladigan miqdorni kiriting: $");
            double amount = Convert.ToDouble(Console.ReadLine());
            account.Deposit(amount);
            LoggerTwo.LogIn("Balans yangilandi: $" + account.GetBalance());
            ReturnToMainMenu();
        }

        private void WithdrawMoney()
        {
            while (true)
            {
                LoggerTwo.LogIn("Joriy balans: $" + account.GetBalance());
                LoggerTwo.LogIn("Echilishi mumkin bo'lgan miqdorlar:");
                LoggerTwo.LogIn("1) $10");
                LoggerTwo.LogIn("2) $20");
                LoggerTwo.LogIn("3) $50");
                LoggerTwo.LogIn("4) $100");
                LoggerTwo.LogIn("5) Boshqa miqdor");
                LoggerTwo.LogIn("6) Chiqish");
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
                        LoggerTwo.LogIn("Noto'g'ri tanlov. Iltimos, qayta urinib ko'ring.");
                        continue;
                }

                if (!account.Withdraw(withdrawAmount))
                {
                    LoggerTwo.LogIn("Balans yetarli emas yoki noto'g'ri miqdor!");
                }
                else
                {
                    LoggerTwo.LogIn("$" + withdrawAmount + " muvaffaqiyatli yechildi.");
                    LoggerTwo.LogIn("Qolgan balans: $" + account.GetBalance());
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
            LoggerTwo.LogIn("Bosh sahifaga qaytish uchun istalgan tugmani bosing...");
            Console.ReadKey();
        }
    }
}
