﻿using System;
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

            Console.WriteLine("***Output all of the neighborhoods in this data list***");
            var query1 =
                from feature in neighborhoods.features
                select feature;
            Console.WriteLine($"Manhattan Neighborhoods:");
            foreach (var feature in query1)
            {
                Console.WriteLine(feature.properties.neighborhood);
            }
            Console.WriteLine("===============================================================================================");

            Console.WriteLine("***Filter out all the neighborhoods that do not have any names***");
            var query2 =
                from feature in neighborhoods.features
                where feature.properties.neighborhood != ""
                select feature;
            foreach (var feature in query2)
            {
                Console.WriteLine(feature.properties.neighborhood);
            }
            Console.WriteLine("===============================================================================================");

            Console.WriteLine("***Remove the Duplicates***");
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

            //Console.WriteLine("Rewrite the queries from above, and consolidate all into one single query.");
        }

        /// <summary>
        /// Read JSON file from path and parse
        /// to create a collection of objects
        /// </summary>
        /// <param name="path">filepath</param>
        /// <returns>Collection of "Feature" objects</returns>
        public static FeatureCollection ReadJSON(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<FeatureCollection>(json);
        }

        



        
    }
}
