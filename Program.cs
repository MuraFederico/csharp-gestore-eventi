using csharp_gestore_eventi;




Event newEvent = CreateEvent();

MakeReservation(newEvent);

IsCancelling(newEvent);


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
        MakeReservation(newEvent);
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
        newEvent.PrintSeats();
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