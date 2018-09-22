using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWebScraping.Common.JsonUtility
{
    public class ConcreteConverter<IInterface, TConcrete> : JsonConverter where TConcrete : IInterface
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IInterface) == objectType;
        }

        public override object ReadJson(JsonReader reader,
         Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<TConcrete>(reader);
        }

        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
