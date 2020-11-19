using System.Threading.Tasks;

namespace search_application.Services
{
    public interface IEmailService
    {
        Task Send(string to, string subject, string content);
    }
}
