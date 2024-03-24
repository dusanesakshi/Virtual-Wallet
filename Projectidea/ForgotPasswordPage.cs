using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

namespace Projectidea
{
    public partial class ForgotPass : Form
    {
        public String ans = "", pass = "";
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Sakshi\Desktop\Ewallet\Database.mdb");
        public ForgotPass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "select * from UserData where Email = '" + textBox1.Text + "'";
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ans = dr["SecAns"].ToString();
                pass = dr["pass"].ToString();
                label2.Text = dr["SecQue"].ToString();
            }
            else
            {
                textBox1.Text = " ";
                textBox2.Text = " ";
                MessageBox.Show("No Account Found !");
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (ans == textBox2.Text)
                {
                MessageBox.Show("Your password is:" + pass);
                }
                else
                {
                MessageBox.Show("Wrong Answer");
                textBox2.Text = " ";
                }
            }
            else
            {
                if (ans == textBox2.Text)
                {
                    label5.Visible = true;
                    label6.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    button3.Visible = true;
                    pictureBox1.Visible = false;
                    
                }
                else
                {
                    MessageBox.Show("Wrong Ans");
                    textBox2.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update UserData set Pass = '"
                                + textBox3.Text + "' where Email = '"
                                + textBox1.Text + "'";
            cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Password updated, Please Login again.");
            LoginPage f = new LoginPage();
            f.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button3.Visible = false;
            pictureBox1.Visible = true;
        }

        private void ForgotPass_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
       
    }
}
