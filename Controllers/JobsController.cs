using Backend.DTOs;
using Backend.Models;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobPortalContext _context;
        private readonly IWebHostEnvironment _env;

        public JobsController(JobPortalContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public IActionResult GetJobs()
        {
            var jobs = _context.Jobs.ToList();
            return Ok(jobs);
        }

        [HttpPost]
        [RequestSizeLimit(10_000_000)]
        [Consumes("multipart/form-data")]  // Add this line
        public async Task<IActionResult> CreateJob([FromForm] JobDto dto, IFormFile? logo)  // Remove [FromForm] from IFormFile
        {
            // Add debug logging
            Console.WriteLine($"RECEIVED: Title='{dto.Title}', Company='{dto.CompanyName}', Location='{dto.Location}', JobType='{dto.JobType}', SalaryMin={dto.SalaryMin}, SalaryMax={dto.SalaryMax}, Description='{dto.Description}'");

            string logoFileName = null;

            if (logo != null)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                var originalFileName = Path.GetFileNameWithoutExtension(logo.FileName);
                var extension = Path.GetExtension(logo.FileName);
                logoFileName = $"{originalFileName}_{timeStamp}{extension}";
                var filePath = Path.Combine(uploadsFolder, logoFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await logo.CopyToAsync(stream);
                }
            }

            var job = new Job
            {
                Title = dto.Title,
                CompanyName = dto.CompanyName,
                Location = dto.Location,
                JobType = dto.JobType,
                SalaryMin = dto.SalaryMin,
                SalaryMax = dto.SalaryMax,
                Description = dto.Description,
                PostedByUserId = dto.PostedByUserId,
                LogoPath = logoFileName != null ? "/uploads/" + logoFileName : null
            };

            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Job created", job.Id, logoUrl = job.LogoPath });
        }
    }
}
