using SQLite;

namespace QuinielaComunitaria.Models
{
    public class User
    {
        [PrimaryKey]
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}