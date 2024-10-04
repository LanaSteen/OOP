using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork7.Models
{
    //•	დავალება 1: შექმენით კლასი რიმლითაც აღწერთ საკუთარ თავს. კლასს უნდა ჰქოონდეს შემდეგი ინფორმაცია თქვენი სახელი,გვარი,ასაკი,პირადი ნომერი, ტელეფონის ნომერი,ელ - ფოსტა.კლასი ინფორმაციას უნდა იღებდეს კონსტრუქტორიდან.მოახდინეთ თქვენი კლასის დემონსტრირება კონსოლში.

    public class Person
    {
        public string FirstName { get; set; }
        public string LastNAme { get; set; }
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Age can't be under 0");
                }
            }
        }
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
        public string Mobile { get; set; }
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (IsValidEmail(value))
                {
                    email = value;
                }
                else
                {
                    throw new ArgumentException("Email needs to contain @");
                }
            }
        }

        public Person()
        {

        }
        public Person(string firtsName, string lastName, string idNumber, string mobile, string email)
        {
            FirstName = firtsName;
            LastNAme = lastName;
            IdNumber = idNumber;
            Mobile = mobile;
            Email = email;
        }

        public void DisplayPersonInfo()
        {
            Console.WriteLine($"My name is {FirstName}, my lastname is {LastNAme} " +
                                  $"my id number is {IdNumber}, my phone number is {Mobile} " +
                                  $"and my email is {Email}");
        }
        public static bool IsValidEmail(string input)
        {
            return input.Contains('@');
        }
        public static bool IsValidIdNumber(string input)
        {
            return Regex.IsMatch(input, @"^\d{11}$");
        }
    }
}
