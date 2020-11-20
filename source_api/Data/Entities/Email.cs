﻿using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Email
    {
        [Key]
        public int Id { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
