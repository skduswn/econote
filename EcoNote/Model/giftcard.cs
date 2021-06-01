using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoNote.Model
{
    class giftcard
    {
        private int num;

        public int gNum
        {
            get { return num; }
            set { num = value; }
        }

        private string userId;

        public string gUserID
        {
            get { return userId; }
            set { userId = value; }
        }

        private int pNum;

        public int gPNum
        {
            get { return pNum; }
            set { pNum = value; }
        }
    }
}
