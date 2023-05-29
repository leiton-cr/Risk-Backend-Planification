using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace RiskBackend.Utils
{
    public class Security
    {
        public static void HashPassword(
            string password,
            out string hashPassword,
            out int salt,
            out string pepper
            )
        {
            byte[] pepperBytes = GeneratePepper();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] pepperedPasswordBytes = ConcatenateByteArrays(passwordBytes, pepperBytes);

            using (var sha256 = SHA256.Create())
            {
                salt = GenerateSalt();
                byte[] saltedPepperedPasswordBytes;
                byte[] hashedBytes;
                hashPassword = "";
                while (!hashPassword.StartsWith("000"))
                {
                    salt++;
                    saltedPepperedPasswordBytes = ConcatenateByteArrays(pepperedPasswordBytes, BitConverter.GetBytes(salt));
                    hashedBytes = sha256.ComputeHash(saltedPepperedPasswordBytes);
                    hashPassword = Convert.ToBase64String(hashedBytes);
                }

                pepper = Convert.ToBase64String(pepperBytes);
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword, int salt, String pepper)
        {

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] pepperBytes = Convert.FromBase64String(pepper);
            byte[] pepperedPasswordBytes = ConcatenateByteArrays(passwordBytes, pepperBytes);

            using (var sha256 = SHA256.Create())
            {

                byte[] saltedPepperedPasswordBytes = ConcatenateByteArrays(pepperedPasswordBytes, BitConverter.GetBytes(salt));
                byte[] hashedBytes = sha256.ComputeHash(saltedPepperedPasswordBytes);
                String newHashPassword = Convert.ToBase64String(hashedBytes);
                return newHashPassword.Equals(hashedPassword);
            }

        }

        private static int GenerateSalt()
        {
            Random random = new Random();
            return random.Next(100000, 9000000);
        }

        private static byte[] ConcatenateByteArrays(byte[] array1, byte[] array2)
        {
            byte[] concatenatedBytes = new byte[array1.Length + array2.Length];
            Buffer.BlockCopy(array1, 0, concatenatedBytes, 0, array1.Length);
            Buffer.BlockCopy(array2, 0, concatenatedBytes, array1.Length, array2.Length);
            return concatenatedBytes;
        }

        private static byte[] GeneratePepper()
        {
            byte[] randomBytes = new byte[20];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
                return Encoding.UTF8.GetBytes(Convert.ToBase64String(randomBytes));
            }
        }

        public static void SendEmail(string to, string subject, string body)
        {
            try
            {
                // Configuración del cliente SMTP
                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);


                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("steverova0594@outlook.com", "Um/W^22hEb*%)6M&8%h75");

                // Creación del mensaje de correo electrónico
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("steverova0594@outlook.com");
                mailMessage.To.Add(to);
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                // Envío del correo electrónico
                smtpClient.Send(mailMessage);

                Console.WriteLine("Correo electrónico enviado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo electrónico: " + ex);
            }
        }

        public static string GenerateJWT(string email)
        {
            var claims = new List<Claim>
    {

        new Claim("email", email)
        // Add more claims as needed
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWT_SECRET_KEY_auth"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
