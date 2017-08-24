using Store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.ViewModels
{
    public class PencilViewModel : Pencil
    {
        public HttpPostedFileBase File { get; set; }
        public List<int> Buyers { get; set; }
    }
}