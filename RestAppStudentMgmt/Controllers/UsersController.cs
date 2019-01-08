using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDataAccess;

namespace RestAppStudentMgmt.Controllers
{
    //[Authorize]
    public class UsersController : ApiController
    {
        // GET api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (UserEntities entities = new UserEntities())
            {
                return entities.Users.ToList();
            }
        }

        // GET api/User/id
        [HttpGet]
        public User Get(int id)
        {
            using (UserEntities entities = new UserEntities())
            {
                return (User) entities.Users.ToList()[entities.Users.ToList().FindIndex(user => user.id==id)];
            }
        }

        // PUT api/Users/User
        [HttpPut]
        public async void Put([FromBody]User nUser)
        {
            using (UserEntities entities = new UserEntities())
            {
                string sqlQueryInsert = "INSERT INTO User VALUES ('" + nUser.id + "','" + nUser.pass + ");";

                await entities.Database.ExecuteSqlCommandAsync(sqlQueryInsert);

                await entities.SaveChangesAsync();
            }
        }

        // DELETE api/User/id
        [HttpDelete]
        public async void Delete(int id)
        {
            using (UserEntities entities = new UserEntities())
            {
                string sqlQueryDel = "DELETE FROM User WHERE id=" + id + ";";
                await entities.Database.ExecuteSqlCommandAsync(sqlQueryDel);
                await entities.SaveChangesAsync();
            }
        }
    }
}
