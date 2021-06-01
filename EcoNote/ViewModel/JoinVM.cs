using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoNote.ViewModel
{
    class JoinVM
    {
        private string name;

        public string uName
        {
            get { return name; }
            set { name = value; }
        }

        private string pNum;

        public string uPNum
        {
            get { return pNum; }
            set { pNum = value; }
        }

        private string id;

        public string uId
        {
            get { return id; }
            set { id = value; }
        }


        private string password;

        public string uPassword
        {
            get { return password; }
            set { password = value; }
        }
    }
}
