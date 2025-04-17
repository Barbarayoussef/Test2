using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    internal class Course
    {
        private int courseNumber;
        private int studentId;
        private int year;
        private string studentName;
        private string semester;
        OleDbConnection myconnection;
        string strSql;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataSet coursesDataSet;
        DataTable coursesTable;
        List<Course> courses;


        public int CourseNumber {  get { return courseNumber; } set { courseNumber = value; } }
        public int StudentId { get { return studentId; } set { studentId = value; } }
        public int Year { get { return year; } set { year = value; } }
        public string StudentName { get { return studentName; } set { studentName = value; } }
        public string Semester { get { return semester; } set { semester = value; } }

        public void AddCourse(Course course)
        {
            myconnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; Data Source=TestDatabase.accdb");
            strSql = "INSERT INTO Courses (studentId,courseNumber,[Year],studentName,semester) VALUES (@studentId,@courseNumber,@Year,@studentName,@semester)";
            command= new OleDbCommand(strSql, myconnection);
            command.Parameters.AddWithValue("@studentId",course.StudentId );
            command.Parameters.AddWithValue("@courseNumber", course.CourseNumber);
            command.Parameters.AddWithValue("@Year", course.Year);
            command.Parameters.AddWithValue("@studentName", course.StudentName);
            command.Parameters.AddWithValue("@semester",course.Semester);

            myconnection.Open();
            command.ExecuteNonQuery();
            
        }

        public DataTable ShowCourses()
        {
            myconnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; Data Source=TestDatabase.accdb");
            strSql = "SELECT * FROM Courses";
            dataAdapter=new OleDbDataAdapter(strSql,myconnection);
            coursesDataSet= new DataSet("coursesTable");
            dataAdapter.Fill(coursesDataSet, "coursesTable");

            coursesTable = coursesDataSet.Tables["coursesTable"];
            return coursesTable;

        }

        public List<Course> SearchCourses(Course course)
        {
             courses = new List<Course>();
            myconnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; Data Source=TestDatabase.accdb");
            strSql = "SELECT * FROM Courses WHERE semester=@semester AND [Year]= @Year ";
            command = new OleDbCommand(strSql, myconnection);
            command.Parameters.AddWithValue("@semster", course.Semester);
            command.Parameters.AddWithValue("@Year", course.Year);
            myconnection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                course.StudentId = Convert.ToInt32(reader["studentId"]);
                course.CourseNumber = Convert.ToInt32(reader["courseNumber"]);
                course.Year = Convert.ToInt32(reader["Year"]);
                course.StudentName = (string)reader["studentName"];
                course.Semester = (string)reader["semester"];
                courses.Add(course);
            }
            
            return courses;

        }
        public DataTable DeleteCourse(int id)
        {
            myconnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0; Data Source=TestDatabase.accdb");
            strSql = "DELETE FROM Courses WHERE CourseID=@CourseID";
            command = new OleDbCommand(strSql, myconnection);
            command.Parameters.AddWithValue("@CourseID", id);
            myconnection.Open();
            command.ExecuteNonQuery();
            
            //this to delete the row from the data grid view in the moment that the user press delete not after close and open the form again
            strSql = "SELECT * FROM Courses";
            dataAdapter = new OleDbDataAdapter(strSql, myconnection);
            coursesDataSet = new DataSet("coursesTable");
            dataAdapter.Fill(coursesDataSet, "coursesTable");

            coursesTable = coursesDataSet.Tables["coursesTable"];
            return coursesTable;

        }

        
    }
}
