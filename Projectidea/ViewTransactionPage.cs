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
    public partial class ViewTransactionPage : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Sakshi\Desktop\Ewallet\Database.mdb");
        public ViewTransactionPage()
        {
            InitializeComponent();
        }

        private void ShowTrans_Load(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TransactionTable where Email='"+LoginPage.email+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            WelcomePage wp = new WelcomePage();
            wp.Show();
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
            CheckBalancePage cp = new CheckBalancePage();
            cp.Show();
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
            MobileRechargePage mp = new MobileRechargePage();
            mp.Show();
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
            PayElectricityPage p = new PayElectricityPage();
            p.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            ViewTransactionPage vp = new ViewTransactionPage();
            vp.Show();
            this.Hide();
        }
    }
}
