using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjM.Models;
using ProjM.Models.DAL;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjM.Controllers
{

    public class VideosController : ApiController
    {
        private object tokens;
        private string aa;

        // GET api/<controller>
        // public List<Video> Get()

        //string Token;
        public class AuthenticateResult
        {
            public string message { get; set; }
            public string token { get; set; }
        }
        public class Root
        {
            public AuthenticateResult AuthenticateResult { get; set; }
        }
        public string Token()
        {

            var client = new RestClient("http://10.120.17.160:8701/VelaEncompassService/API/Authenticate ");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n\"User\":\"shimiab\",\r\n\"Password\":\"Aviv8696\"\r\n}\r\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string x = response.Content;
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content); 
    
        AuthenticateResult y = new AuthenticateResult();
            string z = myDeserializedClass.AuthenticateResult.token;
        
            //string aa = json.AuthenticateResult.token;
        Console.WriteLine(response.Content);
            return z;

            //    //tokens = JSON.parse(response.Content.token);
            //    //return tokens;

        }


        public string Get(string from , string to,string date)
        {
            string x = Token();
            var client = new RestClient("http://10.120.17.160:8701/VelaEncompassService/API/GetPlayback?callsign=26cf1d0b-0e71-420b-ae78-b023e62d0a41&start_datetime="+date+"T"+ from + "&end_datetime="+date+"T"+ to);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Token", x);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            
            return response.Content;


            //var client = new RestClient("http://10.120.17.160:8701/VelaEncompassService/API/GetChannels");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Token", "fc8C3G4Y2UiY_hCb-BSWTINxYUCuBAFw");
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            //return response.Content;
            //Video video = new Video();
            //List<Video> VList = video.Read();
            //return VList;


        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/videos/getItem")]
        public List<Video> Get(string id)
        {
            Video video = new Video();
            List<Video> IList = video.getItem(id);
            return IList;
        }

        // POST api/<controller>
        public void Post([FromBody] Video video)

        {
            
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}