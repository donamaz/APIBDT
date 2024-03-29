using BanDienThoai.Models;
using Microsoft.AspNetCore.Identity;

namespace BanDienThoai.Repositories.Interface
{
    public interface IAccount
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
