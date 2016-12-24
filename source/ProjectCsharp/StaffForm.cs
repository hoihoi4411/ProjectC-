using System;
using System.Drawing;
using System.Windows.Forms;
using ProjectCsharp.Controller;
using ProjectCsharp.Model;
using System.Data;
using ProjectCsharp.Animation;

namespace ProjectCsharp
{
    public partial class StaffForm : Form
    {
        private TemplateController templateController;
        private UserController userController;
        private Login sessionAccount;
        private bool flag;
        private Student add;
        private RequestController requestController;
        public StaffForm(Login sessionAccount)
        {
            InitializeComponent();
            templateController = new TemplateController();
            userController = new UserController();
            requestController = new RequestController();
            ShowStudent(tableShowStudent);
            ShowStudent(dataShowStudent);
            panelShowMesage.Visible = false;
            flag = false;
            panelShowMessageRequest.Visible = false;
            templateController.showPanelInStaffFrom(panelShowRegisterStu, this, 1, lblShowIndex);
            templateController.fillDataInCombobox(userController.getAllDepartment(), cmbShowAllDepartment, "DepartmentName", "DepartmentId");
            this.sessionAccount = sessionAccount;
            txtShowIDSession.Text += " " + this.sessionAccount.LoginId;
            DataRow[] filteredRows = userController.getAllStaffInData().Select("StaffId = '" + sessionAccount.LoginId + "'");
            txtRName.Text = filteredRows[0]["StaffName"].ToString();
            ChangeDataGridView();
        }
        private void ShowStudent(DataGridView input)
        {
            DataView getAllStudent = userController.getDataViewStudent();
            templateController.addDataViewInGridView(getAllStudent, input, false);
            input.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void exitImg_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minuizeImg_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRegisterStudent_MouseHover(object sender, EventArgs e)
        {
            templateController.ChangeColor(btnRegisterStudent, Color.Green);
        }

        private void btnRegisterStudent_MouseLeave(object sender, EventArgs e)
        {
            templateController.ChangeColor(btnRegisterStudent, Color.DarkGreen);
        }

        private void btnRegisterRequest_MouseHover(object sender, EventArgs e)
        {
            templateController.ChangeColor(btnRegisterRequest, Color.Green);
        }

        private void btnRegisterRequest_MouseLeave(object sender, EventArgs e)
        {
            templateController.ChangeColor(btnRegisterRequest, Color.FromArgb(0, 64, 0));
        }

        private void btnSummary_MouseHover(object sender, EventArgs e)
        {
            templateController.ChangeColor(btnSummary, Color.Green);
        }

        private void btnSummary_MouseLeave(object sender, EventArgs e)
        {
            templateController.ChangeColor(btnSummary, Color.DarkGreen);
        }

        private void btnReport_MouseHover(object sender, EventArgs e)
        {
            templateController.ChangeColor(btnReport, Color.Green);
        }

        private void btnReport_MouseLeave(object sender, EventArgs e)
        {
            templateController.ChangeColor(btnReport, Color.FromArgb(0, 64, 0));
        }

        private void txtIDOrName_MouseEnter(object sender, EventArgs e)
        {
            templateController.placeholderTextBox(txtIDOrName, "Entername or ID");
        }

        private void txtEmail_MouseEnter(object sender, EventArgs e)
        {
            templateController.placeholderTextBox(txtEmail, "Email");
        }

        private void txtName_MouseEnter(object sender, EventArgs e)
        {
            templateController.placeholderTextBox(txtName, "Student Name");
        }

        private void txtID_MouseEnter(object sender, EventArgs e)
        {
            templateController.placeholderTextBox(txtID, "Student ID");
        }

        private void txtIDOrName_TextChanged(object sender, EventArgs e)
        {
            templateController.filerNameOrId(txtIDOrName.Text, (DataView)tableShowStudent.DataSource, tableShowStudent, false);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string showError = "";
            bool checkID = Validation.checkId(txtID.Text);
            bool checkName = Validation.checkName(txtName.Text);
            bool checkEmail = Validation.checkEmail(txtEmail.Text);
            if (!checkID)
            {
                showError += "InValid Id ID cannot containt special char and white space \n";
            }
            if (!checkName)
            {
                showError += "Invalid Name, name cannot containt special char and number \n";
            }
            if (!checkEmail)
            {
                showError += "Email must be format xxx@xxx.com";
            }
            if (showError.Equals(""))
            {
                Student add = new Student(txtID.Text, txtName.Text, txtEmail.Text);
                bool checkAddTableStudent = userController.addStudentInDataBase(add);
                if (checkAddTableStudent)
                {
                    templateController.showPanelMessage("Add Student in database successful", panelShowMesage, lblShowMessage, false);
                    ShowStudent(tableShowStudent);
                }
                else
                {
                    templateController.showPanelMessage("Add Student in database error! \n Please check all input!", panelShowMesage, lblShowMessage, true);
                }
            }
            else
            {
                templateController.showPanelMessage(showError, panelShowMesage, lblShowMessage, true);
            }
        }

        private void btnRegisterStudent_MouseClick(object sender, MouseEventArgs e)
        {
            templateController.showPanelInStaffFrom(panelShowRegisterStu, this, 1, lblShowIndex);
            
        }

        private void btnRegisterRequest_MouseClick(object sender, MouseEventArgs e)
        {
            templateController.showPanelInStaffFrom(panelRegisterRequest, this, 2, lblShowIndex);
        }

        private void btnSummary_MouseClick(object sender, MouseEventArgs e)
        {
            templateController.showPanelInStaffFrom(panelSummary, this, 3, lblShowIndex);
        }

        private void btnReport_MouseClick(object sender, MouseEventArgs e)
        {
            new Report(2).Show();
        }

        private void btnAddNewStu_Click(object sender, EventArgs e)
        {
            templateController.showPanelInStaffFrom(panelShowRegisterStu, this, 1, lblShowIndex);
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            templateController.placeholderTextBox(txtIdName, "Entername or ID");
        }

        private void txtContent_Enter(object sender, EventArgs e)
        {
            templateController.placeholderTextBox(txtContent, "Enter Content");
            
        }

        private void dataShowStudent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (flag)
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = dataShowStudent.Rows[rowIndex];
                add = new Student(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());
                txtStudentName.Text = row.Cells[1].Value.ToString();
            }
            flag = true;
            
        }

        private void dataShowStudent_Enter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            templateController.filerNameOrId(txtIdName.Text, (DataView)dataShowStudent.DataSource, dataShowStudent, false);
        }

        private void txtIdName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3_Click(this, new EventArgs());
            }
        }

        private void txtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3_Click(this, new EventArgs());
            }
        }
        private void ChangeDataGridView()
        {
            templateController.showInformationAllPanel(3, requestController.getAllDepartment(), tableRequestStudent);
            label22.Text = "Total row(s): " + requestController.getAllDepartment().Count;
        }
        private void btnSaveRequest_Click(object sender, EventArgs e)
        {
            string showError = "";
            bool checkContent = Validation.checkMaxLenghtAndMin(txtContent.Text, 100000000, 6);
            if (!checkContent)
            {
                showError += "Content cannot empty";
                templateController.showPanelMessage(showError, panelShowMessageRequest, lblShowMessageRequest, true);
            }
            else
            {
                StudentRequest addRequest = new StudentRequest(add.StudentId, sessionAccount.LoginId, null, DateTime.Now, txtContent.Text, null, false, int.Parse(cmbShowAllDepartment.SelectedValue.ToString()));
                bool checkAddTableStudent = requestController.addStudentRequestSendInDataBase(addRequest);
                if (checkAddTableStudent)
                {
                    new Dialog("Message Add Sucessful!", "Student request wil added!", 2).Show();
                    ChangeDataGridView();
                }
            }
        }

        private void btnResetRequest_Click(object sender, EventArgs e)
        {
            txtContent.Text = "";
        }

        private void datePickFrom_ValueChanged(object sender, EventArgs e)
        {
            templateController.filerDate(true, datePickFrom.Text, "", (DataView)tableRequestStudent.DataSource, tableRequestStudent);
            DataView dt = (DataView)tableRequestStudent.DataSource;
            label22.Text = "Total row(s): " + dt.Count;
        }

        private void datePickTo_ValueChanged(object sender, EventArgs e)
        {
            templateController.filerDate(true, "", datePickTo.Text, (DataView)tableRequestStudent.DataSource, tableRequestStudent);
            DataView dt = (DataView)tableRequestStudent.DataSource;
            label22.Text = "Total row(s): " + dt.Count;
        }

        private void btnSearchRequest_Click(object sender, EventArgs e)
        {
            if (!txtSearch.Text.Equals(""))
            {
                templateController.filerNameOrId(txtSearch.Text, (DataView)tableRequestStudent.DataSource, tableRequestStudent, true);
                DataView dt = (DataView)tableRequestStudent.DataSource;
                label22.Text = "Total row(s): " + dt.Count;
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {
            sessionAccount = null;
            this.Hide();
            new LoginForm().Show();
        }
    }
}
