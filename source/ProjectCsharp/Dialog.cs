using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectCsharp
{
    public partial class Dialog : Form
    {
        private int type;
        public Dialog(string title, string message, int type)
        {
            InitializeComponent();
            lblShowIndex.Text = title;
            lblShowMessage.Text = message;
            this.type = type;
            ChangeType();
        }

        private void ChangeType()
        {
            if(type == 1)
            {
                titlePanel.BackColor = SystemColors.Highlight;
                panelFooter.BackColor = SystemColors.Highlight;
                btnExit.BackColor = SystemColors.Highlight;
            }
            else
            {
                titlePanel.BackColor = Color.DarkGreen;
                panelFooter.BackColor = Color.DarkGreen;
            }
            
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
