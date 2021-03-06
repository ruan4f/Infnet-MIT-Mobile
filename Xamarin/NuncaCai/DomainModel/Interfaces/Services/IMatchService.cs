﻿using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Interfaces.Services
{
    public interface IMatchService
    {
        Task AddSync(Guid id, Guid player1Id, Guid player2Id, Guid winnerId, DateTime date);
        Task AddSync(Match match);
        Task UpdateSync(Match match);
        IEnumerable<Match> GetAll();
        IEnumerable<Match> GetSimpleAll();
        Task<Match> GetByIdSync(Guid id);
        void RemoveAll();
    }
}
