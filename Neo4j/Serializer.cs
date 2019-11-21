using System.Collections.Generic;
using Neo4j.Serializer.Converters;
using Newtonsoft.Json;

namespace Neo4j.Serializers
{
    public static class ParameterSerializer
    {
        public static IList<Dictionary<string, object>> ToDictionary<TSourceType>(IList<TSourceType> source)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            string json = JsonConvert.SerializeObject(source, settings);

            return JsonConvert.DeserializeObject<IList<Dictionary<string, object>>>(json, new Converters.CustomDictionaryConverter());
        }
    }
}