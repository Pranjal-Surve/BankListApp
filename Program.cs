using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace BankListApp
{
    internal class User
    {
        static void Main(string[] args)
        {
            AccountManager accountManager = new AccountManager();
            accountManager.CallMainMenu();            
        }

    }
}