using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniqueEmails.Data;
using UniqueEmails.Dtos;

namespace UniqueEmails.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailRepo _emailRepo;
        private readonly ILogger<EmailsController> _logger;

        public EmailsController(IEmailRepo emailRepo, ILogger<EmailsController> logger)
        {
            _emailRepo = emailRepo;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetEmails()
        {
            string[] emails = new string[] 
                {"test.email@gmail.com", "test.email+spam@gmail.com", "testemail@gmail.com"};
            return Ok(emails);
        }

        [HttpPost("NoOfUniqueEmails")]
        public IActionResult GetNoOfUniqueEmails(EmailForEmailStringDto emailForEmailStringDto)
        {
            try
            {
                var emails = _emailRepo.GetUniqueEmails(emailForEmailStringDto.EmailString).ToList();
                return Ok(emails.Count);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "GetNoOfUniqueEmails() Error");

                return StatusCode(500, "Error happened when calculating unique number of emails.");
            }
        }
    }
}