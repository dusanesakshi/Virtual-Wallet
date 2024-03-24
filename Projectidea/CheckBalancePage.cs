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
    public partial class CheckBalancePage : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Sakshi\Desktop\Ewallet\Database.mdb");
        public CheckBalancePage()
        {
            InitializeComponent();
        }

        private void CheckBalance_Load(object sender, EventArgs e)
        {
            con.Open();
            String query = "select * from UserData where Name = '" + LoginPage.C_Name + "'";
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label6.Text = dr["wbal"].ToString();

        //private void CheckBalancePage_Load(object sender, EventArgs e)
        //{
        
        //}
                //textBox3.Text = dr["Mob"].ToString();
                //textBox4.Text = dr["Add"].ToString();
                //label23.Text = dr["Email"].ToString();
                //label24.Text = dr["pass"].ToString();
                //label25.Text = dr["PAN"].ToString();
                //label26.Text = dr["ADHAAR"].ToString();

            }
           
            con.Close();
            

        }

        private void label4_Click(object sender, EventArgs e)
        {
            WelcomePage w =new  WelcomePage();
            w.Show();
            this.Hide();
        }

        //private WelcomePage Welcome_Page()
        //{
        //   // throw new NotImplementedException();
        //}

        

        

        private void label9_Click(object sender, EventArgs e)
        {
            CheckBalancePage cb = new CheckBalancePage();
            cb.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            MoneyTransferPage m = new MoneyTransferPage();
            m.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            MobileRechargePage r = new MobileRechargePage();
            r.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            DTHRechargePage h = new DTHRechargePage();
            h.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            PayElectricityPage p = new PayElectricityPage();
            p.Show();
            this.Hide();
        }

        private void CheckBalancePage_Load(object sender, EventArgs e)
        {
            con.Open();
            String query = "select * from UserData where Name = '" + LoginPage.C_Name + "'";
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label6.Text = dr["wbal"].ToString();

                //private void CheckBalancePage_Load(object sender, EventArgs e)
                //{

                //}
                //textBox3.Text = dr["Mob"].ToString();
                //textBox4.Text = dr["Add"].ToString();
                //label23.Text = dr["Email"].ToString();
                //label24.Text = dr["pass"].ToString();
                //label25.Text = dr["PAN"].ToString();
                //label26.Text = dr["ADHAAR"].ToString();

            }

            con.Close();
            
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            MoneyTransferPage m = new MoneyTransferPage();
            m.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            WelcomePage w = new WelcomePage();
            w.Show();
            this.Hide();
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            MoneyTransferPage m = new MoneyTransferPage();
            m.Show();
            this.Hide();

        }

        private void label11_Click_1(object sender, EventArgs e)
        {
            MobileRechargePage r = new MobileRechargePage();
            r.Show();
            this.Hide();
        }

        private void label12_Click_1(object sender, EventArgs e)
        {
            DTHRechargePage h = new DTHRechargePage();
            h.Show();
            this.Hide();
        }

        private void label13_Click_1(object sender, EventArgs e)
        {
            PayElectricityPage p = new PayElectricityPage();
            p.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            WelcomePage w = new WelcomePage();
            w.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Add_Money am = new Add_Money();
            am.Show();
            this.Hide();
        }
    }
}
