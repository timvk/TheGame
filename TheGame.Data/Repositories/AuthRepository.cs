namespace TheGame.Data.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using DbModels;
    using ServiceModels;

    public class AuthRepository : IDisposable
    {
        private TheGameContext context;

        private UserManager<User> userManager;

        public AuthRepository()
        {
            this.context = new TheGameContext();
            this.userManager = new UserManager<User>(new UserStore<User>(context));
        }

        public async Task<IdentityResult> RegisterUser(CreateUserModel userModel)
        {
            User user = new User
            {
                UserName = userModel.Username
            };

            var result = await this.userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<User> FindUser(string userName, string password)
        {
            User user = await this.userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            this.context.Dispose();
            this.userManager.Dispose();
        }
    }
}
