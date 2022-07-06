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
                if(value.Trim() != "")
                {
                    this.Title = value;
                }
                else
                {
                    throw new ArgumentException("title cannot be an empty string");
                }
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
                if(value > DateTime.Now)
                {
                    this.Date = value;
                }
                else
                {
                    throw new ArgumentException("cannot set date as passed date");
                }
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
                if(value > 0)
                {
                    this.MaxCapacity = value;
                }
                else
                {
                    throw new ArgumentException("max capacity must be a positive value");
                }
            } 
        }
        public int Reserved { get; private set; } = 0;

        public Event(string title, DateTime date, int capacity)
        {
            this.Title = title;
            this.Date = date;
            this.MaxCapacity = capacity;
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
            return $"{Date.ToString("dd/MM/yyyy")} - {Title}";
        }
    }
}
