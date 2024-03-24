using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

using System.Net.Mail;

namespace Projectidea
{
    public partial class SignUpPage : Form
    {
        string opt1;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Sakshi\Desktop\Ewallet\Database.mdb");
        public SignUpPage()
        {
            InitializeComponent();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)

        {
            if(textBox6.Text==textBox7.Text)
            {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into UserData values('"
                                + textBox1.Text + "','"
                                + textBox2.Text + "','"
                                + textBox3.Text + "','"
                                + textBox4.Text + "','"
                                + textBox6.Text + "','"
                                + textBox8.Text + "','"
                                + textBox9.Text + "','"
                                + comboBox1.Text+ "','" 
                                +textBox10.Text+ "','100')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Account Created Successfully!");
            LoginPage l = new LoginPage();
            l.Show();
            this.Hide();
            }
            else
	{
                MessageBox.Show("Password and confirm password does not match");
	}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // genrate otp
            opt1 = RandomString(6);



            // send otp


            // send otp to mail
            MailMessage mail = new MailMessage();
            mail.To.Add(textBox4.Text); // use ur email id for demo

             //mail.CC.Add("gaikwadprasad2209@gmail.com");
             mail.CC.Add("kimsakookie31@gmail.com");

            mail.From = new MailAddress("kimsakookie31@gmail.com");
            mail.Subject = "OPT : Virtual-Wallet!";
            string Body = "Welcome to Virtual-Wallet System, \n Your OTP to ctreate new account with us is : " + opt1 + "\nPleaseDo not Share with Others!";
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("kimsakookie31@gmail.com", "hrhprkopletsoour");

            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);

            MessageBox.Show("OTP sent :" + opt1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (opt1 == textBox5.Text)
            {
                button1.Visible = true;
                MessageBox.Show("OTP matched!");
            }
            else
            {
                button1.Visible = false;
                MessageBox.Show("OTP NOT matched!");
            }
        }

        
    }
}
