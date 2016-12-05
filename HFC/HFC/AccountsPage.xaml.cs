using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HFC
{
    public partial class AccountsPage : ContentPage
    {
        AppState currState;

        public void onLogoutClicked(object sender, EventArgs e)
        {
            currState.currApp.Logout();
        }

        public AccountsPage(AppState curr)
        {
            currState = curr;
            InitializeComponent();
            EmailLabel.Text = currState.User.Email;
            if (currState.User.FavoriteFoodBank != null)
            {
                FoodbankNameLabel.Text = currState.User.FavoriteFoodBank.FoodBankName;
                FoodbankWebsiteLabel.Text = currState.User.FavoriteFoodBank.Website;
            }
                Logout.Clicked += onLogoutClicked;
        }

    }
}
