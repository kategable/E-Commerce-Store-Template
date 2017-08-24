using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core;
using Store.Core.Models;
using Newtonsoft.Json;

namespace Store.Data.Repositories
{
    public class Repository : IRepository
    {
       private readonly JimsStoreContext _context;
        public Repository(JimsStoreContext context)
        {
            _context = context;           
        }

        public List<Buyer> GetAllBuyers()
        {
            return _context.Buyers.ToList();
        }

        public List<Pencil> GetAllPencils()
        {
            var pencils = _context.Pencils.Include("Buyers").OrderBy(p => p.Id);
                       
            return pencils.ToList();
        }

        public Pencil GetPencilById(int id)
        {
            return _context.Pencils.FirstOrDefault(p=>p.Id==id);
        }
        public Pencil CreateNewPencil(Pencil model)
        {
           var newItem=  _context.Pencils.Add(model);
            _context.SaveChanges();
            return newItem;
        }

        public void SavePencil(Pencil model)
        {
            _context.SaveChanges();
        }

        public void UpdatePencil(Pencil model)
        {
            var item = _context.Pencils.First(p=>p.Id==model.Id);
            item.Price = model.Price;
            item.Title = model.Title;
            item.Description = model.Description;
            item.UpdateDateTime = model.UpdateDateTime;
            _context.SaveChanges();

        }

        public void DeletePencil(int id)
        {
            var item = _context.Pencils.First(p => p.Id == id);
            _context.Pencils.Remove(item);
            _context.SaveChanges();
        }
    }
}
