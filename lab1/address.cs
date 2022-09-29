using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1
{
    [Serializable]
    public class Address
    {
        private string name;
        private string street;
        private int house_number;
        public Address(string name, string street, int house_number)
        {
            this.name = name;
            this.street = street;
            this.house_number = house_number;
        }
        public Address() { }
        public string getName() { return name; }
        public string getStreet() { return street; }
        public int getHouseNumber() { return house_number; }
    }
}
