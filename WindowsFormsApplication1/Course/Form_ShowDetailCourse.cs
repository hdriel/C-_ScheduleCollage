using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAandB
{
    public partial class Form_ShowDetailCourse : Form
    {
        Course course;

        public Form_ShowDetailCourse(Course c)
        {
            InitializeComponent();
            GeneralFuntion.Form_Center_FixedDialog(this);
            course = c;
            if(course == null)
            {
                //exit
            }
            lbl_title.Text = lbl_title.Text + "  '" +course.Name + "'";
            txt_lbl_syllabus.SelectionStart = 0;
            txt_lbl_syllabus.SelectionLength = 0;

            GeneralFuntion.Form_Center_FixedDialog(this);
        }
        
        private void Form_AddCourse_Load(object sender, EventArgs e)
        {
            txt_lbl_code.Text = course.ID.ToString();
            txt_lbl_Name.Text = course.Name;
            txt_lbl_Points.Text = course.Points.ToString();
            txt_lbl_HL.Text = course.weeklyHoursLecture.ToString();
            txt_lbl_HP.Text = course.weeklyHoursPractise.ToString();
            txt_lbl_year.Text = course.year.ToString();
            txt_lbl_semester.Text = course.Study_semester;
            txt_lbl_syllabus.Text = course.syllabus;
        }
    }
}
