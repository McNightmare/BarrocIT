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
    class DBMachine
    {
        String query;
        Form form;





        private SqlConnection con;

        public DBMachine()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jeebes\Documents\GitHub\BarrocIT\BarrocIT\BarrocIT\GOTODB.mdf;Integrated Security=True");
        }
       
        public void TestConnection()
        {
            bool open = false;

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    open = true;
                }
                con.Close();
            }

            if (!open)
            {
                Application.Exit();
            }
        }

        public void OpenConnectionToDB()
        {
            con.Open();
        }

        public void CloseConnectionToDB()
        {
            con.Close();
        }

        public void LoadDGV()
        {

        }

        public System.Data.DataTable FillDT(string query)
        {
            TestConnection();
            OpenConnectionToDB();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, GetCon());
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            CloseConnectionToDB();

            return dt;
        }

        public SqlConnection GetCon()
        {
            return con;
        }







        public DBMachine(String q, Form activeForm)
        {
            query = q;
            form = activeForm;
        }

        public void GetDB()
        {
            
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jeebes\Documents\GitHub\BarrocIT\BarrocIT\BarrocIT\GOTODB.mdf;Integrated Security=True");
                DataSet dbSet = new DataSet();

                string query = "asdfadsf";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                adapter.Fill(dbSet);
                form.barrocDB.DataSource = dbSet.Tables[0];
                dataGridView1.Columns[0].ReadOnly = true;



            }
        }
    }
}
