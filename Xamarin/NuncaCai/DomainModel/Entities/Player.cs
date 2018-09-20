using System;
using System.Collections;
using System.Collections.Generic;

namespace DomainModel.Entities
{
    public class Player
    {
        public Player()
        {

        }

        public Player(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Point = 0;
            RegistrationDate = new DateTime();            
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Point { get; set; }

        public DateTime RegistrationDate { get; set; }

    }
}
