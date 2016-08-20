namespace TheGame.Api.Controllers
{
    using System.Web.Http;

    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [Route("{id}")]
        public IHttpActionResult GetUser(int id)
        {
            return Ok("zemi toq user " + id);
        }
    }
}
