using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDetail_App
{
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection(
            "server = localhost; user id=root;database=car_detail ;"
            );
        MySqlCommand cmd;
        MySqlDataAdapter da;
        string sql;
        int result;
        string rb_value;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void model_year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            
            sql = "INSERT INTO `car_tb` (`car_id`, `car_name`, `car_make`, `car_myear`, `car_man`, `car_type`,`car_isavail`, `entrydate`) VALUES('"+tb_id.Text+ "','" + tb_name.Text+ "','" + tb_model.Text+ "','"+myear.Text+"','"+car_mantb.Text+"','"+cartype.Text+"','"+ rb_value +"','"+edate.Value.Date+"')";
            Mymethod(sql, "Submission Failed!!!", "Submitted Successfully!!!");
        }
        private void Mymethod(string sql, string msg_false, string msg_true)
        {
            try
            {
                if (rb_yes.Checked == true)
                {
                  rb_value = "1";
                }
                else 
                {
                    rb_value = "0";
                }

                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(msg_true);
                }
                else
                {
                    MessageBox.Show(msg_false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
       
        private void clear_Click(object sender, EventArgs e)
        {
            tb_id.Text = " ";
            tb_name.Text = " ";
            tb_model.Text = " ";
            myear.Text = " ";
            car_mantb.Text = " ";
            cartype.Text = " ";
        }
        public void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = new MySqlConnection(
            "server = localhost; user id=root;database=car_detail ;"
            );
            MySqlCommand cmd = new MySqlCommand(sql,con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            con.Close();
        }

        private void view_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            form.Display();
            
        }
    }
}
