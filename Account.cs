using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankListApp
{
    internal class Account
    {
        public int AccountNumber { get; set; }
        public string UserName { get; set; }
        public double Balance { get; set; }
        public String BankName { get; set; }
        public long AadharNumber { get; set; }

        public const int MIN_BALANCE = 500;

        public Account() { }
        public Account(int accountNumber, String userName, string bankName) : this(accountNumber, userName, bankName, 0)
        {

        }
        public Account(int accountNumber, string userName, string bankName, long AadharNumber) : this(accountNumber, userName, bankName, 0, MIN_BALANCE)
        {

        }
        public Account(int accountNumber, string userName, string bankName, long AadharNumber, double balance)
        {
            this.AccountNumber = accountNumber;
            this.UserName = userName;
            this.BankName = bankName;
            this.AadharNumber = AadharNumber;

            Balance = balance < MIN_BALANCE ? MIN_BALANCE : balance;

        }

        public bool AmountDeposit(double amount)
        {
            this.Balance += amount;
            return true;
        }
        public bool WithdrawAmount(Account account, double amount)
        {
            if (account.Balance - amount < MIN_BALANCE)
                return false;
            account.Balance -= amount;
            return true;
        }

        public static void PrintAccountDetails(Account account)
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"|{"Account Number",-15} | {"User Name",-15} | {"Banke Name",-10} | {"Balance",-8} | {"Aadhar Number",-13}|");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"|{account.AccountNumber,-15} | {account.UserName,-15} | {account.BankName,-10} | {account.Balance,-8} | {account.AadharNumber,-13}|");
            Console.WriteLine("---------------------------------------------------------------------------");


        }
    }
}
