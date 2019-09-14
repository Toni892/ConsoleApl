using System;
using System.Linq;

namespace konzolna
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            PersonService person = new PersonService();
            do
            {
                Console.WriteLine("Enter command: Add,Delete,List,<role>List,help");

                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "help":
                        Console.Clear();
                        Console.WriteLine("add-add new person");
                        Console.WriteLine("Delete-delete person");
                        Console.WriteLine("List-list all people");
                        Console.WriteLine("<role>List-get people by role");
                        break;

                    case "add":
                        Console.Clear();
                        Person p = new Person();
                        Console.WriteLine("Name: ");
                        p.Name = Console.ReadLine();
                        Console.WriteLine("Last name: ");
                        p.LastName = Console.ReadLine();
                        Console.WriteLine("Age: ");
                        string age = Console.ReadLine();
                        if (age.All(char.IsDigit))
                        {
                            p.Age = Convert.ToInt32(age);
                        }
                        else
                        {
                            Console.WriteLine("Invalid age");
                            break;
                        }
                        Console.WriteLine("Role: ");
                        p.Role = Console.ReadLine();

                        var a = person.Add(p);
                        Console.WriteLine(a);
                        break;
                    case "delete":
                        Console.WriteLine("enter id");
                        string id = Console.ReadLine();
                        var guidId = Guid.Parse(id);
                        var check = person.Delete(guidId);
                        if (check)
                        {
                            Console.WriteLine("deleted");
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "list":
                        var list = person.Display();
                        Console.Clear();
                        foreach (var item in list)
                        {
                            Console.Write($"{item.Id} {item.Name} {item.LastName} {item.Age} {item.Role}");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        Console.WriteLine("press enter");
                        Console.Read();
                        break;
                    case "<role>list":
                        Console.WriteLine("Enter role");
                        string role = Console.ReadLine().ToLower();
                        var listRole = person.ListRole(role);
                        if (listRole != null)
                        {
                            foreach (var item in listRole)
                            {
                                Console.WriteLine($"{item.Name} {item.LastName} {item.Age} {item.Role}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Greska");
                        }
                        break;
                    case "exit":
                        Console.WriteLine("Exiting");
                        break;
                    default:
                        break;
                }
            }
            while (input != "exit");
        }
    }
}