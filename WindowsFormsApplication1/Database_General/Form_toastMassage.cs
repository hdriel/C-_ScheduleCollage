using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAandB.Database_General
{
    public partial class Form_toastMassage : Form
    {
        private Timer timer;
        private Timer timerToClose;
        private int startPosX;
        private int startPosY;


        public Form_toastMassage(string message)
        {
            InitializeComponent();

            lbl_message.Text = message;

            // We want our window to be the top most
            TopMost = true;
            // Pop doesn't need to be shown in task bar
            ShowInTaskbar = false;
            // Create and run timer for animation
            timer = new Timer();            
            timer.Interval = 50;
            timer.Tick += timer_Tick;

           
        }

        protected override void OnLoad(EventArgs e)
        {
            // Move window out of screen
            startPosX = Screen.PrimaryScreen.WorkingArea.Width - Width;
            startPosY = Screen.PrimaryScreen.WorkingArea.Height;
            SetDesktopLocation(startPosX, startPosY);
            base.OnLoad(e);
            // Begin animation
            timer.Start();

            FadeIn(this, 100);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //Lift window by 5 pixels
            startPosY -= 5;
            //If window is fully visible stop the timer
            if (startPosY < Screen.PrimaryScreen.WorkingArea.Height - Height)
            {
                timer.Stop();

                timerToClose = new Timer();
                timerToClose.Interval = 45;
                counter = timer.Interval;
                timerToClose.Tick += timerToClose_Tick;
                timerToClose.Start(); 
            }
            else
                SetDesktopLocation(startPosX, startPosY);
        }




        double counter;
        void timerToClose_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter <= 0)
            {
                timerToClose.Stop();
                FadeOut(this, 100);
            }
            /*
            if (counter <= 300)
            {
                startPosY += 15;
                SetDesktopLocation(startPosX, startPosY);

                if (counter <= 0 || startPosY >= Screen.PrimaryScreen.WorkingArea.Height - Height)
                {
                    timerToClose.Stop();
                    this.Close();
                }
            } 
            */       
        }
        

        

        private async void FadeOut(Form o, int interval = 80)
        {
            //Object is fully visible. Fade it out
            while (o.Opacity > 0.0)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.05;
            }
            o.Opacity = 0; //make fully invisible
            this.Close();       
        }
        private async void FadeIn(Form o, int interval = 80)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible       
        }

        private void Form_toastMassage_Load(object sender, EventArgs e)
        {

        }
    }
}
