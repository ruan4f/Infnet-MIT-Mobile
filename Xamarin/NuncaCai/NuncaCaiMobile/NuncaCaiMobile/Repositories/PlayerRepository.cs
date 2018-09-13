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
    public class PlayerRepository : IPlayerRepository
    {
        private RepositoryContext _db;

        public PlayerRepository()
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


        public void Add(Player player)
        {
            _db.Players.Add(player);
            _db.SaveChanges();
        }

        public IEnumerable<Player> GetAll()
        {
            return _db.Players;
        }

        public void Update(Player player)
        {
            var entry = _db.Entry(player);
            _db.Players.Attach(player);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
