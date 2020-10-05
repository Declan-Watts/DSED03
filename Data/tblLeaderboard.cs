using SQLite;

namespace DSED03.Data
{
    [Table("tblLeaderboard")]
    public class tblLeaderboard
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        [Column("Username")]
        public string Username { get; set; }
        [Column("Wins")]
        public int Wins { get; set; }
        [Column("Loses")]
        public int Loses { get; set; }
        [Column("Score")]
        public int Score { get; set; }
    }
}