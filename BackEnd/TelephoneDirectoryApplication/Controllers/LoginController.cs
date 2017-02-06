using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TelephoneDirectoryApplication.Models;
using TelephoneDirectoryApplication.Data_Layer;
namespace TelephoneDirectoryApplication.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ContactRecordContext _dbContext;

        public LoginController()
        {
            _dbContext = new ContactRecordContext();
        }

        [HttpPost]
        [Route("api/Login")]
        public Response Login(ContactModel loginUser)
        {
            var users = _dbContext.Users.AsEnumerable();

            var user = _dbContext.Users.
                Where(u => u.UserName == loginUser.UserName && u.Password == loginUser.Password)
                .FirstOrDefault();

            if (user == null)
            {
                return new Response
                {
                    IsValid = false,
                    ResponseMessage= "Invalid username or password"
                };
            }

            return new Response
            {
                IsValid = true,
                ResponseMessage = "Press Ok to continue"
            };
        }

    }
}

