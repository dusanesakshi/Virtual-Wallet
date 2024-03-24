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
    public partial class DTHRechargePage : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Sakshi\Desktop\Ewallet\Database.mdb");
        int bal;
        public DTHRechargePage()
        {
            InitializeComponent();
        }

        private void DTHRecharge_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            WelcomePage w = new WelcomePage();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    textBox3.Text = "299";
                    break;
                case 1:
                    textBox3.Text = "399";
                    break;
                case 2:
                    textBox3.Text = "499";
                    break;
                case 3:
                    textBox3.Text = "599";
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox3.Text + " Rs debited");
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

            con.Open();
            OleDbCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "Insert into TransactionTable(Email, SecParty, Type, FromTo, Amt,TransType) values('"
                                + LoginPage.email + "','"
                                + comboBox1.Text + "','"
                                + textBox1.Text + "','"
                                + comboBox2.Text + "','"
                                + textBox3.Text + "','CR')";
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Recharge Done !");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Add_Money am = new Add_Money();
            am.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            CheckBalancePage cp = new CheckBalancePage();
            cp.Show();
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
            DTHRechargePage pa = new DTHRechargePage();
            pa.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            PayElectricityPage p = new PayElectricityPage();
            p.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            ViewTransactionPage vt = new ViewTransactionPage();
            vt.Show();
            this.Hide();
        }
    }
}
