using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace StudentDatabase
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\Work\StudentDatabase\StudentDatabase\ruet.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, EventArgs e)
        {
            con.Open();
            ntf.Text = "";
            idtf.Text = "";
            atf.Text="";
            mtf.Text = "";
            mltf.Text = "";
            stf.Text = "";
            dcb.SelectedIndex = -1;
            show();
            con.Close();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            try {
                con.Open();
                string name = ntf.Text;
                string id = idtf.Text;
                string add = atf.Text;
                string mai = mltf.Text;
                long mo = Int64.Parse(mtf.Text);
                string s = stf.Text;
                string dept = dcb.SelectedItem.ToString();
                string qu = "insert into student values('" + id + "','" + name + "','" + add + "','" + mo + "','" + dept + "','" + mai + "','" + s + "')";
                SqlCommand push = new SqlCommand(qu, con);
                int i = push.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("Student registered succesfully");
                else
                    MessageBox.Show("Student is not rgistered");
                show();
                con.Close();
            
            } catch(System.Exception exp){
                MessageBox.Show("Error : " + exp.ToString());
                con.Close();
            }


        }

        private void delete_Click(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ntf.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            idtf.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            atf.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            mtf.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            stf.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            mltf.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            dcb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

        }

        void show()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from student", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr[1].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr[0].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr[6].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr[4].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr[5].ToString();
            }
        }

      

       
    }
}
