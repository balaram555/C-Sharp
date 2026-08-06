using System;
class BankAccount
{
    private string accountNumber{get; set;}
    private string accountHolder{get; set;}
    private double balance;
    public double Balance
    {
        get { return balance; }
    }

    public BankAccount(string accountNumber, string accountHolder, double initialBalance)
    {
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this.balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount:C}. New balance: {balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrew: {amount:C}. New balance: {balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount.");
        }
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Account Holder: {accountHolder}, Account Number: {accountNumber}, Balance: {balance:C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Account Number: ");
        string accountNumber = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(accountNumber))
        {
            Console.WriteLine("Account number cannot be empty.");
            return;
        }
        if(accountNumber.Length < 9 || accountNumber.Length > 18)
        {
            Console.WriteLine("Account number must be between 9 and 18 characters.");
            return;
        }
        Console.Write("Enter Account Holder Name: ");
        string accountHolder = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(accountHolder))
        {
            Console.WriteLine("Account holder name cannot be empty.");
            return;
        }
        if (accountHolder.Length < 3 || accountHolder.Length > 50)
        {
            Console.WriteLine("Account holder name must be between 3 and 50 characters.");
            return;
        }
        Console.Write("Enter Initial Balance: ");
        // double initialBalance = double.Parse(Console.ReadLine());
        if (!double.TryParse(Console.ReadLine(), out double initialBalance))
        {
            Console.WriteLine("Invalid input. Please enter a valid number for the initial balance.");
            return;
        }
        if (initialBalance < 0)
        {
            Console.WriteLine("Initial balance cannot be negative.");
            return;
        }
        BankAccount newAccount = new BankAccount(accountNumber, accountHolder, initialBalance);
       bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nBank Account Menu:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Display Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
                continue;
            }
            switch (choice)
            {
                case 1:
                    Console.Write("Enter deposit amount: ");
                    if (double.TryParse(Console.ReadLine(), out double depositAmount))
                    {
                        newAccount.Deposit(depositAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    break;
                case 2:
                    Console.Write("Enter withdrawal amount: ");
                    if (double.TryParse(Console.ReadLine(), out double withdrawalAmount))
                    {
                        newAccount.Withdraw(withdrawalAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    break;
                case 3:
                    newAccount.DisplayBalance();
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            
        }
    }
}