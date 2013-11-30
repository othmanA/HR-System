using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace HR
{
    interface itemsCollection
    {
        public void init(int employee_id);
        public ArrayList getALL();
        public bool delete(int id);
    }
}
