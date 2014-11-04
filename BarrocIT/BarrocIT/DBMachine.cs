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
    //In order to run this local change your connection string to your own connection string
    class DBMachine
    {
        SqlConnection con;
        DataSet dbSet;
        public DBMachine()
        {
            //open a connection with the connection string
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ricky van den Berg\Documents\GitHub\BarrocIT\BarrocIT\BarrocIT\GOTODB.mdf;Integrated Security=True");
            dbSet = new DataSet();        
        }
        //Initialize the data in the datagridview for the finance form.    
        public void initFinance(frmFinance frmF)
        {
            //try to open a connection and execute a query
            try
            {
                //make and execute query
                string query = "SELECT * FROM tbl_Financial";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                //fill the datagridview with the results from the query
                adapter.Fill(dbSet);
                frmF.barrocDGV.DataSource = dbSet.Tables[0];
                frmF.barrocDGV.Columns[0].ReadOnly = true;
                SetHeaderNum(frmF.barrocDGV);
            }
            //catch the exception if the connection or query fails
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //Initialize the data in the datagridview for the sales form. 
        public void initSales(frmSales frmS)
        {
            //try to open a connection and execute a query
            try
            {
                //make and execute query
                string query = "SELECT * FROM tbl_Sales";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                //fill the datagridview with the results from the query
                adapter.Fill(dbSet);
                frmS.barrocDGV.DataSource = dbSet.Tables[0];
                frmS.barrocDGV.Columns[0].ReadOnly = true;
                SetHeaderNum(frmS.barrocDGV);
            }
            //catch the exception if the connection or query fails
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //Initialize the data in the datagridview for the sales form. 
        public void initDevelopment(frmDevelopment frmD)
        {
            //try to open a connection and execute a query
            try
            {
                //make and execute query
                string query = "SELECT * FROM tbl_Development";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                //fill the datagridview with the results from the query
                adapter.Fill(dbSet);
                frmD.barrocDGV.DataSource = dbSet.Tables[0];
                frmD.barrocDGV.Columns[0].ReadOnly = true;
                SetHeaderNum(frmD.barrocDGV);
            }
            //catch the exception if the connection or query fails
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void SetHeaderNum(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {                
                row.HeaderCell.Value = row.Index.ToString();               
            }
            
        }
    }
}
