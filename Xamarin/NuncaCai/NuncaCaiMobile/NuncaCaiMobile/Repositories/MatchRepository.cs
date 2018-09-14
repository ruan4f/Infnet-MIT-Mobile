using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using NuncaCaiMobile.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace NuncaCaiMobile.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private RepositoryContext _db;

        public MatchRepository()
        {
            string dbPath = String.Empty;

            switch (Device.RuntimePlatform)
            {
                case Device.UWP:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                    break;
                case Device.iOS:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "data", "database.sqlite");
                    break;
                case Device.Android:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "database.sqlite");
                    break;
            }

            _db = new RepositoryContext(dbPath);
        }


        public void Add(Match match)
        {
            _db.Matches.Add(match);
            _db.SaveChanges();
        }

        public void Update(Match match)
        {
            var entry = _db.Entry(match);
            _db.Matches.Attach(match);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }

        public IEnumerable<Match> GetAll()
        {
            return _db.Matches;
        }
    }
}
