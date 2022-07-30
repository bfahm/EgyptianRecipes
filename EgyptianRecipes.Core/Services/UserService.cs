using AutoMapper;
using EgyptianRecipes.Models;
using EgyptianRecipes.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EgyptianRecipes.Services
{
    public class UserService
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IOptions<AppSettings> appSettings, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            const string errorMessage = "Invalid login attempt.";

            if (user == null)
                throw new BusinessException(errorMessage);

            var validPassword = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!validPassword)
                throw new BusinessException(errorMessage);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles ?? new List<string>())
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(identity);

            return claimsPrincipal;
        }
    }
}
