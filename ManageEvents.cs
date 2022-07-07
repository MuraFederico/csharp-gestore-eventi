using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class ManageEvents
    {
        string title;
        public List<Event> events;
        public ManageEvents(string title)
        {
            this.title = title;
            this.events = new List<Event>();
        }

        public string Title
        {
            get { return title; }
            private set 
            { 
                if(value.Trim() == "")
                {
                    throw new ArgumentException("title cannot be an empty string");
                } 
                title = value;
            }
        }

        public void AddEvent(Event selectedEvent)
        {
            this.events.Add(selectedEvent);
            Console.WriteLine("Event Added");
        }

        public List<Event> FindEventsByDate(DateTime selectedDate)
        {
            List<Event> result = new List<Event>();
            foreach (Event selectedEvent in this.events)
            {
                if(selectedEvent.Date == selectedDate)
                {
                    result.Add(selectedEvent);
                }
            }
            return result;
        }

        public static string PrintEvents(List<Event> eventsList)
        {
            string result = "";
            foreach (Event selectedEvent in eventsList)
            {
                result = result + $"{selectedEvent.Date.ToString("dd/MM/yyyy")} - {selectedEvent.Title}\n";
            }
            return result;
        }

        public void ClearList()
        {
            this.events.Clear();
            Console.WriteLine("all events deleted");
        }

        public override string ToString()
        {
            return $"Name Program: {this.title}\n" + ManageEvents.PrintEvents(this.events);

        }
    }
}
