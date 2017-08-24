using Store.Core.Models; 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Store.Core
{
    public class FileStorage : IFileStorage
    {
        private readonly string _serverPath;
        private readonly string _virtualPath;
        public FileStorage(string serverPath, string virtualPath)
        {
            _serverPath = serverPath;
            _virtualPath = virtualPath;
        }

        public void DeleteFile(int id)
        {

            var dir = string.Format("{0}\\{1}", _serverPath, id);
            string[] files = Directory.GetFiles(dir);
            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
            Directory.Delete(dir,true);
        }

        public string StoreFile(Pencil model,Stream inputStream, string fileName)
        {
            try
            {
                var dir = string.Format("{0}\\{1}", _serverPath, model.Id);
                var virtualPath = string.Format("{0}/{1}/{2}", _virtualPath, model.Id, fileName);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                var tempFileName = string.Format("{0}\\{1}", dir, fileName);
                using (var fileStream = new FileStream(tempFileName, FileMode.Create, FileAccess.Write))
                {
                    inputStream.CopyTo(fileStream);
                }
                return virtualPath;
            }
            catch (Exception ex)
            {
                //logging here...
                return "no file";
            }
         
        }
    }
}