
using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Writes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Diamond_Gold_InflationRate_Crypto
{
    public interface IMqttConnector
    {
        public void Write(string data);
        public void Write(PointData data);
        public void Write(DGIC data, string measurement);
        public void WriteCSVFile(string filepath, string measurement);
        public void WriteCSVFile(IFormFile file, string measurement);
    }
}
