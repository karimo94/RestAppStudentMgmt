using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAppStudentMgmt.Controllers
{
    public class CourseController : ApiController
    {
        // GET: api/Course
        public IEnumerable<string> Get()
        {
            //get all courses
            return new string[] { "value1", "value2" };
        }

        // GET: api/Course/courseId
        public string Get(int courseId)
        {
            return "value";
        }

        // POST: api/Course
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Course/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Course/5
        public void Delete(int id)
        {
        }
    }
}
