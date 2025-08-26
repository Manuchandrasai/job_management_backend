using System;

namespace Backend.DTOs
{
    public class JobDto
{
    public string Title { get; set; }           // matches "Title" 
    public string CompanyName { get; set; }     // matches "CompanyName"
    public string Location { get; set; }        // matches "Location"
    public string JobType { get; set; }         // matches "JobType" 
    public int? SalaryMin { get; set; }         // matches "SalaryMin"
    public int? SalaryMax { get; set; }         // matches "SalaryMax"
    public string Description { get; set; }     // matches "Description"
    public int PostedByUserId { get; set; }     // matches "PostedByUserId"
}

}
