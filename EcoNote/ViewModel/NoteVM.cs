using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoNote.ViewModel
{
    class NoteVM
    {
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
    }
}
