﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarrocIT
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbDepartment.Text != "")
            {
                if (cbDepartment.Text == "Sales" && txtPassword.Text == "Jberger")
                {
                    frmSales frmsales = new frmSales();
                    frmsales.Show();
                }
                else if (cbDepartment.Text == "Finance" && txtPassword.Text == "Wvortelaars")
                {
                    frmFinance frmFinance = new frmFinance();
                    frmFinance.Show();
                }
                else if (cbDepartment.Text == "Development" && txtPassword.Text == "Hvanderhoek")
                {
                    frmDevelopment frmdevelopment = new frmDevelopment();
                    frmdevelopment.Show();
                }
                else if (cbDepartment.Text == "Admin")
                {

                }
                else
                {
                    MessageBox.Show("Please enter the correct password. If you have forgotten your departments password ask one of your coworkers.");
                }
            }
            else
            {
                MessageBox.Show("Please choose your department");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
