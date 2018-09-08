using System;

namespace DomainModel.Entities
{
    public class Player
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
