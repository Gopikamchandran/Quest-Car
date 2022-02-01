using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PagedList;

namespace CarDetail_App
{
    public partial class Form2 : Form
    {
        MySqlConnection con = new MySqlConnection(
            "server = localhost; user id=root;database=car_detail;Convert Zero Datetime=True ; "
            );
        MySqlDataAdapter adp = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        int start;
        public Form2()
        {
            InitializeComponent();

           start = 0;
            loadData();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'car_detailDataSet.car_tb' table. You can move, or remove it, as needed.
            //this.car_tbTableAdapter.Fill(this.car_detailDataSet.car_tb);
            /* SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM car_tb", "server = localhost; database = car_detail; UID = root; password = ");
             DataSet ds = new DataSet();
             da.Fill(ds, "car_tb");
             dgView.DataSource = ds.Tables["car_tb"].DefaultView;*/
           // Display();

        }
        public void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = new MySqlConnection(
            "server = localhost; user id=root;database=car_detail;Convert Zero Datetime=True ; "
            );
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable tbl = new DataTable();
            adp.Fill(ds, start, 5,"car_tb");
           // adp.Fill(tbl);   
           dgv.DataSource = ds.Tables[0]; 
            backbtn.Enabled = false;
            con.Close();
        }
        public void Display()
        {

            DisplayAndSearch("SELECT * FROM car_tb", dgView);
            
        }
        private void Form2_Shown(object sender, EventArgs e)
        {
            // Display();
            loadData();
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayAndSearch("SELECT * FROM car_tb WHERE car_name LIKE '%"+ txtSearch.Text +"%'", dgView);
        }
        private void loadData()
        {
            MySqlCommand cmd;
            string sql = "SELECT * FROM car_tb";
            cmd = new MySqlCommand(sql, con);
            adp.SelectCommand = cmd;
            adp.Fill(ds, start, 5, "car_tb");
            dgView.DataSource = ds.Tables[0];
            backbtn.Enabled = false;
        }
        private void frwdbtn_Click(object sender, EventArgs e)
        {
            start = start + 5;
            backbtn.Enabled = true;
            if (start > 15)
            {
                start = 0;
            }
           
            ds.Clear();
            adp.Fill(ds,start,5,"car_tb");
        

        }

        private void backbtn_Click(object sender, EventArgs e)
        {

            start = start - 5;
            if (start < 0)
            {
                start = 0;
                backbtn.Enabled = false;
            }
            ds.Clear();
            adp.Fill(ds, start, 5, "car_tb");
 
        }
    }
}
