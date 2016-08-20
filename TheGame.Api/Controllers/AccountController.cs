namespace TheGame.Api.Controllers
{
    using System.Web.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    using ServiceModels;
    using Data.Repositories;
    
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private AuthRepository authRepo = null;

        public AccountController()
        {
            this.authRepo = new AuthRepository();
        }

        [AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> Register(CreateUserModel userModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var result = await authRepo.RegisterUser(userModel);

            IHttpActionResult errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.authRepo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (this.ModelState.IsValid)
                {
                    return this.BadRequest();
                }

                return this.BadRequest(this.ModelState);
            }

            return null;
        }
    }
}
