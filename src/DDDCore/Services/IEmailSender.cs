using System.Threading.Tasks;

namespace DDDCore.Presentation.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
