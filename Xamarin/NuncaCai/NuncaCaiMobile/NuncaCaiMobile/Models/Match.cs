using System;
using System.Collections.Generic;
using System.Text;

namespace NuncaCaiMobile.Models
{
    public class Match
    {
        public Match()
        {

        }

        public Match(Guid player1Id, Guid player2Id)
        {
            Id = Guid.NewGuid();
            Player1Id = player1Id;
            Player2Id = player2Id;
            MatchDate = new DateTime();
        }

        public Guid Id { get; set; }

        public Guid Player1Id { get; set; }
        public virtual Player Player1 { get; set; }

        public Guid Player2Id { get; set; }
        public virtual Player Player2 { get; set; }

        public Guid WinnerId { get; set; }
        public virtual Player Winner { get; set; }

        public DateTime MatchDate { get; set; }

        public bool DontHaveWinner => Winner == null;

    }
}
