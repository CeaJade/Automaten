using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Automaten
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine machine = new VendingMachine(true, 10);

            while (true)
            {
                string selection;
                do
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Pick a product");
                        for (int i = 0; i < machine.productHolders.Length; i++)
                        {
                            Console.Write((i + 1) + ") " + machine.productHolders[i].PeekProduct().Name + " ($" + machine.productHolders[i].PeekProduct().Price + ") ");
                            if (machine.productHolders[i].Position > 0)
                            {
                                Console.Write("( " + machine.productHolders[i].Position + " left in stock)");
                            }
                            else
                            {
                                Console.Write("(SOLD OUT)");
                            }
                            Console.WriteLine("");
                        }
                        Console.WriteLine("\nPick a product: ");
                        selection = Console.ReadLine().ToUpper();
                        if (selection == "A")
                        {
                            Admin(machine);                            
                        }
                        else
                        {
                            machine.selectedItem = int.Parse(selection) - 1;
                        }
                    } while (machine.selectedItem > machine.productHolders.Length || machine.selectedItem < 0);

                    if (machine.GetSelectedProduct().Position <= 0)
                    {
                        Console.WriteLine("Product is sold out!");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                } while (selection == "A" || machine.GetSelectedProduct().Position <= 0);

                int inserted;
                do
                {
                    Console.WriteLine("Insert money (0 to cancel)");
                    inserted = int.Parse(Console.ReadLine());
                    if (inserted == 0)
                    {
                        Console.WriteLine("*$" + machine.DispenseCoin(false) + " returned to your wallet");
                        break;
                    }
                    machine.InsertCoins(inserted);

                    if (machine.coinCount < machine.GetSelectedProduct().PeekProduct().Price)
                    {
                        Console.WriteLine("Add more money (press 0 to cancel)");
                    }
                } while (machine.coinCount < machine.GetSelectedProduct().PeekProduct().Price);

                if (inserted > 0) {
                    Console.WriteLine("Press 1 to confirm or 0 to cancel.");
                    string confirm = Console.ReadLine();
                    if (confirm == "1")
                    {
                        Console.WriteLine("One " + machine.DispenseProduct().Name + " popped out");
                        Console.WriteLine("$" + machine.DispenseCoin() + " came out as change");
                    }
                    else
                    {
                        Console.WriteLine("$" + machine.DispenseCoin(false) + " returned to your wallet");
                    }
                }
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        public static void Admin(VendingMachine machine)
        {
            string back;
            do
            {
                Console.Clear();
                Console.WriteLine("Pick your option:");
                Console.WriteLine("1) See stock");
                Console.WriteLine("2) Access money vault");
                Console.WriteLine("3) Price change");
                Console.WriteLine("");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Stock\n");
                        for (int i = 0; i < machine.productHolders.Length; i++)
                        {
                            Console.Write((i + 1) + ") " + machine.productHolders[i].PeekProduct().Name + " ");
                            if (machine.productHolders[i].Position > 0)
                            {
                                Console.Write("( " + machine.productHolders[i].Position + " left in stock)");
                            }
                            else
                            {
                                Console.Write("(SOLD OUT)");
                            }
                            Console.WriteLine("");
                        }
                        Console.WriteLine("\nWould you like to restock? (y/n)");
                        string restock = Console.ReadLine();
                        if (restock == "y")
                        {
                            Console.Clear();
                            Console.Write("Restocking"); Thread.Sleep(600); Console.Write("."); Thread.Sleep(600); Console.Write("."); Thread.Sleep(600); Console.WriteLine(".");
                            Thread.Sleep(1500);
                            for (int i = 0; i < machine.productHolders.Length; i++)
                            {
                                machine.productHolders[i].Position = 10;
                            }
                            Console.Clear();
                            Console.WriteLine("Restocking completed!");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Money vault.");
                        Console.WriteLine("There is currently $" + machine.moneyBox.ShowMoney() + " in the machine");
                        Console.WriteLine("Would you like to take it out? (y/n)");
                        string takeit = Console.ReadLine();
                        if (takeit == "y")
                        {
                            Console.WriteLine("You have emptied the vending machine from $" + machine.moneyBox.ShowMoney());
                            machine.moneyBox.WithdrawMoney();
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Change price of product\n");
                        Console.WriteLine("Pick a product to change");
                        for (int i = 0; i < machine.productHolders.Length; i++)
                        {
                            Console.WriteLine((i + 1) + ") " + machine.productHolders[i].PeekProduct().Name);
                        }
                        int product = int.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("\nChoose the price");
                        machine.productHolders[product].PeekProduct().Price = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nPrice changed! " + machine.productHolders[product].PeekProduct().Price);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input!");
                        break;
                }

                Console.WriteLine("Back to user menu? (y/n)");
                back = Console.ReadLine();

            } while (back == "n");
            Console.Clear();
        }
    }
}
