using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Lab05.Model;
using Microsoft.Reporting.WinForms;

namespace Lab05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StudentDBContext context = new StudentDBContext();
            List<Student> listStudent = context.Students.ToList();
            List<StudentReport> listReport = new List<StudentReport>();
            foreach (Student i in listStudent)
            {
                StudentReport temp = new StudentReport();
                temp.StudentID = i.StudentID;
                temp.FullName = i.FullName;
                temp.AverageScore = i.AverageScore;
                temp.FacultyName = i.Faculty.FacultyName;
                listReport.Add(temp);
            }
            this.reportViewer1.LocalReport.ReportPath = "E:\\Tài liệu\\Visual\\Lab05\\Lab05\\StudentReport.rdlc";
            var reportDataSource = new ReportDataSource("StudentDataSet", listReport);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
