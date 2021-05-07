﻿using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web_Service.Models;

namespace Web_Service.Helpers
{
    static public class JWriter<T>
    {
        static public string Write(in T collection, string current_data = null)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            try
            {
                using (Newtonsoft.Json.JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartArray();

                    foreach (var item in (System.Collections.IList)collection)
                    {
                        writer.WriteStartObject();

                        writer.WritePropertyName("DepartamentalAffiliation");
                        writer.WriteValue((item as AreaInfo).DepartamentalAffiliation);

                        writer.WritePropertyName("AdmArea");
                        writer.WriteValue((item as AreaInfo).AdmArea);

                        writer.WritePropertyName("District");
                        writer.WriteValue((item as AreaInfo).District);

                        writer.WritePropertyName("Location");
                        writer.WriteValue((item as AreaInfo).Location);

                        writer.WritePropertyName("DogParkArea");
                        writer.WriteValue((item as AreaInfo).DogParkArea);

                        writer.WritePropertyName("Lighting");
                        writer.WriteValue((item as AreaInfo).Lighting);

                        writer.WritePropertyName("Fencing");
                        writer.WriteValue((item as AreaInfo).Fencing);

                        writer.WritePropertyName("WorkingHours");
                        writer.WriteStartArray();
                        foreach (var element in (item as AreaInfo).WorkingHours)
                        {
                            writer.WriteStartObject();

                            writer.WritePropertyName("DayOfWeek");
                            writer.WriteValue(element.DayOfWeek);

                            writer.WritePropertyName("Hours");
                            writer.WriteValue(element.Hours);

                            writer.WriteEndObject();
                        }
                        writer.WriteEnd();

                        writer.WriteEndObject();
                    }

                    writer.WriteEnd();

                    if (current_data != "\r\n" && !string.IsNullOrEmpty(current_data))
                    {
                        JArray current_doc = JArray.Parse(current_data);

                        JArray new_data = JArray.Parse(sb.ToString());
                        var child_new_data = new_data.Children();

                        current_doc.Add(child_new_data);

                        return current_doc.ToString();

                    }

                    return sb.ToString();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

        }
    }
}