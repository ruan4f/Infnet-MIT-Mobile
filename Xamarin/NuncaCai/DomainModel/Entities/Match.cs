﻿using System;
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
            Id = id;
            Player1Id = player1.Id;
            Player1 = player1;
            Player2Id = player2.Id;
            Player2 = player2;
            WinnerId = winner.Id;
            Winner = winner;
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
