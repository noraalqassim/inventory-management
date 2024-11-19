using System;
using System.Collections.Generic;
using System.Linq;


namespace InventoryMangement
{
    public class Item
    {
        //LEVEL 1 
        private string _name;
        private int _quantity;
        private DateTime _createdDate;

        //Constractur
        public Item(string name, int quantity, DateTime? createdDate = null)
        {

            Name = name;
            Quantity = quantity;
            CreatedDate = createdDate ?? DateTime.Now;
        }

        //Property: getter and setter
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative");
                }
                _quantity = value;
            }
        }

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }

        }
    }
}