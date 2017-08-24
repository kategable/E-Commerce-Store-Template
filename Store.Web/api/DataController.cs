using Newtonsoft.Json;
using Store.Core;
using Store.Core.Models;
using Store.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Store.Web.api
{
    public class DataController : ApiController
    {
        private readonly IStoreService _service;
        public DataController(IStoreService service)
        {
            _service = service;
        }
      
        
        public object Get()
        {
            var pencils = _service.GetAllPencils();
            var buyers = _service.GetAllBuyers();
            return new { pencils= pencils, buyers= buyers };
        }
        [HttpGet][Route("api/Data/Buyers")]
        public List<Buyer> Buyers()
        {            
            var buyers = _service.GetAllBuyers();
            return buyers  ;
        }
       
        public string Get(int id)
        {
            return "value";
        }
      
        public void Post([FromBody]string value)
        {
        }

        [HttpPut]
        [Route("api/Data/Put/{id}")]
        public IHttpActionResult Put(int id, [FromBody]Pencil model)
        {
            _service.UpdatePencil(model);
            var pencils = _service.GetAllPencils();
            var buyers = _service.GetAllBuyers();
            return Ok(new { pencils = pencils, buyers = buyers });
        }

        [HttpDelete]
        [Route("api/Data/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            _service.DeletePencil(id);
            var pencils = _service.GetAllPencils();
            var buyers = _service.GetAllBuyers();
            return Ok(new { pencils = pencils, buyers = buyers });
        }
    }
}
