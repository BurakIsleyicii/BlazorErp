using BlazorErp.Application.Requests.Mail;
using System.Threading.Tasks;

namespace BlazorErp.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}