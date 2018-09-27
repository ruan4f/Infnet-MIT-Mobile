using System;

namespace NuncaCai.Application.Models
{
    public class MatchModel
    {
        public Guid Id { get; set; }
        public Guid Player1Id { get; set; }
        public Guid Player2Id { get; set; }
        public Guid WinnerId { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
