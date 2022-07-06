using csharp_gestore_eventi;

Console.Write("insert event name: ");
string title = Console.ReadLine();
Console.Write("insert event date (gg/mm/yyyy): ");
DateTime date = DateTime.Parse(Console.ReadLine());
Console.Write("insert event max capacity: ");
int maxCapacity = int.Parse(Console.ReadLine());

try
{
    

    Event newEvent = new Event(title, date, maxCapacity);
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}

Console.Write("how many seat do you want to reserve?");

