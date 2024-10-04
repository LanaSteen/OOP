
using HomeWork7.Models;


namespace HomeWork7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	დავალება 1: შექმენით კლასი რიმლითაც აღწერთ საკუთარ თავს. კლასს უნდა ჰქოონდეს შემდეგი ინფორმაცია თქვენი სახელი,გვარი,ასაკი,პირადი ნომერი, ტელეფონის ნომერი,ელ - ფოსტა.კლასი ინფორმაციას უნდა იღებდეს კონსტრუქტორიდან.მოახდინეთ თქვენი კლასის დემონსტრირება კონსოლში.

            try
            {
                Person person = new Person("Lana", "Steen", "12345678910", "599010101", "lanaStee@gmail.com");

                person.DisplayPersonInfo();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


            //•	დავალება 2: დაწერეთ ანგარიშს კლასი, რომელსაც ექნება
            //•	ანგარიშის ნომერი(22 ნიშნა)
            //•	ვალუტა(სამნიშნა)
            //•	ბალანსი(არ უნდა იყოს უარყოფითი)

            //•	დაწერეთ კლიენტის კლასი, რომელსაც ექნება
            //•	სახელი
            //•	გვარი
            //•	პირადი ნომერი(11 ნიშნა)
            //•	ანგარიში

            //მოახდინეთ თქვენს მიერ შექმნილი კლასების დემონსტრირება კონსოლში ობიექტების სახით. ობიექტებს უნდა შეეძლოთ თანხის განაღდება ბალანსის შევსება, ერთმანეთისთვის თნხის გადარიცხვა.

            try
            {
                Account account1 = new Account("1234567891234567891234", "GEL", 200);
                account1.DisplayAccountInfo();

                Client client1 = new Client("John", "Doe", "12345678910", account1);
                client1.DisplayClientInfo();

                Account account2 = new Account("1234567891234567891235", "GEL", 400);
                account2.DisplayAccountInfo();

                Client client2 = new Client("Jane", "Smith", "12345612345", account2);
                client2.DisplayClientInfo();


                client1.TransferMoneyFromClient(client2, 100);
                client1.TopUpBlaanceFromClient(700);
                client1.TakeOutMoneyFromClient(100);
    


                client2.TransferMoneyFromClient(client2, 200);
                client1.TopUpBlaanceFromClient(800);
                client1.TakeOutMoneyFromClient(100);


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
    }
}
