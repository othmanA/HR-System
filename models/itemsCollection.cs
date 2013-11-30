using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace HR
{
    public interface itemsCollection
    {
         void init(int employee_id);
         ArrayList getALL();
         bool delete(int id);
    }
}
