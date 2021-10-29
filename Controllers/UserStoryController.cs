using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectManagementAPI;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ProjectManagementAPI.Controllers
{
    public class UserStoryController : ApiController
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        // GET: api/Projects
        [Route("api/userstory")]
        public HttpResponseMessage GetUserStories()
        {
            var listuserstory = db.UserStories.Join(db.Projects,
                                p => p.ProjectID,
                                u => u.ProjectID,
                                (userstory, project) =>
                                new
                                {
                                    UserStoryID = userstory.UserStoryID,
                                    Story = userstory.Story,
                                    ProjectName= project.ProjectName
                                }
                                ).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, listuserstory);
        }

        // GET: api/Projects/5
        [Route("api/userstory/{id?}")]
        public HttpResponseMessage GetUserStories(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var userstory = db.UserStories.Where(i => i.UserStoryID == id).ToList();
            if (userstory.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, userstory);
        }

        [Route("api/userstory/{name:alpha}")]
        public HttpResponseMessage GetUserStories(string name)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var userstory = db.UserStories.Where(n => n.Story.Contains(name)).ToList();
            if (userstory.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, userstory);
        }

        // PUT: api/Projects/5
        [HttpPut]
        [Route("api/userstory")]
        public HttpResponseMessage PutUserStory([FromBody] UserStory us)
        {           

            try
            {                
                UserStory userstory = db.UserStories.Single(i => i.UserStoryID == us.UserStoryID);
                if (userstory == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
                }
                userstory.Story = us.Story;
                userstory.ProjectID = us.ProjectID;
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                if (!UserStoryExists(us.UserStoryID))
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

        // POST: api/Projects
        [HttpPost]
        [Route("api/userstory")]
        public HttpResponseMessage PostUserStory(UserStory us)
        {         
            db.UserStories.Add(us);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Added Successfully");
        }

        // DELETE: api/Projects/5
        [HttpDelete]
        [Route("api/userstory/{id?}")]
        public HttpResponseMessage DeleteUserStory(int id)
        {
            UserStory userstory = db.UserStories.Single(i => i.UserStoryID == id);
            if (userstory == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");                
            }

            db.UserStories.Remove(userstory);
            db.SaveChanges();

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

        private bool UserStoryExists(int id)
        {
            return db.UserStories.Count(e => e.ProjectID == id) > 0;
        }
    }
}
