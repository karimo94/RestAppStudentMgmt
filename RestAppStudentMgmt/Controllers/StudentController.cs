using StudentDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAppStudentMgmt.Controllers
{
    public class StudentController : ApiController
    {
        // GET: api/Student
        public IEnumerable<Student> Get()
        {
            //retrive all students
            using (StudentMgmtEntities entities = new StudentMgmtEntities())
            {
                return entities.Students.ToList();
            }
        }

        // GET: api/Student/id
        public Student Get(int id)
        {
            //get a student by id
            using (StudentMgmtEntities entities = new StudentMgmtEntities())
            {
                var list = entities.Students.ToList();
                var row = list[list.FindIndex(stu => stu.id == id)];
                return (Student)row;
            }
        }

        // POST: api/Student
        public async void Post([FromBody]Student student)
        {
            //update a student record
            using (StudentMgmtEntities entities = new StudentMgmtEntities())
            {
                string updateBegin = "UPDATE Student ";
                string updateBody = "SET fname= " + student.fname + ", lname=" + student.lname + ", major=" + student.major +
                    ", dept=" + student.dept + ", credits=" + student.credits + ", year=" + student.year;
                string updateMatch = " WHERE id=" + student.id + ";";
                string sqlQueryUpdate = updateBegin + updateBody + updateMatch;

                await entities.Database.ExecuteSqlCommandAsync(sqlQueryUpdate);
                await entities.SaveChangesAsync();
            }
        }

        // PUT: api/Student/
        public async void Put([FromBody]Student student)
        {
            //create a new student record
            using (StudentMgmtEntities entities = new StudentMgmtEntities())
            {
                string sqlQueryInsert = "INSERT INTO Student VALUES ('" + student.fname + "','" + student.lname 
                    + "'," + student.id + "," + student.year + "," + student.credits + ",'" + student.major + "'," + student.dept + ");";

                await entities.Database.ExecuteSqlCommandAsync(sqlQueryInsert);

                await entities.SaveChangesAsync();
            }
        }

        // DELETE: api/Student/id
        public async void Delete(int id)
        {
            //delete a student record (row)
            //id's are unique so we only delete 1 row
            using (StudentMgmtEntities entities = new StudentMgmtEntities())
            {
                string sqlQueryDel = "DELETE FROM Student WHERE id=" + id + ";";
                await entities.Database.ExecuteSqlCommandAsync(sqlQueryDel);
                await entities.SaveChangesAsync();
            }
        }
    }
}
