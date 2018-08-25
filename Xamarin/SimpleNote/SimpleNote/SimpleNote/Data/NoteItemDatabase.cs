using SimpleNote.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleNote.Data
{  

    public class NoteItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public NoteItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<NoteItem>().Wait();
        }

        public Task<List<NoteItem>> GetItemsAsync()
        {
            return database.Table<NoteItem>().ToListAsync();
        }

        public Task<List<NoteItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<NoteItem>("SELECT * FROM [NoteItem] WHERE [Done] = 0");
        }

        public Task<NoteItem> GetItemAsync(int id)
        {
            return database.Table<NoteItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(NoteItem item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(NoteItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}
