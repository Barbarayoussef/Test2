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
    public partial class frmAddCourse : Form
    {
        Course course;
        public frmAddCourse()
        {
            InitializeComponent();
            course = new Course();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            course.StudentId = Convert.ToInt32(txtStudentId.Text);
            course.CourseNumber= Convert.ToInt32(txtCourseNumbser.Text);
            course.Year = Convert.ToInt32(txtYear.Text);
            course.StudentName=txtStudentName.Text;
            course.Semester=cmbSemester.SelectedItem.ToString();

            course.AddCourse(course);

        }
    }
}
