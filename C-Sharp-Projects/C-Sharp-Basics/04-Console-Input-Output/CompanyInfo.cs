using System;

class CompanyInfo
{
    static void Main()
    {
        Console.WriteLine("Enter company info (name, address, phone number, fax number, website, first and last manager name, manager age and manager phone number) each followed by Enter: ");
        string name = Console.ReadLine();
        string address = Console.ReadLine();
        string phoneNumber = Console.ReadLine();    //I use string for phone numbers, so it can save the zeros in the beginning
        string faxNumber = Console.ReadLine();
        string webSite = Console.ReadLine();
        string managerName = Console.ReadLine();
        string managerLastName = Console.ReadLine();
        int managerAge = int.Parse(Console.ReadLine());
        string managerNumber = Console.ReadLine();
        Console.WriteLine("Company {0} is located at {1}. The phone and fax numbers of {0} are {2} and {3} respectively. The website of the company is {4}. The manager is named {5} {6} and is {7} years old. You can find him at {8}", name, address, phoneNumber, faxNumber, webSite, managerName, managerLastName, managerAge, managerNumber);
    }
}

