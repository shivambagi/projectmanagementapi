using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagementAPI.Controllers
{
    public class ManagerCommentsController : ApiController
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        // GET: api/Projects
        [Route("api/managercomment")]
        public HttpResponseMessage GetUserStories()
        {
            var listmanagercomments = db.ManagerComments.Join(db.ProjectTasks,
                                p => p.ProjectTaskID,
                                m => m.ProjectTaskID,
                                (managercomment, projecttask) =>
                                new
                                {
                                    ManagerCommentID = managercomment.ManagerCommentID,
                                    Comments = managercomment.Comments,
                                    ProjectTaskName = projecttask.ProjectTaskID
                                }
                                ).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, listmanagercomments);
        }

        // GET: api/Projects/5
        [Route("api/managercomment/{id?}")]
        public HttpResponseMessage GetUserStories(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var mnc = db.ManagerComments.Where(i => i.ManagerCommentID == id).ToList();
            if (mnc.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, mnc);
        }

        [Route("api/managercomment/{name:alpha}")]
        public HttpResponseMessage GetUserStories(string name)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var mnc = db.ManagerComments.Where(n => n.Comments.Contains(name)).ToList();
            if (mnc.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, mnc);
        }

        // PUT: api/Projects/5
        [HttpPut]
        [Route("api/managercomment")]
        public HttpResponseMessage PutManagerComment([FromBody] ManagerComment mc)
        {

            try
            {
                ManagerComment mnc = db.ManagerComments.Single(i => i.ManagerCommentID == mc.ManagerCommentID);
                if (mnc == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
                }
                mnc.ManagerCommentID = mc.ManagerCommentID;
                mnc.Comments = mc.Comments;
                mnc.ProjectTaskID = mc.ProjectTaskID;
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                if (!ManagerCommentsExists(mc.ManagerCommentID))
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
        [Route("api/managercomment")]
        public HttpResponseMessage PostManagerComment(ManagerComment mc)
        {
            db.ManagerComments.Add(mc);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Added Successfully");
        }

        // DELETE: api/Projects/5
        [HttpDelete]
        [Route("api/managercomment/{id?}")]
        public HttpResponseMessage DeleteManagerComment(int id)
        {
            ManagerComment mnc = db.ManagerComments.Single(i => i.ManagerCommentID == id);
            if (mnc == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }

            db.ManagerComments.Remove(mnc);
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

        private bool ManagerCommentsExists(int id)
        {
            return db.ManagerComments.Count(e => e.ManagerCommentID == id) > 0;
        }
    }
}
