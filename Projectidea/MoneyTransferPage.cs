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
    public partial class MoneyTransferPage : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Sakshi\Desktop\FINALS\Ewallet\Database.mdb");
        int bal;
        public MoneyTransferPage()
        {
            InitializeComponent();
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
            CheckBalancePage c = new CheckBalancePage();
            c.Show();
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
            MobileRechargePage m = new MobileRechargePage();
            m.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            PayElectricityPage dth = new PayElectricityPage();
            dth.Show();
            this.Hide();
        }

       

        private void MoneyTransfer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Request for " + textBox3.Text + " Rs is sent to " + textBox2.Text + " account at " + comboBox1.Text + " bank");
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


            con.Open();
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = con;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "UPDATE UserData SET wbal = '" + bal + "' WHERE Name = '" + LoginPage.C_Name + "' ";
            cmd1.ExecuteNonQuery();
            con.Close();

            //insert 
            con.Open();
            OleDbCommand cmd3 = con.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Insert into TransactionTable(Email, SecParty, Type, FromTo, Amt,TransType) values('"
                                + LoginPage.email + "','"
                                + comboBox1.Text + "','"
                                + textBox1.Text + "','"
                                + textBox2.Text + "','"
                                + textBox3.Text + "','Dr')";
            cmd3.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Transaction Successful !");
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DTHRechargePage dt = new DTHRechargePage();
            dt.Show();
            dt.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            ViewTransactionPage vt = new ViewTransactionPage();
            vt.Show();
            vt.Hide();
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
