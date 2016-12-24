using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ProjectCsharp.Model;
namespace ProjectCsharp.Controller
{
    public class RequestController
    {
        private DBConnect DB;
        private const string tableStudentRequest = "StudentRequest";


        public RequestController()
        {
            DB = new DBConnect();
        }
        public DataView getAllDepartment()
        {
            DataSet dataSetResults = DB.getJoinStudent(tableStudentRequest);
            DataTable dataTable = dataSetResults.Tables[tableStudentRequest];

            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };
            DataView dataView;
            dataView = new DataView(dataTable); //filter data on dt
            return dataView;
        }

        public DataView getAllStudentInDepartmentStatusFalse()
        {
            DataSet dataSetResults = DB.getJoinStudent(tableStudentRequest);
            DataTable dataTable = dataSetResults.Tables[tableStudentRequest];

            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };
            DataView dataView;
            dataView = new DataView(dataTable); //filter data on dt
            return dataView;
        }
        private DataTable getAllStudentRequestNoJoin()
        {
            DataSet dataSetResults = DB.getQuery(tableStudentRequest, "");
            return dataSetResults.Tables[tableStudentRequest];
        }
        public bool addStudentRequestSendInDataBase(StudentRequest add)
        {
            DataTable dataTable = this.getAllStudentRequestNoJoin();
            DataRow dataRow = dataTable.NewRow();
            dataRow[1] = add.StudentId;
            dataRow[2] = add.ReceiverId;
            if(add.ApprovalId != null)
            {
                dataRow[3] = add.ApprovalId;
            }
            dataRow[4] = add.ReceiveDate;
            dataRow[6] = add.Content;
            if (add.Notes != null)
            {
                dataRow[7] = add.Notes;
            }
            dataRow[8] = add.Status;
            dataRow[9] = add.DepartmentId;
            dataTable.Rows.Add(dataRow);
            return addObjectInData(dataTable, dataRow);
        }
        private bool addObjectInData(DataTable dataTable, DataRow dataRow)
        {
            return DB.updateRow(dataTable);
        }
        public bool updateRequestInDatabase( string note, string request, string aporid)
        {
            return  DB.updateRequestInDatabase(note, request, aporid);
        }
        public DataTable getCountDeppart()
        {
            return DB.getCountDepartment("DepartmentCount").Tables["DepartmentCount"];
        }
    }
}
