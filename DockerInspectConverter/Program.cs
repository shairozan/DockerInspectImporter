using DockerInspectConverter.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DockerInspectConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the absolute path to the directory containing your inspect JSON files");
            string Location = Console.ReadLine();

            try
            {
                string[] Files = Directory.GetFiles(Location);

                foreach(string s in Files)
                {

                    using (StreamReader file = File.OpenText(s))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        List<DockerInspect> inspect = (List<DockerInspect>)serializer.Deserialize(file, typeof(List<DockerInspect>));

                        Console.WriteLine("serialized");
                    }
                }

            } catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return; //Die?
            }

            Console.WriteLine(Location);
            Console.ReadLine();
        }
    }
}
