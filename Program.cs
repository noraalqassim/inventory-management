using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


namespace InventoryMangement
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Display Inventory Mangement Assignment message
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                             Inventory Mangement Assignment                    │");
            Console.WriteLine("├───────────────────────────────────────────────────────────────────────────────┤");

            //Item Class Object
            var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
            var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
            var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
            var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
            var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
            var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
            var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
            var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
            var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
            var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
            var coffee = new Item("Coffee", 20);
            var sandwich = new Item("Sandwich", 15);
            var batteries = new Item("Batteries", 10);
            var umbrella = new Item("Umbrella", 5);
            var sunscreen = new Item("Sunscreen", 8);

            // Add items to the store
            var store = new Store(300);  //300 = maxCapacity 
            store.AddItem(waterBottle);
            store.AddItem(chocolateBar);
            store.AddItem(notebook);
            store.AddItem(pen);
            store.AddItem(tissuePack);
            store.AddItem(chipsBag);
            store.AddItem(sodaCan);
            store.AddItem(soap);
            store.AddItem(shampoo);
            store.AddItem(toothbrush);
            store.AddItem(coffee);
            store.AddItem(sandwich);
            store.AddItem(batteries);
            store.AddItem(umbrella);
            store.AddItem(sunscreen);
            //store.AddItem(sunscreen); //to check if the " not allow to add items with same name to the store " it's Work
            //store.DeleteItem("Items"); //to check if the  " Item with name {itemName} not found in the store. " message it's work 
            //store.DeleteItem("Sunscreen"); // to check if the DeleteItem method it's work

            // GetCurrentVolume method
            Console.WriteLine("│   Current volume of items in store: " + store.GetCurrentVolume().ToString().PadLeft(4, ' ') + "                                      │");

            // FindItemByName method
            Console.WriteLine("│   Finding an item: " + store.FindItemByName("x") + "                                 │");
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");

            //SortByNameAsc method 
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                           Before sorting Name By Asc:                         │");
            store.DisplayItems();

            // Sort items by name
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            store.SortByNameAsc();
            Console.WriteLine("│                             After sorting Name By Asc:                        │");
            store.DisplayItems();

            // Sort items by Date
            store.SortItemsByDate();

            // Group items by date
            var groupedItems = store.GroupByDate();

            // Display items in a formatted table
            store.DisplayItemsByGroupTable(groupedItems);
        }
    }
}
