using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectCsharp.Controller
{
    public class TemplateController
    {
        private DataView input { get; set; }
        private DataGridView output { get; set; }
        public void fillDataInCombobox(DataTable input, ComboBox output, string DisplayMember, string ValueMember)
        {
            output.DataSource = input;
            output.DisplayMember = DisplayMember;
            output.ValueMember = ValueMember;
            output.SelectedIndex = 0;
        }
        public void addDataViewInGridView(DataView input, DataGridView output, bool checkHidden)
        {
            output.DataSource = input;
            if (checkHidden)
            {
                int countColum = input.ToTable().Columns.Count;
                output.Columns[countColum - 1].Visible = false;
                output.Columns[countColum - 2].Visible = false;
            }
            //int n = output.Columns[1].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, false);
            //if(n != null)
            //{
            //    output.Columns[1].Width = n;
            //    output.Columns[0].ReadOnly = true;
            //}
           
        }
        public void ChangeColor (Control input, Color change)
        {
            input.BackColor = change;
        }
        public void showInformationAllPanel(int show, DataView input, DataGridView output)
        {
            switch (show)
            {
                case 3:
                    addDataViewInGridView(input, output, true);
                    output.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
                case 2:
                    addDataViewInGridView(input, output, false);
                    output.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
                case 6:
                    addDataViewInGridView(input, output, true);
                    output.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
                case 7:
                    addDataViewInGridView(input, output, true);
                    output.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
            }
        }
        public void placeholderTextBox(TextBox input, string compare)
        {
            if (compare.Equals(input.Text))
            {
                input.Text = "";
            }
        }
        public void showManagementForm(int show ,Panel showPanel, Form input, Label showLable, Panel TitlePanel, DataView inputDataView , DataGridView output)
        {
            foreach (Control control in input.Controls)
            {
                if (control is Panel && !control.Name.Equals("titlePanel") && !control.Name.Equals("leftPanel"))
                {
                    control.Visible = false;
                }
            }
            showPanel.Visible = true;
            switch (show)
            {
                case 1:
                    showLable.Text = "Add new Manager";
                    TitlePanel.BackColor = SystemColors.Highlight;
                    break;
                case 2:
                    showLable.Text = "Add new Department";
                    TitlePanel.BackColor = Color.Salmon;
                    break;
                case 3:
                    showLable.Text = "Print summary";
                    TitlePanel.BackColor = SystemColors.Highlight;
                    break;
                case 4:
                    showLable.Text = "See Report";
                    TitlePanel.BackColor = Color.Salmon;
                    break;
                case 5:
                    showLable.Text = "Add new Staff";
                    TitlePanel.BackColor = SystemColors.Highlight;
                    break;
                case 6:
                    showLable.Text = "Print summary";
                    TitlePanel.BackColor = SystemColors.Highlight;
                    break;
                case 7:
                    showLable.Text = "Process request form";
                    TitlePanel.BackColor = SystemColors.Highlight;
                    break;

            }
            if (inputDataView != null && output !=  null)
            {
                showInformationAllPanel(show, inputDataView, output);
            }
        }
        private void showPanelResponseLeft(int x, int y, int width, Panel input)
        {
            input.Location = new Point(x, y);
            input.Width = width;
        }
        private void changeWithResponse(int width, DataGridView input)
        {
            input.Width = width;
        }
        public void changeResponseWith(Form input, Panel left, Panel title, Panel errors)
        {
            if (left.Location.X == -1)
            {
                //show left panel 
                showPanelResponseLeft(241, 67, 974, errors);
                foreach (Control control in input.Controls)
                {
                    if (control is Panel && !control.Equals(left) && !control.Equals(title) && !control.Equals(errors))
                    {
                        showPanelResponseLeft(241, 155, 974, (Panel)control);
                    }
                }
            }
            else
            {
                showPanelResponseLeft(81, 67, 1114, errors);
                foreach (Control control in input.Controls)
                {
                    if (control is Panel && !control.Equals(left) && !control.Equals(title) && !control.Equals(errors))
                    {
                        showPanelResponseLeft(81, 155, 1114, (Panel)control);
                    }
                }
            }
        }
        public void showPanelMessage(string show, Panel showPanel, Label showText, bool checkPanel)
        {
            showPanel.Visible = true;
            showText.Text = show;
            if (!checkPanel)
            {
                showPanel.BackColor = Color.Green;
            }
            else
            {
                showPanel.BackColor = Color.Maroon;
            }
        }
        public int filerCount(DataView dataDepart, string filer)
        {
            dataDepart.RowFilter = filer;
            return dataDepart.Count;
        }
        public void filerDate(bool checkFiler, string from, string to, DataView getData, DataGridView output)
        {
            if (checkFiler)
            {
                string filer = "";
                if (!from.Equals(""))
                {
                    filer += "(ReceiveDate <= '" + from + "')";
                }

                if (!to.Equals(""))
                {
                    if (!filer.Equals(""))
                    {
                        filer += " and ";
                    }
                    filer += "(CloseDate >=  '" + to + "')";
                }
                getData.RowFilter = filer;
                addDataViewInGridView(getData, output, true);
            }
        }
        public void filerNameOrId(string name, DataView getData, DataGridView output, bool checkHidden)
        {
            string filer = "(StudentId like '" + name + "*') or (StudentName like '" + name + "*')";
            getData.RowFilter = filer;
            addDataViewInGridView(getData, output, checkHidden);
        }
        public void filerStatus(bool status, DataView getData, DataGridView output, bool checkHidden)
        {
            string filer = "(Status = " + status + ")";
            getData.RowFilter = filer;
            addDataViewInGridView(getData, output, checkHidden);
        }
        public void filerDepartment(string Department, bool status,DataView getData, DataGridView output, bool checkHidden)
        {
            string filer = "(DepartmentId = " + Department + ") and";
            filer = "(Status = "+ status + " )";
            getData.RowFilter = filer;
            addDataViewInGridView(getData, output, checkHidden);
        }
        public void filerDepartmentShow(string Department, DataView getData, DataGridView output, bool checkHidden)
        {
            string filer = "(DepartmentId = " + Department + ")";
            getData.RowFilter = filer;
            addDataViewInGridView(getData, output, checkHidden);
        }
        public void showPanelInStaffFrom(Panel input, Form formInput, int show, Label title)
        {
            foreach (Control control in formInput.Controls)
            {
                if (control is Panel && !control.Name.Equals("titlePanel") && !control.Name.Equals("panel1") && !control.Name.Equals("btnRegisterStudent")
                    && !control.Name.Equals("btnRegisterRequest")  && !control.Name.Equals("btnSummary") && !control.Name.Equals("btnReport"))
                {
                    control.Visible = false;
                }
            }
            input.Visible = true;
            input.Location = new Point(14, 203);
            switch (show)
            {
                case 1:
                    title.Text = "Register new student ";
                    break;
                case 2:
                    title.Text = "Register a new student request form ";
                    break;
                case 3:
                    title.Text = "Print the summary";
                    break;
                case 4:
                    title.Text = "Register new student ";
                    break;
            }
        }
    }
}
