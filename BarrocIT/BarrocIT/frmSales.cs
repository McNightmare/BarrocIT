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
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
            DBMachine dbs = new DBMachine();
            dbs.initSales(this);
        }

        private void frmSales_Load(object sender, EventArgs e)
        {

        }

        private void frmSales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Exit database", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    frmLogin.isActiveSales = false;
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;         
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void barrocDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            QueryHandler q = new QueryHandler();
            q.ConfigureControls(this);
            q.LoadData(this, e.RowIndex);
        }
    }
}
