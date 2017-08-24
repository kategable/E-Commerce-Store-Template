using Store.Core;
using Store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public interface IRepository
    {
        List<Pencil> GetAllPencils();
        List<Buyer> GetAllBuyers();
        Pencil GetPencilById(int id);
        Pencil CreateNewPencil(Pencil model);
        void SavePencil(Pencil model);
        void UpdatePencil(Pencil model);
        void DeletePencil(int id);
    }

}
