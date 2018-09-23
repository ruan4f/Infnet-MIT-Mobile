using System;
using System.Collections.Generic;
using System.Text;

namespace NuncaCaiMobile.Models
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
            RegistrationDate = DateTime.Now;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Point { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
