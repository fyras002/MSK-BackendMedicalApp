namespace MedicalAppBackend.Models
{
    public class Chats
    {
        public int IdChat { get; set; }
        public int? IdUserSender { get; set; }
        public int? IdUserReciver { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? AdminReview { get; set; }
        public bool? Active { get; set; }
    }
}
