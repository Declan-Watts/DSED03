using SQLite;

namespace DSED03.Data
{
    [Table("Users")]
    public class Users
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int id { get; set; }
        [Column("username")]
        public string username { get; set; }
        [Column("active")]
        public string active { get; set; }
        [Column("wins")]
        public int wins { get; set; }
        [Column("loses")]
        public int loses { get; set; }
        [Column("score")]
        public int score { get; set; }
    }
}