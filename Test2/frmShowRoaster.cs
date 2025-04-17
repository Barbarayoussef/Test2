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
    public partial class frmShowRoaster : Form
    {
        Course course;
        public frmShowRoaster()
        {
            InitializeComponent();
            course = new Course();
        }

        private void frmShowRoaster_Load(object sender, EventArgs e)
        {
            dgvCourses.DataSource = course.ShowCourses();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            course.Semester=cmbSemester.SelectedItem.ToString();
            course.Year = Convert.ToInt16(txtYear.Text);
            dgvCourses.DataSource= course.SearchCourses(course);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0) {
               
                int id= Convert.ToInt32(dgvCourses.SelectedRows[0].Cells[5].Value);

                dgvCourses.DataSource=course.DeleteCourse(id);
                
            }



            
        }

        private void RefreshDataGridview()
        {
            dgvCourses.DataSource = null;
            dgvCourses.DataSource = course.ShowCourses();
        }
    }
}
