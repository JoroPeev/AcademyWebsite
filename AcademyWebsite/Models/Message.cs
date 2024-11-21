﻿namespace AcademyWebsite.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

    }
}