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


        internal static List<JsonPeopleType> GetPeoples()
        {
            var assembly = GetAssembly();
            var content = assembly.GetManifestResourceStream("XFLab.Content.People.json");
            string contentText;
            using (var reader = new StreamReader(content))
            {
                contentText = reader.ReadToEnd();
            }
            return Deserialize<List<JsonPeopleType>>(contentText);
        }


        private static T Deserialize<T>(string content) where T : class
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
