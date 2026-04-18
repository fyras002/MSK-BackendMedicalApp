namespace MedicalAppBackend.Models
{
    public class ChatMessages
    {
        public int IdChatMessage { get; set; }
        public int? IdChat { get; set; }
        public string? Message { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? IdUserSender { get; set; }
        public bool? Report { get; set; }
        public bool? Active { get; set; }
    }
}
