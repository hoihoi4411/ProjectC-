using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectCsharp.Model;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProjectCsharp.Controller
{
    public class UserController
    {
        private DBConnect DB;
        private const string tableLogin = "Login";
        private const string tableDepartment = "Department";
        private const string tableStaff = "Staff";
        private const string tableStudent = "Student";
        public UserController()
        {
            DB = new DBConnect();
        } 
        public Login isLogin(string id, string pass, int roles)
        {
            DataSet dataSetLogin = DB.getQuery(tableLogin, "LoginId = '" + id + "' and LoginPassword = '" + pass + "' and Roles = " + roles);
            int totalrows = 0;
            if (dataSetLogin != null)
            {
                totalrows = dataSetLogin.Tables[tableLogin].Rows.Count;
            }
            if (totalrows > 0)
            {
                return new Login(id, pass, roles);
            }
            return null;
        }
        public DataTable getAllDepartment()
        {
            DataSet dataSetResults = DB.getQuery(tableDepartment, "");
            return dataSetResults.Tables[tableDepartment];
        }
        public DataTable getAllLogin()
        {
            DataSet dataSetResults = DB.getQuery(tableLogin, "");
            return dataSetResults.Tables[tableLogin];
        }
        private bool addObjectInData(DataTable dataTable, DataRow dataRow)
        {
            return DB.updateRow(dataTable);
        }
        public bool addDepartmentInData(Department add)
        {
            DataTable dataTableDepartment = this.getAllDepartment();
            DataRow dataRow = dataTableDepartment.NewRow();
            dataRow[1] = add.DepartmentName;
            dataTableDepartment.Rows.Add(dataRow);
            return addObjectInData(dataTableDepartment, dataRow);
        }
        public string getDepartment(string loginId)
        {
           DataSet dataSet =  DB.getJoinStaff("StaffJoin", loginId);
            return dataSet.Tables["StaffJoin"].Rows[0][1]+"";
        }
        public string getDepartmentName(string loginId)
        {
            DataSet dataSet = DB.getJoinStaff("StaffJoin", loginId);
            return dataSet.Tables["StaffJoin"].Rows[0][4] + "";
        }
        public bool addLoginInDataBase(Login add)
        {
            DataTable dataTableLogin = this.getAllLogin();
            DataRow dataRow = dataTableLogin.NewRow();
            dataRow[0] = add.LoginId;
            dataRow[1] = add.LoginPassword;
            dataRow[2] = add.Roles;
            dataTableLogin.Rows.Add(dataRow);
            return addObjectInData(dataTableLogin, dataRow);
        }
        public bool addStaffInDataBase(Staff add)
        {
            DataTable dataTableStaff = this.getAllStaffInData();
            DataRow dataRow = dataTableStaff.NewRow();
            dataRow[0] = add.StaffId;
            dataRow[1] = add.DepartmentId;
            dataRow[2] = add.StaffName;
            dataTableStaff.Rows.Add(dataRow);
            return addObjectInData(dataTableStaff, dataRow);
        }
        public bool addStudentInDataBase(Student add)
        {
            DataTable dataTable = this.getAllStudent();
            DataRow dataRow = dataTable.NewRow();
            dataRow[0] = add.StudentId;
            dataRow[1] = add.StudentName;
            dataRow[2] = add.Email;
            dataTable.Rows.Add(dataRow);
            return addObjectInData(dataTable, dataRow);
        }
        public DataTable getAllStaffInData()
        {
            DataSet dataSetResults = DB.getQuery(tableStaff, "");
            return dataSetResults.Tables[tableStaff];
        }
        public DataTable getAllStaffJoinLoginJoinDepart()
        {
            DataSet dataSetResults = DB.getJoinStaff(tableStaff, "");
            return dataSetResults.Tables[tableStaff];
        }
        public DataTable getAllStudent()
        {
            DataSet dataSetResults = DB.getQuery(tableStudent, "");
            return dataSetResults.Tables[tableStudent];
             
        }
        public DataView getDataViewStudent()
        {
            DataTable dataTable = getAllStudent();
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };
            DataView dataView;
            dataView = new DataView(dataTable); //filter data on dt
            return dataView;
        }

        public DataView getDataViewDepartment()
        {
            DataTable dataTable = getAllDepartment();
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };
            DataView dataView;
            dataView = new DataView(dataTable); //filter data on dt
            return dataView;
        }
        public DataTable getCountStaff(string table)
        {
           return DB.getCountStaff(table).Tables[table];
        }
    }
}
