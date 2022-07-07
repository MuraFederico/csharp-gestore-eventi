using csharp_gestore_eventi;


ManageEvents program = CreateProgram();


Console.WriteLine("How many events do you want to add? ");
int numerEvents = int.Parse(Console.ReadLine());

int i = 0;

while (i < numerEvents)
{

    Event newEvent = CreateEvent();

    MakeReservation(newEvent);

    IsCancelling(newEvent);

    program.AddEvent(newEvent);

    i++;
}

Console.WriteLine($"number of events: {program.events.Count}\n");

Console.WriteLine(program.ToString());

Console.WriteLine();

Console.Write("give me a date (gg/mm/yyyy) ");

DateTime userDate = DateTime.Parse(Console.ReadLine());

List<Event> eventsOfDate = program.FindEventsByDate(userDate);

Console.WriteLine(ManageEvents.PrintEvents(eventsOfDate));

program.ClearList();

Event CreateEvent()
{
    Console.Write("insert event name: ");
    string title = Console.ReadLine();
    Console.Write("insert event date (gg/mm/yyyy): ");
    DateTime date = DateTime.Parse(Console.ReadLine());
    Console.Write("insert event max capacity: ");
    int maxCapacity = int.Parse(Console.ReadLine());
    Event newEvent;
    try
    {
      newEvent =  new Event(title, date, maxCapacity);
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
        newEvent =  CreateEvent();
    }
    return newEvent;
}

void MakeReservation(Event evento)
{
    Console.Write("how many seat do you want to reserve? ");
    int amount = int.Parse(Console.ReadLine());
    try
    {
        evento.Reserve(amount);
    }catch(ExpiredException e)
    {
        Console.WriteLine(e.Message);
        MakeReservation(evento);
    }catch(ArgumentOutOfRangeException e)
    {
        Console.WriteLine(e.Message);
        MakeReservation(evento);
    }
    evento.PrintSeats();
}

void IsCancelling(Event evento)
{
    string answer;
    Console.Write("do you want to cancel a reservation? yes/no ");
    answer = Console.ReadLine();
    if(answer != "yes" && answer != "no")
    {
        Console.WriteLine("invalid answer");
        IsCancelling(evento);
    }
    if(answer == "yes")
    {
        CancelReservation(evento);
    }
    else
    {
        Console.WriteLine("Understood");
        evento.PrintSeats();
    }
    
}

void CancelReservation(Event evento)
{
    Console.Write("how many seat do you want to cancel reservation for? ");
    int amount = int.Parse(Console.ReadLine());
    try
    {
        evento.CancelReservation(amount);
        evento.PrintSeats();
        IsCancelling(evento);
    }
    catch (ExpiredException e)
    {
        Console.WriteLine(e.Message);
        CancelReservation(evento);
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.WriteLine(e.Message);
        CancelReservation(evento);
    }
}

ManageEvents CreateProgram()
{
    Console.WriteLine("PROGRAM CREATION\n");
    Console.Write("Insert program title: ");
    string title = Console.ReadLine();
    try
    {
        return new ManageEvents(title);
        
    }
    catch(ArgumentException e)
    {
        Console.WriteLine(e.Message);
        return CreateProgram();
    }
}