using System;
namespace BankAccount
{
    public class Account
    {
        public int Pin { get; set; }
        public string Amount { get; set; }
        public double Balance { get; set; }
        public string Name { get; set; }

        public bool PinValidator(int pin)
        {
            if(pin == Pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double CheckBalance()
        {
            return Balance;
        }
        public bool Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        public double Deposit(double amount)
        {
            Balance += amount;
            return Balance;
        }
    }
}
