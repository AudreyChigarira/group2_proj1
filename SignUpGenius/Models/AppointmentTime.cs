using System;
using System.ComponentModel.DataAnnotations;

namespace SignUpGenius.Models
{
    public class AppointmentTime
    {
        [Key]
        public int TimeID { get; set; }

        public string Day { get; set; }

        public string Time { get; set; }

        public bool Scheduled { get; set; }
    }
}