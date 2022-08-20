using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Domain
{
    public class Localization
    {
        public int Id { get; set; }
        [Required]
        [StringLength(2000)]
        public string Key { get; set; }

        [Required]
        public string JsonValue { get; set; }

        [NotMapped]

        public Dictionary<string, string> AllLangValue
        {
            get
            {
                var AllValue = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(JsonValue))
                {
                    foreach (var item in JObject.Parse(JsonValue))
                    {
                        var Key = (item.Key[0] != 'K') ? item.Key : item.Key.Substring(1, item.Key.Length - 1);// Json seriliase sayıları nesne yapmakta sorun yaşarsa diye başına K konur.
                        AllValue.Add(Key, item.Value != null ? item.Value.ToString() : "");
                    }
                }
                return AllValue;
            }
            set
            {
                if (value != null && value.Count > 0)
                {
                    var _JsonValue = new ExpandoObject() as IDictionary<string, Object>;
                    foreach (var item in value.Where(x => !string.IsNullOrEmpty(x.Value)))
                    {
                        var Key = (item.Key[0] != 'K') ? "K" + item.Key : item.Key;// Json seriliase sayıları nesne yapmakta sorun yaşarsa diye başına K konur.
                        _JsonValue.Add($"{Key}", item.Value);
                    }

                    JsonValue = Newtonsoft.Json.JsonConvert.SerializeObject(_JsonValue);
                }
                else
                {
                    JsonValue = "";
                }
            }
        }
        public bool Active { get; set; }



    }

}
