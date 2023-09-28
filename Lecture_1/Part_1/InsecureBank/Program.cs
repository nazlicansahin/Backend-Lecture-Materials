using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lecture_1.Part_1.InsecureBank;
class Program
{
    static List<string> accountOwners = new List<string>();
    static List<double> accountBalances = new List<double>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Welcome to the Insecure Bank!");
            Console.WriteLine("1. Create an Account");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (float.TryParse(Console.ReadLine(), out float choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        DepositMoney();
                        break;
                    case 3:
                        WithdrawMoney();
                        break;
                    case 4:
                        CheckBalance();
                        break;
                    case 5:
                        Console.WriteLine("Thank you for using the Insecure Bank!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Enter an integer value");
            }


        }
    }

    static void CreateAccount()
    {

        string ownerName = null;
        Console.Write("Enter your name: ");


        while (ownerName == null || ownerName.Length == 0)
        {
            Console.Write("Name cannot be null: ");

            ownerName = Console.ReadLine();

            while ( accountOwners.Contains(ownerName) )
            {
                Console.WriteLine("There is a person has this name: ");

                Console.Write("Enter a name: ");

                ownerName = Console.ReadLine();
            }

            
        }

        accountOwners.Add(ownerName);

        accountBalances.Add(0.0);

        Console.WriteLine("Account created successfully!");
    }

    static void DepositMoney()
    {
        int index = -1; // Initialize to -1 to indicate "not found."

        try
        {
            Console.Write("Enter your name: ");
            string ownerName = Console.ReadLine();
            index = accountOwners.IndexOf(ownerName);

            if (index == -1)
            {
                Console.WriteLine("Account not found. Please check your name.");
                return; // Exit the method since the account is not found.
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return; // Exit the method due to the error.
        }

        try
        {
            Console.Write("Enter the amount to deposit: ");
            double amount = double.Parse(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive amount to deposit.");
                return; // Exit the method due to the invalid amount.
            }

            accountBalances[index] += amount;
            Console.WriteLine($"Deposited ${amount}. New balance: ${accountBalances[index]}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter a valid number.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void WithdrawMoney()
    {     
            int index = -1; // Initialize to -1 to indicate "not found."

            try
            {
                Console.Write("Enter your name: ");
                string ownerName = Console.ReadLine();
                index = accountOwners.IndexOf(ownerName);

                if (index == -1)
                {
                    Console.WriteLine("Account not found. Please check your name.");
                    return; // Exit the method since the account is not found.
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return; // Exit the method due to the error.
            }
        try
        {
            Console.Write("Enter the amount to withdraw: ");
            double amount = double.Parse(Console.ReadLine());

            if (accountBalances[index] >= amount)
            {
                accountBalances[index] -= amount;
                Console.WriteLine($"Withdrawn ${amount}. New balance: ${accountBalances[index]}");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }

        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter a valid number.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }

    static void CheckBalance()
    {

        int index = -1; // Initialize to -1 to indicate "not found."

        try
        {
            Console.Write("Enter your name: ");
            string ownerName = Console.ReadLine();
            index = accountOwners.IndexOf(ownerName);

            if (index == -1)
            {
                Console.WriteLine("Account not found. Please check your name.");
                return; // Exit the method since the account is not found.
            }
            else
            {
                Console.WriteLine($"Your balance is ${accountBalances[index]}");

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return; // Exit the method due to the error.
        }

    }
}
