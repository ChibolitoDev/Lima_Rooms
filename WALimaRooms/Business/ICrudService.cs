﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICrudService<T>
    {
        bool insert(T t);
        bool Update(T t);
        bool Delete(int id);
        List<T> FindAll();
        T FindById(int? id);
    }
}
