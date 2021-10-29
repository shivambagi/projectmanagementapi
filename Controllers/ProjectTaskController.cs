using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagementAPI.Controllers
{
    public class ProjectTaskController : ApiController
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        [Route("api/projecttask")]
        public HttpResponseMessage GetProjectTasks()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            var listprojecttasks = db.GetAllProjectTasks().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, listprojecttasks);
        }

        [Route("api/projecttask/{id?}")]
        public HttpResponseMessage GetProjectTask(int id)
        {
            var projecttask = db.GetProjectTaskByID(id).ToList();
            if (projecttask.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, projecttask);
        }

        [HttpPut]
        [Route("api/projecttask")]
        public HttpResponseMessage PutProjectTask([FromBody] ProjectTask projecttask)
        {
            try
            {
                if (!ProjectTaskExists(projecttask.ProjectTaskID))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
                }
                db.UpdateProjectTask(projecttask.ProjectTaskID, projecttask.AssignedTo, projecttask.TaskStartDate, projecttask.TaskEndDate, projecttask.TaskCompletion, projecttask.UserStoryID);

            }
            catch (Exception ex)
            {
                if (!ProjectTaskExists(projecttask.ProjectTaskID))
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
        [Route("api/projecttask")]
        public HttpResponseMessage PostProjectTask(ProjectTask projecttask)
        {
            db.InsertProjectTask(projecttask.AssignedTo, projecttask.TaskStartDate, projecttask.TaskEndDate, projecttask.TaskCompletion, projecttask.UserStoryID);

            return Request.CreateResponse(HttpStatusCode.OK, "Added Successfully");
        }

        [HttpDelete]
        [Route("api/projecttask/{id?}")]
        public HttpResponseMessage DeleteProjectTask(int id)
        {
            var projecttask = db.GetEmployeeByID(id).ToList();
            if (projecttask.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }

            db.DeleteProjectTask(id);

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

        private bool ProjectTaskExists(int id)
        {
            return db.ProjectTasks.Count(e => e.ProjectTaskID == id) > 0;
        }
    }
}
