using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HFC
{
    public class FoodBank
    {
        public string FoodBankID { get; set; }
        public string Address { get; set; }
        public string FoodBankName { get; set; }
        public string Website { get; set; }
        public Position Coordinates;
        public ObservableCollection<Need> NeedsList { get; set; }

        public FoodBank()
        {
            FoodBankID = "";
            Address = "";
            Website = "";
            NeedsList = new ObservableCollection<Need>();
            Coordinates = new Position(0, 0);
        }

        public void spoof()
        {
            FoodBankID = "5879";
            Address = "long and lat";
            FoodBankName = "St Matthew Presbyterian";
            Website = "www.younamehere.com";
            Coordinates = new Position(100, 250);
            NeedsList.Add(new Need { NeedID = "4321", Name = "String Cheese", Unit = "lbs" });
            NeedsList.Add(new Need { NeedID = "4322", Name = "Water", Unit = "gals" });
            NeedsList.Add(new Need { NeedID = "4323", Name = "Canned Vegetables", Unit = "Cans"});
            NeedsList.Add(new Need { NeedID = "4324", Name = "Milk", Unit = "gals"});
        }

    }
}
