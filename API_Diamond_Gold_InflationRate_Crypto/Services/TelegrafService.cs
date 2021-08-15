using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Writes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Diamond_Gold_InflationRate_Crypto.Services
{
    public class TelegrafService : ITelegrafService
    {
        private IMqttConnector _mqttConnector;
        public TelegrafService()
        {
            _mqttConnector = MqttConnector.GetInstance();
        }

        public void Write(string data)
        {
            _mqttConnector.Write(data);
        }

        public void Write(PointData point)
        {
            _mqttConnector.Write(point);
        }

        public void Write(DGIC data, string measurement)
        {
            _mqttConnector.Write(data, measurement);
        }

     

        public void WriteCSVFile(string filepath, string measurement)
        {
            _mqttConnector.WriteCSVFile(filepath, measurement);
        }


        public void WriteCSVFile(IFormFile file, string measurement)
        {
            _mqttConnector.WriteCSVFile(file, measurement);
        }
    }
}
