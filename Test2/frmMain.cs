using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    public partial class frmMain : Form
    {
        //Barbara Youssef
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            frmAddCourse frmAddCourse = new frmAddCourse();
            frmAddCourse.Show();
        }

        private void btnShowRosater_Click(object sender, EventArgs e)
        {
            frmShowRoaster frmShowRoaster = new frmShowRoaster();
            frmShowRoaster.Show();
        }
    }
}
