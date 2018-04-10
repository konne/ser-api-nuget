﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerApi
{
    public class SettingsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string)) || (objectType == typeof(List<string>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                var result = new List<string>();
                reader.Read();
                while (reader.TokenType != JsonToken.EndArray)
                {
                    result.Add(reader.Value as string);
                    reader.Read();
                }
                return result;
            }
            else
            {
                return new List<string> { reader.Value as string };
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //ToDo here we can decide to write the json as 
            //if only has one attribute output as string if it has more output as list
        }
    }
}
