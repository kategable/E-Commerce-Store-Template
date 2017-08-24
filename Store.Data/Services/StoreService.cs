using Newtonsoft.Json;
using Store.Core;
using Store.Core.Models;
using Store.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Services
{
    public class StoreService : IStoreService
    {
        private readonly IRepository _repository;
        private readonly IFileStorage _fileStorage;
        public StoreService(IRepository repository, IFileStorage fileStorage)
        {
            _repository = repository;
            _fileStorage = fileStorage;
        }

        public List<Pencil> GetAllPencils()
        {
     
            return _repository.GetAllPencils().ToList();
        }
        public List<Buyer> GetAllBuyers()
        {
            return _repository.GetAllBuyers();
        }

        public Pencil GetPencilById(int id)
        {
            return _repository.GetPencilById(id);
        }
        public Pencil CreateNewPencil(Pencil model, Stream inputStream, string fileName)
        {
            model.UpdateDateTime = DateTime.UtcNow;
            var newItem = _repository.CreateNewPencil(model);
            newItem.ImagePath =  _fileStorage.StoreFile(newItem, inputStream, fileName);
            _repository.SavePencil(newItem);
            return newItem;
        }

        public void UpdatePencil(Pencil model)
        {
            model.UpdateDateTime = DateTime.UtcNow;
            _repository.UpdatePencil(model);
        }

        public void DeletePencil(int id)
        {
            _fileStorage.DeleteFile(id);
            _repository.DeletePencil(id);
        }
    }
}
