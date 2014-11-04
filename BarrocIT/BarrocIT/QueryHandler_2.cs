using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarrocIT
{
    public class QueryHandler
    {
        List<TextBox> textboxes = new List<TextBox>();
        List<NumericUpDown> nuds = new List<NumericUpDown>();
        List<ComboBox> comboboxes = new List<ComboBox>();
        SqlConnection con;
        DataSet dbSet;
        DataGridView dgv;

        public void ConfigureControls(Form activeForm, int rowIndex)
        {
            foreach (Control ctrl in activeForm.Controls)
            {
                if (ctrl is TextBox)
                {
                    textboxes.Add((TextBox)ctrl);
                }
                else if (ctrl is NumericUpDown)
                {
                    nuds.Add((NumericUpDown)ctrl);
                }
                else if (ctrl is ComboBox)
                {
                    comboboxes.Add((ComboBox)ctrl);
                }
                else if (ctrl is DataGridView)
                {
                    dgv = (DataGridView)ctrl;
                }
            }
            LoadData(activeForm, rowIndex);
        }

        protected void LoadData(Form activeForm, int row)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ricky van den Berg\Documents\GitHub\BarrocIT\BarrocIT\BarrocIT\GOTODB.mdf;Integrated Security=True");
            dbSet = new DataSet();

            foreach (DataGridViewTextBoxColumn col in dgv.Columns)
            {
                foreach (TextBox tb in textboxes)
                {
                    if (col.HeaderText == (string)tb.Tag)
                    {
                        if (dgv[col.Index, row].Value != null)
                        {
                            tb.Text = (string)dgv[col.Index, row].Value;
                        }                 
                    }
                }
            }
            foreach (DataGridViewTextBoxColumn col in dgv.Columns)
            {
                foreach (ComboBox cb in comboboxes)
                {
                    if (col.HeaderText == (string)cb.Tag)
                    {
                        if (dgv[col.Index, row].Value != null)
                        {
                            cb.Text = (string)dgv[col.Index, row].Value;
                        }
                    }
                }
            }
            foreach (DataGridViewTextBoxColumn col in dgv.Columns)
            {
                foreach (NumericUpDown nud in nuds)
                {
                    if (col.HeaderText == (string)nud.Tag)
                    {
                        nud.Text = Convert.ToString(dgv[col.Index, row].Value);
                    }
                }
            }

        }
    }
}
