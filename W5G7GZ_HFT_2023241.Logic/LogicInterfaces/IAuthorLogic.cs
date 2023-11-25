using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Logic.Interfaces
{
    public interface IAuthorLogic
    {
        //crud
        void Create(Author item);
        void Update(Author item);
        Author Read(int id);
        IQueryable<Author> ReadAll();
        void Delete(int id);
    }
}
