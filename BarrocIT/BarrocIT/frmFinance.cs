using System;
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
    public partial class frmFinance : Form
    {
        public frmFinance()
        {
            InitializeComponent();
            DBMachine dbf = new DBMachine();
            dbf.initFinance(this);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmFinance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Exit database", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    frmLogin.isActiveFinance = false;
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
            q.ConfigureControls(this, e.RowIndex);
        }
    }
}
