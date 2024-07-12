using System;

namespace ATMbanking
{
    public class ATM
    {
        private ViOneLogger logger;

        private Account account;

        public ATM(Account account)
        {
            this.account = account;
        }

        public void Start()
        {
            logger = new ViOneLogger();
            while (true)
            {
                Console.Clear();
                logger.Info("ATM dasturiga xush kelibsiz!");
                logger.Info("A) Balans tekshirish");
                logger.Info("B) Kartani to'ldirish");
                logger.Info("C) Kartadan pul yechish");
                logger.Info("D) Chiqish");
                Console.Write("Tanlang (A, B, C, D): ");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "D")
                {
                    logger.Info("Dastur tugatildi.");
                    break;
                }

                Console.Write("Parolni kiriting: ");
                string password = Console.ReadLine();

                if (!account.ValidatePassword(password))
                {
                    logger.Info("Noto'g'ri parol. Qayta urinib ko'ring.");
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
                        logger.Info("Noto'g'ri tanlov. Iltimos, qayta urinib ko'ring.");
                        ReturnToMainMenu();
                        break;
                }
            }
        }

        private void CheckBalance()
        {
            logger.Info("Joriy balans: $" + account.GetBalance());
            ReturnToMainMenu();
        }

        private void DepositMoney()
        {
            logger.Info("Balans: $" + account.GetBalance());
            logger.Info("Karta raqami: " + account.CardNumber);
            Console.Write("To'ldiriladigan miqdorni kiriting: $");
            double amount = Convert.ToDouble(Console.ReadLine());
            account.Deposit(amount);
            logger.Info("Balans yangilandi: $" + account.GetBalance());
            ReturnToMainMenu();
        }

        private void WithdrawMoney()
        {
            while (true)
            {
                logger.Info("Joriy balans: $" + account.GetBalance());
                logger.Info("Echilishi mumkin bo'lgan miqdorlar:");
                logger.Info("1) $10");
                logger.Info("2) $20");
                logger.Info("3) $50");
                logger.Info("4) $100");
                logger.Info("5) Boshqa miqdor");
                logger.Info("6) Chiqish");
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
                        logger.Info("Noto'g'ri tanlov. Iltimos, qayta urinib ko'ring.");
                        continue;
                }

                if (!account.Withdraw(withdrawAmount))
                {
                    logger.Info("Balans yetarli emas yoki noto'g'ri miqdor!");
                }
                else
                {
                    logger.Info("$" + withdrawAmount + " muvaffaqiyatli yechildi.");
                    logger.Info("Qolgan balans: $" + account.GetBalance());
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
            logger.Info("Bosh sahifaga qaytish uchun istalgan tugmani bosing...");
            Console.ReadKey();
        }
    }
}
