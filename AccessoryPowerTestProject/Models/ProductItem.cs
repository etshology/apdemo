using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//This is the Model for the Products table.
namespace AccessoryPowerTestProject
{
    class ProductItem
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string number;
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private int kit_flag;
        public int Kit
        {
            get { return kit_flag; }
            set { kit_flag = value; }
        }
        private int part_id;
        public int PartId
        {
            get { return part_id; }
            set { part_id = value; }
        }

        private List<int> partsList;

        public ProductItem()
        {
            id = -1;
            title = string.Empty;
            number = string.Empty;
            price = 0;
            kit_flag = 0;
            part_id = -1;
            partsList = new List<int>();
        }

        public List<int> GetParts()
        {
            return partsList;
        }

        public void SetParts(Dictionary<string, string> parts)
        {
            partsList.Clear();
            foreach (KeyValuePair<string, string> item in parts)
            {
                if (!partsList.Contains(Convert.ToInt32(item.Value)))
                {
                    partsList.Add(Convert.ToInt32(item.Value));
                }
            }
        }

        public void AddPart(int id)
        {
            partsList.Add(id);
        }

        public void AddParts(Dictionary<string, string> parts)
        {
            foreach (KeyValuePair<string, string> item in parts)
            {
                if(!partsList.Contains(Convert.ToInt32(item.Value)))
                {
                    partsList.Add(Convert.ToInt32(item.Value));
                }
            }
        }
    }
}
