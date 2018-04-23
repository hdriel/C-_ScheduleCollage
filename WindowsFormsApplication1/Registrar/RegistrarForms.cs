using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ProjectAandB
{

    public partial class RegistrarForms : Form
    {
        public Form RefTomenu { get; set; }

        public RegistrarForms()
        {
            InitializeComponent();
            DbContextDal dal = new DbContextDal();
            var IDs = dal.students.Select(x => x.ID).ToList();
            foreach(var ID in IDs)
            {
                comboBox_IDs.Items.Add(ID);
            }
            comboBox_formToGenerate.Items.Add("Annual fee permit");
            comboBox_formToGenerate.Items.Add("Annual study permit");

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (comboBox_IDs.SelectedItem == null) {
                MessageBox.Show("Select student ID");
                return;
            }
            if (comboBox_formToGenerate.SelectedItem == null) {
                MessageBox.Show("Select form to generate");
                return;
            }
            if(textBox_feeSum.Visible == true && String.IsNullOrEmpty(textBox_feeSum.Text))
            {
                MessageBox.Show("Enter fee sum");
                return;
            }

                if (comboBox_formToGenerate.SelectedItem.ToString() == "Annual fee permit")
                    CreateFeeForm();
                else
                    CreateStudyForm();   
        }

        private void CreateStudyForm()
        {
            bool createForm = true;
            DbContextDal dal = new DbContextDal();
            int ID = int.Parse(comboBox_IDs.SelectedItem.ToString());
            StudentStudyForm StudyForm = new StudentStudyForm() { ID = ID, FormCreateDate = DateTime.Today, ValidationDate = dateTimePicker1.Value.Date };
            StudentStudyForm SF = dal.StudentsStudyForms.Where(x => x.ID == ID).FirstOrDefault();
            if (SF != null)
            {
                DialogResult result = MessageBox.Show("Student allready have study form, do you want to change it?", "caption", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    createForm = false;
                }
                if (createForm == true)
                {
                    dal.Entry(SF).CurrentValues.SetValues(StudyForm);
                    dal.SaveChanges();
                    MessageBox.Show("Fee study added");
                }
                else
                    MessageBox.Show("Fee study not added");
            }
            else
            {
                dal.StudentsStudyForms.Add(StudyForm);
                dal.SaveChanges();
                MessageBox.Show("Study form added");
            }
        }

        private void CreateFeeForm()
        {
            bool createForm = true;
            DbContextDal dal = new DbContextDal();
            int ID = int.Parse(comboBox_IDs.SelectedItem.ToString());
            StudentFeeForm FeeForm = new StudentFeeForm() { ID = ID, anualFee = float.Parse(textBox_feeSum.Text.ToString()), FormCreateDate = DateTime.Today, ValidationDate = dateTimePicker1.Value.Date };
            StudentFeeForm SF = dal.StudentsFeeForms.Where(x => x.ID == ID).FirstOrDefault();
            if (SF != null)
            {
                DialogResult result = MessageBox.Show("Student allready have fee form, do you want to change it?","caption",MessageBoxButtons.YesNo);
                if(result == DialogResult.No){
                    createForm = false;
                }
                if (createForm == true)
                {
                    dal.Entry(SF).CurrentValues.SetValues(FeeForm);
                    dal.SaveChanges();
                    MessageBox.Show("Fee form added");
                }
                else
                    MessageBox.Show("Fee form not added");
            }
            else
            {
                dal.StudentsFeeForms.Add(FeeForm);
                dal.SaveChanges();
                MessageBox.Show("Fee form added");
            }
        }

        private void comboBox_formToGenerate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_formToGenerate.SelectedItem.ToString() == "Annual fee permit")
            {
                label_feeSum.Show();
                textBox_feeSum.Show();
            }
            else
            {
                label_feeSum.Hide();
                textBox_feeSum.Hide();
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            RefTomenu.Show();
            this.Close();
        }

        private void textBox_feeSum_TextChanged(object sender, EventArgs e)
        {
            float n;
            Regex regex = new Regex("^[0-9.]");
            if (regex.IsMatch(textBox_feeSum.Text))
            {
                if (!float.TryParse(textBox_feeSum.Text, out n))
                {
                    textBox_feeSum.Clear();
                }
                else if (n < 0)
                {
                    textBox_feeSum.Clear();
                }
            }
            else
            {
                MessageBox.Show("Fee sum must be a positive number");
                textBox_feeSum.Clear();
            }
        }
    }
}
