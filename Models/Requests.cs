using System;

namespace hihi.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int IdClient { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}