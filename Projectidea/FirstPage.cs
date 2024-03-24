using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projectidea
{
    public partial class FirstPage : Form
    {
        int tm = 0;
        public FirstPage()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tm++;
            if (tm==5)
            {
              
                LoginPage l = new LoginPage();
                l.Show();
                this.Hide();
            }
        
        }
    }
}
