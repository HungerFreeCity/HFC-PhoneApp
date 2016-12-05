using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HFC
{
    public class AppState
    {
        public Donor User { get; set; }
        public ObservableCollection<FoodBank> FoodBankList { get; set; }
        public App currApp;

        public AppState()
        {
            User = new Donor();
            FoodBankList = new ObservableCollection<FoodBank>();
            currApp = null;
        }

        public AppState(App curr)
        {
            User = new Donor();
            FoodBankList = new ObservableCollection<FoodBank>();
            currApp = curr;
        }

        public void spoof()
        {
            User.unregistered();
            FoodBank temp = new FoodBank();
            temp.spoof();
            FoodBankList.Add(temp);
            FoodBankList.Add(temp);
        }
    }
}
