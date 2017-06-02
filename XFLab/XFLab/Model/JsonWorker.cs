using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XFLab.Model.Types;

namespace XFLab.Model
{
    internal static class JsonWorker
    {

        private static Assembly GetAssembly()
        {
            return typeof(JsonWorker).GetTypeInfo().Assembly;
        }


        private static string GetContentString(string jsonName)
        {
            var assembly = GetAssembly();
            var content = assembly.GetManifestResourceStream(jsonName);
            string contentText;
            using (var reader = new StreamReader(content))
            {
                contentText = reader.ReadToEnd();
            }
            return contentText;
        }

        internal static List<JsonPeopleType> GetPeoples()
        {
            var contentText = GetContentString("XFLab.Content.People.json");
            return Deserialize<List<JsonPeopleType>>(contentText);
        }


        internal static List<Job> GetJobs()
        {
            var content = GetContentString("XFLab.Content.Jobs.json");
            return Deserialize<List<Job>>(content);
        }

        private static T Deserialize<T>(string content) where T : class
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
