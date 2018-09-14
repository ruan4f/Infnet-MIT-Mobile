using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Entities
{
    public class Match
    {
        public Match()
        {

        }

        public Match(Player player1, Player player2)
        {
            Id = Guid.NewGuid();
            Player1 = player1;
            Player2 = player2;
            Winner = null;
            MatchDate = new DateTime();
        }

        public Guid Id { get; set; }

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public Player Winner { get; set; }

        public DateTime MatchDate { get; set; }

    }
}
