namespace TheGame.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using DbModels;

    public class TheGameContext : IdentityDbContext<User>
    {
        public TheGameContext()
            : base("DefaultConnection")
        {
        }
    }
}
