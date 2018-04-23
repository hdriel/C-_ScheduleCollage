using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectAandB.Student_gui
{
    public partial class StudentFormsMenu : Form
    {

        Student student;
        public Form refTomenu { get; set; }
        public StudentFormsMenu(Student student)
        {
            InitializeComponent();
            this.student = student;
            comboBox_formToGenerate.Items.Add("Annual fee permit");
            comboBox_formToGenerate.Items.Add("Annual study permit");
        }

        private void comboBox_formToGenerate_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearControlBox();
            if (comboBox_formToGenerate.SelectedItem.ToString() == "Annual fee permit")
            {
                showFeePermit();
            }
            else
            {
                showStudyPermit();
            }
        }

        private void clearControlBox()
        {
            textBox_DateCreated.Clear();
            textBox_formType.Clear();
            textBox_ID.Clear();
            textBox_name.Clear();
            textBox_validation.Clear();
            richTextBox_formText.Clear();
        }

        private void showStudyPermit()
        {
            DbContextDal dal = new DbContextDal();
            StudentStudyForm SF = dal.StudentsStudyForms.Where(x => x.ID == student.ID).FirstOrDefault();
            if (SF != null)
            {
                textBox_DateCreated.AppendText(SF.FormCreateDate.Date.ToShortDateString());
                textBox_name.AppendText("Name: " + student.Name);
                textBox_ID.AppendText("ID: " + student.ID);
                textBox_formType.AppendText("Study fee permit");
                richTextBox_formText.AppendText("I hereby confirm that " + student.Name + ",student ID " + student.ID + "\nstudies at our institution during the school year "
                    + SF.ValidationDate.Year + " in semester " + student.Study_semester);
                textBox_validation.AppendText("This permit is valid until: " + SF.ValidationDate.Date.ToShortDateString());
                groupBox.Show();
            }
            else
                MessageBox.Show("You dont have study permissiom yet");
        }

        private void showFeePermit()
        {
            DbContextDal dal = new DbContextDal();
            StudentFeeForm SF = dal.StudentsFeeForms.Where(x => x.ID == student.ID).FirstOrDefault();
            if(SF != null)
            {
                textBox_DateCreated.AppendText(SF.FormCreateDate.Date.ToShortDateString());
                textBox_name.AppendText("Name: " + student.Name);
                textBox_ID.AppendText("ID: " + student.ID);
                textBox_formType.AppendText("Annual fee permit");
                richTextBox_formText.AppendText("I hereby confirm that " + student.Name + " studies at our institution during the school year"
                    + SF.ValidationDate.Year + "\nThis are tuition fee for the academic year " + SF.ValidationDate.Year + ": " + SF.anualFee);
                textBox_validation.AppendText("This permit is valid until: " + SF.ValidationDate.Date.ToShortDateString());
                groupBox.Show();
            }

            else
                MessageBox.Show("You dont have fee permissiom yet");
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            refTomenu.Show();
            this.Hide();
        }
    }
}
