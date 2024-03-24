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
    public partial class PayElectricityPage : Form 
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Sakshi\Desktop\Ewallet\Database.mdb");
        int bal;
        public PayElectricityPage()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            PayElectricityPage pe = new PayElectricityPage();
            pe.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Requested ");
            con.Open();
            String query = "select * from UserData where Name = '"
                                + LoginPage.C_Name + "'";
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                bal = Convert.ToInt32(dr["Wbal"].ToString());

            }

            con.Close();

            bal -= Convert.ToInt32(textBox3.Text);

            //update 
            con.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = con;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "UPDATE UserData SET wbal = '" + bal + "' WHERE Name = '" + LoginPage.C_Name + "' ";
            cmd1.ExecuteNonQuery();
            con.Close();

            //insert 
            con.Open();
            OleDbCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "Insert into TransactionTable(Email, SecParty, Type, FromTo, Amt,TransType) values('"
                                + LoginPage.email + "','"
                                + comboBox1.Text + "','"
                                + textBox1.Text + "','"
                                + textBox2.Text + "','"
                                + textBox3.Text + "','Dr')";
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Transaction Successful !");

        }

        private void PayElectricityPage_Load(object sender, EventArgs e)
        {

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
            MoneyTransferPage mp = new MoneyTransferPage();
            mp.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            MobileRechargePage mb = new MobileRechargePage();
            mb.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            DTHRechargePage dth = new DTHRechargePage();
            dth.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            ViewTransactionPage vtp = new ViewTransactionPage();
            vtp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
