using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoNote.ViewModel
{
    class ExchangeVM
    {
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

     

    }
}
