using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Event
    {
        public string Title 
        {
            get
            {
                return this.Title;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("title cannot be an empty string");

                }
                this.Title = value;
            }
        }
        public DateTime Date 
        {
            get
            {
                return this.Date;
            }
            set
            {
                if(value < DateTime.Now)
                {
                    throw new ArgumentException("cannot set date as passed date");
                    
                }
                this.Date = value;
            }
        }
        public int MaxCapacity 
        {
            get
            {
                return this.MaxCapacity;
            } 
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("max capacity must be a positive value");

                }
                this.MaxCapacity = value;
            } 
        }
        public int Reserved { get; private set; } 

        public Event(string title, DateTime date, int capacity)
        {
            this.Title = title;
            this.Date = date;
            this.MaxCapacity = capacity;
            this.Reserved = 0;
        }

        public void Reserve(int amount)
        {
            if(this.Date < DateTime.Now)
            {
                throw new ExpiredException("the event is expired");
            }
            if(Reserved + amount > MaxCapacity)
            {
                throw new ArgumentOutOfRangeException("amount of seat requested higher than aviable seats");
            }
            this.Reserved += amount;
        }
        public void CancelReservation(int amount)
        {
            if (this.Date < DateTime.Now)
            {
                throw new ExpiredException("the event is expired");
            }
            if(amount > Reserved)
            {
                throw new ArgumentOutOfRangeException("amount of reservation cncelled higher than reserved seats");
            }
            this.Reserved-= amount;
        }
        public override string ToString()
        {
            return $"{this.Date.ToString("dd/MM/yyyy")} - {Title}";
        }
    }
}
