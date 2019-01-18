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

            //var queryTest =
            //    from feature in neighborhoods.features
            //    where feature.properties.neighborhood == "Chelsea"
            //    select feature;
            //foreach (var feature in queryTest)
            //{
            //    Console.WriteLine($"Zipcode: {feature.properties.zip} \nCoordinates: {feature.geometry.coordinates[0]},{feature.geometry.coordinates[1]}");
            //}

            var query1 =
                from feature in neighborhoods.features
                select feature;
            Console.WriteLine($"Manhattan Neighborhoods:");
            foreach (var feature in query1)
            {
                Console.WriteLine(feature.properties.neighborhood);
            }
            Console.WriteLine("===============================================================================================");

            var query2 =
                from feature in neighborhoods.features
                where feature.properties.neighborhood != ""
                select feature;
            foreach (var feature in query2)
            {
                Console.WriteLine(feature.properties.neighborhood);
            }
            Console.WriteLine("===============================================================================================");

            var query3 =
                (from feature in neighborhoods.features
                where feature.properties.neighborhood != ""
                orderby feature.properties.neighborhood ascending
                 select feature.properties.neighborhood).Distinct();
            foreach (string neighborhood in query3)
            {
                Console.WriteLine(neighborhood);
            }
            Console.WriteLine("===============================================================================================");
        }

        public static FeatureCollection ReadJSON(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<FeatureCollection>(json);
        }

        



        
    }
}
