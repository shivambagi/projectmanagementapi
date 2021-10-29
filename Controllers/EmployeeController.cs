using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagementAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        [Route("api/employee")]
        public HttpResponseMessage GetEmployees()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            var listemployees = db.GetAllEmployees().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, listemployees);
        }

        [Route("api/employee/{id?}")]
        public HttpResponseMessage GetEmployee(int id)
        {
            var employee = db.GetEmployeeByID(id).ToList();
            if (employee.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        [Route("api/employee/{name:alpha}")]
        public HttpResponseMessage GetEmployee(string name)
        {
            var employee = db.GetEmployeeByName(name).ToList();
            if (employee.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        [HttpPut]
        [Route("api/employee")]
        public HttpResponseMessage PutEmployee([FromBody] Employee employee)
        {       

            try
            {
                if (!EmployeeExists(employee.EmployeeID))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
                }
                db.UpdateEmployee(employee.EmployeeID, employee.EmployeeName, employee.Designation, employee.ManagerID, employee.ContactNo, employee.EmailID, employee.SkillSets);

            }
            catch (Exception ex)
            {
                if (!EmployeeExists(employee.EmployeeID))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");                  
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
        }

        [HttpPost]
        [Route("api/employee")]
        public HttpResponseMessage PostEmployee(Employee employee)
        {
            db.InsertEmployee(employee.EmployeeName, employee.Designation, employee.ManagerID, employee.ContactNo, employee.EmailID, employee.SkillSets);


            return Request.CreateResponse(HttpStatusCode.OK, "Added Successfully");
        }

        [HttpDelete]
        [Route("api/employee/{id?}")]
        public HttpResponseMessage DeleteEmployee(int id)
        {
            var employee = db.GetEmployeeByID(id).ToList();
            if (employee.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }

            db.DeleteEmployee(id);

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }

    }
}
