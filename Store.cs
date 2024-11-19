using System;
using System.Collections.Generic;
using System.Linq;


namespace InventoryMangement
{

    public enum SortOrder
    {
        ASC, DSC
    }
    public class Store
    {
        //LEVEL 2 Methods
        private List<Item> items = new List<Item>();
        private int maxCapacity;

        public Store(int capacity)
        {
            maxCapacity = capacity;
        }
        public bool AddItem(Item item)
        {
            if (items.Count < maxCapacity)
            {
                if (!items.Any(i => i.Name == item.Name))
                {
                    items.Add(item);
                    return true;
                }
                else
                {
                    Console.WriteLine($"│              Item with name {item.Name} already exists in the store.            │");
                    Console.WriteLine("│                                                                               │");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("│               Store is at maximum capacity. Cannot add more items.            │");
                Console.WriteLine("│                                                                               │");
                return false;
            }
        }

        //Method DeleteItem to delete Item.
        public bool DeleteItem(string itemName)
        {
            var item = items.FirstOrDefault(i => i.Name == itemName);
            if (item != null)
            {
                return items.Remove(item);
            }
            else
            {
                Console.WriteLine($"│                Item with name {itemName} not found in the store.                   │");
                return false;
            }
        }

        //Method GetCurrentVolume to compute the total amount of items in the store
        public int GetCurrentVolume()
        {
            return items.Sum(i => i.Quantity);
        }

        //Method FindItemByName to find an item by name.
        public string FindItemByName(string itemName)
        {
            Item? foundedItem = items.Find(item => item.Name.ToLower() == itemName.ToLower());

            if (foundedItem != null)
            {
                // Item found successfully
                return $" Item '{itemName}' found successfully";
            }
            else
            {
                // Item not found
                return $" Item '{itemName}'  does not exist ";
            }
        }

        //Method SortByNameAscto get the sorted collection by name in ascending order.
        public List<Item> SortByNameAsc()
        {
            return items.OrderBy(i => i.Name).ToList(); //OrderBy -> to sort a collection of Name items in ascending order
        }

        // Method to sort items in the store by date
        public List<Item> SortByDate(SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.ASC)
                return items.OrderBy(item => item.CreatedDate).ToList();
            else
                return items.OrderByDescending(item => item.CreatedDate).ToList();
        }

        public void SortItemsByDate()
        {
            // Ask user for sort order
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                      Sort by date: 1- Ascending  2- Descending                │");
            Console.Write("│                           Enter your choice (1 or 2): ");

            int sortOrderInput;
            while (!int.TryParse(Console.ReadLine(), out sortOrderInput) || (sortOrderInput != 1 && sortOrderInput != 2))
            {
                Console.WriteLine("│     Invalid input. Please enter 1 for Ascending or 2 for Descending:          │");
                Console.Write("│                           Enter your choice (1 or 2): ");
            }

            // Determine sort order based on user input
            var sortOrder = sortOrderInput == 1 ? SortOrder.ASC : SortOrder.DSC;

            // Sort the items based on the CreatedDate
            items.Sort((x, y) => sortOrder == SortOrder.ASC ? DateTime.Compare(x.CreatedDate, y.CreatedDate) : DateTime.Compare(y.CreatedDate, x.CreatedDate));

            // Display sorted items
            Console.WriteLine("├───────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│                           After sorting Date:                                 │");
            DisplayItems();
        }


        //For Display Items Level 1 and 2 methods 
        public void DisplayItems()
        {
            //All this to arrange the outputs
            Console.WriteLine("├───────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│                             Store Items Table                                 │");
            Console.WriteLine("├───────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│ Item Name                      │ Quantity    │ Created Date                   │");
            Console.WriteLine("├────────────────────────────────┼─────────────┼────────────────────────────────┤");

            if (items.Count > 0)
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"│ {item.Name,-30} │ {item.Quantity,-11} │ {item.CreatedDate,-30} │"); //The format specifier -30 and -11 are used to align the output within a specified width.
                }
            }
            else
            {
                Console.WriteLine("│                          No items in the store                               │");
            }

            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");
        }

        //LEVEL 3 Methods

        public Dictionary<string, List<Item>> GroupByDate()
        {
            DateTime currentDate = DateTime.Now;
            // Assuming three months threshold for new items
            DateTime threeMonthsAgo = currentDate.AddMonths(-3);

            var newArrivalItems = items.Where(item => item.CreatedDate >= threeMonthsAgo).ToList();
            var oldItems = items.Where(item => item.CreatedDate < threeMonthsAgo).ToList();

            Dictionary<string, List<Item>> groupedItems = new Dictionary<string, List<Item>>();
            groupedItems.Add("New Arrival Items", newArrivalItems);
            groupedItems.Add("Old Items", oldItems);

            return groupedItems;
        }

        // This method Display items in a formatted table
        public void DisplayItemsByGroupTable(Dictionary<string, List<Item>> groupedItems)
        {
            Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                  New Arrival Items:                           │");
            Console.WriteLine("├───────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│ Item Name                      │ Quantity    │ Created Date                   │");
            Console.WriteLine("├────────────────────────────────┼─────────────┼────────────────────────────────┤");

            foreach (var item in groupedItems["New Arrival Items"])
            {
                Console.WriteLine($"│ {item.Name,-30} │ {item.Quantity,-11} │ {item.CreatedDate.ToShortDateString(),-30} │");
            }


            Console.WriteLine("├───────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                  Old Items:                                   │");
            Console.WriteLine("├───────────────────────────────────────────────────────────────────────────────┤");
            Console.WriteLine("│ Item Name                      │ Quantity    │ Created Date                   │");
            Console.WriteLine("├────────────────────────────────┼─────────────┼────────────────────────────────┤");

            foreach (var item in groupedItems["Old Items"])
            {
                Console.WriteLine($"│ {item.Name,-30} │ {item.Quantity,-11} │ {item.CreatedDate.ToShortDateString(),-30} │");
            }
            Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────┘");

        }
    }
}

