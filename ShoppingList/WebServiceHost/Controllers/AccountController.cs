using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Entities;
using WebServiceHost.Database;

namespace WebService.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        [Route("Login")]
        [ResponseType(typeof(LoginInfo))]
        public async Task<IHttpActionResult> Login(string username, string password)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (MainDbContext ctx = new MainDbContext())
            {
                try
                {
                    var loginInfo = await ctx.LoginInfo.FirstOrDefaultAsync(info => info.Username.Equals(username) && info.Password.Equals(password));
                    if (loginInfo == null)
                        return BadRequest("Invalid username or password");

                    return Ok(loginInfo);
                }
                catch
                {
                    return BadRequest("Error while logging in");
                }
            }
        }

        [HttpPut]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(LoginInfo loginInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (MainDbContext ctx = new MainDbContext())
            {
                try
                {
                    ctx.LoginInfo.Add(loginInfo);
                    await ctx.SaveChangesAsync();

                    return Ok();
                }
                catch
                {
                    return BadRequest("Error while registering");
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}