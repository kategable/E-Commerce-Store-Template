using Autofac;
using Store.Core;
using Store.Data.Services;
using Store.Data;
using Store.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web
{
    public class DataModule : Module
    {
        private string _connStr;
        public DataModule(string connString)
        {
            _connStr = connString;
        }
        protected override void Load(ContainerBuilder builder)
        {
           
            builder.Register(c=> {
                var db = new JimsStoreContext(_connStr);
                var rep = new Repository(db);
                return rep;
            }).As<IRepository>().InstancePerLifetimeScope();

            builder.Register(c => new StoreService(c.Resolve<IRepository>(), c.Resolve<IFileStorage>())).As<IStoreService>().InstancePerLifetimeScope();
            builder.Register(c=> new FileStorage(HttpContext.Current.Server.MapPath("~/images"), "images")).As<IFileStorage>().InstancePerLifetimeScope();

            
            base.Load(builder);

        }
    }
}