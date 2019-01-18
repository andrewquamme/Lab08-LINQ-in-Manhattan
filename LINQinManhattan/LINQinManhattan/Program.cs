using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LINQinManhattan.Classes;

namespace LINQinManhattan
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../../../data.json";
            FeatureCollection neighborhoods = ReadJSON(path);

            var query =
                from feature in neighborhoods.features
                where feature.properties.neighborhood == "Chelsea"
                select feature;

            foreach (var feature in query)
            {
                Console.WriteLine($"Zipcode: {feature.properties.zip} \nCoordinates: {feature.geometry.coordinates[0]},{feature.geometry.coordinates[1]}");
            }
        }

        public static FeatureCollection ReadJSON(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<FeatureCollection>(json);
        }



        
    }
}
