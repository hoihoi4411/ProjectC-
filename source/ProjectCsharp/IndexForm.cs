using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectCsharp.Model;
using ProjectCsharp.Controller;
using ProjectCsharp.Animation;
namespace ProjectCsharp
{
    public partial class IndexForm : Form
    {
        private Login userSessionLogin;
        private UserController userController;
        private RequestController requestController;
        private TemplateController templateController;
        private bool flag;
        private int countRow;


        public IndexForm(Login session)
        {
            InitializeComponent();
            flag = false;
            pictureBox7.Visible = true;
            pictureBox8.Visible = false;
            userController = new UserController();
            requestController = new RequestController();
            templateController = new TemplateController();
            userSessionLogin = session;
            ChangeUserRoleSession();
            templateController.fillDataInCombobox(userController.getAllDepartment(), cmbDepartmentShow, "DepartmentName", "DepartmentId");
            templateController.showManagementForm(1, addNewManagerPanel, this,lblShowIndex, titlePanel, null, null );
            templateController.changeResponseWith(this, leftPanel, titlePanel, panelErrorsShow);
            templateController.fillDataInCombobox(userController.getAllDepartment(), cmbShowAllDepartment, "DepartmentName", "DepartmentId");
            addItem();
            label25.Text = "Total row(s): " + requestController.getAllDepartment().Count;
            setDepartmentInLabel(1+"");
            countRow = 0;
            if (userSessionLogin.Roles == 2)
            {
                label26.Text += userController.getDepartmentName(userSessionLogin.LoginId);
                cmbDepartmentShow.Enabled = false;
                cmbDepartmentShow.SelectedIndex = cmbDepartmentShow.FindStringExact(userController.getDepartmentName(userSessionLogin.LoginId));
            }
           
        }
        private void addItem()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            dt.Rows.Add("All",0);
            dt.Rows.Add("Done", 1);
            dt.Rows.Add("Wattings for Process", 2);
            cmbSelectStatus.DataSource = dt;
            cmbSelectStatus.DisplayMember = "Text";
            cmbSelectStatus.ValueMember = "Value";
            cmbSelectStatus.SelectedIndex = 0;
        }
        private void ChangeUserRoleSession()
        {
            lblIDSession.Text += "  " + userSessionLogin.LoginId;
            string roles;
            if (userSessionLogin.Roles == 1)
            {
                roles = " Administrator";
                lblRolesSession.ForeColor = Color.Red;
            }
            else
            {
                btnAddNewManager.Text = "Add new Staff";
                btnAddNewDepartment.Text = "Process request form";
                roles = " Managers";
            }
            lblRolesSession.Text += roles;
        }
        
        private void exitImg_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minuizeImg_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(userSessionLogin.Roles == 1)
            {
                templateController.showManagementForm(1, addNewManagerPanel, this, lblShowIndex, titlePanel, null, null);

            }else
            {
                cmbDepartmentShow.SelectedIndex = cmbDepartmentShow.FindStringExact(userController.getDepartmentName(userSessionLogin.LoginId));
                templateController.showManagementForm(5, addNewManagerPanel, this, lblShowIndex, titlePanel, null, null);
            }
        }

        private void btnAddNewDepartment_Click(object sender, EventArgs e)
        {
            if (userSessionLogin.Roles == 1)
            {
                templateController.showManagementForm(2, addNewDepartmentPanel, this, lblShowIndex, titlePanel, null, null);
            }else
            {
                templateController.showManagementForm(7, panel1, this, lblShowIndex, titlePanel, requestController.getAllDepartment(), dataGridView1);
                label17.Visible = false;
                textBox1.Visible = false;
                button1.Visible = false;
                label20.Visible = false;
                cmbSelectStatus.Visible = false;
                button2.Visible = true;

               // txtDisableContent.ReadOnly = false;
                txtDisableNote.ReadOnly = false;

                //templateController.filerStatus(false, requestController.getAllDepartment(), dataGridView1, true);
                templateController.filerDepartmentShow(userController.getDepartment(userSessionLogin.LoginId), (DataView)dataGridView1.DataSource, dataGridView1, true);
                ChangeCoutnRow();
            }
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            if(userSessionLogin.Roles == 1)
            {
                templateController.showManagementForm(3, panelPrintSummary, this, lblShowIndex, titlePanel, requestController.getAllDepartment(), tableRequestStudent);
            }else
            {
                templateController.showManagementForm(6, panel1, this, lblShowIndex, titlePanel, requestController.getAllDepartment(), dataGridView1);
                button2.Visible = false;
                label17.Visible = true;
                textBox1.Visible = true;
                button1.Visible = true;
                txtDisableNote.ReadOnly = true;
                label20.Visible = true;
                cmbSelectStatus.Visible = true;
                templateController.filerDepartmentShow(userController.getDepartment(userSessionLogin.LoginId), (DataView)dataGridView1.DataSource, dataGridView1, true);

                ChangeCoutnRow();
            }
        }

        private void btnResetStaff_Click(object sender, EventArgs e)
        {
            txtStaffID.Text = "";
            txtStaffName.Text = "";
            txtStaffPassword.Text = "";
        }
        
        private void btnSaveStaff_Click(object sender, EventArgs e)
        {
            string showError = "";
            bool checkID = Validation.checkId(txtStaffID.Text);
            bool checkName = Validation.checkName(txtStaffName.Text);
            bool checkPassword = Validation.checkMaxLenghtAndMin(txtStaffPassword.Text, 49, 6);
            if (!checkID)
            {
                showError += "InValid Id ID cannot containt special char and white space \n";
            }
            if (!checkName)
            {
                showError += "Invalid Name, name cannot containt special char and number \n";
            }
            if (!checkPassword)
            {
                showError += "Password must greater than 6 and less than 50";
            }
            if (showError.Equals(""))
            {
                string did = "1";
                Staff addNewStaff = new Staff();
                if (userSessionLogin.Roles == 2)
                {
                    did = userController.getDepartment(userSessionLogin.LoginId);
                }
                else
                {
                    if (cmbDepartmentShow.SelectedValue != null)
                    {
                        did = cmbDepartmentShow.SelectedValue.ToString();
                    }
                }
                
                int rolesAdd = 2;
                if(userSessionLogin.Roles == 2)
                {
                    rolesAdd = 3;
                }
                Login addNewLogin = new Login(txtStaffID.Text, txtStaffPassword.Text, rolesAdd);
                bool checkAddTableLogin = userController.addLoginInDataBase(addNewLogin);
                addNewStaff.StaffId = txtStaffID.Text;
                addNewStaff.DepartmentId = int.Parse(did);
                addNewStaff.StaffName = txtStaffName.Text;
                bool checkAddTableStaff =  userController.addStaffInDataBase(addNewStaff);
                if(checkAddTableStaff && checkAddTableLogin)
                {
                    templateController.showPanelMessage("Add Staff in database successful", panelErrorsShow, lblShowError, false);
                }else
                {
                    templateController.showPanelMessage("Add Staff in database error! \n Please check all input!", panelErrorsShow, lblShowError, true);
                }
                
            }
            else
            {
                templateController.showPanelMessage(showError, panelErrorsShow, lblShowError, true);
            }
        }
        
        private void btnResetDepartment_Click(object sender, EventArgs e)
        {
            txtDepartmentName.Text = "";
        }

        private void btnSaveDepartment_Click(object sender, EventArgs e)
        {
            bool checkName = Validation.checkName(txtDepartmentName.Text);
            if (!checkName)
            {
                templateController.showPanelMessage("Invalid Name, name cannot containt special char and number", panelErrorsShow, lblShowError, true);
            }
            else
            {
                Department add = new Department(txtDepartmentName.Text);
                bool checkAddDepartment =  userController.addDepartmentInData(add);
                if (checkAddDepartment)
                {
                    templateController.showPanelMessage("Add Department in Data Sucessful", panelErrorsShow, lblShowError, false);
                    templateController.fillDataInCombobox(userController.getAllDepartment(), cmbShowAllDepartment, "DepartmentName", "DepartmentId");
                }
                else
                {
                    templateController.showPanelMessage("Add Department in Data Error", panelErrorsShow, lblShowError, true);
                }
            }
        }
        private void setDepartmentInLabel(string did)
        {
            
            DataView dataDepartmentView = new DataView(userController.getAllStaffJoinLoginJoinDepart());
            string filer = "DepartmentId = " + did;
            string filer2 = filer;
            int countEmployee = templateController.filerCount(dataDepartmentView, filer);
            filer += " and Roles = 2";
            int countManager = templateController.filerCount(dataDepartmentView, filer);
            filer2 += " and Roles = 3";
            int countStaff = templateController.filerCount(dataDepartmentView, filer2);
            lblNameDepart.Text = cmbShowAllDepartment.GetItemText(this.cmbShowAllDepartment.SelectedItem);
            lblAllEmployee.Text = countEmployee+" User";
            lblAllManager.Text = countManager + " User";
            labaAllStaff.Text = countStaff+ " User";
        }
        
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            leftPanel.Location = new Point(-157, -2);
            pictureBox7.Visible = false;
            pictureBox8.Visible = true;
            templateController.changeResponseWith(this, leftPanel, titlePanel, panelErrorsShow);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            leftPanel.Location = new Point(-1, -2);
            pictureBox8.Visible = false;
            pictureBox7.Visible = true;
            templateController.changeResponseWith(this, leftPanel, titlePanel, panelErrorsShow);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userSessionLogin = null;
            this.Hide();
            new LoginForm().Show();
        }

        private void datePickFrom_ValueChanged(object sender, EventArgs e)
        {
            templateController.filerDate(true, datePickFrom.Text, "", (DataView)tableRequestStudent.DataSource, tableRequestStudent);
        }

        private void datePickTo_ValueChanged(object sender, EventArgs e)
        {
            templateController.filerDate(true, "", datePickTo.Text, (DataView)tableRequestStudent.DataSource, tableRequestStudent);
        }

        private void btnSearchRequest_Click(object sender, EventArgs e)
        {
            if (!txtSearch.Text.Equals(""))
            {
                templateController.filerNameOrId(txtSearch.Text, (DataView)tableRequestStudent.DataSource, tableRequestStudent, true);

            }
        }

        private void cmbShowAllDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string did = "1";
            if (cmbDepartmentShow.SelectedValue != null)
            {
                did = cmbShowAllDepartment.SelectedValue.ToString();
            }
            setDepartmentInLabel(did);
        }
        private void ChangeCoutnRow()
        {
            DataView input = (DataView)dataGridView1.DataSource;
            label25.Text = "Total row(s): " + input.Count;
            countRow = input.Count;
        }
        private void cmbSelectStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectStatus.SelectedValue != null) { 
                string getValue = cmbSelectStatus.SelectedValue.ToString();
                if (getValue.Equals("1"))
                {
                    templateController.filerDepartment(userController.getDepartment(userSessionLogin.LoginId), true, (DataView)dataGridView1.DataSource, dataGridView1, true);
                    ChangeCoutnRow();
                    ChangeCoutnRow();
                }
                else if (getValue.Equals("2"))
                {
                    templateController.filerDepartment(userController.getDepartment(userSessionLogin.LoginId), false,(DataView)dataGridView1.DataSource, dataGridView1, true);
                    ChangeCoutnRow();
                }
                else
                {
                    templateController.addDataViewInGridView(requestController.getAllDepartment(), dataGridView1, true);
                    templateController.filerDepartmentShow(userController.getDepartment(userSessionLogin.LoginId), (DataView)dataGridView1.DataSource, dataGridView1, true);
                    ChangeCoutnRow();
                }
            }
            
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (flag && countRow > 0)
            {
                int rowIndex = e.RowIndex;
               
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                //add = new Student(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());
                txtDisablename.Text = row.Cells[9].Value.ToString();
                txtDisableID.Text = row.Cells[0].Value.ToString();
                txtDisableContent.Text = row.Cells[6].Value.ToString();
                txtDisableNote.Text = row.Cells[7].Value.ToString();
            }
            flag = true;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            templateController.filerDate(true, dateTimePicker2.Text, "", (DataView)dataGridView1.DataSource, dataGridView1);
            ChangeCoutnRow();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            templateController.filerDate(true, "", dateTimePicker1.Text, (DataView)dataGridView1.DataSource, dataGridView1);
            ChangeCoutnRow();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                templateController.filerNameOrId(textBox1.Text, (DataView)dataGridView1.DataSource, dataGridView1, true);
                ChangeCoutnRow();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Validation.checkMaxLenghtAndMin(txtDisableNote.Text, 1000000000, 10))
            {
                bool checkPrcocess = requestController.updateRequestInDatabase(txtDisableNote.Text, txtDisableID.Text, userSessionLogin.LoginId);
                if (checkPrcocess)
                {
                    new Dialog("Message Update Request Sucessful!", "Student request will updated!", 1).Show();
                    templateController.showManagementForm(7, panel1, this, lblShowIndex, titlePanel, requestController.getAllDepartment(), dataGridView1);
                    templateController.filerDepartment(userController.getDepartment(userSessionLogin.LoginId), false ,(DataView)dataGridView1.DataSource, dataGridView1, true);
                    ChangeCoutnRow();
                }
                else
                {
                    new Dialog("Message Update Request Errors!", "Student request cannot update!", 1).Show();
                }
            }else
            {
                new Dialog("Message Update Request Errors!", "Note required!", 1).Show();
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Report(1).Show();
        }
    }
}
