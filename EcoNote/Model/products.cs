using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoNote.Model
{
    class Products
    {
        private int num;

        public int pNum
        {
            get { return num; }
            set { num = value; }
        }

        private string name;

        public string pName
        {
            get { return name; }
            set { name = value; }
        }

        private int price;

        public int pPrice
        {
            get { return price; }
            set { price = value; }
        }

        private int stock;

        public int pStock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}
