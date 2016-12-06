using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Newtonsoft.Json;
using Xamarin.Forms;
using System.Net.Http;

namespace HFC
{
    public partial class App : Application, ILoginManager
    {
        public AppState currState { get; set; }
        public App()
        {

            InitializeComponent();
            currState = new AppState(this);

            if (Application.Current.Properties.ContainsKey("LoggedIn"))
            {
                if (Application.Current.Properties["LoggedIn"].Equals("1"))
                {
                    //load user data from device/API
                    if (Application.Current.Properties.ContainsKey("User"))//ideally User property will hold the userid to query api for the rest
                    {
                        if (Application.Current.Properties["User"].Equals("0"))
                        {
                            //do nothing
                            //logged in before but has logged out
                            Application.Current.Properties["LoggedIn"] = "0";
                            Application.Current.SavePropertiesAsync();
                        }
                        else if (Application.Current.Properties["User"].Equals("-1"))
                        {
                            currState.User.unregistered();
                        }
                        else
                        {
                            currState.User.unregistered();
                            //query for user data either from api or off disk
                        }
                    }
                    else
                    {
                        Application.Current.Properties["LoggedIn"] = "0";
                        Application.Current.SavePropertiesAsync();
                    }

                }
                else
                {
                    Application.Current.Properties["LoggedIn"] = "0";
                    Application.Current.SavePropertiesAsync();
                }
            }
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            if (Application.Current.Properties.ContainsKey("LoggedIn"))
            {
                if (Current.Properties["LoggedIn"].Equals("0"))
                {
                    MainPage = new LoginModalPage(this);
                }
                else if (Current.Properties["LoggedIn"].Equals("1"))
                {
                    ShowMainPage();
                }
            }
            else
            {
                MainPage = new LoginModalPage(this);
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Application.Current.SavePropertiesAsync();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public async void ShowMainPage()
        {
            //call get location function from nathan's code
            //query restapi for foodbanklist
            //set foodbanklist and current user
            await getFoodBanks();
            this.MainPage = new MainPage(currState);
        }

        public void Logout()
        {
            Application.Current.Properties["LoggedIn"] = "0";
            Application.Current.Properties["User"] = "0";
            Application.Current.SavePropertiesAsync();
            MainPage = new LoginModalPage(this);
        }

        public async Task getFoodBanks(string Latitude, string Longtitude)
        {
            HttpClient client = new HttpClient();
            string RestUrl = "http://hfcrest.azurewebsites.net/api/Foodbanks/?Longtitude={0}&Latitude={1}";
            var uri = new Uri(string.Format(RestUrl, Longtitude, Latitude));

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                this.currState.FoodBankList = JsonConvert.DeserializeObject<List<FoodBank>>(content);
                foreach(FoodBank Foodbankf in currState.FoodBankList)
                {

                }
            }
            else
            {
                var content = await Task.FromResult<List<FoodBank>>(null);
                this.currState.spoofFoodBankList();
            }
            return;
        }

        public async Task getFoodBanks()
        {
            HttpClient client = new HttpClient();
            string RestUrl = "http://hfcrest.azurewebsites.net/api/Foodbanks";
            var uri = new Uri(RestUrl);

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                this.currState.FoodBankList = JsonConvert.DeserializeObject<List<FoodBank>>(content);
                RestUrl = "http://hfcrest.azurewebsites.net/api/FoodBanks/GetNeeds/{0}";
                for(int i = 0; i < currState.FoodBankList.Count; i++)
                {
                    uri = new Uri(string.Format(RestUrl, currState.FoodBankList[i].FoodBankID));
                    response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        content = await response.Content.ReadAsStringAsync();
                        this.currState.FoodBankList[i].NeedsList = deSerializeNeeds(content);
                    }
                    
                }
            }
            else
            {
                var content = await Task.FromResult<List<FoodBank>>(null);
                this.currState.spoofFoodBankList();
            }
            return;
        }
         public static List<Need> deSerializeNeeds(string content)
        {
            var temp = content.Split(new Char[] { '}' });
            Regex jsondeserial = new Regex("(\\[?\\,?{\"NeedID\":\"(?<needid>[A-Za-z0-9:;,.//(//)\\s]*)\",\"Name\":\"(?<name>[A-Za-z0-9\\s]*)\",\"Unit\":\"(?<unit>[A-Za-z0-9\\s]*)\")");
            Match groups;
            Need tempNeed = new Need();
            List<Need> tempList = new List<Need>();
            foreach (string substr in temp)
            {
                tempNeed = new Need();
                groups = jsondeserial.Match(substr);
                if (groups.Success)
                {
                    tempNeed.NeedID = groups.Groups["needid"].Value;
                    tempNeed.Name = groups.Groups["name"].Value;
                    tempNeed.Unit = groups.Groups["unit"].Value;
                    tempList.Add(tempNeed);
                }
            }
            return tempList;
        }
    }
}