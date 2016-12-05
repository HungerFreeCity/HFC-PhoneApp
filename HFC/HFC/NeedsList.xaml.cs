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
        public NeedsList(FoodBank FirstFoodBank, FoodBank SecondFoodBank)
        {
            var temp = FirstFoodBank.NeedsList[0].Name;
            temp = FirstFoodBank.NeedsList[0].Unit;
            temp = FirstFoodBank.NeedsList[0].NeedID;
            temp = null;
            InitializeComponent();
            ListTitle1.Text = FirstFoodBank.FoodBankName;
            firstList.ItemsSource = FirstFoodBank.NeedsList;
            secondList.ItemsSource = SecondFoodBank.NeedsList;
            ListTitle2.Text = SecondFoodBank.FoodBankName;
        }
        public void onClicked()
        {

        }
    }
}
