using SQLite;

namespace SimpleNote.Data
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
