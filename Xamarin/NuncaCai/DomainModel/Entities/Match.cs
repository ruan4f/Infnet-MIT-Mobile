using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Entities
{
    public class Match
    {
        public Guid Id { get; set; }

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public Player Winner { get; set; }

    }
}
