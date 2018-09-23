using System;
using System.Collections;
using System.Collections.Generic;

namespace DomainModel.Entities
{
    public class Player
    {
        public Player()
        {
            FirstMatches = new List<Match>();
            SecondMatches = new List<Match>();
            WinnerMatches = new List<Match>();
        }

        public Player(string name)
        {
            PlayerId = Guid.NewGuid();
            Name = name;
            Point = 0;
            RegistrationDate = new DateTime();

            FirstMatches = new List<Match>();
            SecondMatches = new List<Match>();
            WinnerMatches = new List<Match>();
        }

        public Guid PlayerId { get; set; }

        public string Name { get; set; }

        public int Point { get; set; }

        public DateTime RegistrationDate { get; set; }
        
        public virtual ICollection<Match> FirstMatches { get; set; }
        public virtual ICollection<Match> SecondMatches { get; set; }
        public virtual ICollection<Match> WinnerMatches { get; set; }

    }
}
