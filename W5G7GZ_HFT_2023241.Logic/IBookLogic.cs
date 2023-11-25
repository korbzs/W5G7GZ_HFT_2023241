﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Logic
{
    public interface IBookLogic
    {
        //crud
        void Create(Book item);
        void Update(Book item);
        Book Read(int id);
        IQueryable<Book> ReadAll();
        void Delete(int id);
    }
}
