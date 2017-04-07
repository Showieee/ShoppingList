using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Entities;
using WebServiceHost.Database;
using WebServiceHost.Entities;

namespace WebService.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        [ActionName("Login")]
        public ApplicationUser Login(string username, string password)
        {
            if (!ModelState.IsValid)
                return null;
            using (MainDbContext context = new MainDbContext())
            {
                try
                {
                    var loginInfo = context.LoginInfo.Include(li => li.UserInfo).FirstOrDefault(info => info.Username.Equals(username) && info.Password.Equals(password));
                    if (loginInfo == null)
                        return null;

                    return new ApplicationUser()
                    {
                        ID = loginInfo.ID,
                        Username = loginInfo.Username,
                        FirstName = loginInfo.UserInfo.FirstName,
                        LastName = loginInfo.UserInfo.LastName,
                        Telephone = loginInfo.UserInfo.Telephone,
                        IsDriver = loginInfo.UserInfo.IsDriver
                    };
                }
                catch
                {
                    return null;
                }
            }
        }

        [HttpGet]
        [ActionName("Test")]
        public IEnumerable<ApplicationUser> Get()
        {
            using (MainDbContext context = new MainDbContext())
            {
                return
                    (
                    from li
                    in context.LoginInfo
                    join ui in context.UserInfo on li.ID equals ui.ID
                    select new ApplicationUser()
                    {
                        ID = li.ID,
                        Username = li.Username,
                        FirstName = ui.FirstName,
                        LastName = ui.LastName,
                        Telephone = ui.Telephone,
                        IsDriver = ui.IsDriver
                    }
                    ).ToList();
            }
        }

        [HttpPost]
        [ActionName("Register")]
        [ResponseType(typeof(int))]
        public int RegisterNewUser([FromBody]ApplicationUser userInfo, string password)
        {
            if (!ModelState.IsValid)
                return 0;

            using (MainDbContext ctx = new MainDbContext())
            {
                try
                {
                    UserInfo ui = new UserInfo()
                    {
                        FirstName = userInfo.FirstName,
                        LastName = userInfo.LastName,
                        Telephone = userInfo.Telephone,
                        IsDriver = userInfo.IsDriver,
                    };
                    LoginInfo li = new LoginInfo()
                    {
                        Username = userInfo.Username,
                        Password = password,
                        UserInfo = ui
                    };


                    ctx.LoginInfo.Add(li);
                    ctx.SaveChanges();

                    return li.ID;
                }
                catch
                {
                    return 0;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}