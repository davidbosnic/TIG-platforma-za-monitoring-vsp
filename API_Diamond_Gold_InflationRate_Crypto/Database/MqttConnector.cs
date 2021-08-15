using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using API_Diamond_Gold_InflationRate_Crypto.Broker;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Writes;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;

namespace API_Diamond_Gold_InflationRate_Crypto
{
    public class MqttConnector : IMqttConnector
    {

        private static Mqtt _mqtt = null;

        private static MqttConnector _connector = null;

        private static readonly object objLock = new object();

        private MqttConnector()
        {
            CreateConnectionToMqtt();
        }

        public static MqttConnector GetInstance()
        {
            if (_connector == null)
            {
                lock (objLock)
                {
                    if (_connector == null)
                    {
                        _connector = new MqttConnector();
                    }
                }
            }

            return _connector;
        }

        private static void CreateConnectionToMqtt()
        {
            _mqtt = new Mqtt();
        }

        public void Write(string data)
        {
            _mqtt.Publish(data, "telegraf");
        }

        public void Write(PointData point)
        {
            _mqtt.Publish(point, "telegraf");
        }

        public void Write(DGIC data, string measurement)
        {
            try
            {

                _mqtt.Publish(data, measurement);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void WriteCSVFile(string filepath, string measurement)
        {
            var path = filepath;
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;


                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {

                    string[] fields = csvParser.ReadFields();
                    DGIC data = new DGIC
                    {
                        Date = Convert.ToDateTime(fields[0]),
                        DiamondPrice = Convert.ToDouble(fields[1]),
                        InflationRate = Convert.ToDecimal(fields[2]),
                        GoldPrice = Convert.ToDouble(fields[3]),
                        BTC_Close = Convert.ToDouble(fields[4]),
                        BTC_Volume = Convert.ToDouble(fields[5]),
                        BTC_Marketcap = Convert.ToDouble(fields[6]),
                        ETH_Close = Convert.ToDouble(fields[7]),
                        ETH_Volume = Convert.ToDouble(fields[8]),
                        ETH_Marketcap = Convert.ToDouble(fields[9]),
                        DOGE_Close = Convert.ToDouble(fields[10]),
                        DOGE_Volume = Convert.ToDouble(fields[11]),
                        DOGE_Marketcap = Convert.ToDouble(fields[12])
                    };
                    _mqtt.Publish(data, measurement);
                }
            }
        }


        public void WriteCSVFile(IFormFile file, string measurement)
        {
            if (file.FileName.EndsWith(".csv"))
            {
                using (var sreader = new StreamReader(file.OpenReadStream()))
                {
                    string[] headers = sreader.ReadLine().Split(',');     
                    while (!sreader.EndOfStream)                          
                    {
                        string[] fields = sreader.ReadLine().Split(',');
                        DGIC data = new DGIC
                        {
                            Date = Convert.ToDateTime(fields[1]),
                            DiamondPrice = Convert.ToDouble(fields[2]),
                            InflationRate = Convert.ToDecimal(fields[3]),
                            GoldPrice = Convert.ToDouble(fields[4]),
                            BTC_Close = Convert.ToDouble(fields[5]),
                            BTC_Volume = Convert.ToDouble(fields[6]),
                            BTC_Marketcap = Convert.ToDouble(fields[7]),
                            ETH_Close = Convert.ToDouble(fields[8]),
                            ETH_Volume = Convert.ToDouble(fields[9]),
                            ETH_Marketcap = Convert.ToDouble(fields[10]),
                            DOGE_Close = Convert.ToDouble(fields[11]),
                            DOGE_Volume = Convert.ToDouble(fields[12]),
                            DOGE_Marketcap = Convert.ToDouble(fields[13])
                        };
                        _mqtt.Publish(data, measurement);
                    }
                }
            }
        }
    }
}
