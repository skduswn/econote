using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoNote.ViewModel
{
    class DonationVM
    {
        private int money;

        public int dMoney
        {
            get { return money; }
            set { money = value; }
        }

        private int totalD;

        public int uTotalD
        {
            get { return totalD; }
            set { totalD = value; }
        }

    }
}
