namespace KYHBPA
{
    public class Photo
    {
        public int Id { get; set; }
        public Member Uploader { get; set; }
        // Associated Event
        public Event Event { get; set; }
        public byte[] Content { get; set; }
        public string PhotoName { get; set; }
        public string Description { get; set; }
    }
}