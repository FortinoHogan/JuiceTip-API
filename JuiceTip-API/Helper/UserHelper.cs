using JuiceTip_API.Data;
using JuiceTip_API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;

namespace JuiceTip_API.Helper
{
    public class UserHelper
    {
        private JuiceTipDBContext _dbContext;
        private readonly IConfiguration _configuration;
        public UserHelper(JuiceTipDBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public MsUser GetUser([FromBody] LoginRequest user)
        {
            try
            {
                var data = _dbContext.MsUser.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
                if (data != null) return data;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string GenerateOTP()
        {
            // Generate a random 6-digit OTP
            Random rnd = new Random();
            int otpNumber = rnd.Next(100000, 999999);
            return otpNumber.ToString();
        }

        public string SendOTPEmail(string name, string email)
        {
            try
            {
                string otp = GenerateOTP();
                string sender = _configuration["Email:Sender"];
                string password = _configuration["Email:Password"];

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(sender, password),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(sender),
                    Subject = "OTP Verification",
                    Body = $"Hello, {name}!<br/><br/>Your JuiceTip Apps OTP code is <b>{otp}</b><br/>Beware of Fraud! This code is only for you to enter in JuiceTip Apps.<br/>Don't give your OTP code to anyone, including JuiceTip.<br/>Ignore this email if you feel like you didn't make the OTP request.<br/>",
                    IsBodyHtml = true
                };

                mailMessage.To.Add(email);
                smtpClient.Send(mailMessage);

                return otp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MsUser UpsertUser([FromBody] RegisterRequest user)
        {
            try
            {
                if (user != null)
                {
                    var newUser = new MsUser
                    {
                        Email = user.Email,
                        Password = user.Password,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address = user.Address,
                        Telephone = user.Telephone,
                    };

                    _dbContext.MsUser.Add(newUser);
                    _dbContext.SaveChanges();

                    return newUser;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
