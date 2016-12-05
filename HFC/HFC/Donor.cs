using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFC
{
    public class Donor
    {
        public string DonorID { get; set; }
        public FoodBank FavoriteFoodBank { get; set; }
        public string Email { get; set; }

        public Donor()
        {
            DonorID = "";
            FavoriteFoodBank = null;
            Email = "";
        }

        public void unregistered()
        {
            DonorID = "-1";
            FavoriteFoodBank = null;
            Email = "Unregistered User No Email On File";
        }
    }
}
