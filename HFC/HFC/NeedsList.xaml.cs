using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HFC
{
    public partial class NeedsList : ContentPage
    {
        FoodBank FirstFoodBank;
        FoodBank SecondFoodBank;
        public NeedsList(AppState curr)
        {
            InitializeComponent();

            if (curr.FoodBankList.Count > 0)
            {
                FirstFoodBank = curr.FoodBankList[1];
                SecondFoodBank = curr.FoodBankList[0];
                var temp = FirstFoodBank.NeedsList[0].Name;
                temp = FirstFoodBank.NeedsList[0].Unit;
                temp = FirstFoodBank.NeedsList[0].NeedID;
                temp = null;
                ListTitle1.Text = FirstFoodBank.FoodBankName;
                firstList.ItemsSource = FirstFoodBank.NeedsList;
                secondList.ItemsSource = SecondFoodBank.NeedsList;
                ListTitle2.Text = SecondFoodBank.FoodBankName;

            }

            else
            {
                curr.spoofFoodBankList();

            }
        }
    }
}
