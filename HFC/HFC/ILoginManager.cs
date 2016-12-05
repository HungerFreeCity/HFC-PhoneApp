using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HFC
{
    public interface ILoginManager
    {
        void ShowMainPage();
        void Logout();
    }
}
