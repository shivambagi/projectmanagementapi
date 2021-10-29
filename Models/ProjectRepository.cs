using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementAPI.Models
{
    public class ProjectRepository
    {
        private ProjectManagementEntities db = new ProjectManagementEntities();

        public void GetAllProjects()
        {
            var allproject = db.GetAllProjects();            
        }
    }
}