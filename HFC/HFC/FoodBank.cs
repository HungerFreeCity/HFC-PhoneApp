using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HFC
{
    public class FoodBank
    {
        public string FoodBankID { get; set; }
        public string Location { get; set; }
        public string FoodBankName { get; set; }
        public string Website { get; set; }
        public ObservableCollection<Need> NeedsList { get; set; }

        public FoodBank()
        {
            FoodBankID = "";
            Location = "";
            Website = "";
            NeedsList = new ObservableCollection<Need>();
        }

        public void spoof()
        {
            FoodBankID = "5879";
            Location = "long and lat";
            FoodBankName = "St Matthew Presbyterian";
            Website = "www.younamehere.com";
            NeedsList.Add(new Need { NeedID = "4321", Name = "String Cheese", Unit = "lbs" });
            NeedsList.Add(new Need { NeedID = "4322", Name = "Water", Unit = "gals" });
            NeedsList.Add(new Need { NeedID = "4323", Name = "Canned Vegetables", Unit = "Cans"});
            NeedsList.Add(new Need { NeedID = "4324", Name = "Milk", Unit = "gals"});
        }

    }
}
