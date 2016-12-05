using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HFC
{
    public partial class Login : ContentPage
    {
        App ilm;
        
        public void OnLoginButtonClicked(object sender, EventArgs e)
        {
            Application.Current.Properties["LoggedIn"] = 1;
            Application.Current.Properties["User"] = -1;
            Application.Current.SavePropertiesAsync();
            ilm.currState.User.unregistered();
            ilm.ShowMainPage();
        }

        public Login(App ilmpassed)
        {
            ilm = ilmpassed;
            InitializeComponent();
            contworeg.Clicked += OnLoginButtonClicked;
        }
    }
}
