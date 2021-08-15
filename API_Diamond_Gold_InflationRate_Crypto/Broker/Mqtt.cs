using InfluxDB.Client.Writes;
using MQTTnet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace API_Diamond_Gold_InflationRate_Crypto.Broker
{
    public class Mqtt
    {
        readonly string MQTT_SERVER = "";
        readonly int MQTT_PORT = 8883;
        readonly string MQTT_USERNAME = "";
        readonly string MQTT_PASSWORD = "";
        private static MqttClient _client = null;
        public Mqtt()
        {
            try
            {
                Connect();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public void Connect()
        {
            try
            {
                _client = new MqttClient(MQTT_SERVER, MQTT_PORT, true, null, null, MqttSslProtocols.TLSv1_2);
                _client.Connect(Guid.NewGuid().ToString(), MQTT_USERNAME, MQTT_PASSWORD);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.InnerException);
            }
        }

        public void Discoonnect()
        {
            try
            {
                if (_client != null)
                    _client.Disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.InnerException);
            }
        }       

        public bool IsConnected()
        {
            if (_client == null)
                return false;
            return _client.IsConnected;
        }

        public void Publish(object data, string topic)
        {
            try
            {
                _client.Publish(topic, JsonStringToByteArray(JsonConvert.SerializeObject(data)), 0, false);
            }
            catch (Exception e)
            {
                Console.WriteLine("Publish failed: " + e.Message);
            }
        }
        
        private static byte[] JsonStringToByteArray(string jsonString)
        {
            var encoding = new UTF8Encoding();
            return encoding.GetBytes(jsonString);
        }

       
    }
}
