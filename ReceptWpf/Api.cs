using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ReceptWpf
{
    public static class Api
    {
        public static HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:5000/api/")
        };
    }
}
