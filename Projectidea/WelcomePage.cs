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
    public partial class WelcomePage : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Sakshi\Desktop\Ewallet\Database.mdb");
        
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void Welcome_Page_Load(object sender, EventArgs e)
        {
            label7.Text = "Welcome" + LoginPage.C_Name + "!";
            con.Open();
            String query = "select * from UserData where Name = '" + LoginPage.C_Name + "'";
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label22.Text = dr["Name"].ToString();
                textBox3.Text = dr["Mob"].ToString();
                textBox4.Text = dr["Add"].ToString();
                label23.Text = dr["Email"].ToString();
                label24.Text = dr["pass"].ToString();
                //label25.Text = dr["PAN"].ToString();
                //label26.Text = dr["ADHAAR"].ToString();

        //private void WelcomePage_Load(object sender, EventArgs e)
        //{
        
        //}

            }
            else
            {
                textBox3.Text = "";
                textBox4.Text = "";

            }
            con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            WelcomePage w = new WelcomePage();
            w.Show();
            this.Hide();

            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Add_Money am = new Add_Money();
            am.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            CheckBalancePage cb = new CheckBalancePage();
            cb.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            MoneyTransferPage mt = new MoneyTransferPage();
            mt.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            MobileRechargePage mr = new MobileRechargePage();
            mr.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            DTHRechargePage dth = new DTHRechargePage();
            dth.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            PayElectricityPage plb = new PayElectricityPage();
            plb.Show();
            this.Hide();
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoginPage f = new LoginPage();
            f.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewTransactionPage s = new ViewTransactionPage();
            s.Show();
            this.Hide();
        }

        private void WelcomePage_Load(object sender, EventArgs e)
        {
            label7.Text = "Welcome" + LoginPage.C_Name + "!";
            con.Open();
            String query = "select * from UserData where Name = '" + LoginPage.C_Name + "'";
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label22.Text = dr["Name"].ToString();
                textBox3.Text = dr["Mob"].ToString();
                textBox4.Text = dr["Add"].ToString();
                label23.Text = dr["Email"].ToString();
                label24.Text = dr["pass"].ToString();
                //label25.Text = dr["PAN"].ToString();
                //label26.Text = dr["ADHAAR"].ToString();

                //private void WelcomePage_Load(object sender, EventArgs e)
                //{

                //}

            }
            else
            {
                textBox3.Text = "";
                textBox4.Text = "";

            }
            con.Close();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            Add_Money am = new Add_Money();
            am.Show();
            this.Hide();
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            CheckBalancePage cb = new CheckBalancePage();
            cb.Show();
            this.Hide();
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            MoneyTransferPage mt = new MoneyTransferPage();
            mt.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            WelcomePage w = new WelcomePage();
            w.Show();
            this.Hide();
        }

        private void label11_Click_1(object sender, EventArgs e)
        {
            MobileRechargePage mr = new MobileRechargePage();
            mr.Show();
            this.Hide();
        }

        private void label12_Click_1(object sender, EventArgs e)
        {
            DTHRechargePage dth = new DTHRechargePage();
            dth.Show();
            this.Hide();
        }

        private void label13_Click_1(object sender, EventArgs e)
        {
            PayElectricityPage plb = new PayElectricityPage();
            plb.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            ViewTransactionPage s = new ViewTransactionPage();
            s.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            LoginPage f = new LoginPage();
            f.Show();
            this.Hide();
        }
    }
}
