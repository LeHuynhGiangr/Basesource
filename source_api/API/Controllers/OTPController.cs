using Data.EF;
using Data.Entities;
using Domain.Services.InternalServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("otp")]
    public class OTPController : ControllerBase
    {
        private readonly ProjectDbContext _context;

        public OTPController(ProjectDbContext context)
        {
            _context = context;
        }

        [HttpPost("send-email-otp")]
        public async Task<IActionResult> SendOTPByEmail([FromForm] string email)
        {
            try
            {
                if (email == null)
                {
                    return BadRequest("Email is required");
                }
                OTP otp = await _context.OTPs.FirstOrDefaultAsync(otp => otp.MailAddress.Equals(email));
                Random rand = new Random();

                if (otp == null)
                {
                    int digits = rand.Next(10000, 100000);

                    otp = new OTP
                    {
                        DateCreated = DateTime.Now,
                        MailAddress = email,
                        OTPcode = digits
                    };

                    _context.OTPs.Add(otp);
                    await _context.SaveChangesAsync();

                    // OK When instance otp created and then create random number,send email.


                    string body = "Verification code: " + digits;

                    await EmailService.SendAsync(email, "Verification Account Social Network", body);

                }
                else
                {
                    int digits = rand.Next(10000, 100000);
                    otp.OTPcode = digits;
                    await _context.SaveChangesAsync();
                }

                return Ok("OTP Send Successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
