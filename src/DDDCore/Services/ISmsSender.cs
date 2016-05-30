using System.Threading.Tasks;

namespace DDDCore.Presentation.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
