﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS,ID,RET>
    {
        List<CLASS> Get();
        CLASS Get(int id);
        RET Add(CLASS obj);
        RET Update(CLASS obj);
        bool Delete(int id);
    }
}
