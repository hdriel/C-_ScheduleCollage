using ProjectAandB.Database_General;
using System;
using System.IO;
using System.Windows.Forms;


namespace ProjectAandB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /* 
               for get this project in another computer and the PMC dont let you to add migration just ran the following command in PM:
               PM> Get-Project -all | Uninstall-Package EntityFramework
               and then run the command: 
               PM> Get-Project -all | Install-Package EntityFramework
               and then restart the project (exit and return the visual studio)

               to run in in the first time, or if you want to run in from the begining with initilize data first
               first at all: 
                    dont forget to change the Connection String in the file 'App.config' to availabe database 
               use the followin command in you Package Manager Console to delete all the table in the database for recreating agian
               PM> update-database -TargetMigration:0 -Force
               And then run the command
               PM> add-migration a
               And then run the command
               PM> update-database
            */

            //SettingDatabase.setupFirstInitDB(true);
            try
            {
                
                DbContextDal dal = new DbContextDal();
                Form_toastMassage toast = new Form_toastMassage("check connection to database!");
                toast.Show();
                if (dal.users.Find(0) == null)
                {
                    GeneralFuntion.createAdminUser();
                }
                
                Application.Run(new Form_LoginStart());
            }
            catch (Exception) { MessageBox.Show("There isn't connection to database!");}
      }
    }
}
