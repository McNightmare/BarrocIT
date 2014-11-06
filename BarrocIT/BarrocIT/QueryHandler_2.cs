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
        string temp;

        public void ConfigureControls(Form activeForm)
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
        }

        public void LoadData(Form activeForm, int row)
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
                            string temp;
                            try
                            {
                                temp = Convert.ToString(dgv[col.Index, row].Value);
                            }
                            catch (Exception)
                            {
                                tb.Text = "";
                                throw;
                            }

                            tb.Text = temp;
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
        public bool CheckInput()
        {
            temp = "Please fill out the following fields: \n";
            foreach (TextBox tb in textboxes)
            {
                if (tb.Text == string.Empty)
                {
                    temp = temp + (tb.Tag + "\n");
                }
            }
            foreach (NumericUpDown nud in nuds)
            {
                if (nud.Value == null)
                {
                    temp = temp + (nud.Tag + "\n");
                }
            }
            foreach (ComboBox cb in comboboxes)
            {
                if (cb.Text == string.Empty)
                {
                    temp = temp + (cb.Tag + "\n");
                }
            } 

            if (temp.Length > 40)
            {
                temp = temp + "\nthey cannot be empty!";
                MessageBox.Show(temp);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
