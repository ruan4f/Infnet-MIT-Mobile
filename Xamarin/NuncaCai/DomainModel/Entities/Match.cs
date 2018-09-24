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

        public Match(Guid id, Player player1, Player player2, Player winner)
        {
            MatchId = id;
            Player1Id = player1.PlayerId;
            Player1 = player1;
            Player2Id = player2.PlayerId;
            Player2 = player2;
            WinnerId = winner.PlayerId;
            Winner = winner;
            MatchDate = DateTime.Now;
        }

        public Match(Guid id, Player player1, Player player2)
        {
            MatchId = id;
            Player1Id = player1.PlayerId;
            Player1 = player1;
            Player2Id = player2.PlayerId;
            Player2 = player2;            
            MatchDate = DateTime.Now;
        }

        public Guid MatchId { get; set; }

        public Guid Player1Id { get; set; }

        public virtual Player Player1 { get; set; }

        public Guid Player2Id { get; set; }

        public virtual Player Player2 { get; set; }

        public Guid WinnerId { get; set; }

        public virtual Player Winner { get; set; }

        public DateTime MatchDate { get; set; }
    }
}
