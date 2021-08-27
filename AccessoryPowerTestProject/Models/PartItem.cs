using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//This is the Model for the Parts table.
namespace AccessoryPowerTestProject
{
    class PartItem
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string number;
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}
