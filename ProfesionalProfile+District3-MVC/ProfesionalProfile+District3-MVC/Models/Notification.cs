﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfesionalProfile_District3_MVC.Models
{
    public class Notification
    {
        [Key]
        public int notificationId { get; set;}
        public string userId { get; set; }
        public string activity { get; set; }
        public DateTime timestamp { get; set; }
        public string details { get; set; }
        public bool isRead { get; set; }
    }
}
