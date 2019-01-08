using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAppStudentMgmt.Controllers
{
    //[Authorize]
    public class UsersController : ApiController
    {
        // GET api/Users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/User/id
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/Users/User
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/User/id
        public void Delete(int id)
        {
        }
    }
}
