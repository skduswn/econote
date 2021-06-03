using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoNote.Model
{
    class Exchange
    {
        private int num;

        public int eNum
        {
            get { return num; }
            set { num = value; }
        }

        private string userId;

        public string eUserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string pNum;

        public string ePNum
        {
            get { return pNum; }
            set { pNum = value; }
        }

        private string pName;

        public string ePName
        {
            get { return pName; }
            set { pName = value; }
        }

        private int price;

        public int ePrice
        {
            get { return price; }
            set { price = value; }
        }

        

    }
}
