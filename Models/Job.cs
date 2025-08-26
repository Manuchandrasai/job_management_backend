using System;

namespace Backend.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
        public int? SalaryMin { get; set; }
        public int? SalaryMax { get; set; }
        public string Description { get; set; }
        public int PostedByUserId { get; set; }
        public string LogoPath { get; set; }
        // public DateTime? ApplicationDeadline { get; set; } // If needed
    }
}
