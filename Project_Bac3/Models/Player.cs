namespace Project_Bac3.Models
{
    public class Player : Person
    {
        public string Description { get; set; } = string.Empty;
        public int EloRating { get; set; } = 400; // Default starting Elo
    }
}