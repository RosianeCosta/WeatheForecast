using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Requests
{
    public class WaetherApiDto
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Waether { get; set; }
        public string Temperature { get; set; }
    }
}