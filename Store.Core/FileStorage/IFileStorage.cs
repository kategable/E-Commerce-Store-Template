
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Store.Core.Models;

namespace Store.Core
{
    public interface IFileStorage
    {
        string StoreFile(Pencil model, Stream inputStream, string fileName);
        void DeleteFile(int id);
    }
}
