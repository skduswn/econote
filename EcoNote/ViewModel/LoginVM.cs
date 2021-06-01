using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoNote.ViewModel
{
    class LoginVM
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
    }
}
