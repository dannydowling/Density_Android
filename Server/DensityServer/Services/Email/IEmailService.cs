using System.Threading.Tasks;

namespace DensityServer
{
    internal interface IEmailService
    {
        Task SendEmail(string emailTo, string subject, string message);
    }
}