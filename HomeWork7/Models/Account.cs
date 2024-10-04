using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork7.Models
{
    //•	დავალება 2: დაწერეთ ანგარიშს კლასი, რომელსაც ექნება
    //•	ანგარიშის ნომერი(22 ნიშნა)
    //•	ვალუტა(სამნიშნა)
    //•	ბალანსი(არ უნდა იყოს უარყოფითი)
    public class Account
    {
        private string accountNumber;
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                if (value.Length == 22 && ContainsOnlyDigitsAndLetters(value))
                {
                    accountNumber = value;
                }
                else
                {
                    throw new ArgumentException("Account number should have 22 symbols numbers and letters ");
                }

            }
        }
        private string currency;
        public string Currency
        {
            get
            {
                return currency;
            }
            set
            {
                if (value.Length == 3 && ContainsOnlyLetters(value))
                {
                    currency = value;
                }
                else
                {
                    throw new ArgumentException("Currency should contain 3 letters");
                }
            }
        }

        private decimal balance;
        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {

                decimal parsedValue = decimal.Parse(value.ToString());
                if (parsedValue >= 0)
                {
                    balance = parsedValue;
                }
                else
                {
                    throw new ArgumentException("Balance cant be less than 0");
                }
            }
        }

        public Account(string accountNumber, string currency, decimal balance)
        {
            AccountNumber = accountNumber;
            Currency = currency;
            Balance = balance;
        }
        public void DisplayAccountInfo()
        {
            Console.WriteLine($"On account  {AccountNumber}, there is  {Balance} {Currency}");
        }


        public void TopUpBlaance(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount to add must be greater than zero.");
            }
            Balance += amount;
            Console.WriteLine($"{amount} {Currency} added to account {AccountNumber}. New balance: {Balance} {Currency}.");
        }

        public void TakeOutMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0.");
            }
            if (amount > Balance)
            {
                throw new ArgumentException("There is not enough money on balance");
            }
            Balance -= amount;
            Console.WriteLine($"{amount} {Currency} is taken from account {AccountNumber}. New balance id {Balance} {Currency}.");
        }

        public void TransferMoney(Account targetAccount, decimal amount)
        {
            if (targetAccount == null)
            {
                throw new ArgumentException("Target account cannot be null.");
            }
            if (Currency != targetAccount.Currency)
            {
                throw new ArgumentException("Cannot transfer money between accounts with different currencies.");
            }
            TakeOutMoney(amount);
            targetAccount.TopUpBlaance(amount);
            Console.WriteLine($"{amount} {Currency} transferred from {AccountNumber} to {targetAccount.AccountNumber}.");
        }



        public static bool ContainsOnlyDigitsAndLetters(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
        }
        public static bool ContainsOnlyLetters(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }
    }
}
