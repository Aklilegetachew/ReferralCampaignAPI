﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReferralCampaignAPI.Models
{
    public class Employee
    {
        [Key] // Specifies that this is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public string ReferralCode { get; set; }

        [Required]
        public int ReferralCount { get; set; }

        [Required]
        public decimal TotalRevenue { get; set; }
    }
}
