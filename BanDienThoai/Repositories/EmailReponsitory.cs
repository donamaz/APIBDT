using BanDienThoai.Repositories.Interface;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Lucene.Net.Support;

namespace BanDienThoai.Repositories
{
    public class EmailReponsitory : IEmail
    {
        private readonly AppSettings _appSettings;

        public EmailReponsitory(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public void Send(string to, string subject, string html, string? from = null)
        {
            throw new NotImplementedException();
        }
    }
}
