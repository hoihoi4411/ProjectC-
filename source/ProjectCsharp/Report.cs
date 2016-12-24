using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectCsharp.Controller;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjectCsharp
{
    public partial class Report : Form
    {
        private RequestController requestController;
        private UserController usersController;
        public Report(int type)
        {
            requestController = new RequestController();
            usersController = new UserController();
            InitializeComponent();
            CountRequestDepartment();
            if(type == 1)
            {
                panel1.BackColor = SystemColors.Highlight;
                button1.BackColor = SystemColors.Highlight;
                button2.BackColor = SystemColors.Highlight;
                chartRequestStudent.Palette = ChartColorPalette.Pastel;
            }
            else
            {
                panel1.BackColor = Color.DarkGreen;
                button1.BackColor = Color.SeaGreen;
                button2.BackColor = Color.SeaGreen;
                chartRequestStudent.Palette = ChartColorPalette.SeaGreen;
            }

        }

        private void exitImg_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void minuizeImg_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CountRequestDepartment();
        }
        private void CountRequestDepartment()
        {
            lblShowIndex.Text = "Count Department Request";
            DataView dataView;
            dataView = new DataView(requestController.getCountDeppart()); //filter data on dt
            dataGridView1.DataSource = dataView;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            chartRequestStudent.Series["Department"].Points.Clear();
            foreach (DataRow dataRowChart in requestController.getCountDeppart().Rows)
            {
                chartRequestStudent.Series["Department"].Points.AddXY(dataRowChart[0] + ":" + dataRowChart[1], dataRowChart[1]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CountStaff();
        }
        private void CountStaff()
        {
            lblShowIndex.Text = "Count Staff in Department";
            DataView dataView;
            dataView = new DataView(usersController.getCountStaff("Staff")); //filter data on dt
            dataGridView1.DataSource = dataView;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            chartRequestStudent.Series["Department"].Points.Clear();
            foreach (DataRow dataRowChart in usersController.getCountStaff("Staff").Rows)
            {
                chartRequestStudent.Series["Department"].Points.AddXY(dataRowChart[0] + ":" + dataRowChart[1], dataRowChart[1]);
            }
        }
    }
}
