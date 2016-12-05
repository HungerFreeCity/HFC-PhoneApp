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
        public MainPage(AppState currState)
        {
            InitializeComponent();

            NeedsList NeedTab = new NeedsList(currState.FoodBankList[0], currState.FoodBankList[1]);
            AccountsPage AcctTab = new AccountsPage(currState);

            //TODO: Jesus, replace this parameter with the appropriate list after retrieving location through LocationServicesHelper.getLocationUpdate.
            MapsPage MapTab = new MapsPage(currState.FoodBankList);

            this.Children.Add(NeedTab);
            this.Children.Add(AcctTab);
            this.Children.Add(MapTab);
        }
    }
}
