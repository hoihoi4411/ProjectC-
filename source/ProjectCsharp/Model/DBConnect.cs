using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjectCsharp.Model
{
    public class DBConnect
    {
        private string conn = ConfigurationManager.ConnectionStrings["PRJC"].ToString();
        private SqlConnection connectionToDataBase;
        private SqlDataAdapter connectionDataAdapter;
        public DBConnect()
        {
            connectionToDataBase = new SqlConnection(conn);
        }
        public DataSet getQuery (string table, string where)
        {
            DataSet dataSetGetResutls = new DataSet();
            string sql = "Select * From " + table + " ";
            if (!where.Equals(""))
            {
                sql += "where " + where;
            }
            return excuteSelectQuery(dataSetGetResutls, sql, table);
        }
        private DataSet excuteSelectQuery(DataSet dataSetGetResutls, string sql, string table)
        {
            connectionDataAdapter = new SqlDataAdapter(sql, connectionToDataBase);
            connectionDataAdapter.Fill(dataSetGetResutls, table);
            return dataSetGetResutls;
        }
        public DataSet getJoinStudent(string table)
        {
            DataSet dataSetGetResutls = new DataSet();
            string sql = "with NewStaff as (SELECT * FROM Staff)";
            sql += " SELECT RequestId, StudentRequest.StudentId, Staff.StaffName as ReceiverId,NewStaff.StaffName as ApprovalId, ReceiveDate, CloseDate, Content, Notes, Status, Student.StudentName, StudentRequest.DepartmentId FROM StudentRequest full Join Staff on ReceiverId = StaffId full join NewStaff on ApprovalId = NewStaff.StaffId full join Student on StudentRequest.StudentId = Student.StudentId";
            sql += " where RequestId IS NOT NULL";
            return excuteSelectQuery(dataSetGetResutls, sql, table);
        }
        public DataSet getJoinStaff(string table, string where)
        {
            DataSet dataSetGetResutls = new DataSet();
           
            string sql = "Select * from Staff join Department on Department.DepartmentId = Staff.DepartmentId join Login on LoginId = StaffId ";
            if (!where.Equals(""))
            {
                sql += "WHERE StaffId = '" + where+"'";
            }
            return excuteSelectQuery(dataSetGetResutls, sql, table);
        }

        public DataSet getCountDepartment(string table)
        {
            DataSet dataSetGetResutls = new DataSet();
            string sql = "SELECT  Department.DepartmentName, Count(StudentRequest.DepartmentId) as 'Number of Request' FROM StudentRequest FULL JOIN Department on StudentRequest.DepartmentId = Department.DepartmentId GROUP BY Department.DepartmentName";
            return excuteSelectQuery(dataSetGetResutls, sql, table);
        }
        public DataSet getCountStaff(string table)
        {
            DataSet dataSetGetResutls = new DataSet();
            string sql = "SELECT  Department.DepartmentName, Count(Staff.DepartmentId) as 'Number of Staff' FROM Staff Full JOIN Department on Staff.DepartmentId = Department.DepartmentId GROUP BY Department.DepartmentName";
            return excuteSelectQuery(dataSetGetResutls, sql, table);
        }
        public bool updateRequestInDatabase(string note, string request, string aporid)
        {
            try
            {
                connectionToDataBase.Open();
                SqlCommand sqlCmd = connectionToDataBase.CreateCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "UPDATE StudentRequest set ApprovalId = '" + aporid + "', CloseDate = '" + DateTime.Now + "', Notes = '" + note + "', Status = 1 WHERE RequestId = "+request;
                sqlCmd.ExecuteNonQuery();
                connectionToDataBase.Close();
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool updateRow(DataTable dataTable)
        {
            try
            {
                SqlCommandBuilder cb = new SqlCommandBuilder(connectionDataAdapter);
                connectionDataAdapter.Update(dataTable);
                return true;
            }
            catch(Exception ex)
            {
                Console.Write(ex);
                return false;
            }
           
        }
    }
}
