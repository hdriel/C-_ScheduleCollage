using System;
using System.Windows.Forms;

namespace ProjectAandB
{
    public partial class Form_SplashScreen : Form
    {
        public Form_SplashScreen()
        {
            InitializeComponent();
        }

        // Fill process bar and after that filled exit from this window
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                this.Close();
            }                           
        }

    }
}
