using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoNote.Model
{
    class move
    {
        private int num;

        public int mNum
        {
            get { return num; }
            set { num = value; }
        }

        private string userId;

        public string mUserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string way;

        public string mWay
        {
            get { return way; }
            set { way = value; }
        }

        private int distance;

        public int mDistance
        {
            get { return distance; }
            set { distance = value; }
        }

        private int CarbonRA;

        public int mCarbonRA
        {
            get { return CarbonRA; }
            set { CarbonRA = value; }
        }
    }
}
