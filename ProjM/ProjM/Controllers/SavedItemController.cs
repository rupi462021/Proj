using ProjM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.IO;
using System.Data;
using ProjM.Models.DAL;

namespace ProjM.Controllers
{
    public class SavedItemController : ApiController
    {
        // GET api/<controller>
        public DataTable Get()
        {
            DBServicesS ds = new DBServicesS();
            string query = "SELECT * FROM SaveItem_2021";
            return ds.Select(query);
        }
        //// GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        // PUT api/<controller>/5
        public void Put(int storyNum, [FromBody] RowEdit value)
        {
            string q = "UPDATE SaveItem_2021 SET description='" + value.description + "', title='" + value.title + "' WHERE storyNum=" + value.storyNum;
            DBServicesS ds = new DBServicesS();
            ds.Update(q);
        }
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            string q = "DELETE FROM SaveItem_2021 WHERE Id=" + id;
            DBServicesS ds = new DBServicesS();
            ds.Update(q);
        }
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

       

        // POST api/<controller>
        //[Route("api/SavedItem")]
        //[Route("")]
        //[HttpPost]
        //[Route("api/SavedItem")]
        public void Post([FromBody] SavedItem sv)
        {
             sv.InsertSave();
        }

        // PUT api/<controller>/5
        

        // DELETE api/<controller>/5
        
    }
}