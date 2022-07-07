using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class ManageEvents
    {
        public string title;
        List<Event> events;
        public ManageEvents(string title)
        {
            this.title = title;
            this.events = new List<Event>();
        }

        public void AddEvent(Event selectedEvent)
        {
            this.events.Add(selectedEvent);
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
                result += $"{selectedEvent.Date.ToString("dd/MM/yyyy")} - {selectedEvent.Title}\n";
            }
            return result;
        }

        public void ClearList()
        {
            this.events.Clear();
        }

        public override string ToString()
        {
            return $"Name Program: {this.title}\n" + ManageEvents.PrintEvents(this.events);

        }
    }
}
