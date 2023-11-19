using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository
{
    public interface IAuthorRepository
    {
        void AddCar(Author author);
        void ChangeName(Author author);
        IQueryable<Author> GetAll();
        Author GetOne(int ID);
        void Delete(int ID;
    }
}
