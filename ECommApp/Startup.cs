using ECommApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECommApp.Startup))]
namespace ECommApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoleAndUser();
        }
        private void createRoleAndUser()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Admin@gmail.com";
                user.Email = "Admin@gmail.com";

                string userPass = "Admin@123";

                var chkUser = UserManager.Create(user, userPass);
 
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);


                var user = new ApplicationUser();
                user.UserName = "User@gmail.com";
                user.Email = "User@gmail.com";

                string userPass = "User@123";

                var chkUser = UserManager.Create(user, userPass);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "User");
                }

            }
        }
    }
}
