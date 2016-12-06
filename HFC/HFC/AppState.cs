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
        public List<FoodBank> FoodBankList { get; set; }
        public App currApp;

        public AppState()
        {
            User = new Donor();
            FoodBankList = new List<FoodBank>();
            currApp = null;
        }

        public AppState(App curr)
        {
            User = new Donor();
            FoodBankList = new List<FoodBank>();
            currApp = curr;
        }

        public void spoofFoodBankList()
        {
            var temp = new Need();
            var templist = new List<Need>();
            templist.Add(temp);
            FoodBankList.Add(new FoodBank {FoodBankName="No Data Could Be Retrieved" ,NeedsList=templist});
            FoodBankList.Add(new FoodBank {FoodBankName="Please Reload App" });
        }
    }
}
