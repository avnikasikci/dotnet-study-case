using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Infrastructure.General
{
    public static class UtilityJson
    {

        static JsonSerializerSettings _Setting = new JsonSerializerSettings()
        {
            DateFormatString = "dd/MM/yyyy",

        };


        public static string JsonSerialize<T>(T Data)
        {

            return JsonConvert.SerializeObject(Data, Formatting.Indented, _Setting);


        }


        public static T JsonDeserialize<T>(string Data)
        {
            try
            {
                return !string.IsNullOrEmpty(Data) ? JsonConvert.DeserializeObject<T>(Data, _Setting) : default(T);

            }
            catch (Exception e)
            {

                //throw;
                return default(T);
            }


        }

    }

}
