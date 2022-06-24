using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IT_SCHOOL_DB_ADO_EXAMPLE_01
{
    public partial class NavigationForm : Form
    {
        public NavigationForm()
        {
            InitializeComponent();
        }
        private void btnGoToAdd_Click(object sender, EventArgs e)
        {
            Form frm = new NewCustomerForm();
            frm.Show();
        }

        private void btnGoToFillOrCancel_Click(object sender, EventArgs e)
        {
            Form frm = new FillOrCancelForm();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
