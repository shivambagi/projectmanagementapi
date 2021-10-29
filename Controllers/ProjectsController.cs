using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectManagementAPI;

namespace ProjectManagementAPI.Controllers
{
    public class ProjectsController : ApiController
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        // GET: api/Projects
        [Route("api/projects")]
        public HttpResponseMessage GetProjects()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            var listproject = db.GetAllProjects().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, listproject);
            //return db.Projects;
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        [Route("api/projects/{id?}")]
        public HttpResponseMessage GetProject(int id)
        {
            //Project project = db.Projects.Find(id);
            var project = db.GetProjectByID(id).ToList();
            if (project.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, project);
        }

        [Route("api/projects/{name:alpha}")]
        public HttpResponseMessage GetProject(string name)
        {
            //Project project = db.Projects.Find(id);
            var project = db.GetProjectByName(name).ToList();
            if (project.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, project);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/projects")]
        public HttpResponseMessage PutProject([FromBody] Project project)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            //    //return BadRequest(ModelState);
            //}

            //if (project.ProjectID != project.ProjectID)
            //{
            //    return BadRequest();
            //}

            //db.Entry(project).State = EntityState.Modified;

            try
            {
                if (!ProjectExists(project.ProjectID))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
                    //return NotFound();
                }
                //db.SaveChanges();
                db.UpdateProject(project.ProjectID,project.ProjectName,project.StartDate,project.EndDate,project.ClientName);

            }
            catch (Exception ex)
            {
                if (!ProjectExists(project.ProjectID))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
                    //return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Projects
        //[ResponseType(typeof(Project))]
        [HttpPost]
        [Route("api/projects")]
        public HttpResponseMessage PostProject(Project project)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            //    //return BadRequest(ModelState);
            //}

            db.InsertProject(project.ProjectName, project.StartDate, project.EndDate, project.ClientName);

            //db.Projects.Add(project);
            //db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Added Successfully");
            //return CreatedAtRoute("DefaultApi", new { id = project.ProjectID }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        [HttpDelete]
        [Route("api/projects/{id?}")]
        public HttpResponseMessage DeleteProject(int id)
        {
            var project = db.GetProjectByID(id).ToList();
            if (project.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
                //return NotFound();
            }

            db.DeleteProject(id);

            //db.Projects.Remove(project);
            //db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
            //return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.ProjectID == id) > 0;
        }
    }
}