using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HFC
{
    public partial class MainPage
    {
        AppState currState;
        public MainPage(AppState curr)
        {
            currState = curr;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            //instantiate a maps page here
            NeedsList NeedTab = new NeedsList(currState);
            AccountsPage AcctTab = new AccountsPage(currState);
            //this.Children.Add(Nameofmapspageinstance) ** uncomment and put the right name in parenthesis
            this.Children.Add(NeedTab);
            this.Children.Add(AcctTab);
        }
    }
}
