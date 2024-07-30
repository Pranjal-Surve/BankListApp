using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankListApp
{
    internal class AccountManager : Account
    {
        //Add Account
        public void AddAccount(List<Account> accounts)
        {
            {
                Console.WriteLine("Enter account number : ");
                AccountNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter user name : ");
                UserName = Console.ReadLine();

                Console.WriteLine("Enter bank name : ");
                BankName = Console.ReadLine();

                Console.WriteLine("Enter aadhar number : ");
                AadharNumber = long.Parse(Console.ReadLine());

                Console.WriteLine("Enter balance : ");
                Balance = double.Parse(Console.ReadLine());

                accounts.Add(new Account(AccountNumber, UserName, BankName, AadharNumber, Balance));

                SerializeDeserialize.SerializeData(accounts);
                Console.WriteLine();
                Console.WriteLine("Account Created Successfully!!");
            }
        }
        //Update Account
        public void UpdateAccount(List<Account> accounts, int accountNumber)
        {
            bool flag = false;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccountNumber == accountNumber)
                {
                    Console.WriteLine("Enter user name : ");
                    UserName = Console.ReadLine();

                    Console.WriteLine("Enter bank name : ");
                    BankName = Console.ReadLine();

                    Console.WriteLine("Enter balance : ");
                    Balance = double.Parse(Console.ReadLine());

                    accounts[i] = new Account(accounts[i].AccountNumber, UserName, BankName, accounts[i].AadharNumber, Balance);
                    SerializeDeserialize.SerializeData(accounts);
                    flag = true;
                }
            }
            //if (!flag)
            //{
            //    Console.WriteLine("Enter Valid account Number");
            //    Console.WriteLine();
            //}
            if (flag)
            {
                Console.WriteLine();
                Console.WriteLine("Account Updated Successfully!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Account doesn't exist/ Invalid Account!");
                Console.WriteLine();
            }
        }

        //Delete Account
        public void DeleteAccount(List<Account> accounts, int accountNumber)
        {
            bool flag = false;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccountNumber == accountNumber)
                {
                    accounts.RemoveAt(i);
                    flag = true;

                }
            }
            SerializeDeserialize.SerializeData(accounts);
            if (flag)
            {
                Console.WriteLine();
                Console.WriteLine("Account Deleted Successfully!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Account doesn't exist!");
                Console.WriteLine();
            }
        }
        //CallMenu
        public void CallMainMenu()
        {
            List<Account> accounts = new List<Account>();
            accounts = SerializeDeserialize.DeserializeData(); 
            Console.WriteLine("\n----------------------------------------Welcome To Swabhav Bank--------------------------------------------");

            int operation = 0;
            while (operation != 4)
            {
                Console.Write("Choose Options from Main Menu below\n----------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.Write("Enter 1 to add account: ");
                Console.WriteLine();
                Console.Write("Enter 2 to Update Account Details: ");
                Console.WriteLine();
                Console.Write("Enter 3 to Delete Account: ");
                Console.WriteLine();
                Console.Write("Enter 4 to do Transactions on Account: ");

                operation = Convert.ToInt16(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        AddAccount(accounts);
                        break;

                    case 2:
                        Console.WriteLine("Enter your Account Number: ");
                        int accountNumber = Convert.ToInt32(Console.ReadLine());
                        UpdateAccount(accounts, accountNumber);
                        break;

                    case 3:
                        Console.WriteLine("Enter your Account Number: ");
                        int accountNumberToBeDeleted = Convert.ToInt32(Console.ReadLine());
                        DeleteAccount(accounts, accountNumberToBeDeleted);
                        break;

                    case 4:
                        CallSubMenu(accounts);
                        break;

                    default:
                        Console.WriteLine("Enter valid number");
                        break;

                }
            }
        }
        public void CallSubMenu(List<Account> accounts)
        {
            Console.WriteLine();
            Console.Write("Please Enter your Account Number: ");
            int userAcountNumber = int.Parse(Console.ReadLine());
            Account selectedAccount = null;

            foreach (Account account in accounts)
            {
                if (account.AccountNumber == userAcountNumber)
                {
                    selectedAccount = account;
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------------Sub Menu-----------------------------------------------------");
                    ChooseOperation(accounts, selectedAccount);

                    Console.WriteLine();
                    Console.WriteLine("------------------------------------------------------Thank you---------------------------------------------------------");
                }
            }

            if (selectedAccount == null)
            {
                Console.WriteLine("Invalid Account Number");
            }
        }
        public void ChooseOperation(List<Account> accounts, Account selectedAccount)
        {
            int operation = 0;
            bool exitSubMenu = false;
            do
            {
                Console.WriteLine("hello! What operation you want to perform? \n1.Deposit \n2.Withdraw \n3.Account with Max Balance \n4.Print Account Details \n5.Exit");
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        Console.WriteLine("Enter the amount to be deposited: ");
                        int depositAmount = int.Parse(Console.ReadLine());
                        if (selectedAccount.AmountDeposit(depositAmount))
                        {
                            Console.WriteLine(depositAmount + " is successfully deposited to account " + selectedAccount.AccountNumber);
                            Console.WriteLine("Your current balance is: " + selectedAccount.Balance);
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter the amount to be withdrawn: ");
                        int withdrwanAmount = int.Parse(Console.ReadLine());
                        if (selectedAccount.WithdrawAmount(selectedAccount, withdrwanAmount))
                        {
                            Console.WriteLine(withdrwanAmount + " is successfully withdrawn from account " + selectedAccount.AccountNumber);
                            Console.WriteLine("Your current balance is: " + selectedAccount.Balance);
                        }
                        else
                        {
                            Console.WriteLine("You don't have sufficient balance");
                        }
                        break;

                    case 3:
                        Account accountWithMaxBalance = null;
                        double maxBalance = 0;
                        foreach (Account userAccount in accounts)
                        {
                            if (userAccount.Balance > maxBalance)
                            {
                                accountWithMaxBalance = userAccount;
                                maxBalance = userAccount.Balance;
                            }
                        }
                        Console.WriteLine("Account with max balance is:");
                        Account.PrintAccountDetails(accountWithMaxBalance);
                        break;

                    case 4:
                        Console.WriteLine();
                        Account.PrintAccountDetails(selectedAccount);
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                }
                if (!exitSubMenu)
                {
                    bool validResponse = false;
                    while (!validResponse)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Do you want to perform another operation? (y/n)");
                        string continueInput = Console.ReadLine().Trim().ToLower();

                        if (continueInput == "y")
                        {
                            validResponse = true; // Continue loop
                        }
                        else if (continueInput == "n")
                        {
                            validResponse = true;
                            exitSubMenu = true; // Set flag to exit the sub-menu
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                        }
                    }
                }

            } while (!exitSubMenu);
            
        }

    }
}
