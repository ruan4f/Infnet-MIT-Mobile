using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Entities
{
    public class Match
    {
        public Match()
        {
            MatchesPlayed = new HashSet<MatchPlayed>();
        }

        public Match(Guid id, Player player1, Player player2, Player winner)
        {
            MatchId = id;
            //Player1Id = player1.PlayerId;
            //Player1 = player1;
            //Player2Id = player2.PlayerId;
            //Player2 = player2;
            //WinnerId = winner.PlayerId;
            //Winner = winner;
            MatchDate = DateTime.Now;
            MatchesPlayed = new List<MatchPlayed>();
            MatchesPlayed.Add(new MatchPlayed(this, player1, player2, winner));
        }

        public Match(Guid id, Player player1, Player player2)
        {
            MatchId = id;
            //Player1Id = player1.PlayerId;
            //Player1 = player1;
            //Player2Id = player2.PlayerId;
            //Player2 = player2;            
            MatchDate = DateTime.Now;
            MatchesPlayed = new List<MatchPlayed>();
            MatchesPlayed.Add(new MatchPlayed(this, player1, player2));
        }

        public Guid MatchId { get; set; }

        public MatchPlayed MatchPlayed => MatchesPlayed.FirstOrDefault(m => m.MatchId == MatchId);

        public virtual ICollection<MatchPlayed> MatchesPlayed { get; set; }

        //public Guid Player1Id { get; set; }

        //public Player Player1 { get; set; }

        //public Guid Player2Id { get; set; }

        //public Player Player2 { get; set; }

        //public Guid WinnerId { get; set; }

        //public Player Winner { get; set; }

        public DateTime MatchDate { get; set; }
        
        //public bool Player1Winner => Player1Id == WinnerId;

        //public bool Player2Winner => Player2Id == WinnerId;
    }
}
