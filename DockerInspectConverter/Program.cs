using DockerInspectConverter.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace DockerInspectConverter
{
    class Program
    {
        public static DockerInspect specs { get; set; }
        public static List<string> Images { get; set; }


        static void Main(string[] args)
        {
            Images = new List<string>();
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
                        specs = inspect[0];

                        Console.WriteLine(ServiceCreation());
                    }
                }

            } catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return; //Die?
            }

            Console.WriteLine();
            Console.WriteLine("##### Unique list of Images:");
            foreach(string image in Images)
            {
                Console.WriteLine(image);
            }

            Console.ReadLine();
        }

        public static string EnvironmentVariables()
        {
            StringBuilder b = new StringBuilder();
           
            if(specs.Spec.TaskTemplate.ContainerSpec.Env != null)
            {
                foreach (string s in specs.Spec.TaskTemplate.ContainerSpec.Env)
                {
                    b.Append($"-e {s} ");
                }
            }

            return b.ToString();
        }

        public static string Ports()
        {
            StringBuilder b = new StringBuilder();

            if(specs.Spec.EndpointSpec.Ports != null)
            {
                foreach (Data.Spec.Port c in specs.Spec.EndpointSpec.Ports)
                {
                    b.Append($"-p {c.PublishedPort}:{c.TargetPort} ");
                }
            }

           
            return b.ToString();
        }

        public static string Args()
        {
            StringBuilder b = new StringBuilder();

            if(specs.Spec.TaskTemplate.ContainerSpec.Args != null)
            {
                foreach(string arg in specs.Spec.TaskTemplate.ContainerSpec.Args)
                {
                    b.Append($"{arg} ");
                }
            }

            return b.ToString();
        }

        public static string ServiceCreation()
        {
            StringBuilder b = new StringBuilder();

            string name = specs.Spec.Name;
            string NetworkId = "REPLACEME";
            string Image = specs.Spec.TaskTemplate.ContainerSpec.Image;
            Images.Add(Image);

            b.Append("docker service create ");

            b.Append($"--name {name} ");
            b.Append($"--replicas {specs.Spec.Mode.Replicated.Replicas}") ;
            b.Append($" --network {NetworkId} ");
            b.Append($"{EnvironmentVariables()} ");
            b.Append($"{Ports()} ");
            b.Append($"{Image} ");
            b.Append($"{Args()} ");

            string output = b.ToString();

            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            output = regex.Replace(output, " ");



            return output;
        }
    }
}
