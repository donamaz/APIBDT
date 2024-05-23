

using BanDienThoai.Helpers;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BanQuanAo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountReponsitory accountRepo;

        public AccountController(IAccountReponsitory repo)
        {
            accountRepo = repo;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await accountRepo.SignUpAsync(signUpModel);

            if (result.Succeeded)
            {
                return Ok("Đăng ký thành công!");
            }
            else
            {
                return BadRequest("Đã xảy ra lỗi khi đăng ký!");
            }
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            var token = await accountRepo.SignInAsync(signInModel);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            var (userRoles, firstName, lastName) = ExtractUserRolesAndNameFromToken(token);

            // Trả về một đối tượng JSON chứa cả tên vai trò và token
            return Ok(new { token, roles = userRoles, firstname = firstName, lastname = lastName });
        }
        public static (List<string> roles, string firstName, string lastName) ExtractUserRolesAndNameFromToken(string token)
        {
            var userRoles = new List<string>();
            string firstName = "";
            string lastName = "";

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken != null)
                {
                    var claims = jwtToken.Claims;
                    foreach (var claim in claims)
                    {
                        if (claim.Type == ClaimTypes.Role)
                        {
                            // Xác định vai trò từ claim và thêm vào danh sách vai trò
                            var role = claim.Value;
                            if (role == AppRole.Admin || role == AppRole.Customer || role == AppRole.Manager || role == AppRole.Accountant || role == AppRole.HR || role == AppRole.Warehouse)
                            {
                                userRoles.Add(role);
                            }
                        }
                        else if (claim.Type == "firstname")
                        {
                            firstName = claim.Value;
                        }
                        else if (claim.Type == "lastname")
                        {
                            lastName = claim.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý nếu có lỗi khi giải mã token
                Console.WriteLine("Error extracting user roles and name from token: " + ex.Message);
            }

            return (userRoles, firstName, lastName);
        }
    }
}
