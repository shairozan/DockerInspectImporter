using DockerInspectConverter.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        public string EnvironmentVariables(DockerInspect specs)
        {
            StringBuilder b = new StringBuilder();
           
            foreach(string s in specs.Spec.TaskTemplate.ContainerSpec.Env)
            {
                b.Append($"-e {s}");
            }

            return b.ToString();
        }

        public string ServiceCreation(DockerInspect specs)
        {
            StringBuilder b = new StringBuilder();

            string name = specs.Spec.Name;

            return name;
        }
    }
}
