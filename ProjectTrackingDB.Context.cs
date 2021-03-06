//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagementAPI
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProjectManagementEntities : DbContext
    {
        public ProjectManagementEntities()
            : base("name=ProjectManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ManagerComment> ManagerComments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectTask> ProjectTasks { get; set; }
        public virtual DbSet<UserStory> UserStories { get; set; }
    
        public virtual int DeleteProject(Nullable<int> projectID)
        {
            var projectIDParameter = projectID.HasValue ?
                new ObjectParameter("ProjectID", projectID) :
                new ObjectParameter("ProjectID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProject", projectIDParameter);
        }
    
        public virtual ObjectResult<GetAllProjects_Result> GetAllProjects()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProjects_Result>("GetAllProjects");
        }
    
        public virtual ObjectResult<GetProjectByID_Result> GetProjectByID(Nullable<int> projectID)
        {
            var projectIDParameter = projectID.HasValue ?
                new ObjectParameter("ProjectID", projectID) :
                new ObjectParameter("ProjectID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProjectByID_Result>("GetProjectByID", projectIDParameter);
        }
    
        public virtual ObjectResult<GetProjectByName_Result> GetProjectByName(string projectName)
        {
            var projectNameParameter = projectName != null ?
                new ObjectParameter("ProjectName", projectName) :
                new ObjectParameter("ProjectName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProjectByName_Result>("GetProjectByName", projectNameParameter);
        }
    
        public virtual int InsertProject(string projectName, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, string clientName)
        {
            var projectNameParameter = projectName != null ?
                new ObjectParameter("ProjectName", projectName) :
                new ObjectParameter("ProjectName", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var clientNameParameter = clientName != null ?
                new ObjectParameter("ClientName", clientName) :
                new ObjectParameter("ClientName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertProject", projectNameParameter, startDateParameter, endDateParameter, clientNameParameter);
        }
    
        public virtual int UpdateProject(Nullable<int> projectID, string projectName, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, string clientName)
        {
            var projectIDParameter = projectID.HasValue ?
                new ObjectParameter("ProjectID", projectID) :
                new ObjectParameter("ProjectID", typeof(int));
    
            var projectNameParameter = projectName != null ?
                new ObjectParameter("ProjectName", projectName) :
                new ObjectParameter("ProjectName", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var clientNameParameter = clientName != null ?
                new ObjectParameter("ClientName", clientName) :
                new ObjectParameter("ClientName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateProject", projectIDParameter, projectNameParameter, startDateParameter, endDateParameter, clientNameParameter);
        }
    
        public virtual int DeleteEmployee(Nullable<int> employeeID)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteEmployee", employeeIDParameter);
        }
    
        public virtual int DeleteProjectTask(Nullable<int> projectTaskID)
        {
            var projectTaskIDParameter = projectTaskID.HasValue ?
                new ObjectParameter("ProjectTaskID", projectTaskID) :
                new ObjectParameter("ProjectTaskID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProjectTask", projectTaskIDParameter);
        }
    
        public virtual ObjectResult<GetAllEmployees_Result> GetAllEmployees()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllEmployees_Result>("GetAllEmployees");
        }
    
        public virtual ObjectResult<GetAllProjectTasks_Result> GetAllProjectTasks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProjectTasks_Result>("GetAllProjectTasks");
        }
    
        public virtual ObjectResult<GetEmployeeByName_Result> GetEmployeeByName(string employeeName)
        {
            var employeeNameParameter = employeeName != null ?
                new ObjectParameter("EmployeeName", employeeName) :
                new ObjectParameter("EmployeeName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetEmployeeByName_Result>("GetEmployeeByName", employeeNameParameter);
        }
    
        public virtual ObjectResult<GetProjectTaskByID_Result> GetProjectTaskByID(Nullable<int> projectTaskID)
        {
            var projectTaskIDParameter = projectTaskID.HasValue ?
                new ObjectParameter("ProjectTaskID", projectTaskID) :
                new ObjectParameter("ProjectTaskID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProjectTaskByID_Result>("GetProjectTaskByID", projectTaskIDParameter);
        }
    
        public virtual ObjectResult<GetUserStories_Result> GetUserStories()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserStories_Result>("GetUserStories");
        }
    
        public virtual int InsertEmployee(string employeeName, string designation, Nullable<int> managerID, string contactNo, string emailID, string skillSets)
        {
            var employeeNameParameter = employeeName != null ?
                new ObjectParameter("EmployeeName", employeeName) :
                new ObjectParameter("EmployeeName", typeof(string));
    
            var designationParameter = designation != null ?
                new ObjectParameter("Designation", designation) :
                new ObjectParameter("Designation", typeof(string));
    
            var managerIDParameter = managerID.HasValue ?
                new ObjectParameter("ManagerID", managerID) :
                new ObjectParameter("ManagerID", typeof(int));
    
            var contactNoParameter = contactNo != null ?
                new ObjectParameter("ContactNo", contactNo) :
                new ObjectParameter("ContactNo", typeof(string));
    
            var emailIDParameter = emailID != null ?
                new ObjectParameter("EmailID", emailID) :
                new ObjectParameter("EmailID", typeof(string));
    
            var skillSetsParameter = skillSets != null ?
                new ObjectParameter("SkillSets", skillSets) :
                new ObjectParameter("SkillSets", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertEmployee", employeeNameParameter, designationParameter, managerIDParameter, contactNoParameter, emailIDParameter, skillSetsParameter);
        }
    
        public virtual int InsertProjectTask(Nullable<int> assignedTo, Nullable<System.DateTime> taskStartDate, Nullable<System.DateTime> taskEndDate, Nullable<int> taskCompletion, Nullable<int> userStoryID)
        {
            var assignedToParameter = assignedTo.HasValue ?
                new ObjectParameter("AssignedTo", assignedTo) :
                new ObjectParameter("AssignedTo", typeof(int));
    
            var taskStartDateParameter = taskStartDate.HasValue ?
                new ObjectParameter("TaskStartDate", taskStartDate) :
                new ObjectParameter("TaskStartDate", typeof(System.DateTime));
    
            var taskEndDateParameter = taskEndDate.HasValue ?
                new ObjectParameter("TaskEndDate", taskEndDate) :
                new ObjectParameter("TaskEndDate", typeof(System.DateTime));
    
            var taskCompletionParameter = taskCompletion.HasValue ?
                new ObjectParameter("TaskCompletion", taskCompletion) :
                new ObjectParameter("TaskCompletion", typeof(int));
    
            var userStoryIDParameter = userStoryID.HasValue ?
                new ObjectParameter("UserStoryID", userStoryID) :
                new ObjectParameter("UserStoryID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertProjectTask", assignedToParameter, taskStartDateParameter, taskEndDateParameter, taskCompletionParameter, userStoryIDParameter);
        }
    
        public virtual int UpdateEmployee(Nullable<int> employeeID, string employeeName, string designation, Nullable<int> managerID, string contactNo, string emailID, string skillSets)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            var employeeNameParameter = employeeName != null ?
                new ObjectParameter("EmployeeName", employeeName) :
                new ObjectParameter("EmployeeName", typeof(string));
    
            var designationParameter = designation != null ?
                new ObjectParameter("Designation", designation) :
                new ObjectParameter("Designation", typeof(string));
    
            var managerIDParameter = managerID.HasValue ?
                new ObjectParameter("ManagerID", managerID) :
                new ObjectParameter("ManagerID", typeof(int));
    
            var contactNoParameter = contactNo != null ?
                new ObjectParameter("ContactNo", contactNo) :
                new ObjectParameter("ContactNo", typeof(string));
    
            var emailIDParameter = emailID != null ?
                new ObjectParameter("EmailID", emailID) :
                new ObjectParameter("EmailID", typeof(string));
    
            var skillSetsParameter = skillSets != null ?
                new ObjectParameter("SkillSets", skillSets) :
                new ObjectParameter("SkillSets", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateEmployee", employeeIDParameter, employeeNameParameter, designationParameter, managerIDParameter, contactNoParameter, emailIDParameter, skillSetsParameter);
        }
    
        public virtual int UpdateProjectTask(Nullable<int> projectTaskID, Nullable<int> assignedTo, Nullable<System.DateTime> taskStartDate, Nullable<System.DateTime> taskEndDate, Nullable<int> taskCompletion, Nullable<int> userStoryID)
        {
            var projectTaskIDParameter = projectTaskID.HasValue ?
                new ObjectParameter("ProjectTaskID", projectTaskID) :
                new ObjectParameter("ProjectTaskID", typeof(int));
    
            var assignedToParameter = assignedTo.HasValue ?
                new ObjectParameter("AssignedTo", assignedTo) :
                new ObjectParameter("AssignedTo", typeof(int));
    
            var taskStartDateParameter = taskStartDate.HasValue ?
                new ObjectParameter("TaskStartDate", taskStartDate) :
                new ObjectParameter("TaskStartDate", typeof(System.DateTime));
    
            var taskEndDateParameter = taskEndDate.HasValue ?
                new ObjectParameter("TaskEndDate", taskEndDate) :
                new ObjectParameter("TaskEndDate", typeof(System.DateTime));
    
            var taskCompletionParameter = taskCompletion.HasValue ?
                new ObjectParameter("TaskCompletion", taskCompletion) :
                new ObjectParameter("TaskCompletion", typeof(int));
    
            var userStoryIDParameter = userStoryID.HasValue ?
                new ObjectParameter("UserStoryID", userStoryID) :
                new ObjectParameter("UserStoryID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateProjectTask", projectTaskIDParameter, assignedToParameter, taskStartDateParameter, taskEndDateParameter, taskCompletionParameter, userStoryIDParameter);
        }
    
        public virtual ObjectResult<GetEmployeeByID_Result> GetEmployeeByID(Nullable<int> employeeID)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetEmployeeByID_Result>("GetEmployeeByID", employeeIDParameter);
        }
    }
}
