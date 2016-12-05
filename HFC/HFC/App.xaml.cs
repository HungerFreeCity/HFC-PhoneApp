using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HFC
{
    public partial class App : Application, ILoginManager
    {
        public AppState currState { get; set; }
        public App()
        {
            InitializeComponent();
            currState = new AppState(this);
            if (Application.Current.Properties.ContainsKey("LoggedIn"))
            {
                if (Current.Properties["LoggedIn"].Equals(0))
                {
                    MainPage = new LoginModalPage(this);
                }
                else if (Current.Properties["LoggedIn"].Equals(1))
                {
                    ShowMainPage();
                }
            }
            else
            {
                MainPage = new LoginModalPage(this);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            if (Application.Current.Properties.ContainsKey("LoggedIn"))
            {
                if (Application.Current.Properties["LoggedIn"].Equals(1))
                {
                    //load user data from device/API
                    if (Application.Current.Properties.ContainsKey("User"))//ideally User property will hold the userid to query api for the rest
                    {
                        if (Application.Current.Properties["User"].Equals("0"))
                        {
                            //do nothing
                            //logged in before but has logged out
                        }
                        else if (Application.Current.Properties["User"].Equals("-1"))
                        {
                        }
                        else
                        {
                            //query for user data either from api or off disk
                        }
                    }
                    else
                    {
                        Application.Current.Properties["LoggedIn"] ="0";
                        Application.Current.SavePropertiesAsync();
                    }

                }
                else
                {
                    Application.Current.Properties["LoggedIn"] = "0";
                    Application.Current.SavePropertiesAsync();
                }
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Application.Current.SavePropertiesAsync();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void ShowMainPage()
        {
            //call get location function from nathan's code
            //query restapi for foodbanklist
            //set foodbanklist and current user
            currState.spoof();
            this.MainPage = new MainPage(currState);
        }

        public void Logout()
        {
            Application.Current.Properties["LoggedIn"] = 0;
            Application.Current.Properties["User"] = 0;
            Application.Current.SavePropertiesAsync();
            MainPage = new LoginModalPage(this);
        }
    }
}
