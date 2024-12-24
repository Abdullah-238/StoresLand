//namespace StoresPlace_Front.Login;

//public partial class pgResetPassword : ContentPage
//{
//	public pgResetPassword()
//	{
//		InitializeComponent();
//	}

//    public class PasswordResetRequest
//    {
//        public string Email { get; set; }
//    }

//    using System;
//using System.Net;
//using System.Net.Mail;
//using System.Text;
//using System.Web.Security; // To generate the token

//public class PasswordResetService
//{
//    public void SendPasswordResetEmail(string email)
//    {
//        // Generate a password reset token
//        string token = GeneratePasswordResetToken(email);

//        // Build reset URL (make sure your app is running on a server)
//        string resetUrl = "https://yourwebsite.com/ResetPassword?token=" + token;

//        // Send email with reset link
//        SendEmail(email, resetUrl);
//    }

//    private string GeneratePasswordResetToken(string email)
//    {
//        // Here we use Membership.GeneratePasswordResetToken() as an example; you can replace with your method
//        // It is better to store this token in your database along with the expiration time.
//        return Convert.ToBase64String(Encoding.UTF8.GetBytes(email + ":" + DateTime.UtcNow.ToString("yyyyMMddHHmmss")));
//    }

//    private void SendEmail(string toEmail, string resetUrl)
//    {
//        var fromEmail = "no-reply@yourwebsite.com"; // Set your sender email
//        var fromPassword = "your-email-password";  // Set your email password

//        var client = new SmtpClient("smtp.yourmailserver.com")
//        {
//            Port = 587,
//            Credentials = new NetworkCredential(fromEmail, fromPassword),
//            EnableSsl = true,
//        };

//        var mailMessage = new MailMessage(fromEmail, toEmail)
//        {
//            Subject = "Password Reset Request",
//            Body = $"You requested a password reset. Click the link below to reset your password:\n\n{resetUrl}",
//            IsBodyHtml = false,
//        };

//        try
//        {
//            client.Send(mailMessage);
//        }
//        catch (Exception ex)
//        {
//            // Handle email send failure (log, notify admin, etc.)
//            Console.WriteLine(ex.Message);
//        }
//    }

//    public class AccountController : Controller
//    {
//        private PasswordResetService _passwordResetService = new PasswordResetService();

//        // Action to handle password reset request (Step 1)
//        [HttpPost]
//        public ActionResult RequestPasswordReset(PasswordResetRequest model)
//        {
//            if (ModelState.IsValid)
//            {
//                // Send password reset email
//                _passwordResetService.SendPasswordResetEmail(model.Email);
//                ViewBag.Message = "If this email is registered, you will receive a password reset link.";
//            }
//            return View();
//        }

//        // Action to handle password reset confirmation (Step 4)
//        public ActionResult ResetPassword(string token)
//        {
//            if (string.IsNullOrEmpty(token))
//            {
//                return RedirectToAction("RequestPasswordReset");
//            }

//            // Validate the token
//            var email = ValidatePasswordResetToken(token);
//            if (email == null)
//            {
//                return RedirectToAction("RequestPasswordReset");
//            }

//            // Token is valid, show the page to reset the password
//            return View(new ResetPasswordModel { Email = email });
//        }

//        // Action to actually reset the password (Step 5 and 6)
//        [HttpPost]
//        public ActionResult ResetPassword(ResetPasswordModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                // Save new password to database
//                UpdateUserPassword(model.Email, model.NewPassword);
//                ViewBag.Message = "Your password has been reset successfully.";
//            }
//            return View();
//        }

//        private string ValidatePasswordResetToken(string token)
//        {
//            try
//            {
//                // Decode the token and extract email and timestamp
//                var decodedBytes = Convert.FromBase64String(token);
//                var decodedString = Encoding.UTF8.GetString(decodedBytes);
//                var parts = decodedString.Split(':');
//                var email = parts[0];
//                var timestamp = DateTime.Parse(parts[1]);

//                // Check if token is expired (e.g., 1 hour expiry time)
//                if ((DateTime.UtcNow - timestamp).TotalHours > 1)
//                {
//                    return null; // Token expired
//                }

//                return email;
//            }
//            catch
//            {
//                return null; // Invalid token format
//            }
//        }

//        private void UpdateUserPassword(string email, string newPassword)
//        {
//            // Your logic to update password in the database securely (hashing)
//            var hashedPassword = HashPassword(newPassword);

//            // Update password in your DB (replace with your actual update logic)
//            using (var context = new ApplicationDbContext())
//            {
//                var user = context.Users.FirstOrDefault(u => u.Email == email);
//                if (user != null)
//                {
//                    user.PasswordHash = hashedPassword;
//                    context.SaveChanges();
//                }
//            }
//        }

//        private string HashPassword(string password)
//        {
//            // Use a hashing algorithm to securely store the password
//            return Convert.ToBase64String(new System.Security.Cryptography.SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(password)));
//        }
//    }

//    public class ResetPasswordModel
//    {
//        public string Email { get; set; }
//        public string NewPassword { get; set; }
//        public string ConfirmPassword { get; set; }
//    }


//}