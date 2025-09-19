using Library.Models;
using Library.Repositories.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Utilities.Seeding
{

    public class DbInitializer : IDbInitializer
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole<Guid>> _roleManager;
        private ApplicationDbContext _context;

        public DbInitializer(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (!_roleManager.RoleExistsAsync(WebSiteRole.WebSite_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole<Guid>(WebSiteRole.WebSite_Admin))
                    .GetAwaiter().GetResult();

                _roleManager.CreateAsync(new IdentityRole<Guid>(WebSiteRole.WebSite_Librarian))
                    .GetAwaiter().GetResult();

                _roleManager.CreateAsync(new IdentityRole<Guid>(WebSiteRole.WebSite_Reader))
                    .GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                }, "Admin@123").GetAwaiter().GetResult();
                var appUser = _userManager.Users.Where(_ => _.Email == "admin@gmail.com").FirstOrDefault();
                if (appUser != null)
                {
                    _userManager.AddToRoleAsync(appUser, WebSiteRole.WebSite_Admin).GetAwaiter().GetResult();
                }
            }
        }
    }
}
