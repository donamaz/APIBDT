
using BanQuanAo.Models;
using Microsoft.AspNetCore.Identity;

namespace BanQuanAo.Reponsitoreis.Interface
{
    public interface IAccountReponsitory
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
        
    }
}
