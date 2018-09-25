using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    public class MatchPlayed
    {
        public MatchPlayed()
        {

        }

        public MatchPlayed(Match match, Player player1, Player player2, Player winner)
        {
            MatchId = match.MatchId;
            Match = match;
            Player1Id = player1.PlayerId;
            Player1 = player1;
            Player2Id = player2.PlayerId;
            Player2 = player2;
            WinnerId = winner.PlayerId;
            Winner = winner;
        }

        public MatchPlayed(Match match, Player player1, Player player2)
        {
            MatchId = match.MatchId;
            Match = match;
            Player1Id = player1.PlayerId;
            Player1 = player1;
            Player2Id = player2.PlayerId;
            Player2 = player2;            
        }

        public Guid MatchId { get; set; }
        public Match Match { get; set; }

        public Guid Player1Id { get; set; }
        public Player Player1 { get; set; }
        
        public Guid Player2Id { get; set; }        
        public Player Player2 { get; set; }
        
        public Guid WinnerId { get; set; }        
        public Player Winner { get; set; }

        [NotMapped]
        public bool Player1Winner => Player1Id == WinnerId;

        [NotMapped]
        public bool Player2Winner => Player2Id == WinnerId;

    }
}
