using Store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
    
namespace Store.Data.Services
{
    public interface IStoreService
    {
        List<Pencil> GetAllPencils();
        List<Buyer> GetAllBuyers();
        Pencil GetPencilById(int id);
        Pencil CreateNewPencil(Pencil model, Stream inputStream, string fileName);
        void UpdatePencil(Pencil model);
        void DeletePencil(int id);
    }
}
