using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoNote.Model
{
    class Donation
    {
        private int num;

        public int dNum
        {
            get { return dNum; }
            set { dNum = value; }
        }

        private string userId;

        public string dUserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int money;

        public int dMoney
        {
            get { return money; }
            set { money = value; }
        }

    }
}
