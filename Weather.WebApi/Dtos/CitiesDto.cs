using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.WebApi.Dtos
{
    public class CitiesDto
    {
        public CitiesDto()
        { 
        }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Clima { get; set; }
        public string Temperatura { get; set; }
    }
}
