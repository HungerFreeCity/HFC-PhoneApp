using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HFC
{
    public partial class LoginModalPage
    {
        public LoginModalPage(App ilm)
        {
            var login = new Login(ilm);
            this.Children.Add(login);
        }
    }
}
