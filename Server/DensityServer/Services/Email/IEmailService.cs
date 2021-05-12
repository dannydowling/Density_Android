using System.Threading.Tasks;

namespace DensityServer
{
    public interface IEmailService
    {
       public Task SendEmail(string emailTo, string subject, string message);
    }
}