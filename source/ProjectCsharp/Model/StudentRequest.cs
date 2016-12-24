using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectCsharp.Model
{
    public class StudentRequest
    {
        public int RequestId { get; set; }
        public string StudentId  { get; set; }
        public string ReceiverId  { get; set; }
        public string ApprovalId { get; set; }
        public DateTime ReceiveDate  { get; set; }
        public DateTime CloseDate  { get; set; }
        public string Content  { get; set; }
        public string Notes  { get; set; }
        public bool Status  { get; set; }
        public int DepartmentId { get; set; }
        public StudentRequest(string sid, string rid, string aid, DateTime rdate, DateTime cdate, string content, string note, bool status, int departmentId)
        {
            StudentId = sid;
            ReceiverId = rid;
            if(aid != null)
            {
                ApprovalId = aid;
            }
            ReceiveDate = rdate;
            if (cdate != null)
            {
                CloseDate = cdate;
            }
            Content = content;
            if(note != null)
            {
                Notes = note;
            }
            Status = status;
            DepartmentId = departmentId;
        }
        public StudentRequest(string sid, string rid, string aid, DateTime rdate,  string content, string note, bool status, int department)
        {
            StudentId = sid;
            ReceiverId = rid;
            if (aid != null)
            {
                ApprovalId = aid;
            }
            ReceiveDate = rdate;
            Content = content;
            if (note != null)
            {
                Notes = note;
            }
            Status = status;
            DepartmentId = department;
        }

    }
}
