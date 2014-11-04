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
    public partial class frmDevelopment: Form
    {
        public List<Control> tbs_Dev = new List<Control>();
        private void GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                GetAllControls(c);
                if (c is TextBox) tbs_Dev.Add(c);
            }
        }
        public frmDevelopment()
        {
            InitializeComponent();
            DBMachine dbd = new DBMachine();
            dbd.initDevelopment(this);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmDevelopment_Load(object sender, EventArgs e)
        {

        }

        private void frmDevelopment_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Exit database", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    frmLogin.isActiveDevelopment = false;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void barrocDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void barrocDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            QueryHandler q = new QueryHandler();
            q.ConfigureControls(this, e.RowIndex);
        }

        
    }
}
