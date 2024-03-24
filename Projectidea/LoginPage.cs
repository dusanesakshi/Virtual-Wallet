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
    public partial class LoginPage : Form
    {
        string captcha = "";
        public static string C_Name = "";
        public static string email = "";
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Sakshi\Desktop\Ewallet\Database.mdb");
        public LoginPage()
        {
            InitializeComponent();
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void Login_Load(object sender, EventArgs e)
        {
            captcha = RandomString(8);
            textBox3.Text = captcha;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            SignUpPage f = new SignUpPage();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "select* from UserData where Email = '" + textBox1.Text + "'";

            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if(textBox3.Text==textBox4.Text)
            {
            if (dr.Read())
            {
                if (dr["pass"].ToString()==textBox2.Text)

                {
                    C_Name = dr["Name"].ToString();
                    email = dr["Email"].ToString();
                    WelcomePage wp = new WelcomePage();
                    wp.Show();
                    this.Hide();
                    //MessageBox.Show("Welcome"+ " "  + C_Name); 
                }
                else
                {
                    MessageBox.Show("Wrong password");
                    textBox2.Text = "";
                }
            }

            else
            {
                textBox1.Text = " ";
                textBox2.Text = " ";
                MessageBox.Show("Wrong account");
            }
            }
            else
            {
                MessageBox.Show("Invalid captcha");
                textBox4.Text = "";
            }
            con.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            ForgotPass fp = new ForgotPass();
            fp.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            captcha = RandomString(8);
            textBox3.Text = captcha;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            {
                captcha = RandomString(8);
                textBox3.Text = captcha;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
