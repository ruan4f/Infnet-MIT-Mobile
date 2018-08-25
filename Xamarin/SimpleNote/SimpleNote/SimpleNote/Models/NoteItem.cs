using SQLite;
namespace SimpleNote.Models
{
    public class NoteItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }    
        public bool Done { get; set; }
    }
}
