using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoNote.Model
{
    class User
    {
        private string id;

        public string uId
        {
            get { return id; }
            set { id = value; }
        }

        private string pwd;
        
        public string uPwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

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

        private int totalC;

        public int uTotalC
        {
            get { return totalC; }
            set { totalC = value; }
        }

        private int totalD;

        public int uTotalD
        {
            get { return totalD; }
            set { totalD = value; }
        }

    }
}
