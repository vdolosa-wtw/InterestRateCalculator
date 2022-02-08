using InterestRateCalculator.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;

namespace InterestRateCalculator.Domain.Services
{
    public class UserService: IUserService
    {
        protected readonly UserManager<ApplicationUser> userManager;
        protected readonly IHttpContextAccessor httpContextAccessor;

        public UserService(UserManager<ApplicationUser> userManager,
                            IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;

            var userId = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            this.CurrentUser = this.userManager.Users.FirstOrDefault(u => u.Id == userId);
        }

        public ApplicationUser CurrentUser { get; private set; }
    }
}
