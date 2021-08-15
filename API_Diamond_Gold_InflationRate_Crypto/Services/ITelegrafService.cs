using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Writes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Diamond_Gold_InflationRate_Crypto.Services
{
    public interface ITelegrafService
    {
        public void Write(string data);

        public void Write(PointData point);

        public void Write(DGIC data, string measurement);

        public void WriteCSVFile(string filepath, string measurement);

        void WriteCSVFile(IFormFile file, string measurement);
    }
}
