using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork7.Models
{
    //•	დაწერეთ კლიენტის კლასი, რომელსაც ექნება
    //•	სახელი
    //•	გვარი
    //•	პირადი ნომერი(11 ნიშნა)
    //•	ანგარიში
    public class Client
    {
        public string FirstName { get; set; }
        public string LastNAme { get; set; }
      
        private string idNumber;
        public string IdNumber
        {
            get
            {
                return idNumber;
            }
            set
            {
                if (value.Length == 11 && IsValidIdNumber(value))
                {
                    idNumber = value;
                }
                else
                {
                    throw new ArgumentException("Id number should be 11 digits");
                }
            }
        }

        public Account Account { get; set; }
        

        public Client(string firtsName, string lastName, string idNumber, Account account)
        {
            FirstName = firtsName;
            LastNAme = lastName;
            IdNumber = idNumber;
            Account = account;
        }


        public void DisplayClientInfo()
        {
            Console.WriteLine($"My name is {FirstName}, my lastname is {LastNAme} " +
                                  $"my id number is {IdNumber}, and i have account {Account.AccountNumber}");
        }

        public void TopUpBlaanceFromClient(decimal amount)
        {
            Account.TopUpBlaance(amount);
        }

        public void TakeOutMoneyFromClient(decimal amount)
        {
            Account.TakeOutMoney(amount);
        }

        public void TransferMoneyFromClient(Client targetClient, decimal amount)
        {
            if (targetClient == null)
            {
                throw new ArgumentException("Target client cannot be null.");
            }
            if (Account.Currency != targetClient.Account.Currency)
            {
                throw new ArgumentException("Cannot transfer money between accounts with different currencies.");
            }
            Account.TransferMoney(targetClient.Account, amount);
        }




        public static bool IsValidIdNumber(string input)
        {
            return Regex.IsMatch(input, @"^\d{11}$");
        }

    }
}
