namespace BookingApp.Models.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;

        public int RoomID { get; set; }

        public virtual Room Room { get; set; }
    }
}
