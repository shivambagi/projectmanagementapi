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
    
    public partial class GetProjectTaskByID_Result
    {
        public int ProjectTaskID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<System.DateTime> TaskStartDate { get; set; }
        public Nullable<System.DateTime> TaskEndDate { get; set; }
        public Nullable<int> TaskCompletion { get; set; }
        public string Story { get; set; }
    }
}
