using System;
using System.Threading;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Account myAccount = new Account(); // new account
            Console.WriteLine("Hello Please Enter your Your Name: ");// user user input for name
            string name = Console.ReadLine();
            myAccount.Name = name; // assign account name

            Console.WriteLine("Hello Please Enter your Your PIN: ");// user input for Pin
            int pin = int.Parse(Console.ReadLine());
            myAccount.Pin = pin;// set account pin

 

            Console.WriteLine("Thank you for opening your new Account you will have $500.00 Rewards enjoy!!");

            myAccount.Balance = 500.00;// set account balance

            Thread.Sleep(2000);// sleep 

            Console.WriteLine(" Connecting Please wahite ....... ");

            Thread.Sleep(2000);

            int tryTimes = 0;// set try
            while (tryTimes < 2) // set retry times to 2 times 
            {
                try
                {
                    Console.WriteLine("Welcome Please Enter your PIN to Use this Service: ");
                    int pinCode = int.Parse(Console.ReadLine());
                    bool correctPin = myAccount.PinValidator(pinCode);

                    if (correctPin) // check if the pin is correct 
                    {
                        Console.WriteLine($"Hello, {myAccount.Name}! \nPlease Choose what you like to do Next?\n" +
                            $"Please 1 OR 2 OR 3");
                    }
                    else // if not correct 
                    {
                        Console.WriteLine(" The PIN is NOT Correct this service not Avalable now!!");
                    }
                }
                catch(Exception e)// handling exception
                {
                    Console.WriteLine($"{e.Message}\n" +
                        $" Please Try one more time");// print message 
                
                }
                finally
                {
                    tryTimes++; // increment 
                }
            }

            Console.WriteLine("Please Choose Servcie\n" +
                "1- Check your Balance!\n" +
                "2- Withdraw\n" +
                "3- Deposit\n");// choose opreation to preform 
            int option = int.Parse(Console.ReadLine());

            switch (option)// case statment 
            {
                case 1:// check balance o
                    double balance = myAccount.CheckBalance();
                    Console.WriteLine($"Avalable Balance is: $ {balance}");
                    break;
                case 2:// withdraw
                    Console.Write("Please enter withdraw Amount: =>");
                    double amount = double.Parse(Console.ReadLine());
                    bool withdraw = myAccount.Withdraw(amount);// check if transaction true
                    if (withdraw)// if true return this message
                    {
                        Console.WriteLine($"Transaction successfully! your new balance is  $ {myAccount.Balance}");
                    }
                    else // if  false return this message with account and amount 
                    {
                        Console.WriteLine($"Sorry Transaction not completed $ {withdraw} is Greater $ {myAccount.Balance}");
                    }
                    break;
                case 3:
                    Console.Write("Please enter Deposit Amount: =>");
                    double amountDep = double.Parse(Console.ReadLine());
                    double newBalance = myAccount.Deposit(amountDep);// add Deposit 
                    Console.WriteLine($"Success, Your New Balance now is: $ {newBalance}");
                    break;
                default: // if user input was not 1 or 2 or 3 will print this message and end the program
                    Console.WriteLine("Option not valid!!");
                    break;
            }

        }
    }
}
