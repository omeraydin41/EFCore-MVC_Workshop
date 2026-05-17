namespace EFCore_MVC_Workshop.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageTitle { get; set; }//messajın başlığı
        public string MessageDetail { get; set; }//mesajın detayı 
        public string SenderNameSurname { get; set; }//mesajın detayı 
        public string SenderImageUrl { get; set; }//mesajın detayı 
        public DateTime DateTime { get; set; }//mesajın gonderilme tarıhi.
        public bool IsRead { get; set; }//mesaj okundu mu 
    }
}
