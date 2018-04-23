using Facebook;
using System;
using System.Windows.Forms;

namespace ProjectAandB.FacebookAccount
{
    class Facebook_Account
    {
        /*
        On The premission of public_profile & user_about_me & user_friends you can get only the: id, cover,name,first_name,last_name,age_range,link,gender,locale,picture,timezone,updated_time,verified,         
        On the premission of email tou can get only the: email.
        facebook had restrictions the field birthday
        */

        private const string AppId = "239010066477815";
        private const string ExtendedPermissions = "public_profile,user_friends,email";
        private string _accessToken;
        Account account = new Account();
        Form_FB_LoginDialog fbLoginDialog;


        public Account getAccountFromFacebook()
        {
            fbLoginDialog = new Form_FB_LoginDialog(AppId, ExtendedPermissions); // open new form of login facebbok in the the web
            fbLoginDialog.ShowDialog();                                          // show this form to user - for do connect to his account facebook
            _accessToken = fbLoginDialog.FacebookOAuthResult.AccessToken;        // get the access token for this user connection
            if (fbLoginDialog.FacebookOAuthResult != null)
            {
                if (fbLoginDialog.FacebookOAuthResult.IsSuccess)                 // if the connect successfuly
                {
                    var fb = new FacebookClient(_accessToken); // connect to the facebookClient with the access token og this user
                    try
                    {
                        dynamic result = fb.Get("me?fields=id,name,email,gender"); // pull thes values from the facebook account
                        account = new Account()                                    // enter thes values to new account object
                        {
                            Name = result.name,
                            Email = result.email,
                            Id = result.id,
                            gender = result.gender
                        };
                    }
                    catch (Exception)
                    {
                        account = new Account();
                    }
                }
                else
                {
                    //MessageBox.Show(fbLoginDialog.FacebookOAuthResult.ErrorDescription);
                }
            }
            logout();               // logout from the facebook connection
            fbLoginDialog.Close();  // close the form of the login facebbok
            return account;         // return the account facebook with values from connection
        }
        
        private void logout()
        {
            var webBrowser = new WebBrowser();
            var fb = new FacebookClient();
            var logouUrl = fb.GetLogoutUrl(new { access_token = _accessToken, next = "https://www.facebook.com/connect/login_success.html" });
            webBrowser.Navigate(logouUrl);
        }
        
    }
}
