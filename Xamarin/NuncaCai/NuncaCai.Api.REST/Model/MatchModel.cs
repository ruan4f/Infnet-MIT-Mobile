using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuncaCai.Api.REST.Model
{
    public class MatchModel
    {

        public Guid Id { get; set; }
        public Guid Player1Id { get; set; }
        public Guid Player2Id { get; set; }
        public Guid WinnerId { get; set; }
        public DateTime Date { get; set; }
    }
}
