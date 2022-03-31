using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace practical17MVC.Helper
{
    //public class Helper
    //{
    //}
    public class StudentAPI
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44383/");
            return Client;
        }
    }
       
}
