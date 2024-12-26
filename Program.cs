class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select the test you want to run:");
        Console.WriteLine("1. Register Test");
        Console.WriteLine("2. Login Test");
        Console.WriteLine("3. Add to Cart Test");
        Console.WriteLine("4. Delete Cart Test");
        Console.WriteLine("5. Place Order Test");
        Console.WriteLine("6. Contact Test");
        Console.WriteLine("7. Page Load Performance Test");
        Console.WriteLine("input number:");

        string pilihan = Console.ReadLine();

        if (pilihan == "1")
        {
            RegisterTest registerTest = new RegisterTest();
            registerTest.Run();
        }
        else if (pilihan == "2")
        {
            LoginTest loginTest = new LoginTest();
            loginTest.Run();
        }
         else if (pilihan == "3")
        {
           AddToCartTest addToCartTest = new AddToCartTest();
            addToCartTest.Run();
        }
         else if (pilihan == "4")
        {
           DeleteCartTest deleteCartTest = new DeleteCartTest();
            deleteCartTest.Run();
        }
         else if (pilihan == "5")
        {
           PlaceOrderTest placeOrderTest = new PlaceOrderTest();
            placeOrderTest.Run();
        }
        else if (pilihan == "6")
        {
           ContactTest contactTest = new ContactTest();
            contactTest.Run();
        }
         else if (pilihan == "7")
        {
           PageLoadPerformanceTest pageLoadPerformanceTest = new PageLoadPerformanceTest();
            pageLoadPerformanceTest.Run();
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }
}
