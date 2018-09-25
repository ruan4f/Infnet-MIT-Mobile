using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DomainModel.Entities
{
    public class Match
    {
        public Match()
        {
            MatchesPlayed = new HashSet<MatchPlayed>();
        }

        public Match(Guid id, DateTime date)
        {
            MatchId = id;
            MatchDate = date;
            MatchesPlayed = new HashSet<MatchPlayed>();
        }

        public Match(Guid id, Player player1, Player player2, Player winner)
        {
            MatchId = id;
            MatchDate = DateTime.Now;
            MatchesPlayed = new List<MatchPlayed>();
            MatchesPlayed.Add(new MatchPlayed(this, player1, player2, winner));
        }

        public Match(Guid id, Player player1, Player player2)
        {
            MatchId = id;          
            MatchDate = DateTime.Now;
            MatchesPlayed = new List<MatchPlayed>();
            MatchesPlayed.Add(new MatchPlayed(this, player1, player2));
        }

        public Guid MatchId { get; set; }

        [NotMapped]
        public MatchPlayed MatchPlayed => MatchesPlayed.FirstOrDefault(m => m.MatchId == MatchId);

        public virtual ICollection<MatchPlayed> MatchesPlayed { get; set; }

        public DateTime MatchDate { get; set; }
    }
}
