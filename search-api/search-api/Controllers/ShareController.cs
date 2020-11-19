using Microsoft.AspNetCore.Mvc;
using search_application.Services;
using System;
using System.Threading.Tasks;

namespace search_api.Controllers
{
    public class ShareController : Controller
    {
        private readonly IEmailService emailService;

        public ShareController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        [Route("share")]
        public async Task<IActionResult> Post([FromQuery]string destination_email, string content_url)
        {
            try
            {
                await emailService.Send(destination_email, "Shared question", content_url);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
